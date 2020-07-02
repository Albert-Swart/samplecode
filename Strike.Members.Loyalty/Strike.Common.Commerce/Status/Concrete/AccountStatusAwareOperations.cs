using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations : IAccountStatusAwareOperations, ILoyaltyPointAccountActivationMethod, 
        IAccountDeactivationMethod, IAccountDepositMethod, IAccountBalanceRetrievalMethod
    {
        private IAccountState state;
        private object mutex = new object();

        private readonly IAccountState activeState;
        private readonly IAccountState inactiveState;
        private readonly IAccountState initialState;

        public AccountStatusAwareOperations(
            IAccountState activeState,
            IAccountState inactiveState,
            IAccountState initialState)
        {
            this.activeState = activeState ?? throw new System.ArgumentNullException(nameof(activeState));
            this.inactiveState = inactiveState ?? throw new System.ArgumentNullException(nameof(inactiveState));
            this.initialState = initialState ?? throw new System.ArgumentNullException(nameof(initialState));

            SetState(initialState);
        }

        public void ActivateAccount(IAccountIdentity account)
        {
            state.ActivateAccount(this, account);
        }

        public void DeactivateAccount(IAccountIdentity account)
        {
            state.DeactivateAccount(this, account);
        }

        public void Deposit(AccountInformation account, Amount amount)
        {
            state.Deposit(this, account, amount);
        }

        public Amount RetrieveBalance(AccountInformation account)
        {
            var result = state.RetrieveBalance(this, account);
            return result;
        }

        private void SetState(IAccountState state)
        {
            lock (mutex)
            {
                this.state = state;
                this.state.StateTransition(this);
            }
        }
    }
}