using System;

namespace Strike.Common.Logging.Loggers
{
    public interface ILog
    {
        void Trace(string message, params object[] arguments);

        void Info(string message, params object[] arguments);

        void Warning(string message, params object[] arguments);

        void Error(string message, params object[] arguments);

        void Exception(Exception ex, string message, params object[] arguments);
    }
}