using LAB2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class Error :IComparable
    {
        public double deltaR { get; private set; }
        public double deltaG { get; private set; }
        public double deltaB { get; private set; }
        public int dR { get; private set; }
        public int dG { get; private set; }
        public int dB { get; private set; }
        public double deltaA { get; private set; }
        public double delta { get; private set; }
        public string left { get; private set;  }
        public string right { get; private set; }
        public Error(MyImageObject x1,MyImageObject y1)
        {
            var x = x1.statistic;
            var y = y1.statistic;
            deltaR = (double)Math.Abs(x.avgR - y.avgR)/y.avgR;
            deltaG = (double)Math.Abs(x.avgG - y.avgG)/y.avgG;
            deltaB = (double)Math.Abs(x.avgB - y.avgB)/y.avgB;
            dR = x.dR - y.dR;
            dG = x.dG - y.dG;
            dB = x.dB - y.dB;

            delta = deltaR+ deltaG+ deltaB;
            //delta = dR+dG+dB;
            //delta =  Math.Pow(deltaR*deltaR + deltaG*deltaG + deltaB+deltaB+deltaA*deltaA,2);

            left = x1.name;
            right = y1.name;
        }     

        public int CompareTo(object obj)
        {
            if (delta == ((Error)obj).delta) return 0;
            else if (delta > ((Error)obj).delta) return 1;
            else return -1;
        }
        public override string ToString()
        {
            return left+" "+dR+" "+ dG + " "+ dB;
        }
    }
}
