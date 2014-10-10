using System;

namespace code_smell
{
    public abstract class Customer
    {
        protected Account account;
        protected String email;
        protected String name;

        internal Customer(String name, String email, Account account)
        {
            this.name = name;
            this.email = email;
            this.account = account;
        }

        public abstract void withdraw(Money money);

        internal abstract String getFullName();

        public String getName()
        {
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getEmail()
        {
            return email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
    }
}