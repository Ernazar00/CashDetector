using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class YIQ
    {
        public double Y { get; set; }
        public double I { get; set; }
        public double Q { get; set; }

        public YIQ(int R,int G,int B)
        {
            Y = 0.299 * R + 0.587 * G + 0.114 * B;
            I = 0.596 * R - 0.274 * G - 0.322 * B;
            Q = 0.211 * R - 0.522 * G + 0.311 * B;

            if (Y < 0) Y = 0;
            if (I < 0) I = 0;
            if (Q < 0) Q = 0;
        }
        public YIQ(System.Drawing.Color color)
        {
            Y = 0.299 * color.R + 0.587 * color.G + 0.114 * color.B;
            I = 0.596 * color.R - 0.274 * color.G - 0.322 * color.B;
            Q = 0.211 * color.R - 0.522 * color.G + 0.311 * color.B;

            if (Y < 0) Y = 0;
            if (I < 0) I = 0;
            if (Q < 0) Q = 0;
        }
    }
}
