using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Currencies
{
    public class FixedCurrencyExchangeRate : ICurrencyExchangeRate
    {
        private readonly Currency source;
        private readonly Currency target;
        private readonly decimal ratio;

        public FixedCurrencyExchangeRate(Currency source, Currency target, decimal ratio)
        {
            this.source = CtorGuard.NotNull(source, nameof(source));
            this.target = CtorGuard.NotNull(target, nameof(target));
            this.ratio = ratio;
        }

        public Currency Source { get => source; }

        public Currency Target { get => target; }

        public decimal Ratio { get => ratio; }
    }
}