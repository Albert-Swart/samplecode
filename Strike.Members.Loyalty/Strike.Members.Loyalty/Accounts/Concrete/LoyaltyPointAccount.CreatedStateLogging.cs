using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public class CreatedStateLogging : IAccountState
        {
            private readonly ILog log;
            private readonly IAccountState decorated;

            public CreatedStateLogging(
                ILog log,
                IAccountState decorated)
            {
                this.log = CtorGuard.NotNull(log, nameof(log));
                this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
            }

            public void ActivateAccount(LoyaltyPointAccount account)
            {
                log.Info("Activating new account: {0}.", account);

                decorated.ActivateAccount(account);

                log.Info("New account activated: {0}.", account);
            }

            public void DeactivateAccount(LoyaltyPointAccount account)
            {
                log.Warning("Request to deactivate a new account that is not active yet: {0}.", account);

                decorated.DeactivateAccount(account);
            }

            public Amount RetrieveBalance(LoyaltyPointAccount account)
            {
                log.Trace("Retrieving balance for new inactive account: {0}.", account);

                var result = decorated.RetrieveBalance(account);

                log.Trace("Account balance is {0}: {1}.", result, account);

                return result;
            }

            public void Deposit(LoyaltyPointAccount account, Amount amount)
            {
                log.Info("Request to deposit '{0}' into new inactive account '{1}'.", amount, account);

                decorated.Deposit(account, amount);
            }

            public void StateTransition(LoyaltyPointAccount account)
            {
                log.Trace("Internal state changed to '{0}'.", decorated.GetType().Name);

                decorated.StateTransition(account);
            }
        }

    }
}