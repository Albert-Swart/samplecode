using System;
using System.Linq;
using System.Collections.Generic;

using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class DemoAccountBalanceRetrievalMethod : ILoyaltyPointAccountBalanceRetrievalMethod
    {
        private readonly IEnumerable<Amount> transactions;
        private readonly ICurrencyAdaptor currencyAdaptor;

        public DemoAccountBalanceRetrievalMethod(IEnumerable<Amount> transactions, ICurrencyAdaptor currencyAdaptor)
        {
            this.transactions = CtorGuard.NotNull(transactions, nameof(transactions));
            this.currencyAdaptor = CtorGuard.NotNull(currencyAdaptor, nameof(currencyAdaptor));
        }

        public Amount RetrieveBalance(LoyaltyPointAccountIdentity identity, Currency requiredCurrency)
        {
            if (!transactions.Any())
                return new Amount(requiredCurrency, 0);

            var result = transactions.Aggregate((a, b) =>
                new Amount(requiredCurrency, currencyAdaptor.Adapt(b, requiredCurrency).Value + a.Value));

            return result;
        }
    }
}