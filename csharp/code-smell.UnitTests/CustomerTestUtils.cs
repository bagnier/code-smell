namespace code_smell.UnitTests
{
    public class CustomerTestUtils
    {
        private static readonly CustomerFactory CustomerFactory = new CustomerFactory();

        public static Customer GetCompanyCustomer(Account account)
        {
            Customer customer = CustomerFactory.createCompany("company", "company@mail.com", account, 0.50);
            account.setCustomer(customer);
            return customer;
        }

        public static Customer GetPersonCustomer(Account account)
        {
            Customer customer = CustomerFactory.createPerson("danix", "dan", "dan@mail.com", account);
            account.setCustomer(customer);
            return customer;
        }

        public static Customer GetPersonWithAccount(bool premium)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.SetIban("RO023INGB434321431241");
            account.SetMoney(Money.newEuro(34.0));

            Customer customer = GetPersonCustomer(account);
            return customer;
        }

        public static Account GetAccount(bool premium)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.SetIban("RO023INGB434321431241");
            account.SetMoney(Money.newEuro(34.0));
            return account;
        }
    }
}