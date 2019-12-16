using System.Collections.Generic;
using NUnit.Framework;

namespace Task9_4
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTests()
        {
            var s = new List<char>() { '1', '1', '2', '2', '3', '3' };
            Assert.AreEqual(new List<char>() { '1', '2', '3' }, Solution<char>.GetUniqueInOrder<List<char>>(s));
            var str = "sssssAAacCCBBBb";;
            Assert.AreEqual("sAacCBb", Solution<char>.GetUniqueInOrder<string>(str));
        }
    }
}
