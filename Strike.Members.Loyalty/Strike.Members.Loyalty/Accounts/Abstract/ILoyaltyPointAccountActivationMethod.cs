namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface ILoyaltyPointAccountActivationMethod
    {
        void ActivateAccount(LoyaltyPointAccountIdentity account);
    }
}