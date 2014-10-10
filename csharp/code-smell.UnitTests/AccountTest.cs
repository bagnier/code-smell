using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class AccountTest
    {
        [SetUp]
        public void SetUp()
        {
            _customerFactory = new CustomerFactory();
        }

        private CustomerFactory _customerFactory;

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
        public void TestBankchargePremiumLessThanAWeek()
        {
            Account account = getPremiumAccount(5);
            Assert.That(account.Bankcharge(), Is.EqualTo(14.5))
                ;
        }

        [Test]
        public void TestBankchargePremiumMoreThanAWeek()
        {
            Account account = getPremiumAccount(9);
            Assert.That(account.Bankcharge(), Is.EqualTo(16.5))
                ;
        }

        [Test]
        public void TestOverdraftFeeNotPremium()
        {
            Account account = getNormalAccount();
            Assert.That(account.OverdraftFee(), Is.EqualTo(0.20))
                ;
        }

        [Test]
        public void TestOverdraftFeePremium()
        {
            Account account = getPremiumAccount(9);
            Assert.That(account.OverdraftFee(), Is.EqualTo(0.10))
                ;
        }
    }
}