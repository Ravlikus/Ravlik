using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MethodsSol
{

    [TestFixture]
    public class DoubleExtentionsTests
    {
        [TestCase(-255.255, ExpectedResult = "1100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(255.255, ExpectedResult = "0100000001101111111010000010100011110101110000101000111101011100")]
        [TestCase(4294967295.0, ExpectedResult = "0100000111101111111111111111111111111111111000000000000000000101")]
        [TestCase(0.5, ExpectedResult = "0011111111100000000000000000000000000000000000000000000000000001")]
        [TestCase(double.MinValue, ExpectedResult = "1111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.MaxValue, ExpectedResult = "0111111111101111111111111111111111111111111111111111111111111111")]
        [TestCase(double.Epsilon, ExpectedResult = "0000000000000000000000000000000000000000000000000000000000000001")]
        [TestCase(double.PositiveInfinity, ExpectedResult = "Positive Infinity")]
        [TestCase(double.NegativeInfinity, ExpectedResult = "Negative Infinity")]
        public static string SimpleTest(Double input)
        {
            return input.ToBinaryString();
        }
    }
}
