namespace Strike.Common.Accounts.Currencies
{
    public interface ICurrencyExchangeRate
    {
        Currency Source { get; }

        Currency Target { get; }

        decimal Ratio { get; }
    }
}