using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public class ActiveStateLogging : IAccountState
        {
            private readonly ILog log;
            private readonly IAccountState decorated;

            public ActiveStateLogging(ILog log, IAccountState decorated)
            {
                this.log = CtorGuard.NotNull(log, nameof(log));
                this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
            }

            public void ActivateAccount(LoyaltyPointAccount account)
            {
                log.Warning("Request to activate account '{0}'. This account is already active. The request will be ignored.", account);

                decorated.ActivateAccount(account);
            }

            public void DeactivateAccount(LoyaltyPointAccount account)
            {
                log.Info("Request to deactivate account '{0}'.", account);

                decorated.DeactivateAccount(account);

                log.Info("Account '{0}' deactivated.", account);
            }

            public Amount RetrieveBalance(LoyaltyPointAccount account)
            {
                log.Trace("Request to retrieve balance of active account '{0}'.", account);

                var balance = decorated.RetrieveBalance(account);

                log.Trace("Balance of active account '{0}' retrieved. Current balance is '{1}'.", account, balance);

                return balance;
            }

            public void Deposit(LoyaltyPointAccount account, Amount amount)
            {
                log.Info("Request to deposit '{0}' into active account '{1}'.", amount, account);

                decorated.Deposit(account, amount);

                log.Info("Deposit of '{0}' made into active account '{1}'. New balance is '{2}'", amount, account, account.CurrentPoints);
            }

            public void StateTransition(LoyaltyPointAccount status)
            {
                log.Trace("Internal state changed to '{0}'. Invoking state transition method.", decorated.GetType().FullName);

                decorated.StateTransition(status);

                log.Trace("State transition method on '{0}' invoked.", decorated.GetType().Name);
            }
        }
    }
}