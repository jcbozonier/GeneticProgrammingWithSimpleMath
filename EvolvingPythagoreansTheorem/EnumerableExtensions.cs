using System;
using System.Collections.Generic;

namespace EvolvingPythagoreansTheorem
{
    public static class MathExtensions
    {
        public static double Squared(this int x)
        {
            return Math.Pow(x, 2);
        }

        public static double Squared(this double x)
        {
            return Math.Pow(x, 2);
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<int> Until(this int inclusiveStart, int exclusiveEnd)
        {
            for (var i = inclusiveStart; i < exclusiveEnd; i++)
            {
                yield return i;
            }
        }

        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }
}
