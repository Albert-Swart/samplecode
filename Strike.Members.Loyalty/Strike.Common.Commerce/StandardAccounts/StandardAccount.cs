using Strike.Common.Accounts;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Status;

namespace Strike.Common.Accounts
{
    public class StandardAccount : IAccount
    {
        private readonly IAccountStatusAwareOperations statusAwareOperations;

        private AccountInformation accountInformation;

        internal StandardAccount(IAccountStatusAwareOperations statusAwareOperations, IAccountIdentity identity, Currency primaryCurrency)
        {
            this.statusAwareOperations = statusAwareOperations;

            accountInformation = new AccountInformation
            {
                Identity = identity,
                PrimaryCurrency = primaryCurrency
            };
        }

        public void Activate()
        {
            statusAwareOperations.ActivateAccount(accountInformation.Identity);
        }

        public void Deactivate()
        {
            statusAwareOperations.DeactivateAccount(accountInformation.Identity);
        }

        public Amount Balance
        {
            get
            {
                var result = statusAwareOperations.RetrieveBalance(accountInformation);
                return result;
            }
        }

        public Currency PrimaryCurrency
        {
            get
            {
                return accountInformation.PrimaryCurrency;
            }
        }

        public void Deposit(Amount amount)
        {
            statusAwareOperations.Deposit(accountInformation, amount);
        }
    }
}