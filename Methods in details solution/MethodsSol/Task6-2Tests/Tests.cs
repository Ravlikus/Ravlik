using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task6_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_2.Tests
{
    [TestClass()]
    public class SolutionTests
    {
        [TestMethod()]
        public void EuclidianAlgSimpleTests()
        {
            Assert.AreEqual(2,EuclidianGCDFinder.FindGCD(4,6));
            Assert.AreEqual(2, EuclidianGCDFinder.FindGCD(4, 6, 8));
            Assert.AreEqual(8, EuclidianGCDFinder.FindGCD(8, 8, 8));
            Assert.AreEqual(0, EuclidianGCDFinder.FindGCD(0, 0, 0));
            Assert.AreEqual(1, EuclidianGCDFinder.FindGCD(0, 0, 1));
            Assert.AreEqual(2, EuclidianGCDFinder.FindGCD(-4, 6, 8));
            Assert.AreEqual(1, EuclidianGCDFinder.FindGCD(15, 18, 10, 5));
            Assert.AreEqual(3, EuclidianGCDFinder.FindGCD(516, 1002, 903, 240, 5904, 6010101, 882, 6873, 2001, 20001, 4010202, 666));
        }

        [TestMethod()]
        public void SteinsAlgSimpleTests()
        {
            Assert.AreEqual(2, SteinGCDFinder.FindGCD(4, 6));
            Assert.AreEqual(2, SteinGCDFinder.FindGCD(4, 6, 8));
            Assert.AreEqual(8, SteinGCDFinder.FindGCD(8, 8, 8));
            Assert.AreEqual(0, SteinGCDFinder.FindGCD(0, 0, 0));
            Assert.AreEqual(1, SteinGCDFinder.FindGCD(0, 0, 1));
            Assert.AreEqual(2, SteinGCDFinder.FindGCD(-4, 6, 8));
            Assert.AreEqual(1, SteinGCDFinder.FindGCD(15, 18, 10, 5));
            Assert.AreEqual(3, EuclidianGCDFinder.FindGCD(516, 1002, 903, 240, 5904, 6010101, 882, 6873, 2001, 20001, 4010202, 666));
        }
    }
}