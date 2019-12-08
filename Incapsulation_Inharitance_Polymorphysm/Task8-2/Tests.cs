using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task8_2
{
    [TestFixture]
    class Tests
    {
        [TestCase(ExpectedResult = true)]
        public bool TriangleTest()
        {
            var triangle = new Triangle(3, 4, Math.PI/2);
            Assert.AreEqual(5, triangle.CLenght);
            triangle.ABAngle = Math.PI / 3;
            triangle.BLenght = 3;
            Assert.AreEqual(3, triangle.CLenght, 0.0001);
            return true;
        }
    }
}
