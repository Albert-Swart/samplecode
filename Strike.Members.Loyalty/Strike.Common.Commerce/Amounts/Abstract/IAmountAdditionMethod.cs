namespace Strike.Common.Accounts.Amounts
{
    public interface IAmountAdditionMethod
    {
        Amount Add(Amount amountOne, Amount amountTwo);
    }
}