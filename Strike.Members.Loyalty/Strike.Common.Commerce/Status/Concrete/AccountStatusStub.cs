namespace Strike.Common.Commerce.Accounts
{
    public class AccountStatusStub : IAccountActivationMethod, IAccountDeactivationMethod, IAccountReactivationMethod
    {
        public void Activate(IAccountIdentity account)
        {
            DoNothing();
        }

        public void Deactivate(IAccountIdentity account)
        {
            DoNothing();
        }

        public void Reactivate(IAccountIdentity account)
        {
            DoNothing();
        }

        private void DoNothing() { }
    }
}