using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindMaxTask
{
    public static class MaxFinder
    {
        public static int FindMax(int[] array)
        {
            if (array == null)
                throw new NullReferenceException();
            if (array.Length == 0)
                throw new ArgumentException();
            var result = Int32.MinValue;
            result = FindMax(array,result,0);

            return result;
        }

        private static int FindMax(int[] array, int currentMax, int i)
        {
            if (i == array.Length )
                return currentMax;
            if (array[i] > currentMax)
                currentMax = array[i];

            currentMax = FindMax(array, currentMax, i + 1);
            return currentMax;
        }

    }

    public static class IBESFinder // IBES - Index Between Equals Sums (лучшее, что смог придумать вплане нейминга)
    {
        public static int? FindIEBS(double[] array)
        {
            if (array == null)
                throw new NullReferenceException();
            if (array.Length < 3)
                return null;
            var rightSumm = 0d;

            for (int counter = 1; counter < array.Length; counter++)
            {
                rightSumm += array[counter];
            }

            var leftSumm = 0d;
            int i = 1;

            for (; i < array.Length - 1; i++)
            {
                leftSumm += array[i - 1];
                rightSumm -= array[i];
                if (Math.Abs(leftSumm - rightSumm)<0.01)
                    return i;
            }

            return null;
        }
    }

    public static class Concatenator
    {
        public static string Concatenate(string firstStr, string secondStr)
        {
            if (firstStr == null || secondStr == null)
                throw new NullReferenceException();

            var result = new StringBuilder(firstStr.Length + secondStr.Length);
            result.Append(firstStr);
            var usedChars = new List<char>(firstStr.Length + secondStr.Length);

            foreach (var letter in firstStr)
            {
                if (!usedChars.Contains(letter))
                usedChars.Add(letter);
            }

            foreach (var letter in secondStr)
            {
                if (!usedChars.Contains(letter))
                {
                    result.Append(letter);
                }
            }

            return result.ToString();
        }
    }

    public static class NextBiggerFinder
    {
        public static int? FindNextBigger(int originValue)
        {
            if (originValue<=0)
                throw new ArgumentException("Значение должно быть положительным");
            int container;
            var arrayPresentation = ConvertIntToArray(originValue);
            int i = 1;
            for (; i < arrayPresentation.Length; i++)
            {
                if (arrayPresentation[i] < arrayPresentation[i - 1])
                {
                    container = arrayPresentation[i];
                    arrayPresentation[i] = arrayPresentation[i - 1];
                    arrayPresentation[i - 1] = container;
                    break;
                }
            }

            var rightPart = new int[i];
            for (int j = 0; j < i; j++)
            {
                rightPart[j] = arrayPresentation[j];
            }

            rightPart = rightPart.OrderByDescending(x => x).ToArray();

            for (int j = 0; j < i; j++)
            {
                arrayPresentation[j] = rightPart[j];
            }

            int result = 0;
            for (i = 0; i < arrayPresentation.Length; i++)
            {
                result += (int) (arrayPresentation[i] * Math.Pow(10, i ));
            }

            if (result <= originValue)
            {
                return null;
            }
            else return result;
        }

        private static int[] ConvertIntToArray(int value)
        {
            var result = new int[GetIntLenght(value)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = (int)(value / Math.Pow(10,  i ));
                value %= (int)Math.Pow(10, i);
            }

            return result;
        }

        private static int GetIntLenght(int value)
        {
            int i = 0;
            for (; value != 0; i++)
            {
                value /= 10;
            }
            return i;
        }

        public static int? FindNextBigger(int originalValue, out long workTime)
        {
            var timer = new Stopwatch();
            timer.Start();
            var result = FindNextBigger(originalValue);
            timer.Stop();
            workTime = timer.ElapsedMilliseconds;
            return result;
        }
    }

    public static class DigitFilter
    {
        public static int[] FilterByDigitContainment(int[] array, byte digit)
        {
            var result = new List<int>(array.Length);
            foreach (var number in array)
            {
                if (CheckContainment(number, digit))
                    result.Add(number);
            }

            return result.ToArray();
        }

        private static bool CheckContainment(int number, byte digit)
        {
            return (number.ToString().Contains(digit.ToString()));
        }
    }
}
