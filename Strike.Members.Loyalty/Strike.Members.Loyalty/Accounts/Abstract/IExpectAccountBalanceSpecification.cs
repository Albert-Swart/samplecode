using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Specifications;

namespace Strike.Members.Loyalty.Accounts
{
    public interface IExpectAccountBalanceSpecification
    {
        ISpecBuilder<StandardAccountSpecification> WithInitialBalance(Amount balance);
    }
}