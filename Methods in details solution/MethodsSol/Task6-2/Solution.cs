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
        /// <summary>
        /// Метод, замеряющий время работы метода FindGCD с задаными входными параметрами
        /// </summary>
        public static TimeSpan GetGCDFindingTiming(params int[] values)
        {
            var timer = new Stopwatch();
            timer.Start();
            var s = FindGCD( values);
            timer.Stop();
            return timer.Elapsed;
        }
        /// <summary>
        /// Метод ищет НОД всех входящих чисел
        /// </summary>
        public static int FindGCD(params int[]  values)
        {
            var result = FindGCD(values[0], values[1]);
            for (int i = 2; i < values.Length; i++)
            {
                result = FindGCD(result, values[i]);
            }
            return result;
        }
        /// <summary>
        /// Метод ищет НОД 2-х чисел
        /// </summary>
        public static int FindGCD(int a, int b)
        {
            while (true)
            {
                if (a == 0) return b;
                if (b == 0) return a;
                a = Math.Abs(a);
                b = Math.Abs(b);
                if (a == b) return a;
                var min = Math.Min(a, b);
                var diff = Math.Abs(a - b);
                a = min;
                b = diff;
            }
        }
    }

    public static class SteinGCDFinder
    {
        /// <summary>
        /// Метод, замеряющий время работы метода FindGCD с задаными входными параметрами
        /// </summary>
        public static TimeSpan GetGCDFindingTiming(params int[] values)
        {
            var timer = new Stopwatch();
            timer.Start();
            var s = FindGCD(values);
            timer.Stop();
            return timer.Elapsed;
        }

        /// <summary>
        /// Метод ищет НОД всех входящих чисел
        /// </summary>
        public static int FindGCD(params int[] values)
        {
            var result = FindGCD(values[0],values[1]);
            for (int i = 2; i < values.Length; i++)
            {
                result = FindGCD(result, values[i]);
            }
            return result;
        }

        /// <summary>
        /// Метод ищет НОД 2-х чисел
        /// </summary>
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
