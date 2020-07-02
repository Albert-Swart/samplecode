using System;

using Ninject;
using Ninject.Modules;

using Strike.Common.Logging.Logs;
using Strike.Common.Logging.Loggers;
using Strike.Common.Logging.Console.Colors;
using Strike.Common.Logging.Console.Loggers;

namespace Strike.Common.Logging.Console.Ninject
{
    public class StandardConsoleLoggingBindings : NinjectModule
    {
        private readonly ConsoleColor defaultForegroundColor;
        private readonly ConsoleFormattedMessageConfig traceConfig;
        private readonly ConsoleFormattedMessageConfig infoConfig;
        private readonly ConsoleFormattedMessageConfig warningConfig;
        private readonly ConsoleFormattedMessageConfig errorConfig;
        private readonly ConsoleFormattedMessageConfig exceptionConfig;

        public StandardConsoleLoggingBindings(ConsoleColor defaultForegroundColor) : this(
            defaultForegroundColor, StandardMessageConfig.TraceMessages, StandardMessageConfig.InfoMessages,
            StandardMessageConfig.WarningMessages, StandardMessageConfig.ErrorMessages, StandardMessageConfig.ExceptionMessages)
        { }

        public StandardConsoleLoggingBindings(
            ConsoleColor defaultForegroundColor,
            ConsoleFormattedMessageConfig traceConfig,
            ConsoleFormattedMessageConfig infoConfig,
            ConsoleFormattedMessageConfig warningConfig,
            ConsoleFormattedMessageConfig errorConfig,
            ConsoleFormattedMessageConfig exceptionConfig)
        {
            this.defaultForegroundColor = defaultForegroundColor;
            this.traceConfig = traceConfig ?? throw new ArgumentNullException(nameof(traceConfig));
            this.infoConfig = infoConfig ?? throw new ArgumentNullException(nameof(infoConfig));
            this.warningConfig = warningConfig ?? throw new ArgumentNullException(nameof(warningConfig));
            this.errorConfig = errorConfig ?? throw new ArgumentNullException(nameof(errorConfig));
            this.exceptionConfig = exceptionConfig ?? throw new ArgumentNullException(nameof(exceptionConfig));
        }

        public override void Load()
        {
            Bind<IConsoleColorResetBehaviour>().To<ConsoleForegroundColorResetBehaviour>()
                .WithConstructorArgument(defaultForegroundColor);

            Bind<IMessageLogger<object[]>>().To<FormattedMessageLogger>()
                .Named("Trace")
                .WithConstructorArgument(traceConfig);

            Bind<IMessageLogger<object[]>>().To<FormattedMessageLogger>()
                .Named("Info")
                .WithConstructorArgument(infoConfig);

            Bind<IMessageLogger<object[]>>().To<FormattedMessageLogger>()
                .Named("Warning")
                .WithConstructorArgument(warningConfig);

            Bind<IMessageLogger<object[]>>().To<FormattedMessageLogger>()
                .Named("Error")
                .WithConstructorArgument(errorConfig);

            Bind<IExceptionMessageLogger<Exception>>().To<ConsoleExceptionMessageLogger>()
                .Named("Exception")
                .WithConstructorArgument(exceptionConfig);

            Bind<ILog>().To<StandardLog>()
                .WithConstructorArgument("traceLogger", context => context.Kernel.Get<IMessageLogger<object[]>>("Trace"))
                .WithConstructorArgument("infoLogger", context => context.Kernel.Get<IMessageLogger<object[]>>("Info"))
                .WithConstructorArgument("warningLogger", context => context.Kernel.Get<IMessageLogger<object[]>>("Warning"))
                .WithConstructorArgument("errorLogger", context => context.Kernel.Get<IMessageLogger<object[]>>("Error"))
                .WithConstructorArgument("exceptionLogger", context => context.Kernel.Get<IExceptionMessageLogger<Exception>>("Exception"));
        }
    }
}