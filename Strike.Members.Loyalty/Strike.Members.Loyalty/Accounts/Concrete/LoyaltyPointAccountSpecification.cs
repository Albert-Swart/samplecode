namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountSpecification
    {
        public decimal InitialBalance { get; set; }

        public LoyaltyPointAccountIdentitySpecification Identity { get; set; }
    }
}