using Strike.Common.Accounts.Currencies;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Amounts
{
    public class CurrencyNormalization : IAmountAdditionMethod
    {
        private readonly ICurrencyAdaptor currencyAdaptor;
        private readonly IAmountAdditionMethod decorated;

        public CurrencyNormalization(
            ICurrencyAdaptor currencyAdaptor,
            IAmountAdditionMethod decorated)
        {
            this.currencyAdaptor = CtorGuard.NotNull(currencyAdaptor, nameof(currencyAdaptor));
            this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
        }

        public Amount Add(Amount amountOne, Amount amountTwo)
        {
            var normalizedAmountTwo = currencyAdaptor.Adapt(amountTwo, amountOne.Currency);

            var result = decorated.Add(amountOne, normalizedAmountTwo);
            return result;
        }
    }
}