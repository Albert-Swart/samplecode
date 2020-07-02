using Strike.Common.Logging.Loggers;

using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountBalanceRetrievalMethodLogging : ILoyaltyPointAccountBalanceRetrievalMethod
    {
        private readonly ILog log;
        private readonly ILoyaltyPointAccountBalanceRetrievalMethod decorated;

        public LoyaltyPointAccountBalanceRetrievalMethodLogging(
            ILog log,
            ILoyaltyPointAccountBalanceRetrievalMethod decorated)
        {
            this.log = CtorGuard.NotNull(log, nameof(log));
            this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
        }

        public Amount RetrieveBalance(LoyaltyPointAccountIdentity identity, Currency requiredCurrency)
        {
            log.Trace("Retrieving balance for '{0}' using implementation '{1}'.", identity, decorated.GetType().Name);

            var result = decorated.RetrieveBalance(identity, requiredCurrency);
            return result;
        }
    }
}