using NUnit.Framework;

namespace Task9_5
{
    [TestFixture]
    class Tests
    {
        [TestCase("Каждый охотник желает", ExpectedResult = "желает охотник Каждый")]
        [TestCase("Каждый", ExpectedResult = "Каждый")]
        public string SimpleTest(string input)
        {
            return Solution.ReverseAllWords(input);
        }
    }
}
