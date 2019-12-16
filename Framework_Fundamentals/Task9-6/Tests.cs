using NUnit.Framework;

namespace Task9_6
{
    [TestFixture]
    class Tests
    {
        [TestCase("1","10", ExpectedResult = "11")]
        [TestCase("10000000000000000000", "10", ExpectedResult = "10000000000000000010")]
        public string SimpleTest(string a, string b)
        {
            return Solution.AddBigNumbers(a, b);
        }
    }
}
