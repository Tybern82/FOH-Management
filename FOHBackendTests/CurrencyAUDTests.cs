using NUnit.Framework;
using FOHBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOHBackend.Tests {
    [TestFixture()]
    public class CurrencyAUDTests {
        [Test()]
        public void ParseTest() {
            string[] testStrings = new string[] {"$0", "$0.00", "$-0.00", "$0.15", "$12", "$12.62", " $12.62 " };
            foreach (string s in testStrings) {
                Assert.NotNull(CurrencyAUD.Parse(s), "Failed to parse [" + s + "]");
                CurrencyAUD c = (CurrencyAUD)s;
                Assert.NotNull(c, "Failed to parse [" + s + "]");
            }
            string[] failStrings = new string[] { "0", "0.00", "-$0.00", "$.15", "$12.", "$12.0", "$ 0.00" };
            foreach (string s in failStrings) Assert.Null(CurrencyAUD.Parse(s), "Incorrectly parsed :[" + s + "]");
            Assert.AreEqual(new CurrencyAUD(12, 62), CurrencyAUD.Parse("$12.62"));
            Assert.AreEqual(new CurrencyAUD(-1262), CurrencyAUD.Parse("$-12.62"));

            for (int x = 0; x < 100000; x++) {
                CurrencyAUD c = new CurrencyAUD(x);
                CurrencyAUD cneg = new CurrencyAUD(-x);
                string cstr = c.ToString();
                string cnegstr = cneg.ToString();
                Assert.AreEqual(c, CurrencyAUD.Parse(cstr));
                Assert.AreEqual(cneg, CurrencyAUD.Parse(cnegstr));
            }

            Random r = new Random(DateTime.Now.Millisecond);
            for (int x = 0; x < 1000; x++) {
                long val = r.Next(int.MinValue, int.MaxValue);
                CurrencyAUD c = val;
                string cstr = c.ToString();
                CurrencyAUD c2 = (CurrencyAUD)cstr;
                Console.WriteLine("Value [" + val + "] - [" + cstr + "]");
                Assert.AreEqual(c, c2);
            }
        }
    }
}