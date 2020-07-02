namespace Strike.Common.Accounts.Amounts
{
    public class AmountAdditionMethod : IAmountAdditionMethod
    {
        public Amount Add(Amount amountOne, Amount amountTwo)
        {
            var value = amountOne.Value + amountTwo.Value;           

            var result = new Amount(amountOne.Currency, value);
            return result;
        }
    }
}