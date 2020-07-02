using Strike.Common.Accounts.Balances;
using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class CreatedState : AccountState
        {
            private readonly ILoyaltyPointAccountActivationMethod activationMethod;
            private readonly IAccountBalanceRetrievalMethod balanceRetrievalMethod;
            private readonly IAccountDepositMethod depositMethod;

            public CreatedState(
                ILoyaltyPointAccountActivationMethod activationMethod,
                IAccountBalanceRetrievalMethod balanceRetrievalMethod,
                IAccountDepositMethod depositMethod)
            {
                this.activationMethod = activationMethod ?? throw new System.ArgumentNullException(nameof(activationMethod));
                this.balanceRetrievalMethod = balanceRetrievalMethod ?? throw new System.ArgumentNullException(nameof(balanceRetrievalMethod));
                this.depositMethod = depositMethod ?? throw new System.ArgumentNullException(nameof(depositMethod));
            }

            public override void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                activationMethod.ActivateAccount(account);
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