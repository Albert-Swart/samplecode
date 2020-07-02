using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public class InactiveStateLogging : IAccountState
        {
            private readonly ILog log;
            private readonly IAccountState decorated;

            public InactiveStateLogging(ILog log, IAccountState decorated)
            {
                this.log = CtorGuard.NotNull(log, nameof(log));
                this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
            }

            public void ActivateAccount(LoyaltyPointAccount account)
            {
                log.Info("Request to re-activate account '{0}'.", account);

                decorated.ActivateAccount(account);

                log.Info("Account '{0}' re-activated.", account);
            }

            public void DeactivateAccount(LoyaltyPointAccount account)
            {
                log.Warning("Attempt to deactivate already inactive account '{0}'.", account);

                decorated.DeactivateAccount(account);
            }

            public Amount RetrieveBalance(LoyaltyPointAccount account)
            {
                log.Trace("Retrieving balance for new inactive account: {0}.", account);

                var result = decorated.RetrieveBalance(account);

                log.Trace("Balance returned for inactive account '{1}' is '{0}'.", result, account);

                return result;
            }

            public void Deposit(LoyaltyPointAccount account, Amount amount)
            {
                log.Warning("Request to make deposit of '{0}' into inactive account '{1}'.", amount, account);

                decorated.Deposit(account, amount);
            }

            public void StateTransition(LoyaltyPointAccount status)
            {
                log.Trace("Internal state changed to '{0}'.", decorated.GetType().Name);

                decorated.StateTransition(status);
            }
        }

    }
}