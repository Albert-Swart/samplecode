namespace Strike.Common.Accounts.Currencies
{
    public interface ICurrencyExchangeRateProvider
    {
        ICurrencyExchangeRate ForConversion(Currency source, Currency target);
    }
}