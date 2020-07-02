using Strike.Common.Objects.Factories;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Amounts;
using Strike.Common.Objects.Constructors;

namespace Strike.PowerPlay.Loyalty.Accounts
{
    public class LoyaltyPointAccountFactory : ISpecificationFactory<LoyaltyPointAccount, LoyaltyPointAccountSpecification>
    {
        private readonly Currency primaryCurrency;
        private readonly LoyaltyPointAccount.IAccountState createdState;
        private readonly LoyaltyPointAccount.IAccountState activeState;
        private readonly LoyaltyPointAccount.IAccountState inactiveState;
        private readonly ISpecificationFactory<LoyaltyPointAccountIdentity, LoyaltyPointAccountIdentitySpecification> identityFactory;

        public LoyaltyPointAccountFactory(
            Currency primaryCurrency,
            LoyaltyPointAccount.IAccountState createdState,
            LoyaltyPointAccount.IAccountState activeState,
            LoyaltyPointAccount.IAccountState inactiveState,
            ISpecificationFactory<LoyaltyPointAccountIdentity, LoyaltyPointAccountIdentitySpecification> identityFactory)
        {
            this.primaryCurrency = CtorGuard.NotNull(primaryCurrency, nameof(primaryCurrency));
            this.createdState = CtorGuard.NotNull(createdState, nameof(createdState));
            this.activeState = CtorGuard.NotNull(activeState, nameof(activeState));
            this.inactiveState = CtorGuard.NotNull(inactiveState, nameof(inactiveState));

            this.identityFactory = CtorGuard.NotNull(identityFactory, nameof(identityFactory));
        }

        public LoyaltyPointAccount CreateFromSpecification(LoyaltyPointAccountSpecification specification)
        {
            var identity = identityFactory.CreateFromSpecification(specification.Identity);

            var initialBalance = new Amount(primaryCurrency, specification.InitialBalance);

            var account = new LoyaltyPointAccount(createdState, activeState, inactiveState, identity, primaryCurrency);
            account.AddPoints(initialBalance);
            return account;
        }
    }
}