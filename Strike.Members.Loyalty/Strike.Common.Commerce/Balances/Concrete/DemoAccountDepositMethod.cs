using System;
using System.Collections.Generic;

using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;

namespace Strike.Common.Accounts.Balances
{
    public class DemoAccountDepositMethod : IAccountDepositMethod
    {
        private IDictionary<string, IList<Amount>> transactions;

        public DemoAccountDepositMethod()
        {
            transactions = new Dictionary<string, IList<Amount>>(); // transactions ?? throw new ArgumentNullException(nameof(transactions));
        }

        public void Deposit<TIdentity>(TIdentity identity, Amount amount, Currency targetCurrency)
        {
            
            transactions.Add(identity.ToString(), );
        }
    }
}