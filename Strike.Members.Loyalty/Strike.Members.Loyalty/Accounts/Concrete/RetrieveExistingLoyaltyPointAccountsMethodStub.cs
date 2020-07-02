using System.Collections.Generic;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class RetrieveExistingLoyaltyPointAccountsMethodStub : IRetrieveLoyaltyPointAccountsMethod
    {
        public IEnumerable<LoyaltyPointAccount> RetrieveFor(string identity) => new List<LoyaltyPointAccount>();
    }
}