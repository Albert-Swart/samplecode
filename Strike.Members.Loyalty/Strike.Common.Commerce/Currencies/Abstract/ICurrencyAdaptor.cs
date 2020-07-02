using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts.Currencies
{
    public interface ICurrencyAdaptor
    {
        Amount Adapt(Amount amount, Currency currency);
    }
}