using System;
using NUnit.Framework;

namespace Task9_6
{
    [TestFixture]
    class Tests
    {
        [TestCase("1","10", ExpectedResult = "11")]
        [TestCase("10000000000000000000", "10", ExpectedResult = "10000000000000000010")]
        [TestCase("1011588638", "627066262", ExpectedResult = "1638654900")]
        public string SimpleTest(string a, string b)
        {
            return Solution.AddBigNumbers(a, b);
        }

        [TestCase]
        public void FunctionalTest()
        {
            var rnd = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var a = rnd.Next(int.MaxValue / 2 - 1);
                var b = rnd.Next(int.MaxValue / 2 - 1);
                try { Assert.AreEqual(a + b, int.Parse(Solution.AddBigNumbers(a.ToString(), b.ToString()))); }
                catch (Exception ex) { throw new Exception($"a = {a}, b = {b}, result = {Solution.AddBigNumbers(a.ToString(), b.ToString())}"); }
            }
        }
    }
}
