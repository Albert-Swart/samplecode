using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountIdentity
    {
        private readonly string msisdn;
        private readonly IRenderMethod<LoyaltyPointAccountIdentity> renderMethod;

        public LoyaltyPointAccountIdentity(string msisdn, IRenderMethod<LoyaltyPointAccountIdentity> renderMethod)
        {
            this.msisdn = CtorGuard.NotNull(msisdn, nameof(msisdn));
            this.renderMethod = CtorGuard.NotNull(renderMethod, nameof(renderMethod));
        }

        public string Msisdn { get => msisdn; }

        public override string ToString()
        {
            var result = renderMethod.Render(this);
            return result;
        }
    }
}