namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountReactivationMethodStub : ILoyaltyPointAccountReactivationMethod
    {
        public void Reactivate(LoyaltyPointAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}
