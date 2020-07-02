using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;
using Strike.Common.Logging.Loggers;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class CreatedStateLogging : IAccountState
        {
            private readonly ILogger logger;
            private readonly IAccountState decorated;

            public CreatedStateLogging(
                ILogger logger,
                IAccountState decorated)
            {
                this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
                this.decorated = decorated ?? throw new System.ArgumentNullException(nameof(decorated));
            }

            public void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                logger.LogInfo("Activating new account: {0}.", account);

                decorated.ActivateAccount(context, account);

                logger.LogInfo("New account activated: {0}.", account);
            }

            public void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
               logger.LogWarning("Request to deactivate a new account that is not active yet: {0}.", account);
            }

            public Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account)
            {
                logger.LogTrace("Retrieving balance for new inactive account: {0}.", account);

                var result = decorated.RetrieveBalance(context, account);

                logger.LogTrace("Account balance is {0}: {1}.", result, account);

                return result;
            }

            public void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount)
            {
                logger.LogWarning("Request to deposit '{0}' into a new inactive account '{1}'.", amount, account);
            }

            public void StateTransition(AccountStatusAwareOperations context)
            {
                logger.LogTrace("Internal state changed to '0'.", decorated.GetType().Name);

                decorated.StateTransition(context);
            }
        }
    }
}