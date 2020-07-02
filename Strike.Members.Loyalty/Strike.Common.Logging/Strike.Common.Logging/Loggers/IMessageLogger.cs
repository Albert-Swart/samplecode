namespace Strike.Common.Logging.Loggers
{
    public interface IMessageLogger<TContext>
    {
        void Log(string message, TContext context);
    }
}