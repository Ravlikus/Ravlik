using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12_8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_8.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void CountTest()
        {
            Assert.AreEqual(14, Calculator.Count("5 1 2 + 4 * + 3 -"));
        }
    }
}