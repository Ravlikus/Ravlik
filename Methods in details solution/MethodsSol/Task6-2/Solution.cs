using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_2
{
    public static class EuclidianGCDFinder // НОД 
    {
        public static TimeSpan GetGCDFindingTiming(int a, int b, params int[] values)
        {
            var timer = new Stopwatch();
            timer.Start();
            var s = FindGCD(a, b, values);
            timer.Stop();
            return timer.Elapsed;
        }

        public static int FindGCD(int a, int b,params int[]  values)
        {
            var result = FindGCD(a, b);
            for (int i = 0; i < values.Length; i++)
            {
                result = FindGCD(result, values[i]);
            }
            return result;
        }

        public static int FindGCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b) return a;
            var min = Math.Min(a, b);
            var diff = Math.Abs(a - b);
            return FindGCD(min, diff);
        }
    }

    public static class SteinGCDFinder
    {
        public static TimeSpan GetGCDFindingTiming(int a, int b, params int[] values)
        {
            var timer = new Stopwatch();
            timer.Start();
            var s = FindGCD(a, b, values);
            timer.Stop();
            return timer.Elapsed;
        }

        public static int FindGCD(int a, int b, params int[] values)
        {
            var result = FindGCD(a, b);
            for (int i = 0; i < values.Length; i++)
            {
                result = FindGCD(result, values[i]);
            }
            return result;
        }

        public static int FindGCD(int a, int b)
        {
            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;
            if (a == 1) return 1;
            if (b == 1) return 1;
            if (a % 2 == 0 && b % 2 == 0) return 2 * FindGCD(a / 2, b / 2);
            if (a % 2 == 0 && b % 2 != 0) return FindGCD(a / 2, b);
            if (a % 2 != 0 && b % 2 == 0) return FindGCD(a, b / 2);
            if (a > b) return FindGCD((a - b) / 2, b);
            return FindGCD((b - a) / 2, a);
        }
    }
}
