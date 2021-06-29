using System.Drawing;

namespace LAB2
{
    class MyPixel
    {
        Color color;
        public int X{ get; private set; }
        public int Y{ get; private set; }
        public MyPixel(int x,int y,Color color)
        {
            X = x;
            Y = y;
            this.color = color;
        }
        public Color GetColor()
        {
            return color;
        }
    }
}