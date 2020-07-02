using System;

using Strike.Common.Logging.Loggers;
using Strike.Common.Objects.Constructors;

namespace Strike.Common.Logging.Logs
{
    public class StandardLog : ILog
    {
        private readonly IMessageLogger<object[]> traceLogger;
        private readonly IMessageLogger<object[]> infoLogger;
        private readonly IMessageLogger<object[]> warningLogger;
        private readonly IMessageLogger<object[]> errorLogger;
        private readonly IExceptionMessageLogger<Exception> exceptionLogger;

        public StandardLog(
            IMessageLogger<object[]> traceLogger,
            IMessageLogger<object[]> infoLogger,
            IMessageLogger<object[]> warningLogger,
            IMessageLogger<object[]> errorLogger,
            IExceptionMessageLogger<Exception> exceptionLogger)
        {
            this.traceLogger = CtorGuard.NotNull(traceLogger, nameof(traceLogger));
            this.infoLogger = CtorGuard.NotNull(infoLogger, nameof(infoLogger));
            this.warningLogger = CtorGuard.NotNull(warningLogger, nameof(warningLogger));
            this.errorLogger = CtorGuard.NotNull(errorLogger, nameof(errorLogger));
            this.exceptionLogger = CtorGuard.NotNull(exceptionLogger, nameof(exceptionLogger));
        }

        public void Error(string message, params object[] arguments)
        {
            errorLogger.Log(message, arguments);
        }

        public void Exception(Exception ex, string message, params object[] arguments)
        {
            exceptionLogger.Log(ex, message, arguments);
        }

        public void Info(string message, params object[] arguments)
        {
            infoLogger.Log(message, arguments);
        }

        public void Trace(string message, params object[] arguments)
        {
            traceLogger.Log(message, arguments);
        }

        public void Warning(string message, params object[] arguments)
        {
            warningLogger.Log(message, arguments);
        }
    }
}