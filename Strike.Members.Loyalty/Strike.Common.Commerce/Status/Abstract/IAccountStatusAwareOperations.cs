using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts.Status
{
    public interface IAccountStatusAwareOperations
    {
        void ActivateAccount(IAccountIdentity account);

        void DeactivateAccount(IAccountIdentity account);

        void Deposit(AccountInformation account, Amount amount);

        Amount RetrieveBalance(AccountInformation account);
    }
}