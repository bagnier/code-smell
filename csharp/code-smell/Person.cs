using System;

namespace code_smell
{
    public class Person : Customer
    {
        protected String Surname;

        public Person(String name, String surname, String email, Account account) : base(name, email, account)
        {
            Surname = surname;
        }

        public override void Withdraw(Money money)
        {
            if (Account.GetAccountType().isPremium())
            {
                if (Account.IsOverdraft())
                {
                    Account.Substract(Money.newInstance(money.getAmount() + money.getAmount()*Account.OverdraftFee(),
                                                        money.getCurrency()));
                }
                else
                {
                    Account.Substract(Money.newInstance(money.getAmount(), money.getCurrency()));
                }
            }
            else
            {
                if (Account.IsOverdraft())
                {
                    Account.Substract(Money.newInstance(money.getAmount() + money.getAmount()*Account.OverdraftFee(),
                                                        money.getCurrency()));
                }
                else
                {
                    Account.Substract(Money.newInstance(money.getAmount(), money.getCurrency()));
                }
            }
        }

        internal override String GetFullName()
        {
            return Name + " " + Surname + " ";
        }
    }
}