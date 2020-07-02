using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Currencies
{
    public class CurrencyAdaptor : ICurrencyAdaptor
    {
        private readonly ICurrencyExchangeRateProvider exchangeRateProvider;

        public CurrencyAdaptor(ICurrencyExchangeRateProvider exchangeRateProvider)
        {
            this.exchangeRateProvider = CtorGuard.NotNull(exchangeRateProvider, nameof(exchangeRateProvider));
        }

        public Amount Adapt(Amount amount, Currency target)
        {
            var exchangeRate = exchangeRateProvider.ForConversion(amount.Currency, target);
            var adaptedValue = amount.Value * exchangeRate.Ratio;

            var result = new Amount(target, adaptedValue);
            return result;
        }
    }
}