using System;

namespace code_smell
{
    public class CustomerReport
    {
        private readonly Account account;
        private readonly Customer customer;

        public CustomerReport(Customer customer, Account account)
        {
            this.customer = checkNotNull(customer);
            this.account = checkNotNull(account);
        }

        private T checkNotNull<T>(T instance)
        {
            if (instance == null) throw new NullReferenceException();
            return instance;
        }

        public String printCustomerDaysOverdrawn()
        {
            String fullName = customer.getFullName();

            String accountDescription = "Account: IBAN: " + account.getIban() + ", Days Overdrawn: "
                                        + account.getDaysOverdrawn();
            return fullName + accountDescription;
        }

        public String printCustomerMoney()
        {
            String fullName = customer.getFullName();
            String accountDescription = "";
            accountDescription += "Account: IBAN: " + account.getIban() + ", Money: " +
                                  String.Format("{0:0.0}", account.getMoneyAmount());
            return fullName + accountDescription;
        }

        public String printCustomerAccount()
        {
            return "Account: IBAN: " + account.getIban() + ", Money: " +
                   String.Format("{0:0.0}", account.getMoneyAmount()) + ", Account type: "
                   + account.getAccountType();
        }

        public String printCustomer()
        {
            return customer.getName() + " " + customer.getEmail();
        }
    }
}