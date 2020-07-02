namespace Strike.Common.Accounts.Status
{
    public class AccountDeactivationMethodStub : IAccountDeactivationMethod
    {
        public void DeactivateAccount(IAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}