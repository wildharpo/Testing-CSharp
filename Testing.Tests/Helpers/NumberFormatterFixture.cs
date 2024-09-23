using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Client.Helpers;

namespace Testing.Tests.Helpers
{
    [TestClass]
    public class NumberFormatterFixture
    {
        [TestMethod]
        public void TestHyphensAreRemoved()
        {
            var numberFormatter = new NumberFormatter();
            Assert.AreEqual(14174397795, numberFormatter.GetFormattedNumber("417-439-7795"));
        }
    }
}
