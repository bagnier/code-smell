using System;

namespace code_smell
{
    public abstract class Customer
    {
        protected Account Account;
        protected String Email;
        protected String Name;

        internal Customer(String name, String email, Account account)
        {
            this.Name = name;
            this.Email = email;
            this.Account = account;
        }

        public abstract void Withdraw(Money money);

        internal abstract String GetFullName();

        public String GetName()
        {
            return Name;
        }

        public void SetName(String name)
        {
            this.Name = name;
        }

        public String GetEmail()
        {
            return Email;
        }

        public void SetEmail(String email)
        {
            this.Email = email;
        }
    }
}