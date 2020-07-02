using Strike.Common.Commerce.Amounts;
using Strike.Common.Commerce.Balances;

namespace Strike.Common.Commerce.Accounts
{
    public partial class Account : IAccountStatusOperations, IAccountBalanceOperations
    {
        private IState state;
        private object mutex = new object();

        private readonly IState activeState;
        private readonly IState inactiveState;
        private readonly IState initialState;

        public Account(
            IState activeState,
            IState inactiveState,
            IState initialState)
        {
            this.activeState = activeState ?? throw new System.ArgumentNullException(nameof(activeState));
            this.inactiveState = inactiveState ?? throw new System.ArgumentNullException(nameof(inactiveState));
            this.initialState = initialState ?? throw new System.ArgumentNullException(nameof(initialState));

            SetState(initialState);
        }

        public void Activate(IAccountIdentity account)
        {
            state.Activate(this, account);
        }

        public void Deactivate(IAccountIdentity account)
        {
            state.Deactivate(this, account);
        }

        public void DepositInto(IAccountIdentity account, Amount amount)
        {
            state.MakeDeposit(account, amount);
        }

        public Amount RetrieveBalanceFor(IAccountIdentity account)
        {
            var result = state.RetrieveBalanceFor(account);
            return result;
        }

        private void SetState(IState state)
        {
            lock (mutex)
            {
                this.state = state;
                this.state.StateTransition(this);
            }
        }
    }
}