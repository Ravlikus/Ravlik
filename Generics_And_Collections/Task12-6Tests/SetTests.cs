using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task12_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_6.Tests
{
    [TestClass()]
    public class SetTests
    {
        Set<int> set = new Set<int>();
        [TestMethod()]
        public void AddAndContainTest()
        {
            set.Add(1);
            Assert.AreEqual(true, set.Contain(1));
            set.Add(10);
            set.Add(37);
            set.Add(8);
            set.Add(6);
            set.Add(-2);
            Assert.AreEqual(true, set.Contain(1));
            Assert.AreEqual(true, set.Contain(10));
            Assert.AreEqual(true, set.Contain(37));
            Assert.AreEqual(true, set.Contain(8));
            Assert.AreEqual(true, set.Contain(6));
            Assert.AreEqual(true, set.Contain(-2));
        }


        [TestMethod()]
        public void ClearTest()
        {
            set.Add(10);
            set.Add(37);
            set.Add(8);
            set.Add(6);
            set.Add(-2);
            set.Clear();
            Assert.AreEqual(false, set.Contain(10));           
        }

        [TestMethod()]
        public void RemoveTest()
        {
            set.Add(10);
            set.Add(37);
            set.Add(8);
            set.Add(6);
            set.Add(-2);
            Assert.AreEqual(true, set.Contain(37));
            set.Remove(37);
            Assert.AreEqual(false, set.Contain(37));
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            var values = new[] { 1, 2, 3, 4, 5 };
            foreach(var value in values)
            {
                set.Add(value);
            }

            foreach(var value in set)
            {
                Assert.AreEqual(true, values.Contains(value));
            }
        }
    }
}