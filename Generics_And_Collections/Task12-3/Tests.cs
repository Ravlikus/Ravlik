using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_3
{
    [TestFixture]
    public class Tests
    {
        [TestCase()]
        public void SimpleTest()
        {
            var expected = new[] { 1, 1, 2, 3, 5, 8, 13, 21 };
            var result = Solution.GetFibbonacciNumbers(expected.Length).ToArray();
            for(int i = 0; i<result.Length; i++)
            {
                Assert.AreEqual(expected[i], result[i]);
            }
        }
    }
}
