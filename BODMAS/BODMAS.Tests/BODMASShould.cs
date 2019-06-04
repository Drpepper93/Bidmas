using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BODMAS.Tests
{
    [TestFixture]
    class BODMASShould
    {
        [Test]
        public void CalcCorrectAnswer()
        {
            string eq = "2*4/8+1-8*22-4";
            var ans = BODMAS.BIDMAS(eq);
            Assert.That(ans, Is.EqualTo(Convert.ToDouble(-178)));

            string eq2 = "25*25/3*4^2-22+46-200000+3";
            var ans2 = BODMAS.BIDMAS(eq2);
            Assert.That(ans2, Is.EqualTo(Convert.ToDouble(-196639.666666667)));

            string eq3 = "4*8/-22*-78+55-22+3";
            var ans3 =BODMAS.BIDMAS(eq3);
            Assert.That(ans3, Is.EqualTo(Convert.ToDouble(149.454545454546)));
        }
    }
}
