using Strike.Common.Objects.Constructors;

using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;

namespace Strike.Common.Accounts.Balances
{
    public class IgnoreAccountDepositMethod : IAccountDepositMethod
    {
        private readonly ILogger logger;

        public IgnoreAccountDepositMethod(ILogger logger)
        {
            this.logger = CtorGuard.NotNull(logger, nameof(logger));
        }

        public void Deposit(AccountInformation account, Amount amount)
        {
            logger.LogWarning("Request to deposit '{0}' into '{1}' ignored.");
        }
    }
}