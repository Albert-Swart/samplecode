using Strike.Common.Objects.Specifications;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IExpectLoyaltyPointAccountIdentitySpecification
    {
        IExpectInitialLoyaltyPointBalanceSpecification WithIdentity(LoyaltyPointAccountIdentitySpecification specification);

        IExpectInitialLoyaltyPointBalanceSpecification WithIdentity(ISpecificationBuilder<LoyaltyPointAccountIdentitySpecification> specificationBuilder);
    }
}