using NUnit.Framework;

namespace code_smell.UnitTests
{
    [TestFixture]
    public class CustomerReportTest
    {
        [Test]
        public void testPrintCustomer()
        {
            Account account = CustomerTestUtils.getAccount(false);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.printCustomer(), Is.EqualTo("danix dan@mail.com"));
        }

        [Test]
        public void testPrintCustomerAccountNormal()
        {
            Account account = CustomerTestUtils.getAccount(false);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.printCustomerAccount(),
                        Is.EqualTo("Account: IBAN: RO023INGB434321431241, Money: 34.0, Account type: normal"));
        }

        [Test]
        public void testPrintCustomerAccountPremium()
        {
            Account account = CustomerTestUtils.getAccount(true);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.printCustomerAccount(),
                        Is.EqualTo("Account: IBAN: RO023INGB434321431241, Money: 34.0, Account type: premium"));
        }

        [Test]
        public void testPrintCustomerDaysOverdrawn()
        {
            Account account = CustomerTestUtils.getAccount(false);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.printCustomerDaysOverdrawn(),
                        Is.EqualTo("danix dan Account: IBAN: RO023INGB434321431241, Days Overdrawn: 9"));
        }

        [Test]
        public void testPrintCustomerMoney()
        {
            Account account = CustomerTestUtils.getAccount(false);
            Customer customer = CustomerTestUtils.getPersonCustomer(account);
            var customerReport = new CustomerReport(customer, account);
            Assert.That(customerReport.printCustomerMoney(),
                        Is.EqualTo("danix dan Account: IBAN: RO023INGB434321431241, Money: 34.0"));
        }
    }
}