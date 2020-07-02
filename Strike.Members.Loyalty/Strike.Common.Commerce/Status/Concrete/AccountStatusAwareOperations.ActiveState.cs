using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class ActiveState : AccountState
        {
            private readonly IAccountDeactivationMethod deactivationMethod;
            private readonly IAccountBalanceRetrievalMethod balanceRetrievalMethod;
            private readonly IAccountDepositMethod depositMethod;

            public ActiveState(
                IAccountDeactivationMethod deactivationMethod,
                IAccountBalanceRetrievalMethod balanceRetrievalMethod,
                IAccountDepositMethod depositMethod)
            {
                this.deactivationMethod = deactivationMethod ?? throw new System.ArgumentNullException(nameof(deactivationMethod));
                this.balanceRetrievalMethod = balanceRetrievalMethod ?? throw new System.ArgumentNullException(nameof(balanceRetrievalMethod));
                this.depositMethod = depositMethod ?? throw new System.ArgumentNullException(nameof(depositMethod));
            }

            public override void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                deactivationMethod.DeactivateAccount(account);
                context.SetState(context.inactiveState);
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