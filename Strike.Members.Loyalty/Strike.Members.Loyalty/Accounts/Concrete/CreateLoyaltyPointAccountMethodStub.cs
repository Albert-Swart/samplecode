namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class CreateLoyaltyPointAccountMethodStub : ICreateLoyaltyPointAccountMethod
    {
        public void Save(LoyaltyPointAccount account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}