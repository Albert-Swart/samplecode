using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public class CreatedState : AccountState
        {
            private readonly ILoyaltyPointAccountActivationMethod activationMethod;
            private readonly ILoyaltyPointAccountBalanceRetrievalMethod balanceRetrievalMethod;
            private readonly ILoyaltyPointAccountDepositMethod depositMethod;

            public CreatedState(
                ILoyaltyPointAccountActivationMethod activationMethod,
                ILoyaltyPointAccountBalanceRetrievalMethod balanceRetrievalMethod,
                ILoyaltyPointAccountDepositMethod depositMethod)
            {
                this.activationMethod = CtorGuard.NotNull(activationMethod, nameof(activationMethod));
                this.balanceRetrievalMethod = CtorGuard.NotNull(balanceRetrievalMethod, nameof(balanceRetrievalMethod));
                this.depositMethod = CtorGuard.NotNull(depositMethod, nameof(depositMethod));
            }

            public override void ActivateAccount(LoyaltyPointAccount account)
            {
                activationMethod.ActivateAccount(account.identity);
                account.SetState(account.activeState);
            }

            public override Amount RetrieveBalance(LoyaltyPointAccount account)
            {
                var result = balanceRetrievalMethod.RetrieveBalance(account.identity, account.primaryCurrency);
                return result;
            }

            public override void Deposit(LoyaltyPointAccount account, Amount amount)
            {
                depositMethod.Deposit(account.identity, amount);
            }
        }

    }
}