using LAB2.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace LAB2
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        Dictionary<string, Bitmap> moneys = new Dictionary<string, Bitmap>();
        Dictionary<string, Bitmap> moneysSrc = new Dictionary<string, Bitmap>();
        Dictionary<string, Bitmap> centsSrc = new Dictionary<string, Bitmap>();
        List<MyImageObject> myMoney = new List<MyImageObject>();
        List<MyImageObject> myCents = new List<MyImageObject>();
        private void Form1_Load(object sender, EventArgs e)
        {
            g1.Checked = true;
            Morphology.SetMask(1);
            moneys["0,01"] = new Bitmap("SourceImages/0,01.png");
            moneys["0,1"] = new Bitmap("SourceImages/0,1.png");
            moneys["1"] = new Bitmap("SourceImages/1,0.png");
            moneys["2"] = new Bitmap("SourceImages/2,0.png");
            moneys["5"] = new Bitmap("SourceImages/5,0.png");
            moneys["10"] = new Bitmap("SourceImages/10,0.png");
            moneys["20"] = new Bitmap("SourceImages/20,0.png");
            moneys["50"] = new Bitmap("SourceImages/50,0.png");
            moneys["100"] = new Bitmap("SourceImages/100,0.png");
            moneys["200"] = new Bitmap("SourceImages/200,0.png");
            moneys["500"] = new Bitmap("SourceImages/500,0.png");

            centsSrc["0,01"] = new Bitmap("SourceImages/001.png");
            centsSrc["0,1"] = new Bitmap("SourceImages/01.png");
            centsSrc["1"] = new Bitmap("SourceImages/1.png");
            centsSrc["2"] = new Bitmap("SourceImages/2.png");
            moneysSrc["5"] = new Bitmap("SourceImages/5.png");
            moneysSrc["10"] = new Bitmap("SourceImages/10.png");
            moneysSrc["20"] = new Bitmap("SourceImages/20.png");
            moneysSrc["50"] = new Bitmap("SourceImages/50.png");
            moneysSrc["100"] = new Bitmap("SourceImages/100.png");
            moneysSrc["200"] = new Bitmap("SourceImages/200.png");
            moneysSrc["500"] = new Bitmap("SourceImages/500.png");

            foreach(var key in moneysSrc.Keys)
            {
                var item = moneysSrc[key];
                MyImageObject myImage = new MyImageObject(key);
                for(int i = 0;i<item.Width;i++)
                {
                    for(int j=0;j<item.Height;j++)
                    {
                        var pixel = item.GetPixel(i, j);
                        if (pixel.GetBrightness() > 0.01F) myImage.AddPixel(i, j, pixel, false);
                    }
                }
                myImage.CalculateParameters();
                myMoney.Add(myImage);
                moneyBox.AppendText(myImage + "\n");
                Application.DoEvents();
            }
            foreach(var key in centsSrc.Keys)
            {
                var item = centsSrc[key];
                MyImageObject myImage = new MyImageObject(key);
                for(int i = 0;i<item.Width;i++)
                {
                    for(int j=0;j<item.Height;j++)
                    {
                        var pixel = item.GetPixel(i, j);
                        if (pixel.GetBrightness() > 0.01F) myImage.AddPixel(i, j, pixel, false);
                    }
                }
                myImage.CalculateParameters();
                myCents.Add(myImage);
                moneyBox.AppendText(myImage + "\n");
                Application.DoEvents();
            }
        }

        private void OpenImgBtn_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    srcImageBox.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        Dictionary<string,MyImageObject> myImages = new Dictionary<string,MyImageObject>();
        void Recognize()
        {
            Bitmap res = (Bitmap)srcImageBox.Image;
            myImages.Clear();
            res = BinaryConvertor.AvarageK(res);
            resImageBox.Image = res;
            res = Svertka.Mean(res,(int)meanValue.Value);
            resImageBox.Image = res;
            res = Detector.ABCDetecting((Bitmap)res, ref myImages);
            double Summ = 0;
            MessageBox.Show(myImages.Count.ToString());
            foreach (var key in myImages.Keys)
            {
                var item = myImages[key];
                MyImageObject myImage = new MyImageObject(key);

                foreach (var pixel in item.GetPixels())
                {
                    bool isBound = false;
                    for(int i=-1;i<2;i++)
                    {
                        for(int j=-1;j<2;j++)
                        {
                            int x = pixel.X + i;
                            int y = pixel.Y + j;
                            if(x>=0&&y>=0&&y<res.Height&&x<res.Width)
                            {
                                if (((Bitmap)srcImageBox.Image).GetPixel( x, y).GetBrightness()<0.00001) isBound = true;
                            }
                        }
                    }
                    myImage.AddPixel(pixel.X, pixel.Y, ((Bitmap)srcImageBox.Image).GetPixel(pixel.X, pixel.Y), isBound);
                }

                myImage.CalculateParameters();
                bool isCircle = myImage.IsCircle();
                List<Error> stats = new List<Error>();
                if(!isCircle)
                foreach (var money in myMoney)
                {
                    Error error = new Error(myImage, money);
                    stats.Add(error);
                }
                else 
                foreach (var money in myCents)
                {
                    Error error = new Error(myImage, money);
                    stats.Add(error);
                }
                stats.Sort();

                //Bitmap temp = moneys.ContainsKey(stats[0].right)? moneys[stats[0].right]:centsSrc[stats[0].right]
                Bitmap temp = moneys[stats[0].right];
                foreach(var pixel in myImage.GetPixels())
                {
                    res.SetPixel(pixel.X, pixel.Y, pixel.GetColor());
                }
                foreach(var pixel in myImage.GetBoundPixels())
                {
                    res.SetPixel(pixel.X, pixel.Y, isCircle?Color.Red:Color.Green);
                }
                for (int k = 0; k < temp.Width; k++)
                {
                    for (int l = 0; l < temp.Height; l++)
                    {
                        if (temp.GetPixel(k, l).GetBrightness() > 0.01F)
                        {
                            int i = k + item.X - temp.Width / 2;
                            int j = l + item.Y - temp.Height / 2;

                            if (i < res.Width &&
                                j < res.Height &&
                                i >= 0 && j >= 0)
                            {
                                Color c = temp.GetPixel(k, l);
                                res.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                            }
                        }
                    }
                }
                Summ += double.Parse(stats[0].right);
                targetBox.AppendText(myImage.ToString() + "  " + stats[0].right + "\n");
            }
            resImageBox.Image = res;

            targetBox.AppendText("Сумма = "+Summ + "\n");
        }       
        void Recognize(ref Bitmap res)
        {
            double Summ = 0;
            MessageBox.Show("Количество объектов "+myImages.Count.ToString());
            foreach (var key in myImages.Keys)
            {
                var item = myImages[key];
                MyImageObject myImage = new MyImageObject(key);

                foreach (var pixel in item.GetPixels())
                {
                    bool isBound = false;
                    for(int i=-1;i<2;i++)
                    {
                        for(int j=-1;j<2;j++)
                        {
                            int x = pixel.X + i;
                            int y = pixel.Y + j;
                            if(x>=0&&y>=0&&y<res.Height&&x<res.Width)
                            {
                                if (((Bitmap)srcImageBox.Image).GetPixel( x, y).GetBrightness()<0.00001) isBound = true;
                            }
                        }
                    }
                    myImage.AddPixel(pixel.X, pixel.Y, ((Bitmap)srcImageBox.Image).GetPixel(pixel.X, pixel.Y), isBound);
                }

                myImage.CalculateParameters();
                bool isCircle = myImage.IsCircle();
                List<Error> stats = new List<Error>();
                if(!isCircle)
                foreach (var money in myMoney)
                {
                    Error error = new Error(myImage, money);
                    stats.Add(error);
                }
                else 
                foreach (var money in myCents)
                {
                    Error error = new Error(myImage, money);
                    stats.Add(error);
                }
                stats.Sort();

                //Bitmap temp = moneys.ContainsKey(stats[0].right)? moneys[stats[0].right]:centsSrc[stats[0].right]
                Bitmap temp = moneys[stats[0].right];
                foreach(var pixel in myImage.GetPixels())
                {
                    res.SetPixel(pixel.X, pixel.Y, pixel.GetColor());
                }
                foreach(var pixel in myImage.GetBoundPixels())
                {
                    res.SetPixel(pixel.X, pixel.Y, isCircle?Color.Red:Color.Green);
                }
                for (int k = 0; k < temp.Width; k++)
                {
                    for (int l = 0; l < temp.Height; l++)
                    {
                        if (temp.GetPixel(k, l).GetBrightness() > 0.01F)
                        {
                            int i = k + item.X - temp.Width / 2;
                            int j = l + item.Y - temp.Height / 2;

                            if (i < res.Width &&
                                j < res.Height &&
                                i >= 0 && j >= 0)
                            {
                                Color c = temp.GetPixel(k, l);
                                res.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                            }
                        }
                    }
                }
                Summ += double.Parse(stats[0].right);
                targetBox.AppendText(myImage.ToString() + "  " + stats[0].right + "\n");
            }
            resImageBox.Image = res;

            targetBox.AppendText("Сумма = "+Summ + "\n");
        }
        private void DoActionBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                if(ActionsList.SelectedItem!=null)
                {
                    Bitmap res = (Bitmap)srcImageBox.Image.Clone();
                    if(ActionsList.SelectedItem.ToString() == "Бинаризация"){ res = BinaryConvertor.AvarageK((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Свертка")    { res = Svertka.Mean((Bitmap)srcImageBox.Image,(int)meanValue.Value); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Сужение")    { res = Morphology.Erosion((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Расширение") { res = Morphology.Dilation((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Открытие")   { res = Morphology.Open((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Закрытие")   { res = Morphology.Close((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if(ActionsList.SelectedItem.ToString() == "Выделение связных областей")   
                    {
                        res = Detector.ABCDetecting((Bitmap)res, ref myImages); 
                        resImageBox.Image = res;
                    }
                    if(ActionsList.SelectedItem.ToString() == "Распознать")   
                    {
                        try {
                            Recognize();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        
                        //res = Detector.ABCDetecting((Bitmap)res); resImageBox.Image = res;
                    }
                    if(ActionsList.SelectedItem.ToString() == "Оттенки серого")   
                    { res = Grayworld.ToGray((Bitmap)srcImageBox.Image); resImageBox.Image = res; }
                    if (ActionsList.SelectedItem.ToString() == "Серый мир")
                    { res = Grayworld.ToGrayworld((Bitmap)res); resImageBox.Image = res; }
                    if (ActionsList.SelectedItem.ToString() == "Растяжение контрастности")
                    { res = Grayworld.AutoLevels((Bitmap)res); resImageBox.Image = res; }
                    //resImageBox.Image = res;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DoActionsBtn_Click(object sender, EventArgs e)
        {
            try 
            {
                Bitmap res = (Bitmap)srcImageBox.Image.Clone();

                myImages.Clear();
                foreach (var item in CurrentActList.Items)
                {
                    try 
                    {
                        if (item.ToString() == "Бинаризация") { res = BinaryConvertor.AvarageK((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Свертка") { res = Svertka.Mean((Bitmap)res, (int)meanValue.Value); resImageBox.Image = res; }
                        if (item.ToString() == "Сужение") { res = Morphology.Erosion((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Расширение") { res = Morphology.Dilation((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Открытие") { res = Morphology.Open((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Закрытие") { res = Morphology.Close((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Выделение связных областей")
                        { 
                            res = Detector.ABCDetecting((Bitmap)res, ref myImages); resImageBox.Image = res;
                        }
                        if (item.ToString() == "Оттенки серого")
                        { res = Grayworld.ToGray((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Серый мир")
                        { res = Grayworld.ToGrayworld((Bitmap)res); resImageBox.Image = res; }
                        if (item.ToString() == "Распознать")
                        {
                            Recognize(ref res);
                        }
                        Application.DoEvents();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            catch(Exception ex) { }
        }
        private void AddIntoListBtn_Click(object sender, EventArgs e)
        {
            if(ActionsList.SelectedItem!=null)
            CurrentActList.Items.Add(ActionsList.SelectedItem);
        }
        private void DeleteActionBtn_Click(object sender, EventArgs e)
        {
            CurrentActList.Items.Remove(CurrentActList.SelectedItem);
        }

        private void g2_CheckedChanged(object sender, EventArgs e)
        {
            if (g1.Checked) Morphology.SetMask(1);
            if (g2.Checked) Morphology.SetMask(2);
            if (g3.Checked) Morphology.SetMask(3);
        }
    }
}