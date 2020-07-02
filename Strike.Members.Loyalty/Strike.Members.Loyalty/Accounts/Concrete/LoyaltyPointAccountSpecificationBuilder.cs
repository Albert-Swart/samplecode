using Strike.Common.Objects.Constructors;
using Strike.Common.Objects.Specifications;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountSpecificationBuilder :
        ISpecificationBuilder<LoyaltyPointAccountSpecification>, IExpectLoyaltyPointAccountIdentitySpecification, IExpectInitialLoyaltyPointBalanceSpecification
    {
        private LoyaltyPointAccountSpecification specification;

        private LoyaltyPointAccountSpecificationBuilder(LoyaltyPointAccountSpecification specification)
        {
            this.specification = CtorGuard.NotNull(specification, nameof(specification));
        }

        public static IExpectLoyaltyPointAccountIdentitySpecification Start() => new LoyaltyPointAccountSpecificationBuilder(new LoyaltyPointAccountSpecification());

        public IExpectInitialLoyaltyPointBalanceSpecification WithIdentity(LoyaltyPointAccountIdentitySpecification specification)
        {
            var spec = new LoyaltyPointAccountSpecification
            {
                Identity = specification
            };

            return new LoyaltyPointAccountSpecificationBuilder(spec);
        }

        public IExpectInitialLoyaltyPointBalanceSpecification WithIdentity(ISpecificationBuilder<LoyaltyPointAccountIdentitySpecification> specificationBuilder)
        {
            var specification = new LoyaltyPointAccountSpecification
            {
                Identity = specificationBuilder.Build()
            };

            return new LoyaltyPointAccountSpecificationBuilder(specification);
        }

        public ISpecificationBuilder<LoyaltyPointAccountSpecification> WithInitialLoyaltyPoints(decimal balance)
        {
            var specification = new LoyaltyPointAccountSpecification
            {
                Identity = this.specification.Identity,
                InitialBalance = balance
            };

            return new LoyaltyPointAccountSpecificationBuilder(specification);
        }

        public LoyaltyPointAccountSpecification Build() => specification;
    }
}