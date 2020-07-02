using Strike.Common.Objects.Constructors;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;

namespace Strike.Common.Accounts.Balances
{
    public class IgnoreAccountBalanceRetrieval : IAccountBalanceRetrievalMethod
    {
        private readonly ILogger logger;
        private readonly Amount defaultBalance;

        public IgnoreAccountBalanceRetrieval(ILogger logger, Amount defaultBalance)
        {
            this.logger = CtorGuard.NotNull(logger, nameof(logger));
            this.defaultBalance = CtorGuard.NotNull(defaultBalance, nameof(defaultBalance));
        }

        public void Deposit(IAccountIdentity account, Amount amount)
        {
            logger.LogWarning("Request to deposit '{0}' into '{1}' ignored.");
        }

        public Amount RetrieveBalance(AccountInformation account)
        {
            logger.LogWarning("Request to retrieve balance of '{0}' ignored. A default balance of '{1}' will be returned.");

            return defaultBalance;
        }
    }
}