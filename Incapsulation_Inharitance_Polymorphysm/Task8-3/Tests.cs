using NUnit.Framework;

namespace Task8_3
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void CreatinAndCounting()
        {
            var poly = new Polynom(new[] { 2.0, 1.0 });
            Assert.AreEqual(24, poly.CountResult(4));
        }

        [TestCase]
        public void Equaling()
        {
            var poly1 = new Polynom(new[] { -1.0, 2.0 });
            var poly2 = new Polynom(new[] { -1.0, 2.0 });
            Assert.AreEqual(true, poly1 == poly2 && !(poly1 != poly2));
            var poly3 = new Polynom(new[] { 1.0, 2.0 });
            Assert.AreEqual(false, poly1 == poly3 || poly2 == poly3);
            Assert.AreEqual(true, poly1 != poly3 && poly2 != poly3);
        }

        [TestCase]
        public void Adding()
        {
            var poly1 = new Polynom(new[] { 2.0, 1.0 });
            var poly2 = new Polynom(new[] { -3.0, 0.0, 2.0 });
            var poly3 = poly1 + poly2;
            Assert.AreEqual(true, poly3 == new Polynom(new[] { -1.0, 1.0, 2.0 }));
            poly3 = poly3 - poly1;
            Assert.AreEqual(true, poly2 == poly3);
        }
    }
}
