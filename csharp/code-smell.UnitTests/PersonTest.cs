using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class PersonTest
    {
        public static Money SomeEuro = Money.newEuro(10);

        [Test]
        public void TestWithdrawPersonWithNormalAccount()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(false, 34.0);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void TestWithdrawPersonWithNormalAccountAndOverdraft()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(false, -10.0);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(-22.0));
        }

        [Test]
        public void TestWithdrawPersonWithPremiumAccount()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(true, 34.0);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void TestWithdrawPersonWithPremiumAccountAndOverdraft()
        {
            Account account = AccountTestUtils.GetAccountByTypeAndMoney(true, -10.0);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            customer.Withdraw(SomeEuro);
            Assert.That(account.GetMoneyAmount(), Is.EqualTo(-21.0));
        }
    }
}