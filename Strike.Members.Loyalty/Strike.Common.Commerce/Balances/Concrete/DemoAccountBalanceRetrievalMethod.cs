using System;
using System.Linq;
using System.Collections.Generic;

using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts.Balances
{
    public class DemoAccountBalanceRetrievalMethod : IAccountBalanceRetrievalMethod
    {
        private readonly IEnumerable<Amount> transactions;
        private readonly ICurrencyAdaptor currencyAdaptor;
        private readonly Currency defaultCurrency;

        public DemoAccountBalanceRetrievalMethod(IEnumerable<Amount> transactions, ICurrencyAdaptor currencyAdaptor, Currency defaultCurrency)
        {
            this.transactions = transactions ?? throw new ArgumentNullException(nameof(transactions));
            this.currencyAdaptor = currencyAdaptor ?? throw new ArgumentNullException(nameof(currencyAdaptor));
            this.defaultCurrency = defaultCurrency ?? throw new ArgumentNullException(nameof(defaultCurrency));
        }

        public Amount RetrieveBalance(AccountInformation account)
        {
            if (!transactions.Any())
                return new Amount(defaultCurrency, 0);

            var result = transactions.Aggregate((a, b) => 
                new Amount(defaultCurrency, currencyAdaptor.Adapt(b, defaultCurrency).Value + a.Value));

            return result;
        }
    }
}