using Strike.Common.Accounts.Amounts;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public partial class LoyaltyPointAccount
    {
        public interface IAccountState
        {
            void StateTransition(LoyaltyPointAccount account);

            void ActivateAccount(LoyaltyPointAccount account);

            void DeactivateAccount(LoyaltyPointAccount account);

            void Deposit(LoyaltyPointAccount account, Amount amount);

            Amount RetrieveBalance(LoyaltyPointAccount account);
        }
    }
}