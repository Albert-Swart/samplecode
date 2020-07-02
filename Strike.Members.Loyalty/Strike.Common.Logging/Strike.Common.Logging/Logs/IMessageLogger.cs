namespace Strike.Common.Logging.Loggers
{
    public interface IMessageLogger
    {
        void Log(string message, params object[] arguments);
    }
}