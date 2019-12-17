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
        public int SteinsAlgSimpleTests(params int[] values)
        {
            return Solution.SteinGCDFinder.FindGSD(values);
        }
    }
}
