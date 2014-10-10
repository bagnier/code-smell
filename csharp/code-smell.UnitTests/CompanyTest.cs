using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class CompanyTest
    {
        private static readonly Money SomeEuro = Money.newEuro(10);

        [Test]
        public void TestWithdrawCompanyWithNormalAccount()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(false, 34);
            Customer customer = CustomerTestUtils.GetCompanyCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void TestWithdrawCompanyWithNormalAccountAndOverdraft()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(false, -10);
            Customer customer = CustomerTestUtils.GetCompanyCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(-21.0));
        }

        [Test]
        public void TestWithdrawCompanyWithPremiumAccount()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(true, 34);
            Customer customer = CustomerTestUtils.GetCompanyCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void TestWithdrawCompanyWithPremiumAccountAndOverdraft()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(true, -10);
            Customer customer = CustomerTestUtils.GetCompanyCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(-20.25));
        }
    }
}