using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2.Helpers
{
    class Statistic
    {
        public int avgR { get; private set; }
        public int avgG { get; private set; }
        public int avgB { get; private set; }
        public int avg  { get; private set; }
        public int dR { get; private set; }
        public int dG { get; private set; }
        public int dB { get; private set; }
        public int[] gR { get; private set; }
        public int[] gG { get; private set; }
        public int[] gB { get; private set; }
        public Statistic(List<MyPixel> pixels)
        {
            gR = new int[256];
            gG = new int[256];
            gB = new int[256];
            for(int i=0; i< pixels.Count;i++)
            {
                int R = pixels[i].GetColor().R;
                int G = pixels[i].GetColor().G;
                int B = pixels[i].GetColor().B;
                avgR += R;
                avgG += G;
                avgB += B;
                gR[R]++;
                gG[G]++;
                gB[B]++;
            }
            avgR /= pixels.Count;
            avgG /= pixels.Count;
            avgB /= pixels.Count;
            int iR = 0, iG =0 , iB=0;
            for (int i = 0; i < 256; i++)
            {
                if (dR < gR[i])
                {
                    dR = gR[i];
                    iR = i;
                }
                if (dG < gG[i])
                {
                    dG = gG[i]; iG = i;
                }
                if (dB < gB[i])
                {
                    dB = gB[i]; iB = i;
                }
            }
            dR = iR;
            dG = iG;
            dB = iB;
            avg = (avgR + avgG + avgB) / 3;
        }
        public override string ToString()
        {
            return "R'="+dR+"\tG'="+dG+"\tB'="+dB+"\tavg="+avg;
        }
    }
}
