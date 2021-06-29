using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;

namespace LAB2
{
    class Morphology
    {
        static bool[,] g1 =
        {
            { false, true, false },
            {  true, true,  true },
            { false, true, false }
        };
        static bool[,] g2 =
        {
            { true, true, true },
            { true, true, true },
            { true, true, true }
        };
        static bool[,] g3 =
        {
            { false, false, true ,true, true, false, false},
            { false,  true, true ,true, true,  true, false},
            {  true,  true, true ,true, true,  true,  true},
            {  true,  true, true ,true, true,  true,  true},
            {  true,  true, true ,true, true,  true,  true},
            { false,  true, true ,true, true,  true, false},
            { false, false, true ,true, true, false, false}
        };
        static bool[,] g = g1;
        public static void SetMask(int k)
        {
            if (k == 1) g = g1;
            else if (k == 2) g = g2;
            else if (k == 3) g = g3;
            else throw new Exception("Параметр должен быть только один из перечисленных: {1,2,3}!");
        }
       
        public static Bitmap Dilation( Bitmap source)
        {
            Bitmap res2 = new Bitmap((Bitmap)source.Clone());
            var g1 = g;

            Bit[,] res = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Bit[,] dst = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Dilation(ref res2, ref res, dst, g1);

            return res2;
        } 
        public static void Dilation(ref Bitmap res2, ref Bit[,] dst, Bit[,] res,bool[,] g1)
        {
            int width = res.GetLength(0);
            int height = res.GetLength(1);
            int n = g1.GetLength(0);

            for (int i = n / 2; i < width - n / 2; i++)
            {
                for (int j = n / 2; j < height - n / 2; j++)
                {
                    Bit max = new Bit(false);
                    for (int l = 0; l < n; l++)
                        for (int k = 0; k < n; k++)
                        {
                            Bit pixel = res[i + l - n / 2, j + k - n / 2];
                            if (new Bit((bool)pixel && g1[l, k]) > max) max = pixel;
                        }
                    res2.SetPixel(i, j, max ? Color.White : Color.Black);
                    dst[i, j] = max;
                }
            }
        } 
        public static void Erosion(ref Bitmap res2,ref Bit[,] dst, Bit[,] res, bool[,] g1)
        {
            int width = res.GetLength(0);
            int height = res.GetLength(1);
            int n = g1.GetLength(0);

            for (int i = n / 2; i < width - n / 2; i++)
            {
                for (int j = n / 2; j < height - n / 2; j++)
                {
                    Bit min = new Bit(false);
                    for (int l = 0; l < n; l++)
                        for (int k = 0; k < n; k++)
                        {
                            Bit pixel = res[i + l - n / 2, j + k - n / 2];
                            if (min < pixel) min = pixel;
                        }
                    for (int l = 0; l < n; l++)
                        for (int k = 0; k < n; k++)
                        {
                            Bit pixel = res[i + l - n / 2, j + k - n / 2];
                            if (new Bit((bool)pixel && g1[l, k]) < min) min = pixel;
                        }
                    res2.SetPixel(i, j, min ? Color.White : Color.Black);
                    dst[i,j] = min;
                }
            }
        }
        public static Bitmap Erosion(Bitmap source)
        {
            Bitmap res2 = new Bitmap((Bitmap)source.Clone());
            var g1 = g;

            Bit[,] res = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Bit[,] dst = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Erosion(ref res2,ref dst,res, g1);

            return res2;
        }
        public static Bitmap Open(Bitmap source)
        {
            Bitmap res2 = new Bitmap((Bitmap)source.Clone());
            var g1 = g;

            Bit[,] res = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Bit[,] dst = BinaryConvertor.BitmapToBlackWhite2((Bitmap)source);
            Erosion(ref res2,ref dst,res, g1);
            Dilation(ref res2, ref res, dst, g1);

            return res2;
        }
        //Закрытие
        public static Bitmap Close(Bitmap source)
        {
            Bitmap res2 = new Bitmap((Bitmap)source.Clone());
            var g1 = g;

            Bit[,] res = BinaryConvertor.BitmapToBlackWhite2(res2);
            Bit[,] dst = BinaryConvertor.BitmapToBlackWhite2(res2);

            Dilation(ref res2, ref dst, res, g1);
            Erosion(ref res2, ref res, dst, g1);
            return res2;
        }

    }
}
