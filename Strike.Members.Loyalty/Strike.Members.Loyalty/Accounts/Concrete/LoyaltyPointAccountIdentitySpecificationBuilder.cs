using Strike.Common.Objects.Constructors;
using Strike.Common.Objects.Specifications;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountIdentitySpecificationBuilder :
        ISpecificationBuilder<LoyaltyPointAccountIdentitySpecification>, IExpectMsisdn
    {
        private readonly LoyaltyPointAccountIdentitySpecification specification;

        private LoyaltyPointAccountIdentitySpecificationBuilder(LoyaltyPointAccountIdentitySpecification specification)
        {
            this.specification = CtorGuard.NotNull(specification, nameof(specification));
        }

        public static IExpectMsisdn Start() => new LoyaltyPointAccountIdentitySpecificationBuilder(
            new LoyaltyPointAccountIdentitySpecification());

        public ISpecificationBuilder<LoyaltyPointAccountIdentitySpecification> WithMsisdn(string msisdn)
        {
            var specification = new LoyaltyPointAccountIdentitySpecification
            {
                Msisdn = msisdn
            };

            return new LoyaltyPointAccountIdentitySpecificationBuilder(specification);
        }

        public LoyaltyPointAccountIdentitySpecification Build() => specification;
    }
}