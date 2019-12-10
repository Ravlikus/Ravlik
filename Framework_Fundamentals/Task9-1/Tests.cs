using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task9_1
{
    [TestFixture]
    class Tests
    {
        [TestCase]
        public void SimpleTest()
        {
            var jefrey = new Person() { Name = "Jefrey Richter", PhoneNumber = "+12345678900", Revenue=1000000}; //God bless Jefrey
            var culture = new CultureInfo("");
            var phoneFormat = "pp(ppp)ppp-pppp";
            var outFormat = "Customer record: {n}, {p}, {r}";
            var s = jefrey.ToString(outFormat, phoneFormat, culture);
        }
    }
}
