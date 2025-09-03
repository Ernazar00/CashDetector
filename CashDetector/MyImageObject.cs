using LAB2.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LAB2
{
    class MyImageObject :IComparable
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int S { get; private set; }
        public int P { get; private set; }
        public string name { get; private set; }
        private int left = 10000;
        private int right = 0;
        private int top = 10000;
        private int bottom = 0;
        public Statistic statistic { get; private set; }
        List<MyPixel> PixelsList = new List<MyPixel>();
        List<MyPixel> BoundPixels = new List<MyPixel>();
        public MyImageObject(string name) 
        { 
            this.name = name;
            S = 0;
            P = 0;
            X = 0;
            Y = 0;
        }
        public void AddPixel(int x,int y,Color color,bool IsBound)
        {
            MyPixel pixel = new MyPixel(x, y, color);
            PixelsList.Add(pixel);
            if (IsBound) 
            {
                BoundPixels.Add(pixel);
                P++; 
            }
            if (left > x) left = x;
            if (right < x) right = x;
            if (top > y) top = y;
            if (bottom < y) bottom = y;
            X += x;
            Y += y;
            S++;

        }
        public List<MyPixel> GetPixels()
        {
            return PixelsList;
        }
        public List<MyPixel> GetBoundPixels()
        {
            return BoundPixels;
        }
        public void CalculateParameters()
        {
            X /= S;
            Y /= S;
            statistic = new Statistic(PixelsList);
        }
        public bool IsCircle()
        {
            CalculateParameters();
            double e = 0.1;

            double r1 = (right - left)/2 ;
            double s = Math.PI * r1 * r1;
            double delta = Math.Abs(s - S)/S;
            return delta < e;
        }
        public int CompareTo(object obj)
        {
            if (((MyImageObject)obj).statistic.avg > this.statistic.avg) return 1;
            else if (((MyImageObject)obj).statistic.avg == this.statistic.avg) return 0;
            else return -1;
        }
        public override string ToString()
        {
            return name+" "+statistic;
        }
    }
}
