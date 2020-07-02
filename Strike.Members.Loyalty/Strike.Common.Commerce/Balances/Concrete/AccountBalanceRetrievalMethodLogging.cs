using System;

using Strike.Common.Logging.Loggers;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;

namespace Strike.Common.Accounts.Balances
{
    public class AccountBalanceRetrievalMethodLogging : IAccountBalanceRetrievalMethod
    {
        private readonly ILogger logger;
        private readonly IAccountBalanceRetrievalMethod decorated;

        public AccountBalanceRetrievalMethodLogging(
            ILogger logger,
            IAccountBalanceRetrievalMethod decorated)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }

        public Amount RetrieveBalance<TIdentity>(TIdentity identity, Currency requiredCurrency)
        {
            logger.LogTrace("Retrieving balance for '{0}' using implementation '{1}'.", identity, decorated.GetType().Name);

            var result = decorated.RetrieveBalance(identity, requiredCurrency);
            return result;
        }
    }
}