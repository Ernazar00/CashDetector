using System;
using System.Drawing;

namespace LAB2
{
    class Grayworld
    {
        public static Bitmap ToGray(Bitmap sourse)
        {
            Bitmap res = (Bitmap)sourse.Clone();

            for (int i = 0; i < sourse.Width; i++)
            {
                for (int j = 0; j < sourse.Height; j++)
                {
                    Color c = sourse.GetPixel(i, j);
                    YIQ yiq = new YIQ(c.R, c.G, c.B);

                    res.SetPixel(i, j, Color.FromArgb((int)yiq.Y, (int)yiq.Y, (int)yiq.Y));
                }
            }

            return res;
        }
        public static Bitmap ToGrayworld(Bitmap src)
        {
            Bitmap res = (Bitmap)src.Clone();
            int w = src.Width;
            int h = src.Height;
            int N = w * h;
            int avgR = 0,avgG=0,avgB=0,avg=0;

            for(int i=0;i<w;i++)
            {
                for(int j=0;j<h;j++)
                {
                    avgR += res.GetPixel(i, j).R;
                    avgG += res.GetPixel(i, j).G;
                    avgB += res.GetPixel(i, j).B;
                }
            }
            avgR /= N;
            avgG /= N;
            avgB /= N;
            avg = (avgR + avgG + avgB) / 3;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int R = (int)((double)res.GetPixel(i, j).R * ((double)avg / avgR));
                    int G = (int)((double)res.GetPixel(i, j).G * ((double)avg / avgG));
                    int B = (int)((double)res.GetPixel(i, j).B * ((double)avg / avgB));
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    res.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            return res;
        }
        public static Bitmap AutoLevels(Bitmap src)
        {
            Bitmap res = (Bitmap)src.Clone();
            Color c = res.GetPixel(0, 0);

            int Rmin = 255; int Rmax = 0;
            int Gmin = 255; int Gmax = 0;
            int Bmin = 255; int Bmax = 0;
            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    c = res.GetPixel(i, j);
                    if (c.R > Rmax) Rmax = c.R;
                    if (c.G > Gmax) Gmax = c.G;
                    if (c.B > Bmax) Bmax = c.B;

                    if (c.R < Rmin) Rmin = c.R;
                    if (c.G < Gmin) Gmin = c.G;
                    if (c.B < Bmin) Bmin = c.B;
                }
            }
            for (int i = 0; i < src.Width; i++)
            {
                for (int j = 0; j < src.Height; j++)
                {
                    c = src.GetPixel(i, j);
                    int R = (c.R - Rmin) * 255 / (Rmax - Rmin);
                    int G = (c.G - Gmin) * 255 / (Gmax - Gmin);
                    int B = (c.B - Bmin) * 255 / (Bmax - Bmin);
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    res.SetPixel(i, j, Color.FromArgb(R, G, B));
                }
            }

            return res;
        }

    }
}
