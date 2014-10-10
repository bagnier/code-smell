using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class MoneyTest
    {
        [Test]
        public void testSubstract()
        {
            Money difference = Money.newEuro(20.0).substract(Money.newEuro(10.0));
            Assert.That(difference.getAmount(), Is.EqualTo(10.0));
            Assert.That(difference.getCurrency(), Is.EqualTo(Money.EUR_CURRENCY));
        }

        [Test]
        [ExpectedException]
        public void testSubstractDifferentCurrencies()
        {
            Money.newEuro(20.0).substract(Money.newInstance(10.0, "USD"));
        }

        [Test]
        public void testSubstractNegative()
        {
            Money difference = Money.newEuro(20.0).substract(Money.newEuro(100.0));
            Assert.That(difference.getAmount(), Is.EqualTo(-80.0));
            Assert.That(difference.getCurrency(), Is.EqualTo(Money.EUR_CURRENCY));
        }
    }
}