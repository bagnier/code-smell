using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class PersonTest
    {
        public static Money SOME_EURO = Money.newEuro(10);

        [Test]
        public void testWithdrawPersonWithNormalAccount()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(false, 34.0);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void testWithdrawPersonWithNormalAccountAndOverdraft()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(false, -10.0);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(-22.0));
        }

        [Test]
        public void testWithdrawPersonWithPremiumAccount()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(true, 34.0);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(24.0));
        }

        [Test]
        public void testWithdrawPersonWithPremiumAccountAndOverdraft()
        {
            Account account = AccountTestUtils.getAccountByTypeAndMoney(true, -10.0);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            customer.withdraw(SOME_EURO);
            Assert.That(account.getMoneyAmount(), Is.EqualTo(-21.0));
        }
    }
}