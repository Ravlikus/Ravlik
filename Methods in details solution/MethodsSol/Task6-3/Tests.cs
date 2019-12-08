using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Task6_3
{
    [TestFixture]
    public class NulleableExtentionsTests
    {
        [TestCase(15, ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public static bool SimpleIntTest(int? s)
        {
             return s.IsNull();
        }

        [TestCase(15.0, ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public static bool SimpleDoubleTest(double? s)
        {
            return s.IsNull();
        }

        [TestCase("Kate", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = true)]
        public static bool SimpleStrTest(string s)
        {
            return s.IsNull();
        }
    }
}
