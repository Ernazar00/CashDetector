using System;
using System.Collections.Generic;
using System.Drawing;

namespace LAB2
{
    class Detector
    {
        //Выделение контура
        public static Bitmap EdgeDetection(Bitmap b, float threshold)
        {
            Bitmap bSrc = (Bitmap)b.Clone();

            int nWidth = b.Width - 1;
            int nHeight = b.Height - 1;

            for (int y = 0; y < nHeight; ++y)
            {
                for (int x = 0; x < nWidth; ++x)
                {
                    //  | p0 |  p1  |
                    //  |    |  p2  |
                    var pixel = b.GetPixel(x, y);
                    var pixel1 = b.GetPixel(x + 1, y);
                    var pixel2 = b.GetPixel(x, y + 1);
                    var p0 = ToGray(new byte[] { pixel.R, pixel.G, pixel.B });
                    var p1 = ToGray(new byte[] { pixel1.R, pixel1.G, pixel1.B });
                    var p2 = ToGray(new byte[] { pixel2.R, pixel2.G, pixel2.B });
                    byte[] p = new byte[3];
                    if (Math.Abs(p1 - p2) + Math.Abs(p1 - p0) > threshold)
                        p[0] = p[1] = p[2] = 255;
                    else
                        p[0] = p[1] = p[2] = 0;
                    bSrc.SetPixel(x, y, Color.FromArgb(p[0], p[1], p[2]));
                }
            }

            return bSrc;
        }
        static float ToGray(byte[] bgr)
        {
            return bgr[2] * 0.3f + bgr[1] * 0.59f + bgr[0] * 0.11f;
        }
        //Последовательное сканирование
        public static Bitmap ABCDetecting(Bitmap src)
        {
            //double treshold = 0.5;
            int w = src.Width;
            int h = src.Height;
            int[,] dst = new int[w, h];
            //Bitmap temp = (Bitmap)src.Clone();
            //temp = Morphology.Dilation(temp);
            //src = Morphology.Dilation(src);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (src.GetPixel(i, j).GetBrightness()>0.9F) dst[i, j] = 1;
                    else dst[i, j] = 0;
                }
            }
            int[,] res = ABC(dst);
            Bitmap resBitmap = new Bitmap(w, h);
            HashSet<int> colors = new HashSet<int>();
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (res[i, j] == 0) resBitmap.SetPixel(i, j, Color.Black);
                    else
                    {
                        colors.Add(res[i, j]);
                        if (res[i, j] % 2 == 0) resBitmap.SetPixel(i, j, Color.Red);
                        if (res[i, j] % 3 == 0) resBitmap.SetPixel(i, j, Color.Green);
                        if (res[i, j] % 4 == 0) resBitmap.SetPixel(i, j, Color.Purple);
                        if (res[i, j] % 5 == 0) resBitmap.SetPixel(i, j, Color.Blue);
                        if (res[i, j] % 6 == 0) resBitmap.SetPixel(i, j, Color.Yellow);
                        if (res[i, j] % 7 == 0) resBitmap.SetPixel(i, j, Color.Brown);
                        if (res[i, j] % 8 == 0) resBitmap.SetPixel(i, j, Color.GreenYellow);
                        if (res[i, j] % 9 == 0) resBitmap.SetPixel(i, j, Color.Orange);
                        if (res[i, j] % 10 == 0) resBitmap.SetPixel(i, j, Color.Pink);
                        if (res[i, j] % 11 == 0) resBitmap.SetPixel(i, j, Color.AliceBlue);
                    }
                }
            }
            return resBitmap;
        }
        public static Bitmap ABCDetecting(Bitmap src,ref Dictionary<string,MyImageObject> myImages)
        {
            //double treshold = 0.5;
            int w = src.Width;
            int h = src.Height;
            int[,] dst = new int[w, h];
            //Bitmap temp = (Bitmap)src.Clone();
            //temp = Morphology.Dilation(temp);
            //src = Morphology.Dilation(src);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (src.GetPixel(i, j).GetBrightness()>0.9F) dst[i, j] = 1;
                    else dst[i, j] = 0;
                }
            }
            int[,] res = ABC(dst);
            Bitmap resBitmap = new Bitmap(w, h);
            HashSet<int> colors = new HashSet<int>();
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (res[i, j] == 0) resBitmap.SetPixel(i, j, Color.Black);
                    else
                    {
                        if(myImages.ContainsKey(res[i,j].ToString()))
                            myImages[res[i,j].ToString()].AddPixel(i, j, src.GetPixel(i, j), false);
                        else
                        {
                            myImages[res[i, j].ToString()] = new MyImageObject(res[i, j].ToString());
                            myImages[res[i, j].ToString()].AddPixel(i, j, src.GetPixel(i, j), false);
                        }
                        colors.Add(res[i, j]);
                        if (res[i, j] % 11 == 0) resBitmap.SetPixel(i, j, Color.AliceBlue);
                        else if (res[i, j] % 10 == 0) resBitmap.SetPixel(i, j, Color.Pink);
                        else if (res[i, j] % 9 == 0) resBitmap.SetPixel(i, j, Color.Orange);
                        else if (res[i, j] % 8 == 0) resBitmap.SetPixel(i, j, Color.GreenYellow);
                        else if (res[i, j] % 7 == 0) resBitmap.SetPixel(i, j, Color.Brown);
                        else if (res[i, j] % 6 == 0) resBitmap.SetPixel(i, j, Color.Yellow);
                        else if (res[i, j] % 5 == 0) resBitmap.SetPixel(i, j, Color.Blue);
                        else if (res[i, j] % 4 == 0) resBitmap.SetPixel(i, j, Color.Purple);
                        else if (res[i, j] % 3 == 0) resBitmap.SetPixel(i, j, Color.Green);
                        else if (res[i, j] % 2 == 0) resBitmap.SetPixel(i, j, Color.Red);
                        else resBitmap.SetPixel(i, j, Color.White);
                    }
                }
            }
            string[] dicArrray = new string[myImages.Count];
            myImages.Keys.CopyTo(dicArrray,0);
            for (int i=0;i<dicArrray.Length;i++)
            {
                if (myImages[dicArrray[i]].S<1000)
                    myImages.Remove(dicArrray[i]);
            }
            foreach (var i in myImages.Keys)
            {
                myImages[i].CalculateParameters();
            }
            return resBitmap;
        }
        public static int[,] ABC(int[,] Image0)
        {
            int m = Image0.GetLength(0);
            int n = Image0.GetLength(1);
            int A, B, C;
            int cur = 1;
            int kn, km;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    kn = j - 1;
                    if (kn < 0)
                    {
                        kn = 0;
                        B = 0;
                    }
                    else { B = Image0[i, kn]; }
                    km = i - 1;
                    if (km < 0)
                    {
                        km = 0;
                        C = 0;
                    }
                    else { C = Image0[km, j]; }
                    A = Image0[i, j];
                    if (A == 0) { }
                    else if (B == 0 && C == 0)
                    {
                        ++cur;
                        Image0[i, j] = cur;
                    }
                    else if (B != 0 && C == 0) Image0[i, j] = B;
                    else if (B == 0 && C != 0) Image0[i, j] = C;
                    else if (B != 0 && C != 0)
                        if (B == C) Image0[i, j] = B;
                        else
                        {
                            Image0[i, j] = B;
                            for (int l = 0; l < m; l++)
                                for (int k = 0; k < n; k++)
                                    if (Image0[l, k] == C) Image0[l, k] = B;
                        }
                }
            return Image0;
        }
        //Поиск ближайших пикселей края
        public static Bitmap DistanceTransform(Bitmap bin)
        {
            Bitmap bitmap = (Bitmap)bin.Clone();
            int w = bin.Width;
            int h = bin.Height;
            int[,] dst = new int[w, h];
            //Bitmap temp = (Bitmap)src.Clone();
            //temp = Morphology.Dilation(temp);
            //src = Morphology.Dilation(src);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if (bin.GetPixel(i, j).R > 250&&
                        bin.GetPixel(i, j).G > 250&&
                        bin.GetPixel(i, j).B > 250) dst[i, j] = 1;
                    else dst[i, j] = 0;
                }
            }
            int[,] res = DT(dst);
            int max = 0;
            
            for(int i=0;i<w;i++)
            {
                for(int j=0;j<h;j++)
                {
                    if (res[i, j] > max) max = res[i, j];
                }
            }
            for (int i=0;i<w;i++)
            {
                for(int j=0;j<h;j++)
                {
                    int scale = (int)(((double)res[i, j] / (double)max) * 255);
                    bitmap.SetPixel(i, j, Color.FromArgb(scale, scale, scale));
                }
            }

            return bitmap;
        }  
        public static int[,] DT(int[,] src) 
        {
            int Width = src.GetLength(0);
            int Height = src.GetLength(1);
            int[,] res = new int[Width, Height];
            int N = Width*Height;
            for (int i=0;i<Width;i++)
            {
                for(int j=0;j<Height;j++)
                {
                    if (src[i, j] == 0)
                    {
                        res[i, j] = 0;
                        N--;
                    }
                    else { res[i, j] = -1; }
                }
            }
            int s = 0;
            int m = 1;
            for(; ; )
            {
                for (int i=0;i<Width;i++)
                {
                    for(int j=0;j<Height;j++)
                    {
                        if (res[i, j] ==-1) 
                        {
                            if (i != 0 && res[i - 1, j] == s) { res[i, j] = m; N--; }
                            else if (i != Width - 1 && res[i + 1, j] == s) { res[i, j] = m; N--; }
                            else if (j != 0 && res[i, j - 1] == s) { res[i, j] = m; N--; }
                            else if (j != Height - 1 && res[i, j + 1] == s) { res[i, j] = m; N--; }
                        }
                    }
                }
                s++;
                m++;
                if (N == 0) return res;
            }
        }
    }
}
