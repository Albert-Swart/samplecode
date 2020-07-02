namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LogFriendlyLoyaltyPointAccountIdentityRenderMethod : IRenderMethod<LoyaltyPointAccountIdentity>
    {
        public string Render(LoyaltyPointAccountIdentity identity)
        {
            var result = $"{identity.Msisdn}";
            return result;
        }
    }
}