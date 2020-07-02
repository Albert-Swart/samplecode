using System;

namespace Strike.Common.Logging.Loggers
{
    public class Logger : ILogger
    {
        private readonly IMessageLogger traceMessageLogger;
        private readonly IMessageLogger infoMessageLogger;
        private readonly IMessageLogger warningMessageLogger;
        private readonly IMessageLogger errorMessageLogger;
        private readonly IExceptionMessageLogger exceptionMessageLogger;

        public Logger(
            IMessageLogger traceMessageLogger,
            IMessageLogger infoMessageLogger,
            IMessageLogger warningMessageLogger,
            IMessageLogger errorMessageLogger,
            IExceptionMessageLogger exceptionMessageLogger)
        {
            this.traceMessageLogger = traceMessageLogger ?? throw new System.ArgumentNullException(nameof(traceMessageLogger));
            this.infoMessageLogger = infoMessageLogger ?? throw new System.ArgumentNullException(nameof(infoMessageLogger));
            this.warningMessageLogger = warningMessageLogger ?? throw new System.ArgumentNullException(nameof(warningMessageLogger));
            this.errorMessageLogger = errorMessageLogger ?? throw new System.ArgumentNullException(nameof(errorMessageLogger));
            this.exceptionMessageLogger = exceptionMessageLogger ?? throw new System.ArgumentNullException(nameof(exceptionMessageLogger));
        }

        public void LogError(string message, params object[] arguments)
        {
            errorMessageLogger.Log(message, arguments);
        }

        public void LogException(Exception ex, string message, params object[] arguments)
        {
            exceptionMessageLogger.Log(ex, message, arguments);
        }

        public void LogInfo(string message, params object[] arguments)
        {
            infoMessageLogger.Log(message, arguments);
        }

        public void LogTrace(string message, params object[] arguments)
        {
            traceMessageLogger.Log(message, arguments);
        }

        public void LogWarning(string message, params object[] arguments)
        {
            warningMessageLogger.Log(message, arguments);
        }
    }
}