namespace Strike.Common.Accounts.Status
{
    public interface IAccountReactivationMethod
    {
        void Reactivate(IAccountIdentity account);
    }
}