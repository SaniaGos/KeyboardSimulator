using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSimulator
{
    public static class MyRand
    {
        static Random rand;
        static MyRand()
        {
            rand = new Random();
        }
        public static int GetRand(int minValue = 0, int maxValue = 10000)
        {
            return rand.Next(minValue, maxValue + 1);
        }
    }

}
