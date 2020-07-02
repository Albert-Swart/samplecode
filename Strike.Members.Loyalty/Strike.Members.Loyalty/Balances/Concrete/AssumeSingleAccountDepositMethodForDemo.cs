using System.Collections.Generic;

using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class AssumeSingleAccountDepositMethodForDemo : ILoyaltyPointAccountDepositMethod
    {
        private IList<Amount> transactions;

        public AssumeSingleAccountDepositMethodForDemo(IList<Amount> transactions)
        {
            this.transactions = CtorGuard.NotNull(transactions, nameof(transactions));
        }

        public void Deposit(LoyaltyPointAccountIdentity identity, Amount amount)
        {
            transactions.Add(amount);
        }
    }
}