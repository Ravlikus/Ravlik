using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_4
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTest()
        {
            var queue = new Solution.Queue<int>();
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue(0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.AreEqual(3, queue.Count);
            Assert.AreEqual(0, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(1, queue.Count);
            queue.Clear();
            Assert.AreEqual(0, queue.Count);
        }
    }
}
