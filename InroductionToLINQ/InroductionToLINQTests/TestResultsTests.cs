using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InroductionToLINQ.Tests
{

    [TestClass]
    public class TestResultsTests
    {
        [TestMethod]
        public void ToStringTests()
        {
            var test = new TestResult(0,"studentA","test1",DateTime.MinValue,5);
            Assert.AreEqual($"0|studentA|test1|{DateTime.MinValue.ToString("dd.MM.yyyy")}|5", test.ToString(1,8,5,10,1,"I|S|T|D|A"));
        }
    }
}
