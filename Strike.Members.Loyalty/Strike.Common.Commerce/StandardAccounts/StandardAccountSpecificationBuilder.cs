using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Specifications;

namespace Strike.Common.Accounts
{
    public class StandardAccountSpecificationBuilder : 
        ISpecBuilder<StandardAccountSpecification>, IExpectLoyaltyPointAccountIndentitySpec, IExpectLoyaltyPointAccountBalanceSpec
    {
        private StandardAccountSpecification spec;

        private StandardAccountSpecificationBuilder(StandardAccountSpecification spec)
        {
            this.spec = spec ?? throw new System.ArgumentNullException(nameof(spec));
        }

        public static IExpectLoyaltyPointAccountIndentitySpec Start() => new StandardAccountSpecificationBuilder(new StandardAccountSpecification());

        public IExpectLoyaltyPointAccountBalanceSpec WithIdentity(LoyaltyPointAccountIdentitySpecification identitySpec)
        {
            var spec = new StandardAccountSpecification
            {
                Identity = identitySpec
            };

            return new StandardAccountSpecificationBuilder(spec);
        }

        public IExpectLoyaltyPointAccountBalanceSpec WithIdentity(ISpecBuilder<LoyaltyPointAccountIdentitySpecification> identitySpecBuilder)
        {
            var spec = new StandardAccountSpecification
            {
                Identity = identitySpecBuilder.Build()
            };

            return new StandardAccountSpecificationBuilder(spec);
        }

        public ISpecBuilder<StandardAccountSpecification> WithInitialBalance(Amount balance)
        {
            var spec = new StandardAccountSpecification
            {
                Identity = this.spec.Identity,
                StartingBalance = balance
            };

            return new StandardAccountSpecificationBuilder(spec);
        }

        public StandardAccountSpecification Build() => spec;
    }
}