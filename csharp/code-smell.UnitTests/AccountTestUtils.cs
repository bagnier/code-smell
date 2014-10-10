namespace code_smell.UnitTests
{
    public class AccountTestUtils
    {
        public static Account getAccountByTypeAndMoney(bool premium, double money)
        {
            var accountType = new AccountType(premium);
            var account = new Account(accountType, 9);
            account.setIban("RO023INGB434321431241");
            account.setMoney(Money.newEuro(money));
            return account;
        }
    }
}