//using System;

//using Ninject.Modules;

//using Strike.Common.Logging.Console.Colors;
//using Strike.Common.Logging.Console.Info;
//using Strike.Common.Logging.Loggers;

//namespace Strike.Common.Logging.Console.Test
//{
//    public class ConsoleLoggingDefaultBindingsModule : NinjectModule
//    {
//        private readonly ConsoleColor infoColor;
//        private readonly string infoFormat;

//        public ConsoleLoggingDefaultBindingsModule(ConsoleColor infoColor, string infoFormat)
//        {
//            this.infoColor = infoColor;
//            this.infoFormat = infoFormat;
//        }

//        public override void Load()
//        {
//            Bind<IColorResetBehaviour>().To<HardColorResetBehaviour>();

//            Bind<IInfoLogger>().To<ConsoleInfoLogger>()
//                .WithConstructorArgument(infoColor)
//                .WithConstructorArgument(infoFormat);

//            Bind<ILogger>().To<Logger>();
//        }
//    }
//}