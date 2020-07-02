using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public class ActiveState : AccountState
        {
            private readonly ILoyaltyPointAccountDeactivationMethod deactivationMethod;
            private readonly ILoyaltyPointAccountBalanceRetrievalMethod balanceRetrievalMethod;
            private readonly ILoyaltyPointAccountDepositMethod depositMethod;

            public ActiveState(
                ILoyaltyPointAccountDeactivationMethod deactivationMethod,
                ILoyaltyPointAccountBalanceRetrievalMethod balanceRetrievalMethod,
                ILoyaltyPointAccountDepositMethod depositMethod)
            {
                this.deactivationMethod = CtorGuard.NotNull(deactivationMethod, nameof(deactivationMethod));
                this.balanceRetrievalMethod = CtorGuard.NotNull(balanceRetrievalMethod, nameof(balanceRetrievalMethod));
                this.depositMethod = CtorGuard.NotNull(depositMethod, nameof(depositMethod));
            }

            public override void DeactivateAccount(LoyaltyPointAccount account)
            {
                deactivationMethod.DeactivateAccount(account.identity);
                account.SetState(account.inactiveState);
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