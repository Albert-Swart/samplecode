using Strike.Common.Objects.Specifications;

namespace Strike.Members.Loyalty.Accounts
{
    public interface IExpectAccountIndentitySpecification
    {
        IExpectAccountBalanceSpecification WithIdentity(LoyaltyPointAccountIdentitySpecification spec);

        IExpectAccountBalanceSpecification WithIdentity(ISpecBuilder<LoyaltyPointAccountIdentitySpecification> specBuilder);
    }
}