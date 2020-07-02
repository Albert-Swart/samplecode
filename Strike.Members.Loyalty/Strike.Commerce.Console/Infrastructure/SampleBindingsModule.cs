using System.Collections.Generic;

using Ninject;
using Ninject.Modules;

using Strike.Common.Objects.Factories;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Amounts;
using Strike.PowerPlay.Loyalty.Accounts;

namespace Sample
{
    public class SampleBindingsModule : NinjectModule
    {
        private readonly Currency loyaltyPoints;
        private readonly Currency zar;
        private readonly IList<Amount> transactions;

        public SampleBindingsModule(Currency loyaltyPoints, Currency zar, IList<Amount> transactions)
        {
            this.loyaltyPoints = loyaltyPoints;
            this.zar = zar;
            this.transactions = transactions;
        }

        public override void Load()
        {
            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.ActiveStateLogging>()
                .Named(NamedBindings.Accounts.Status.Active);

            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.ActiveState>()
                .WhenInjectedInto<LoyaltyPointAccount.ActiveStateLogging>()
                .WithConstructorArgument("balanceRetrievalMethod", context => context.Kernel.Get<ILoyaltyPointAccountBalanceRetrievalMethod>(NamedBindings.Balances.RetrievalBehaviour.Allow))
                .WithConstructorArgument("depositMethod", context => context.Kernel.Get<ILoyaltyPointAccountDepositMethod>(NamedBindings.Balances.DepositBehaviour.Allow));

            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.InactiveStateLogging>()
                .Named(NamedBindings.Accounts.Status.Inactive);

            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.InactiveState>()
                .WhenInjectedInto<LoyaltyPointAccount.InactiveStateLogging>()
                .WithConstructorArgument("balanceRetrievalMethod", context => context.Kernel.Get<ILoyaltyPointAccountBalanceRetrievalMethod>(NamedBindings.Balances.RetrievalBehaviour.Allow))
                .WithConstructorArgument("depositMethod", context => context.Kernel.Get<ILoyaltyPointAccountDepositMethod>(NamedBindings.Balances.DepositBehaviour.Ignore));

            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.CreatedStateLogging>()
                .Named(NamedBindings.Accounts.Status.Created);

            Bind<LoyaltyPointAccount.IAccountState>().To<LoyaltyPointAccount.CreatedState>()
                .WhenInjectedInto<LoyaltyPointAccount.CreatedStateLogging>()
                .WithConstructorArgument("balanceRetrievalMethod", context => context.Kernel.Get<ILoyaltyPointAccountBalanceRetrievalMethod>(NamedBindings.Balances.RetrievalBehaviour.Allow))
                .WithConstructorArgument("depositMethod", context => context.Kernel.Get<ILoyaltyPointAccountDepositMethod>(NamedBindings.Balances.DepositBehaviour.Allow));

            Bind<ILoyaltyPointAccountBalanceRetrievalMethod>().To<LoyaltyPointAccountBalanceRetrievalMethodLogging>()
                .Named(NamedBindings.Balances.RetrievalBehaviour.Allow);

            Bind<ILoyaltyPointAccountBalanceRetrievalMethod>().To<DemoAccountBalanceRetrievalMethod>()
                .WhenInjectedInto<LoyaltyPointAccountBalanceRetrievalMethodLogging>()
                .InSingletonScope()
                .WithConstructorArgument(transactions as IEnumerable<Amount>)
                .WithConstructorArgument(loyaltyPoints);

            Bind<ILoyaltyPointAccountDepositMethod>().To<AssumeSingleAccountDepositMethodForDemo>()
                .InSingletonScope()
                .Named(NamedBindings.Balances.DepositBehaviour.Allow)
                .WithConstructorArgument(transactions);// as IList<Amount>);

            Bind<ILoyaltyPointAccountDepositMethod>().To<IgnoreAccountDepositMethod>()
                .Named(NamedBindings.Balances.DepositBehaviour.Ignore);

            Bind<ICurrencyExchangeRateProvider>().To<CurrencyExchangeRateProvider>();

            Bind<ICurrencyAdaptor>().To<CurrencyAdaptorLogging>();

            Bind<ICurrencyAdaptor>().To<CurrencyAdaptor>()
                .WhenInjectedInto<CurrencyAdaptorLogging>();

            Bind<ICurrencyExchangeRate>().To<FixedCurrencyExchangeRate>()
                .WithConstructorArgument("source", loyaltyPoints)
                .WithConstructorArgument("target", zar)
                .WithConstructorArgument(5.0M);

            Bind<ICurrencyExchangeRate>().To<FixedCurrencyExchangeRate>()
                .WithConstructorArgument("source", loyaltyPoints)
                .WithConstructorArgument("target", loyaltyPoints)
                .WithConstructorArgument(1.0M);

            Bind<ICurrencyExchangeRate>().To<FixedCurrencyExchangeRate>()
                .WithConstructorArgument("source", zar)
                .WithConstructorArgument("target", loyaltyPoints)
                .WithConstructorArgument(8.0M);

            Bind<ISpecificationFactory<LoyaltyPointAccount, LoyaltyPointAccountSpecification>>().To<LoyaltyPointAccountFactory>()
                .WithConstructorArgument(loyaltyPoints)
                .WithConstructorArgument("createdState", context => context.Kernel.Get<LoyaltyPointAccount.IAccountState>(NamedBindings.Accounts.Status.Created))
                .WithConstructorArgument("inactiveState", context => context.Kernel.Get<LoyaltyPointAccount.IAccountState>(NamedBindings.Accounts.Status.Inactive))
                .WithConstructorArgument("activeState", context => context.Kernel.Get<LoyaltyPointAccount.IAccountState>(NamedBindings.Accounts.Status.Active));

            Bind<ISpecificationFactory<LoyaltyPointAccountIdentity, LoyaltyPointAccountIdentitySpecification>>().To<LoyaltyPointAccountIdentityFactory>();

            Bind<ILoyaltyPointAccountDeactivationMethod>().To<LoyaltyPointAccountDeactivationMethodStub>();

            Bind<ILoyaltyPointAccountReactivationMethod>().To<LoyaltyPointAccountReactivationMethodStub>();

            Bind<ILoyaltyPointAccountActivationMethod>().To<LoyaltyPointAccountActivationMethodStub>();

            Bind<IRenderMethod<LoyaltyPointAccountIdentity>>().To<LogFriendlyLoyaltyPointAccountIdentityRenderMethod>();
        }
    }
}