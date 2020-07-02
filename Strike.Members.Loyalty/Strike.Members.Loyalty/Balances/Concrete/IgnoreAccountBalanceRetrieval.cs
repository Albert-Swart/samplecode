using Strike.Common.Objects.Constructors;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Logging.Loggers;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class IgnoreAccountBalanceRetrieval : ILoyaltyPointAccountBalanceRetrievalMethod
    {
        private readonly ILog log;
        private readonly Amount defaultBalance;

        public IgnoreAccountBalanceRetrieval(ILog log, Amount defaultBalance)
        {
            this.log = CtorGuard.NotNull(log, nameof(log));
            this.defaultBalance = CtorGuard.NotNull(defaultBalance, nameof(defaultBalance));
        }

        public Amount RetrieveBalance(LoyaltyPointAccountIdentity identity, Currency requiredCurrency)
        {
            log.Warning("Request to retrieve balance of '{0}' ignored. A default balance of '{1}' will be returned.", identity, defaultBalance);

            return defaultBalance;
        }
    }
}