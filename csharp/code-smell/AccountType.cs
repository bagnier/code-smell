using System;

namespace code_smell
{
    public class AccountType
    {
        private readonly bool premium;

        public AccountType(bool premium)
        {
            this.premium = premium;
        }

        public bool IsPremium()
        {
            return premium;
        }

        public override String ToString()
        {
            return premium ? "premium" : "normal";
        }
    }
}