using System;

using Strike.Common.Logging.Console.Loggers;

namespace Strike.Common.Logging.Console.Ninject
{
    public static class StandardMessageConfig
    {
        public static ConsoleFormattedMessageConfig TraceMessages = new ConsoleFormattedMessageConfig
        {
            ForegroundColor = ConsoleColor.Gray,
            MessageFormat = "TRACE: {0}"
        };

        public static ConsoleFormattedMessageConfig InfoMessages = new ConsoleFormattedMessageConfig
        {
            ForegroundColor = ConsoleColor.White, MessageFormat = "INFO: {0}"
        };

        public static ConsoleFormattedMessageConfig WarningMessages = new ConsoleFormattedMessageConfig
        {
            ForegroundColor = ConsoleColor.Yellow,
            MessageFormat = "WARNING: {0}"
        };

        public static ConsoleFormattedMessageConfig ErrorMessages = new ConsoleFormattedMessageConfig
        {
            ForegroundColor = ConsoleColor.Red,
            MessageFormat = "ERROR: {0}"
        };

        public static ConsoleFormattedMessageConfig ExceptionMessages = new ConsoleFormattedMessageConfig
        {
            ForegroundColor = ConsoleColor.Red,
            MessageFormat = "EXCEPTION: {0}\n{1}",
        };
    }
}