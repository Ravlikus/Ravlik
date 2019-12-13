using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task9_2
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTest()
        {
            var result = Solution.ToTitleCase("a an the from", "A long journey with an UNEXPECTABLE ending from the greatest Author");
            Assert.AreEqual("A Long Journey With an Unexpectable Ending from the Greatest Author", result);
            Assert.AreEqual("", Solution.ToTitleCase("", ""));
            Assert.AreEqual("Brave", Solution.ToTitleCase("", "Brave"));
        }
    }
}
