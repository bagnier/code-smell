namespace code_smell.UnitTests
{
    public class CustomerTestUtils
    {
        private static readonly CustomerFactory customerFactory = new CustomerFactory();

        public static Customer getCompanyCustomer(Account account)
        {
            Customer customer = customerFactory.createCompany("company", "company@mail.com", account, 0.50);
            account.setCustomer(customer);
            return customer;
        }

        public static Customer getPersonCustomer(Account account)
        {
            Customer customer = customerFactory.createPerson("danix", "dan", "dan@mail.com", account);
            account.setCustomer(customer);
            return customer;
        }

        public static Customer getPersonWithAccount(bool premium)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.setIban("RO023INGB434321431241");
            account.setMoney(Money.newEuro(34.0));

            Customer customer = getPersonCustomer(account);
            return customer;
        }

        public static Account getAccount(bool premium)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.setIban("RO023INGB434321431241");
            account.setMoney(Money.newEuro(34.0));
            return account;
        }
    }
}