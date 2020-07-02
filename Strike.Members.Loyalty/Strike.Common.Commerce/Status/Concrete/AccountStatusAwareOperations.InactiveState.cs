using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class InactiveState : AccountState
        {
            private readonly IAccountReactivationMethod reactivateMethod;
            private readonly IAccountBalanceRetrievalMethod balanceRetrievalMethod;
            private readonly IAccountDepositMethod depositMethod;

            public InactiveState(
                IAccountReactivationMethod reactivateMethod,
                IAccountBalanceRetrievalMethod balanceRetrievalMethod,
                IAccountDepositMethod depositMethod)
            {
                this.reactivateMethod = reactivateMethod ?? throw new System.ArgumentNullException(nameof(reactivateMethod));
                this.balanceRetrievalMethod = balanceRetrievalMethod ?? throw new System.ArgumentNullException(nameof(balanceRetrievalMethod));
                this.depositMethod = depositMethod ?? throw new System.ArgumentNullException(nameof(depositMethod));
            }

            public override void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                reactivateMethod.Reactivate(account);
                context.SetState(context.activeState);
            }

            public override Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account)
            {
                var result = balanceRetrievalMethod.RetrieveBalance(account);
                return result;
            }

            public override void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount)
            {
                depositMethod.Deposit(account, amount);
            }
        }
    }
}