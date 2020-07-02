using System.Collections.Generic;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IRetrieveLoyaltyPointAccountsMethod
    {
        IEnumerable<LoyaltyPointAccount> RetrieveFor(string msisdn);
    }
}