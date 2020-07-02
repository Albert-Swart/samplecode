using Strike.Common.Objects.Assertions;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Amounts
{
    public class AmountAdditionMethodPreConditions : IAmountAdditionMethod
    {
        private readonly IAmountAdditionMethod decorated;

        public AmountAdditionMethodPreConditions(IAmountAdditionMethod decorated)
        {
            this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
        }

        public Amount Add(Amount amountOne, Amount amountTwo)
        {
            Assert.NotNull(amountOne, nameof(amountOne));

            Assert.NotNull(amountTwo, nameof(amountTwo));

            Assert.Equal(amountOne.Currency.Code, amountTwo.Currency.Code, "Can only add amounts with the same currency.");

            var result = decorated.Add(amountOne, amountTwo);
            return result;
        }
    }
}