using Strike.Common.Objects.Constructors;
using System.Collections.Generic;
using System.Linq;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class UsersMayOnlyHaveOneLoyaltyPointAccount :
        RejectorRule<string, IEnumerable<LoyaltyPointAccount>>
    {
        private readonly IRetrieveLoyaltyPointAccountsMethod retrieveAccountsMethod;

        public UsersMayOnlyHaveOneLoyaltyPointAccount(IRetrieveLoyaltyPointAccountsMethod retrieveAccountsMethod)
        {
            this.retrieveAccountsMethod = CtorGuard.NotNull(retrieveAccountsMethod, nameof(retrieveAccountsMethod));
        }

        public override string Reason
        {
            get
            {
                return "User may only have a single loyalty point account.";
            }
        }

        public override bool RejectValue(string context, IEnumerable<LoyaltyPointAccount> value)
        {
            var existingAccounts = retrieveAccountsMethod.RetrieveFor(context);
            var result = existingAccounts.Count() > 1;
            return result;
        }
    }
}