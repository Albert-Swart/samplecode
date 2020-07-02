using Strike.Common.Logging.Loggers;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Currencies
{
    public class CurrencyAdaptorLogging : ICurrencyAdaptor
    {
        private readonly ILog log;
        private readonly ICurrencyAdaptor decorated;

        public CurrencyAdaptorLogging(
            ILog log,
            ICurrencyAdaptor decorated)
        {
            this.log = CtorGuard.NotNull(log, nameof(log));
            this.decorated = CtorGuard.NotNull(decorated, nameof(decorated));
        }

        public Amount Adapt(Amount amount, Currency currency)
        {
            if (amount.Currency.Code != currency.Code)
            {
                log.Trace("Request to adapt amount '{0}' to currency '{1}'.", amount, currency);

                var result = decorated.Adapt(amount, currency);

                log.Trace("Result after adapt of '{0}' to currency '{1}' is '{2}'.", amount, currency, result);

                return result;
            }

            return decorated.Adapt(amount, currency);
        }
    }
}