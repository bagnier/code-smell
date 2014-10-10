using System;

namespace code_smell
{
    public class Account
    {
        private readonly int _daysOverdrawn;
        private readonly AccountType _type;

        private Customer _customer;
        private String _iban;
        private Money _money;

        public Account(AccountType type, int daysOverdrawn)
        {
            _type = type;
            _daysOverdrawn = daysOverdrawn;
        }

        public double Bankcharge()
        {
            double result = 4.5;

            result += OverdraftCharge();

            return result;
        }

        private double OverdraftCharge()
        {
            if (_type.isPremium())
            {
                double result = 10;
                if (GetDaysOverdrawn() > 7)
                {
                    result += (GetDaysOverdrawn() - 7)*1.0;
                }

                return result;
            }
            else
            {
                return GetDaysOverdrawn()*1.75;
            }
        }

        public double OverdraftFee()
        {
            if (_type.isPremium())
            {
                return 0.10;
            }
            else
            {
                return 0.20;
            }
        }

        public int GetDaysOverdrawn()
        {
            return _daysOverdrawn;
        }

        public String GetIban()
        {
            return _iban;
        }

        public void SetIban(String iban)
        {
            _iban = iban;
        }

        public void SetMoney(Money money)
        {
            _money = money;
        }

        public Customer GetCustomer()
        {
            return _customer;
        }

        public void setCustomer(Customer customer)
        {
            _customer = customer;
        }

        public AccountType GetAccountType()
        {
            return _type;
        }

        public bool IsOverdraft()
        {
            return _money.getAmount() < 0;
        }

        public void Substract(Money money)
        {
            _money = _money.substract(money);
        }

        public double GetMoneyAmount()
        {
            return _money.getAmount();
        }
    }
}