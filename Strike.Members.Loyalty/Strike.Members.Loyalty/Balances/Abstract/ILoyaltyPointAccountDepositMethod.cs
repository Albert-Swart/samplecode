using Strike.Common.Accounts.Amounts;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface ILoyaltyPointAccountDepositMethod
    {
        void Deposit(LoyaltyPointAccountIdentity identity, Amount amount);
    }
}