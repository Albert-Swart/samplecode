
using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public abstract class AccountState : IAccountState
        {
            public abstract void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount);

            public abstract Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account);

            public virtual void StateTransition(AccountStatusAwareOperations context)
            {
                DoNothing();
            }

            public virtual void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                DoNothing();
            }

            public virtual void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                DoNothing();
            }

            private void DoNothing() { }
        }
    }
}