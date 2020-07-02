using Strike.Common.Objects.Specifications;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IExpectMsisdn
    {
        ISpecificationBuilder<LoyaltyPointAccountIdentitySpecification> WithMsisdn(string msisdn);
    }
}