using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface ILoyaltyPointAccountBalanceRetrievalMethod
    {
        Amount RetrieveBalance(LoyaltyPointAccountIdentity identity, Currency requiredCurrency);
    }
}