using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class ActiveStateLogging : IAccountState
        {
            private readonly ILogger logger;
            private readonly IAccountState decorated;

            public ActiveStateLogging(ILogger logger, IAccountState decorated)
            {
                this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
                this.decorated = decorated ?? throw new System.ArgumentNullException(nameof(decorated));
            }

            public void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                logger.LogWarning("Request to activate account '{0}'. This account is already active. The request will be ignored.", account);
            }

            public void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                logger.LogInfo("Request to deactivate account '{0}'.", account);

                decorated.DeactivateAccount(context, account);

                logger.LogInfo("Account '{0}' deactivated.", account);
            }

            public Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account)
            {
                logger.LogTrace("Request to retrieve balance of active account '{0}'.", account);

                var balance = decorated.RetrieveBalance(context, account);

                logger.LogTrace("Balance of active account '{0}' retrieved. Current balance is '{1}'.", account, balance);

                return balance;
            }

            public void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount)
            {
                logger.LogInfo("Request to deposit '{0}' into active account '{1}'.", amount, account);

                decorated.Deposit(context, account, amount);

                logger.LogInfo("Deposit of '{0}' made into active account '{1}'.", amount, account);
            }

            public void StateTransition(AccountStatusAwareOperations status)
            {
                logger.LogTrace("Internal state changed to '{0}'. Invoking state transition method.", decorated.GetType().FullName);

                decorated.StateTransition(status);

                logger.LogTrace("State transition method on '{0}' invoked.", decorated.GetType().Name);
            }
        }
    }
}