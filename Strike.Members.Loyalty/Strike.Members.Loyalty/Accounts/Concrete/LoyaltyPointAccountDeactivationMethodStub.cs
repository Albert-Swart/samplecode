namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountDeactivationMethodStub : ILoyaltyPointAccountDeactivationMethod
    {
        public void DeactivateAccount(LoyaltyPointAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}