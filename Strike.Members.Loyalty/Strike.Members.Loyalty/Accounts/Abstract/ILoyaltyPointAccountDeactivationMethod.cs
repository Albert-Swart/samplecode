namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface ILoyaltyPointAccountDeactivationMethod
    {
        void DeactivateAccount(LoyaltyPointAccountIdentity account);
    }
}