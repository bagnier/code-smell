using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class AccountTest
    {
        [SetUp]
        public void setUp()
        {
            customerFactory = new CustomerFactory();
        }

        private CustomerFactory customerFactory;

        private Account getNormalAccount()
        {
            var premium = new AccountType(false);
            return new Account(premium, 9);
        }

        private Account getPremiumAccount(int daysOverdrawn)
        {
            var normal = new AccountType(true);
            return new Account(normal, daysOverdrawn);
        }

        [Test]
        public void testBankchargePremiumLessThanAWeek()
        {
            Account account = getPremiumAccount(5);
            Assert.That(account.bankcharge(), Is.EqualTo(14.5))
                ;
        }

        [Test]
        public void testBankchargePremiumMoreThanAWeek()
        {
            Account account = getPremiumAccount(9);
            Assert.That(account.bankcharge(), Is.EqualTo(16.5))
                ;
        }

        [Test]
        public void testOverdraftFeeNotPremium()
        {
            Account account = getNormalAccount();
            Assert.That(account.overdraftFee(), Is.EqualTo(0.20))
                ;
        }

        [Test]
        public void testOverdraftFeePremium()
        {
            Account account = getPremiumAccount(9);
            Assert.That(account.overdraftFee(), Is.EqualTo(0.10))
                ;
        }
    }
}