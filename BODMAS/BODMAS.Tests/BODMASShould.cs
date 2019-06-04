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
        public void Calc1CorrectAnswer()
        {
            string eq = "2*4/8+1-8*22-4";
            var ans = BODMAS.BIDMAS(eq);
            Assert.That(ans, Is.EqualTo(Convert.ToDouble(-178)));
        }
        [Test]
        public void Calc2CorrectAnswer()
        {
            string eq = "25*25/3*4^2-22+46-200000+3";
            var ans = BODMAS.BIDMAS(eq);
            Assert.That(ans, Is.EqualTo(Convert.ToDouble(-196639.666666667)));
        }
        [Test]
        public void Calc3CorrectAnswer()
        {
            string eq = "4*8/-22*-78+55-22+3";
            var ans = BODMAS.BIDMAS(eq);
            Assert.That(ans, Is.EqualTo(Convert.ToDouble(149.454545454546)));
        }
        [Test]
        public void Calc4CorrectAnswer()
        {
            string eq = "0-29+-4+4";
            var ans = BODMAS.BIDMAS(eq);
            Assert.That(ans, Is.EqualTo(Convert.ToDouble(-29)));
        }
        [Test]
        public void MinCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("2+3-3-4-53-53");
            var ans = BODMAS.Min(-53, 53, 7, 12, sb);
            Assert.That(ans, Is.EqualTo("2+3-3-4-106"));
        }
        [Test]
        public void PluCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("2+3-3-4-53-53");
            var ans = BODMAS.Plu(2,3,0,2, sb);
            Assert.That(ans, Is.EqualTo("5-3-4-53-53"));
        }
        [Test]
        public void TimCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("2+3*3-4-53-53");
            var ans = BODMAS.Tim(3, 3, 2, 4, sb);
            Assert.That(ans, Is.EqualTo("2+9-4-53-53"));
        }
        [Test]
        public void DivCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("2+3/3-4-53-53");
            var ans = BODMAS.Div(3, 3, 2, 4, sb);
            Assert.That(ans, Is.EqualTo("2+1-4-53-53"));
        }
        [Test]
        public void NaoCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("1987+378");
            var ans = BODMAS.Nao(sb,8,3);
            Assert.That(ans, Is.EqualTo(378));
        }
        [Test]
        public void NboCorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("1987+378");
            var ans = BODMAS.Nbo(sb, -1, 4);
            Assert.That(ans, Is.EqualTo(1987));
        }
        [Test]
        public void Replacalc1CorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("0-29+4^8+4");
            var ans = BODMAS.Replacalc("^",6,sb);
            Assert.That(ans, Is.EqualTo("0-29+65536+4"));
        }
        [Test]
        public void Replacalc2CorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("0-29+4*8+4");
            var ans = BODMAS.Replacalc("*", 6, sb);
            Assert.That(ans, Is.EqualTo("0-29+32+4"));
        }
        [Test]
        public void Replacalc3CorrectAnswer()
        {
            StringBuilder sb = new StringBuilder("0-29+4-8+4");
            var ans = BODMAS.Replacalc("-", 6, sb);
            Assert.That(ans, Is.EqualTo("0-29+-4+4"));
        }
    }
}
