﻿using NUnit.Framework;

namespace Task9_2
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTest()
        {
            var result = Solution.ToTitleCase("A long journey with an UNEXPECTABLE ending from the greatest Author", "a an the from");
            Assert.AreEqual("A Long Journey With an Unexpectable Ending from the Greatest Author", result);
            result = Solution.ToTitleCase( "A long journey with an UNEXPECTABLE ending from the greatest Author");
            Assert.AreEqual("A Long Journey With an Unexpectable Ending from the Greatest Author", result);
            Assert.AreEqual("", Solution.ToTitleCase("", ""));
            Assert.AreEqual("Brave", Solution.ToTitleCase( "Brave",""));
        }
    }
}
