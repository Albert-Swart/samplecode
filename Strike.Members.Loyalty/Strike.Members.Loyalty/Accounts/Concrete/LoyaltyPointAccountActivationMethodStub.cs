namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountActivationMethodStub : ILoyaltyPointAccountActivationMethod
    {
        public void ActivateAccount(LoyaltyPointAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}