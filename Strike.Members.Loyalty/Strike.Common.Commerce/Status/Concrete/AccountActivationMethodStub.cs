namespace Strike.Common.Accounts.Status
{
    public class AccountActivationMethodStub : ILoyaltyPointAccountActivationMethod
    {
        public void ActivateAccount(IAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}
