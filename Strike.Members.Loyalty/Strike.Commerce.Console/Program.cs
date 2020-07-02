using System.Collections.Generic;
using UserInterface = System.Console;

using Ninject;

using Strike.Common.Objects.Factories;
using Strike.Common.Logging.Console.Ninject;
using Strike.Common.Accounts.Currencies;
using Strike.Common.Accounts.Amounts;

using Strike.PowerPlay.Loyalty.Accounts;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var loyaltyPoints = new Currency("LOYALTYPOINTS", "MONSTER.POWERPLAY");
            var zar = new Currency("ZAR", "ISO.4217");

            var transactions = new List<Amount>();

            var kernel = new StandardKernel();

            kernel.Load(
                new SampleBindingsModule(loyaltyPoints, zar, transactions), 
                new StandardConsoleLoggingBindings(UserInterface.ForegroundColor));

            var accountSpecificationFactory = kernel.Get<ISpecificationFactory<LoyaltyPointAccount, LoyaltyPointAccountSpecification>>();

            var accountSpecification = LoyaltyPointAccountSpecificationBuilder.Start()
                .WithIdentity(LoyaltyPointAccountIdentitySpecificationBuilder.Start()
                    .WithMsisdn("27818289111"))
                .WithInitialLoyaltyPoints(100)
                .Build();

            var account = accountSpecificationFactory.CreateFromSpecification(accountSpecification);

            account.Activate();

            account.AddPoints(new Amount(loyaltyPoints, 5));

            account.Deactivate();

            account.AddPoints(new Amount(loyaltyPoints, 10));

            account.Activate();

            account.AddPoints(new Amount(zar, 1));

            Console.ReadLine();
        }
    }
}