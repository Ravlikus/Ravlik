using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task12_1
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void BinarySearchFunctionalTest()
        {
            var rnd = new Random();
            var comparer = Comparer<int>.Create(new Comparison<int>((a, b) => a - b));
            for (int i = 0; i < 10000; i++)
            {
                var elementsCount = rnd.Next(1, 10000);
                var neededPosition = rnd.Next(1, elementsCount);
                var neededValue = rnd.Next(1, int.MaxValue / 2);
                var input = new List<int>();
                for (int j = 0; j < elementsCount; j++)
                {
                    if (j < neededPosition) input.Add(rnd.Next(neededValue));
                    else if (j > neededPosition) input.Add(rnd.Next(neededValue, int.MaxValue));
                    else input.Add(neededValue);
                }
                input.Sort();
                Assert.AreEqual(neededPosition, Solution.FindElement(input.ToArray(), neededValue, comparer));
            }
        }
    }
}
