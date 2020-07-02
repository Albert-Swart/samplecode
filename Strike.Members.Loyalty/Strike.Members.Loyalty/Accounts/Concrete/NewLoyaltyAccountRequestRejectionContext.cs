using System.Collections.Generic;

using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class NewLoyaltyAccountRequestRejectionContext
    {
        private readonly IEnumerable<LoyaltyPointAccount> existingAccounts;
        private readonly IEnumerable<IRejectionReason> rejectionReasons;

        public NewLoyaltyAccountRequestRejectionContext(IEnumerable<LoyaltyPointAccount> existingAccounts, IEnumerable<IRejectionReason> rejectionReasons)
        {
            this.existingAccounts = CtorGuard.NotNull(existingAccounts, nameof(existingAccounts));
            this.rejectionReasons = CtorGuard.NotNull(rejectionReasons, nameof(rejectionReasons));
        }

        public IEnumerable<LoyaltyPointAccount> ExistingAccounts { get => existingAccounts; }

        public IEnumerable<IRejectionReason> RejectionReasons { get => rejectionReasons; }
    }
}