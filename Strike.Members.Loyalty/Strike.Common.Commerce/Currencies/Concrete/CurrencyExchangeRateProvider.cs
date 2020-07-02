using System.Linq;
using System.Collections.Generic;

using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Currencies
{
    public class CurrencyExchangeRateProvider : ICurrencyExchangeRateProvider
    {
        private readonly IEnumerable<ICurrencyExchangeRate> exchangeRates;

        public CurrencyExchangeRateProvider(ICurrencyExchangeRate[] exchangeRates)
        {
            this.exchangeRates = CtorGuard.NotNull(exchangeRates, nameof(exchangeRates));
        }

        public ICurrencyExchangeRate ForConversion(Currency source, Currency target)
        {
            var result = exchangeRates.Where(exchange => 
                exchange.Source.Code == source.Code && exchange.Target.Code == target.Code);

            return result.First();
        }
    }
}