using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class CustomerReportTest
    {
        [Test]
        public void TestPrintCustomer()
        {
            Account account = CustomerTestUtils.GetAccount(false);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.PrintCustomer(), Is.EqualTo("danix dan@mail.com"));
        }

        [Test]
        public void TestPrintCustomerAccountNormal()
        {
            Account account = CustomerTestUtils.GetAccount(false);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.PrintCustomerAccount(),
                        Is.EqualTo("Account: IBAN: RO023INGB434321431241, Money: 34.0, Account type: normal"));
        }

        [Test]
        public void TestPrintCustomerAccountPremium()
        {
            Account account = CustomerTestUtils.GetAccount(true);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.PrintCustomerAccount(),
                        Is.EqualTo("Account: IBAN: RO023INGB434321431241, Money: 34.0, Account type: premium"));
        }

        [Test]
        public void TestPrintCustomerDaysOverdrawn()
        {
            Account account = CustomerTestUtils.GetAccount(false);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.PrintCustomerDaysOverdrawn(),
                        Is.EqualTo("danix dan Account: IBAN: RO023INGB434321431241, Days Overdrawn: 9"));
        }

        [Test]
        public void TestPrintCustomerMoney()
        {
            Account account = CustomerTestUtils.GetAccount(false);
            Customer customer = CustomerTestUtils.GetPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.PrintCustomerMoney(),
                        Is.EqualTo("danix dan Account: IBAN: RO023INGB434321431241, Money: 34.0"));
        }
    }
}