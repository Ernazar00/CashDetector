using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
    class Bit
    {
        private bool e;
        private int y;
        public Bit(bool e)
        {
            this.e = e;
            if (e) y = 1;
            else y = 0;
        }
        public static bool operator true(Bit c1)
        {
            return c1.e != false;
        }
        public static explicit operator bool(Bit bit)
        {
            return bit.e;
        }
        public static bool operator false(Bit c1)
        {
            return c1.e == false;
        }
        public static bool operator >(Bit c1, Bit c2)
        {
            return c1.y > c2.y;
        }
        public static bool operator <(Bit c1, Bit c2)
        {
            return c1.y < c2.y;
        }
    }
}
