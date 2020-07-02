using Strike.Common.Objects.Constructors;

using Strike.Common.Accounts.Amounts;
using Strike.Common.Logging.Loggers;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class IgnoreAccountDepositMethod : ILoyaltyPointAccountDepositMethod
    {
        private readonly ILog log;

        public IgnoreAccountDepositMethod(ILog log)
        {
            this.log = CtorGuard.NotNull(log, nameof(log));
        }

        public void Deposit(LoyaltyPointAccountIdentity identity, Amount amount)
        {
            log.Warning("Request to deposit Loyalty Points into Inactive account rejected. The deposited amount of '{0}' will not reflect in account '{1}'.", amount, identity);
        }
    }
}