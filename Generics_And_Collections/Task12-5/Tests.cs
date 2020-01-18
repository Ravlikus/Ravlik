using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_5
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTest()
        {
            var stack = new Solution.Stack<int>();
            Assert.AreEqual(0, stack.Count);
            stack.Push(0);
            stack.Push(1);
            stack.Push(2);
            Assert.AreEqual(3, stack.Count);
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
            Assert.AreEqual(1, stack.Count);
            stack.Clear();
            Assert.AreEqual(0, stack.Count);
        }
    }
}
