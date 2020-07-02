using System;
using UserInterface = System.Console;

using Strike.Common.Logging.Loggers;
using Strike.Common.Logging.Console.Colors;

namespace Strike.Common.Logging.Console.Loggers
{
    public class FormattedMessageLogger : IMessageLogger<object[]>
    {
        private readonly ConsoleFormattedMessageConfig config;
        private readonly IConsoleColorResetBehaviour colorResetBehaviour;

        public FormattedMessageLogger(ConsoleFormattedMessageConfig config, IConsoleColorResetBehaviour colorResetBehaviour)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.colorResetBehaviour = colorResetBehaviour;
        }

        public void Log(string message, params object[] arguments)
        {
            var formattedMessage = string.Format(config.MessageFormat, message);
            UserInterface.ForegroundColor = config.ForegroundColor;
            UserInterface.WriteLine(formattedMessage, arguments);
            colorResetBehaviour.Reset();
        }
    }
}