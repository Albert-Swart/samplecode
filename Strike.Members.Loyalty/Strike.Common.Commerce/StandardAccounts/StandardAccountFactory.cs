using Strike.Common.Objects.Factories;

using Strike.Common.Accounts.Balances;
using Strike.Common.Accounts.Status;
using Strike.Common.Accounts.Currencies;

namespace Strike.Common.Accounts
{
    public class StandardAccountFactory : ISpecificationFactory<IAccount, StandardAccountSpecification>
    {
        private readonly Currency primaryCurrency;
        private readonly IAccountStatusAwareOperations statusAwareOperations;
        private readonly IAccountDepositMethod balanceUpdateMethod;
        private readonly ISpecificationFactory<IAccountIdentity, LoyaltyPointAccountIdentitySpecification> identityFactory;

        public StandardAccountFactory(
            Currency primaryCurrency,
            IAccountStatusAwareOperations statusAwareOperations,
            IAccountDepositMethod balanceUpdateMethod,
            ISpecificationFactory<IAccountIdentity, LoyaltyPointAccountIdentitySpecification> identityFactory)
        {
            this.primaryCurrency = primaryCurrency;
            this.statusAwareOperations = statusAwareOperations;
            this.balanceUpdateMethod = balanceUpdateMethod;
            this.identityFactory = identityFactory;
        }

        public IAccount CreateFromSpecification(StandardAccountSpecification spec)
        {
            var identity = identityFactory.CreateFromSpecification(spec.Identity);

            var accountInformation = new AccountInformation
            {
                Identity = identity,
                PrimaryCurrency = primaryCurrency
            };

            balanceUpdateMethod.Deposit(accountInformation, spec.StartingBalance);

            var result = new StandardAccount(statusAwareOperations, identity, primaryCurrency);
            return result;
        }
    }
}