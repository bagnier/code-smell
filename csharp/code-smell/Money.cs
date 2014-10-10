using System;

namespace code_smell
{
    public class Money
    {
        public static String EUR_CURRENCY = "EUR";
        private readonly double amount;
        private readonly String currency;

        private Money(double amount, String currency)
        {
            this.amount = amount;
            this.currency = checkNotNull(currency);
        }

        public static Money newInstance(double amount, String currency)
        {
            return new Money(amount, currency);
        }

        public static Money newEuro(double amount)
        {
            return new Money(amount, EUR_CURRENCY);
        }

        public double getAmount()
        {
            return amount;
        }

        public String getCurrency()
        {
            return currency;
        }

        public Money substract(Money money)
        {
            checkNotNull(money);
            if (!money.getCurrency().Equals(currency))
            {
                throw new Exception("Can't substract different currencies!");
            }
            return new Money(amount - money.amount, currency);
        }

        private T checkNotNull<T>(T instance)
        {
            if (instance == null) throw new NullReferenceException();
            return instance;
        }
    }
}