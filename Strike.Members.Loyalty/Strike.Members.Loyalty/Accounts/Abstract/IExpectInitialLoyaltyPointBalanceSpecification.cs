using Strike.Common.Objects.Specifications;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IExpectInitialLoyaltyPointBalanceSpecification
    {
        ISpecificationBuilder<LoyaltyPointAccountSpecification> WithInitialLoyaltyPoints(decimal balance);
    }
}