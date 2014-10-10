using System;

namespace code_smell
{
    public class Company : Customer
    {
        protected double companyOverdraftDiscount = 1;

        public Company(String name, String email, Account account, double companyOverdraftDiscount)
            : base(name, email, account)
        {
            this.companyOverdraftDiscount = companyOverdraftDiscount;
        }

        public override void withdraw(Money money)
        {
            if (account.getAccountType().isPremium())
            {
                if (account.isOverdraft())
                {
                    // 50 percent discount for overdraft for premium account
                    account.substract(Money.newInstance(
                        money.getAmount() + money.getAmount()*account.overdraftFee()*companyOverdraftDiscount/2,
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
                    // no discount for overdraft for not premium account
                    account.substract(Money.newInstance(
                        money.getAmount() + money.getAmount()*account.overdraftFee()*companyOverdraftDiscount,
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
            return name;
        }
    }
}