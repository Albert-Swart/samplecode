namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface ILoyaltyPointAccountReactivationMethod
    {
        void Reactivate(LoyaltyPointAccountIdentity account);
    }
}