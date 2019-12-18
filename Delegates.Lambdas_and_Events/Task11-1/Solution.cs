using System;
using System.Diagnostics;

namespace Task11_1
{
    public class Solution
    {
        public delegate int GSDFinder(params int[] values);
        public delegate TimeSpan TimeChecker(params int[] values);


        public static class EuclidianGCDFinder // НОД 
        {
            public static GSDFinder FindGSD = GetGSDByValues;
            public static TimeChecker GetGSDFindingTiming = GetTiming;

            /// <summary>
            /// Метод, замеряющий время работы метода FindGCD с задаными входными параметрами
            /// </summary>
            private static TimeSpan GetTiming(params int[] values)
            {
                var timer = new Stopwatch();
                timer.Start();
                var s = GetGSDByValues(values);
                timer.Stop();
                return timer.Elapsed;
            }

            /// <summary>
            /// Метод ищет НОД всех входящих чисел
            /// </summary>
            private static int GetGSDByValues(params int[] values)
            {
                var result = GetGSDByValues(values[0], values[1]);
                for (int i = 2; i < values.Length; i++)
                {
                    result = GetGSDByValues(result, values[i]);
                }
                return result;
            }

            /// <summary>
            /// Метод ищет НОД 2-х чисел
            /// </summary>
            private static int GetGSDByValues(int a, int b)
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
            public static GSDFinder FindGSD = GetGSDByValues;
            public static TimeChecker GetGSDFindingTiming = GetTiming;

            /// <summary>
            /// Метод, замеряющий время работы метода FindGCD с задаными входными параметрами
            /// </summary>
            private static TimeSpan GetTiming(params int[] values)
            {
                var timer = new Stopwatch();
                timer.Start();
                var s = GetGSDByValues(values);
                timer.Stop();
                return timer.Elapsed;
            }

            /// <summary>
            /// Метод ищет НОД всех входящих чисел
            /// </summary>
            private static int GetGSDByValues(params int[] values)
            {
                var result = GetGSDByValues(values[0], values[1]);
                for (int i = 2; i < values.Length; i++)
                {
                    result = GetGSDByValues(result, values[i]);
                }
                return result;
            }

            /// <summary>
            /// Метод ищет НОД 2-х чисел
            /// </summary>
            private static int GetGSDByValues(int a, int b)
            {
                if (a == 0) return b;
                if (b == 0) return a;
                if (a == b) return a;
                if (a == 1) return 1;
                if (b == 1) return 1;
                if (a % 2 == 0 && b % 2 == 0) return 2 * GetGSDByValues(a / 2, b / 2);
                if (a % 2 == 0 && b % 2 != 0) return GetGSDByValues(a / 2, b);
                if (a % 2 != 0 && b % 2 == 0) return GetGSDByValues(a, b / 2);
                if (a > b) return GetGSDByValues((a - b) / 2, b);
                return GetGSDByValues((b - a) / 2, a);
            }
        }
    }
}
