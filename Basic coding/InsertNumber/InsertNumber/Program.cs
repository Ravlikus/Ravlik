using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumberInserter.InsertNumber(8,15,3,8));
            Console.ReadKey();
        }
    }

    public static class NumberInserter
    {
        public static int InsertNumber(int first, int second, byte i, byte j)
        {
            if (j < i) throw new ArgumentException();
            var firstBinaryArray = convertIntToBinaryArray(first);
            var secondBinaryArray = convertIntToBinaryArray(second);
            var resultBinaryArray = new int[getBinaryLenght(first) + getBinaryLenght(second)];
            var firstCounter = 0;
            var resultCounter = 0;

            for (; firstCounter < i; ++firstCounter , resultCounter++)
            {
                resultBinaryArray[resultCounter] = firstBinaryArray[firstCounter];
            }

            firstCounter = j + 1;

            for (var secondCounter = 0; secondCounter < secondBinaryArray.Length && resultCounter<=j; secondCounter++, resultCounter++)
            {
                resultBinaryArray[resultCounter] = secondBinaryArray[secondCounter];
            }

            for (; firstCounter < firstBinaryArray.Length; firstCounter++, resultCounter++)
            {
                resultBinaryArray[resultCounter] = firstBinaryArray[firstCounter];
            }

            var result = 0;
            for (resultCounter = 0; resultCounter < resultBinaryArray.Length; resultCounter++)
            {
                result += resultBinaryArray[resultCounter]*CustomPower(2, resultCounter);
            }

            return result;

        }

        private static int[] convertIntToBinaryArray(int value)
        {
            var result = new int[getBinaryLenght(value)];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = value / CustomPower(2, i);
                value %= CustomPower(2, i);
            }

            return result;
        }

        public static int CustomPower(int value, int power)
        {
            if (power == 0)
                return 1;
            int result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= value;
            }

            return result;
        }

        private static int getBinaryLenght(int value)
        {
            var result = 0;
            while (value != 0)
            {
                result++;
                value /= 2;
            }

            return result;
        }
    }
}
