using Strike.Common.Accounts;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount : ILoyaltyPointAccount
    {
        private IAccountState state;
        private object mutex = new object();

        private readonly IAccountState createdState;
        private readonly IAccountState activeState;
        private readonly IAccountState inactiveState;

        private readonly LoyaltyPointAccountIdentity identity;

        private readonly Currency primaryCurrency;

        public LoyaltyPointAccount(
            IAccountState createdState,
            IAccountState activeState,
            IAccountState inactiveState,
            LoyaltyPointAccountIdentity identity,
            Currency primaryCurrency)
        {
            this.createdState = CtorGuard.NotNull(createdState, nameof(createdState));
            this.activeState = CtorGuard.NotNull(activeState, nameof(activeState));
            this.inactiveState = CtorGuard.NotNull(inactiveState, nameof(inactiveState));

            this.identity = identity;
            this.primaryCurrency = primaryCurrency;

            SetState(createdState);
        }

        public void Activate()
        {
            state.ActivateAccount(this);
        }

        public void Deactivate()
        {
            state.DeactivateAccount(this);
        }

        public Amount CurrentPoints
        {
            get
            {
                var result = state.RetrieveBalance(this);
                return result;
            }
        }

        public void AddPoints(Amount amount)
        {
            state.Deposit(this, amount);
        }

        public override string ToString()
        {
            return identity.Msisdn;
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