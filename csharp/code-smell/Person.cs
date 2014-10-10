using System;

namespace code_smell
{
    public class Person : Customer
    {
        protected String surname;

        public Person(String name, String surname, String email, Account account) : base(name, email, account)
        {
            this.surname = surname;
        }

        public override void withdraw(Money money)
        {
            if (account.getAccountType().isPremium())
            {
                if (account.isOverdraft())
                {
                    account.substract(Money.newInstance(money.getAmount() + money.getAmount()*account.overdraftFee(),
                                                        money.getCurrency()));
                }
                else
                {
                    account.substract(Money.newInstance(money.getAmount(), money.getCurrency()));
                }
            }
            else
            {
                if (account.isOverdraft())
                {
                    account.substract(Money.newInstance(money.getAmount() + money.getAmount()*account.overdraftFee(),
                                                        money.getCurrency()));
                }
                else
                {
                    account.substract(Money.newInstance(money.getAmount(), money.getCurrency()));
                }
            }
        }

        internal override String getFullName()
        {
            return name + " " + surname + " ";
        }
    }
}