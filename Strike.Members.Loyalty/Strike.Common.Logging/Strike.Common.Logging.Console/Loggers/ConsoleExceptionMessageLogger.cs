using System;
using UserInterface = System.Console;

using Strike.Common.Logging.Loggers;
using Strike.Common.Logging.Console.Colors;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Logging.Console.Loggers
{
    public class ConsoleExceptionMessageLogger : IExceptionMessageLogger<Exception>
    {
        private readonly ConsoleFormattedMessageConfig config;
        private readonly IConsoleColorResetBehaviour colorResetBehaviour;

        public ConsoleExceptionMessageLogger(ConsoleFormattedMessageConfig config, IConsoleColorResetBehaviour colorResetBehaviour)
        {
            this.config = CtorGuard.NotNull(config, nameof(config));
            this.colorResetBehaviour = CtorGuard.NotNull(colorResetBehaviour, nameof(colorResetBehaviour));
        }

        public void Log(Exception ex)
        {
            UserInterface.ForegroundColor = config.ForegroundColor;
            UserInterface.WriteLine(ex.Message);
            colorResetBehaviour.Reset();
        }

        public void Log(Exception ex, string message, params object[] arguments)
        {
            var formattedMessage = string.Format(message, arguments);
            var messageX = string.Format(config.MessageFormat, formattedMessage, ex);
            UserInterface.ForegroundColor = config.ForegroundColor;
            UserInterface.WriteLine(messageX);
            colorResetBehaviour.Reset();
        }
    }
}