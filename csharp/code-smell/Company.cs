using System;

namespace code_smell
{
    public class Company : Customer
    {
        protected double CompanyOverdraftDiscount = 1;

        public Company(String name, String email, Account account, double companyOverdraftDiscount)
            : base(name, email, account)
        {
            CompanyOverdraftDiscount = companyOverdraftDiscount;
        }

        public override void Withdraw(Money money)
        {
            if (Account.GetAccountType().isPremium())
            {
                if (Account.IsOverdraft())
                {
                    // 50 percent discount for overdraft for premium account
                    Account.Substract(Money.newInstance(
                        money.getAmount() + money.getAmount()*Account.OverdraftFee()*CompanyOverdraftDiscount/2,
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
                    // no discount for overdraft for not premium account
                    Account.Substract(Money.newInstance(
                        money.getAmount() + money.getAmount()*Account.OverdraftFee()*CompanyOverdraftDiscount,
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
            return Name;
        }
    }
}