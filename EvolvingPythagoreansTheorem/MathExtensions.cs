using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolvingPythagoreansTheorem
{
    public static class MathExtensions
    {
        public static int Ceiling(this double x)
        {
            return (int) Math.Ceiling(x);
        }

        public static double Squared(this int x)
        {
            return Math.Pow(x, 2);
        }

        public static double Squared(this double x)
        {
            return Math.Pow(x, 2);
        }
    }
}
