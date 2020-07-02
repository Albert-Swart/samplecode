using Strike.Common.Logging.Loggers;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Amounts
{
    public class AmountAdditionMethodLogging : IAmountAdditionMethod
    {
        private readonly ILog log;
        private readonly IAmountAdditionMethod decorated;

        public AmountAdditionMethodLogging(
            ILog log,
            IAmountAdditionMethod decorated)
        {
            this.log = CtorGuard.NotNull(log, nameof(log));
            this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
        }

        public Amount Add(Amount amountOne, Amount amountTwo)
        {
            log.Trace("Adding amount {0} to amount {1}.", amountTwo, amountOne);

            var result = decorated.Add(amountOne, amountTwo);

            log.Trace("Result of add is {0}.", result);

            return result;
        }
    }
}