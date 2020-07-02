using Strike.Common.Objects.Constructors;

namespace Strike.Common.Accounts.Currencies
{
    public sealed class Currency
    {
        private readonly string currencyCode;
        private readonly string currencyNamespace;

        public Currency(string currencyCode, string currencyNamespace)
        {
            this.currencyCode = CtorGuard.NotNull(currencyCode, nameof(currencyCode));
            this.currencyNamespace = CtorGuard.NotNull(currencyNamespace, nameof(currencyNamespace));
        }

        public string Code { get => currencyCode; }

        public string Namespace { get => currencyNamespace; }

        public override string ToString()
        {
            return currencyCode;
        }
    }
}