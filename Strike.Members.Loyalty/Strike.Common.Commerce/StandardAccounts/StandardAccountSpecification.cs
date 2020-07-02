using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts
{
    public class StandardAccountSpecification
    {
        public Amount StartingBalance { get; set; }

        public LoyaltyPointAccountIdentitySpecification Identity { get; set; }
    }
}