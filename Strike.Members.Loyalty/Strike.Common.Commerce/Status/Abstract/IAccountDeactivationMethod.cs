namespace Strike.Common.Accounts.Status
{
    public interface IAccountDeactivationMethod
    {
        void DeactivateAccount(IAccountIdentity account);
    }
}