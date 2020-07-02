using Strike.Common.Objects.Constructors;
using Strike.Common.Objects.Factories;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountIdentityFactory : 
        ISpecificationFactory<LoyaltyPointAccountIdentity, LoyaltyPointAccountIdentitySpecification>
    {
        private readonly IRenderMethod<LoyaltyPointAccountIdentity> renderMethod;

        public LoyaltyPointAccountIdentityFactory(IRenderMethod<LoyaltyPointAccountIdentity> renderMethod)
        {
            this.renderMethod = CtorGuard.NotNull(renderMethod, nameof(renderMethod));
        }

        public LoyaltyPointAccountIdentity CreateFromSpecification(LoyaltyPointAccountIdentitySpecification specification)
        {
            var result = new LoyaltyPointAccountIdentity(specification.Msisdn, renderMethod);
            return result;
        }
    }
}