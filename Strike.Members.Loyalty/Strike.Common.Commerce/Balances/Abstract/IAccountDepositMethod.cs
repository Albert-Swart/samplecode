using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;

namespace Strike.Common.Accounts.Balances
{
    public interface IAccountDepositMethod
    {
        void Deposit<TIdentity>(TIdentity identity, Amount amount, Currency targetCurrency);
    }
}