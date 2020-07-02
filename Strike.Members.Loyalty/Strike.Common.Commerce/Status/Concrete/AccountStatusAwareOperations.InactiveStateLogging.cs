using System;

using Strike.Common.Logging.Loggers;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Balances;

namespace Strike.Common.Accounts.Status
{
    public partial class AccountStatusAwareOperations
    {
        public class InactiveStateLogging : IAccountState
        {
            private readonly ILogger logger;
            private readonly IAccountState decorated;

            public InactiveStateLogging(ILogger logger, IAccountState decorated)
            {
                this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
                this.decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
            }

            public void ActivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                logger.LogInfo("Request to re-activate account '{0}'.", account);

                decorated.ActivateAccount(context, account);

                logger.LogInfo("Account '{0}' re-activated.", account);
            }

            public void DeactivateAccount(AccountStatusAwareOperations context, IAccountIdentity account)
            {
                logger.LogWarning("Attempt to deactivate already inactive account '{0}'.", account);
            }

            public Amount RetrieveBalance(AccountStatusAwareOperations context, AccountInformation account)
            {
                logger.LogTrace("Retrieving balance for new inactive account: {0}.", account);

                var result = decorated.RetrieveBalance(context, account);

                logger.LogTrace("Balance returned for inactive account '{1}' is '{0}'.", result, account);

                return result;
            }

            public void Deposit(AccountStatusAwareOperations context, AccountInformation account, Amount amount)
            {
                logger.LogWarning("Request to make deposit of '{0}' into inactive account '{1}'.", amount, account);
            }

            public void StateTransition(AccountStatusAwareOperations status)
            {
                logger.LogTrace("Internal state changed to '0'.", decorated.GetType().Name);

                decorated.StateTransition(status);
            }
        }
    }
}