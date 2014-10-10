namespace code_smell.UnitTests
{
    public class AccountTestUtils
    {
        public static Account GetAccountByTypeAndMoney(bool premium, double money)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.SetIban("RO023INGB434321431241");
            account.SetMoney(Money.newEuro(money));
            return account;
        }
    }
}