using NUnit.Framework;

namespace Task9_3
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTests()
        {
            Assert.AreEqual("www.Example.com?key=value", Solution.AddOrChangeURLParameters("www.Example.com", "key=value"));
            Assert.AreEqual("www.Example.com?key1=value&key2=value", Solution.AddOrChangeURLParameters("www.Example.com?key1=value", "key2=value"));
            Assert.AreEqual("www.Example.com?key1=newValue", Solution.AddOrChangeURLParameters("www.Example.com?key1=value", "key1=newValue"));
        }
    }
}
