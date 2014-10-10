using System;

namespace code_smell
{
    public class Account
    {
        private readonly int daysOverdrawn;
        private readonly AccountType type;

        private Customer customer;
        private String iban;
        private Money money;

        public Account(AccountType type, int daysOverdrawn)
        {
            this.type = type;
            this.daysOverdrawn = daysOverdrawn;
        }

        public double bankcharge()
        {
            double result = 4.5;

            result += overdraftCharge();

            return result;
        }

        private double overdraftCharge()
        {
            if (type.isPremium())
            {
                double result = 10;
                if (getDaysOverdrawn() > 7)
                {
                    result += (getDaysOverdrawn() - 7)*1.0;
                }

                return result;
            }
            else
            {
                return getDaysOverdrawn()*1.75;
            }
        }

        public double overdraftFee()
        {
            if (type.isPremium())
            {
                return 0.10;
            }
            else
            {
                return 0.20;
            }
        }

        public int getDaysOverdrawn()
        {
            return daysOverdrawn;
        }

        public String getIban()
        {
            return iban;
        }

        public void setIban(String iban)
        {
            this.iban = iban;
        }

        public void setMoney(Money money)
        {
            this.money = money;
        }

        public Customer getCustomer()
        {
            return customer;
        }

        public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }

        public AccountType getAccountType()
        {
            return type;
        }

        public bool isOverdraft()
        {
            return money.getAmount() < 0;
        }

        public void substract(Money money)
        {
            this.money = this.money.substract(money);
        }

        public double getMoneyAmount()
        {
            return money.getAmount();
        }
    }
}