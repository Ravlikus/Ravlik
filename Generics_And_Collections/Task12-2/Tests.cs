using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task12_2
{
    [TestFixture]
    public class Tests
    {
        [TestCase(ExpectedResult = true)]
        public bool SimpleTest()
        {
            var input = "Wow! wow. WELL";
            Assert.AreEqual(2, Solution.GetWordFrequency(input)["wow"]);
            return true;
        }
    }
}
