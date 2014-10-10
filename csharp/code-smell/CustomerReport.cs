using System;

namespace code_smell
{
    public class CustomerReport
    {
        private readonly Account _account;
        private readonly Customer _customer;

        public CustomerReport(Customer customer, Account account)
        {
            _customer = checkNotNull(customer);
            _account = checkNotNull(account);
        }

        private T checkNotNull<T>(T instance)
        {
            if (instance == null) throw new NullReferenceException();
            return instance;
        }

        public String PrintCustomerDaysOverdrawn()
        {
            String fullName = _customer.GetFullName();

            String accountDescription = "Account: IBAN: " + _account.GetIban() + ", Days Overdrawn: "
                                        + _account.GetDaysOverdrawn();
            return fullName + accountDescription;
        }

        public String PrintCustomerMoney()
        {
            String fullName = _customer.GetFullName();
            String accountDescription = "";
            accountDescription += "Account: IBAN: " + _account.GetIban() + ", Money: " +
                                  String.Format("{0:0.0}", _account.GetMoneyAmount());
            return fullName + accountDescription;
        }

        public String PrintCustomerAccount()
        {
            return "Account: IBAN: " + _account.GetIban() + ", Money: " +
                   String.Format("{0:0.0}", _account.GetMoneyAmount()) + ", Account type: "
                   + _account.GetAccountType();
        }

        public String PrintCustomer()
        {
            return _customer.GetName() + " " + _customer.GetEmail();
        }
    }
}