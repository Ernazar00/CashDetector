using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class Svertka
    {
        public static Bitmap Mean(Bitmap source, int M)
        {
            if (M % 2 != 1) throw new Exception("Параметр должен быть четным!");
            int n = source.Width;
            int m = source.Height;
            Bitmap res = new Bitmap(n, m);
            for (int i = M / 2; i < n - M / 2; i++)
            {
                for (int j = M / 2; j < m - M / 2; j++)
                {
                    int[] rs = new int[M * M];
                    int[] gs = new int[M * M];
                    int[] bs = new int[M * M];

                    for (int k = 0; k < M; k++)
                        for (int l = 0; l < M; l++)
                        {
                            Color c = source.GetPixel(i + k - M / 2, j + l - M / 2);
                            rs[l * k + l] = c.R;
                            bs[l * k + l] = c.B;
                            gs[l * k + l] = c.G;
                        }
                    Array.Sort(rs);
                    Array.Sort(gs);
                    Array.Sort(bs);
                    res.SetPixel(i, j, Color.FromArgb(rs[M * M / 2], gs[M * M / 2], bs[M * M / 2]));
                }
            }

            return res;
        }

        public static Bitmap SvertkaAVG(Bitmap source)
        {
            int[][] g =
            {
                    new int[]{ 1, 1, 1 },
                    new int[]{ 1, 1, 1 },
                    new int[]{ 1, 1, 1 }
            };
            int n = source.Width;
            int m = source.Height;
            int w = g.GetLength(0) / 2;
            int h = g.GetLength(0) / 2;
            Bitmap res = new Bitmap(n, m);
            for (int i = w; i < n - w; i++)
            {
                for (int j = h; j < m - h; j++)
                {
                    int fr = 0, fg = 0, fb = 0;
                    for (int k = 0; k < w; k++)
                        for (int l = 0; l < h; l++)
                        {
                            Color c = source.GetPixel(i + k - w, j + l - h);
                            fr += c.R * g[k][l];
                            fg += c.G * g[k][l];
                            fb += c.B * g[k][l];
                        }
                    fr /= 9;
                    fg /= 9;
                    fb /= 9;
                    res.SetPixel(i, j, Color.FromArgb(fr, fg, fb));
                }
            }
            return res;
        }
        public static Bitmap RotateImage(Bitmap b, float angle)
        {
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height);
            //make a graphics object from the empty bitmap
            using (Graphics g = Graphics.FromImage(returnBitmap))
            {
                //move rotation point to center of image
                g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
                //rotate
                g.RotateTransform(angle);
                //move image back
                g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
                //draw passed in image onto graphics object
                g.DrawImage(b, new Point(0, 0));
            }
            return returnBitmap;
        }
        public static Image ResizeImage(Image source, RectangleF destinationBounds)
        {
            RectangleF sourceBounds = new RectangleF(0.0f, 0.0f, (float)source.Width, (float)source.Height);
            RectangleF scaleBounds = new RectangleF();

            Image destinationImage = new Bitmap((int)destinationBounds.Width, (int)destinationBounds.Height);
            Graphics graph = Graphics.FromImage(destinationImage);
            graph.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            // Fill with background color
            graph.FillRectangle(new SolidBrush(System.Drawing.Color.White), destinationBounds);

            float resizeRatio, sourceRatio;
            float scaleWidth, scaleHeight;

            sourceRatio = (float)source.Width / (float)source.Height;

            if (sourceRatio >= 1.0f)
            {
                //landscape
                resizeRatio = destinationBounds.Width / sourceBounds.Width;
                scaleWidth = destinationBounds.Width;
                scaleHeight = sourceBounds.Height * resizeRatio;
                float trimValue = destinationBounds.Height - scaleHeight;
                graph.DrawImage(source, 0, (trimValue / 2), destinationBounds.Width, scaleHeight);
            }
            else
            {
                //portrait
                resizeRatio = destinationBounds.Height / sourceBounds.Height;
                scaleWidth = sourceBounds.Width * resizeRatio;
                scaleHeight = destinationBounds.Height;
                float trimValue = destinationBounds.Width - scaleWidth;
                graph.DrawImage(source, (trimValue / 2), 0, scaleWidth, destinationBounds.Height);
            }

            return destinationImage;

        }
       
    }
}