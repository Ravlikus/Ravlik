using System;
using System.Linq;
using NUnit.Framework;

namespace Task11_1
{
    [TestFixture]
    public class SolutionTests
    {
        [TestCase(4, 6, ExpectedResult = 2 )]
        [TestCase(4, 6, 8, ExpectedResult = 2)]
        [TestCase(8, 8, 8, ExpectedResult = 8)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        [TestCase(-4, 6, 8, ExpectedResult = 2)]
        [TestCase(15, 18, 10, 5, ExpectedResult = 1)]
        [TestCase(516, 1002, 903, 240, 5904, 6010101, 882, 6873, 2001, 20001, 4010202, 666, ExpectedResult = 3)]
        public int EuclidianAlgSimpleTests(params int[] values)
        {
            return Solution.EuclidianGCDFinder.FindGSD(values);
        }

        [TestCase(4, 6, ExpectedResult = 2)]
        [TestCase(4, 6, 8, ExpectedResult = 2)]
        [TestCase(8, 8, 8, ExpectedResult = 8)]
        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(0, 0, 1, ExpectedResult = 1)]
        [TestCase(-4, 6, 8, ExpectedResult = 2)]
        [TestCase(15, 18, 10, 5, ExpectedResult = 1)]
        [TestCase(516, 1002, 903, 240, 5904, 6010101, 882, 6873, 2001, 20001, 4010202, 666, ExpectedResult = 3)]
        public int SteinsAlgSimpleTests(params int[] values)
        {
            return Solution.SteinGCDFinder.FindGSD(values);
        }

        // Тесты снизу очень медленные, на моей машине 100 итераций занимают около 1-2 минут

        [TestCase]
        public void EuclidianFunctionalTest()
        {
            var rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                var inputs = new int[rnd.Next(2,10)];
                var result = rnd.Next(1000);
                for(int j = 0; j<inputs.Length; j++)
                {
                    inputs[j] = result * rnd.Next(int.MaxValue / result - 1);
                }
                try { Assert.AreEqual(0, Solution.EuclidianGCDFinder.FindGSD(inputs)%result); }
                catch (Exception ex){ throw new Exception($"{ex.Message} result: {result}; inputs: {inputs.Select(x => x.ToString()).Aggregate((a, b) => $"{a} {b}")}"); }
            }
        }

        [TestCase]
        public void SteinsAlgFunctionalTest()
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var inputs = new int[rnd.Next(2, 10)];
                var result = rnd.Next(1000);
                for (int j = 0; j < inputs.Length; j++)
                {
                    inputs[j] = result * rnd.Next(int.MaxValue / result - 1);
                }
                try { Assert.AreEqual(0, Solution.SteinGCDFinder.FindGSD(inputs) % result); }
                catch (Exception ex) { throw new Exception($"{ex.Message} result: {result}; inputs: {inputs.Select(x => x.ToString()).Aggregate((a, b) => $"{a} {b}")}"); }
            }
        }
    }
}
