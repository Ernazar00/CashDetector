using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace LAB2
{    
    class BinaryConvertor
    {
        public static Bitmap WithText(Bitmap bitmap, String text, int X, int Y, int textWidth)
        {
            var bmp = (Bitmap)bitmap.Clone();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, textWidth, FontStyle.Bold, GraphicsUnit.Pixel);
                g.DrawString(text, font, Brushes.Red, X, Y);
            }
            return bmp;
        }
        public static Bitmap TresholdBinary(Bitmap source)
        {
            Bitmap res = BitmapToBlackWhite(source);

            return res;
        }
        public static Bitmap AvarageK(Bitmap source)
        {
            Bitmap res = (Bitmap)source.Clone();
            int w = res.Width;
            int h = res.Height;
            float T = 0;
            for(int i=0;i < w; i++)
            {
                for(int j = 0;j< h; j++)
                {
                    T += res.GetPixel(i, j).GetBrightness();
                }
            }
            T /= w * h;
            bool e1 = true;
            float e2 = 0.001F;
            while(e1)
            {
                int m1 = 0;
                int m2 = 0;
                float t1 = 0;
                float t2 = 0;

                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        float temp = res.GetPixel(i, j).GetBrightness();
                        if (temp<T)
                        {
                            m1++;
                            t1 += temp;
                        }
                        else 
                        {
                            m2++;
                            t2 += temp;
                        }
                    }
                }
                t1 /= m1;  t2 /= m2;
                float T1 = (t1 + t2) / 2;
                if (Math.Abs(T - T1) > e2) e1 = false;
                else { T = T1;}
            }
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    res.SetPixel(i, j, res.GetPixel(i,j).GetBrightness() < T ? Color.Black : Color.White);
                }
            }

            return res;
        }
        //Открытие
        public static Bit[,] BitmapToBlackWhite2(Bitmap src)
        {
            int w = src.Width;
            int h = src.Height;
            Bit[,] dst = new Bit[w,h];

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    Color color = src.GetPixel(i, j).GetBrightness()>0.9F?Color.White:Color.Black;
                    if (color == Color.White) dst[i, j] = new Bit(true);
                    else dst[i, j] = new Bit(false);
                }
            }

            return dst;
        }
        public static Bitmap BitmapToBlackWhite(Bitmap src)
        {
            double treshold = 0.5;
            Bitmap res2 = (Bitmap)src.Clone();

            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    Color color = src.GetPixel(i, j).GetBrightness() < treshold ? Color.Black : Color.White;
                    res2.SetPixel(i, j, color);
                }
            }

            return res2;
        }
        public static Bitmap Bradley_threshold (Bitmap src)
        {
            int width = src.Width;
            int height = src.Height;
            Bitmap res = (Bitmap)src.Clone();
            int S = width / 8;
            int s2 = S / 2;
            const float t = 0.15F;
            long[] integral_image ;
            long sum = 0;
            int count = 0;
            int index;
            int x1, y1, x2, y2;

            //рассчитываем интегральное изображение 
            integral_image = new long[width * height];

            for (int i = 0; i < width; i++)
            {
                sum = 0;
                for (int j = 0; j < height; j++)
                {
                    index = j * width + i;
                    var pixel = src.GetPixel(i,j);
                    int I = (int)(0.2125*pixel.R + 0.7154* pixel.G + 0.0721* pixel.B);
                    sum += I;
                    if (i == 0)
                        integral_image[index] = sum;
                    else
                        integral_image[index] = integral_image[index - 1] + sum;
                }
            }

            //находим границы для локальные областей
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    index = j * width + i;

                    x1 = i - s2;
                    x2 = i + s2;
                    y1 = j - s2;
                    y2 = j + s2;

                    if (x1 < 0)
                        x1 = 0;
                    if (x2 >= width)
                        x2 = width - 1;
                    if (y1 < 0)
                        y1 = 0;
                    if (y2 >= height)
                        y2 = height - 1;

                    count = (x2 - x1) * (y2 - y1);

                    sum = integral_image[y2 * width + x2] - integral_image[y1 * width + x2] -
                                integral_image[y2 * width + x1] + integral_image[y1 * width + x1];
                    var pixel = src.GetPixel(i, j);
                    int I = (int)(0.2125 * pixel.R + 0.7154 * pixel.G + 0.0721 * pixel.B);
                    if ((long)(I * count) < (long)(sum * (1.0 - t)))
                        res.SetPixel(i,j,Color.Black);
                    else
                        res.SetPixel(i, j, Color.White);
                }
            }
            return res;

        }
    }
}
