using Strike.Common.Accounts.Currencies;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Amounts
{
    public sealed class Amount
    {
        private readonly Currency currency;
        private readonly decimal value;

        public Amount(Currency currency, decimal value)
        {
            this.currency = CtorGuard.NotNull(currency, nameof(currency));
            this.value = CtorGuard.NotNull(value, nameof(value));
        }

        public Currency Currency { get => currency; }

        public decimal Value { get => value; }

        public override string ToString()
        {
            var result = $"{Value} {Currency.Code}";
            return result;
        }
    }
}