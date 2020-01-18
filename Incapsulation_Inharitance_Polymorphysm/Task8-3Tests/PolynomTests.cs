using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task8_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_3.Tests
{
    [TestClass()]
    public class PolynomTests
    {
        [TestMethod()]
        public void CreatinAndCounting()
        {
            var poly = new Polynom(new[] { new PolynomUnit(2, 1), new PolynomUnit(1, 2) });
            Assert.AreEqual(24, poly.CountResult(4));
        }

        [TestMethod()]
        public void Equaling()
        {
            var poly1 = new Polynom(new[] { new PolynomUnit(-1, 1), new PolynomUnit(2, 2) });
            var poly2 = new Polynom(new[] { new PolynomUnit(-1, 1), new PolynomUnit(2, 2) });
            Assert.AreEqual(true, poly1 == poly2 && !(poly1 != poly2));
            var poly3 = new Polynom(new[] { new PolynomUnit(1, 1), new PolynomUnit(2, 2) });
            Assert.AreEqual(false, poly1 == poly3 || poly2 == poly3);
            Assert.AreEqual(true, poly1 != poly3 && poly2 != poly3);
        }

        [TestMethod()]
        public void Adding()
        {
            var poly1 = new Polynom(new[] { new PolynomUnit(2, 1), new PolynomUnit(1, 2) });
            var poly2 = new Polynom(new[] { new PolynomUnit(-3, 1), new PolynomUnit(2, 3) });
            var poly3 = poly1 + poly2;
            Assert.AreEqual(true, poly3 == new Polynom(new[] { new PolynomUnit(-1, 1), new PolynomUnit(1, 2), new PolynomUnit(2, 3) }));
            poly3 = poly3 - poly1;
            Assert.AreEqual(true, poly2 == poly3);
        }

        [TestMethod()]
        public void Multiplying()
        {
            var poly1 = new Polynom(new[] { new PolynomUnit(1, 1) });
            var poly2 = new Polynom(new[] { new PolynomUnit(1, 1) });
            Assert.AreEqual(true, poly1 * poly2 == new Polynom(new[] { new PolynomUnit(1, 2) }));
            poly2 = new Polynom(new[] { new PolynomUnit(2, 1) , new PolynomUnit(1, 2) });
            Assert.AreEqual(true, poly1 * poly2 == new Polynom(new[] { new PolynomUnit(2, 2), new PolynomUnit(1, 3) }));
        }

        [TestMethod()]
        public void Dividing()
        {
            var poly1 = new Polynom(new[] { new PolynomUnit(1, 4), new PolynomUnit(2, 3), new PolynomUnit(2, 2), new PolynomUnit(1,1) });
            var poly2 = new Polynom(new[] { new PolynomUnit(1, 1), new PolynomUnit(1,2) });
            Assert.AreEqual(true, poly1 / poly2 == new Polynom(new[] {  new PolynomUnit(1, 0), new PolynomUnit(1, 1), new PolynomUnit(1, 2) }));
            poly1 = new Polynom(new[] { new PolynomUnit(1, 2), new PolynomUnit(8, 1) });
            poly2 = new Polynom(new[] { new PolynomUnit(1, 1), new PolynomUnit(1, 0) });
            var poly3 = poly1 / poly2;
            Assert.AreEqual(true,poly1.MOD == new Polynom(new PolynomUnit(-7, 0)));
        }
    }
}