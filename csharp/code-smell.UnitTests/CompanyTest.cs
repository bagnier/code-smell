using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class CompanyTest
    {
        private static readonly Money SOME_EURO = Money.newEuro(10);

        [Test]
        public void testWithdrawCompanyWithNormalAccount()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(false, 34);
            Customer customer = CustomerTestUtils.getCompanyCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void testWithdrawCompanyWithNormalAccountAndOverdraft()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(false, -10);
            Customer customer = CustomerTestUtils.getCompanyCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(-21.0));
        }

        [Test]
        public void testWithdrawCompanyWithPremiumAccount()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(true, 34);
            Customer customer = CustomerTestUtils.getCompanyCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void testWithdrawCompanyWithPremiumAccountAndOverdraft()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(true, -10);
            Customer customer = CustomerTestUtils.getCompanyCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(-20.25));
        }
    }
}