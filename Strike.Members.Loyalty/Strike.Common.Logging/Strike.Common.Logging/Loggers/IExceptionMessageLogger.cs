using System;

namespace Strike.Common.Logging.Loggers
{
    public interface IExceptionMessageLogger<TException> where TException : Exception
    {
        void Log(TException ex, string message, params object[] arguments);
    }
}