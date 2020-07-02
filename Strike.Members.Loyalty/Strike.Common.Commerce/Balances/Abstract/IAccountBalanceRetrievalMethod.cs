using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;

namespace Strike.Common.Accounts.Balances
{
    public interface IAccountBalanceRetrievalMethod
    {
        Amount RetrieveBalance<TIdentity>(TIdentity identity, Currency requiredCurrency);
    }
}