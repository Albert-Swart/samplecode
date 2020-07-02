using Strike.Common.Accounts.Amounts;

namespace Strike.PowerPlay.Loyalty.Accounts
{

    public partial class LoyaltyPointAccount
    {
        public abstract class AccountState : IAccountState
        {
            public abstract void Deposit(LoyaltyPointAccount account, Amount amount);

            public abstract Amount RetrieveBalance(LoyaltyPointAccount account);

            public virtual void StateTransition(LoyaltyPointAccount account)
            {
                DoNothing();
            }

            public virtual void ActivateAccount(LoyaltyPointAccount account)
            {
                DoNothing();
            }

            public virtual void DeactivateAccount(LoyaltyPointAccount account)
            {
                DoNothing();
            }

            private void DoNothing() { }
        }

    }
}