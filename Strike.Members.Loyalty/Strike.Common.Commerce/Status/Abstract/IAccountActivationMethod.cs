namespace Strike.Common.Accounts.Status
{
    public interface ILoyaltyPointAccountActivationMethod
    {
        void ActivateAccount(LoyaltyPointAccountIdentity account);
    }
}