using Strike.Common.Accounts.Amounts;

namespace Strike.Common.Accounts
{
    public interface ILoyaltyPointAccount
    {
        void Activate();

        void Deactivate();

        Amount CurrentPoints { get; }

        void AddPoints(Amount amount);
    }
}