namespace Strike.Common.Accounts.Status
{
    public class AccountReactivationMethodStub : IAccountReactivationMethod
    {
        public void Reactivate(IAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}
