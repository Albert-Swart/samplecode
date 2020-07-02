using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public interface IAccountState
        {
            void StateTransition(AccountStatusAwareOperations context);

            void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account);

            void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account);

            void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount);

            Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account);
        }
    }
}