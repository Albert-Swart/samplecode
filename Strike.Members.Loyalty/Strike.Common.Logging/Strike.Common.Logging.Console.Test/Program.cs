using System;
using UserInterface = System.Console;

using Ninject;

using Strike.Common.Logging.Console.Ninject;
using Strike.Common.Logging.Loggers;

namespace Strike.Common.Logging.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLoggingModule = new StandardConsoleLoggingBindings(UserInterface.ForegroundColor);

            var kernel = new StandardKernel();
            kernel.Load(consoleLoggingModule);

            var log = kernel.Get<ILog>();

            log.Trace("Test trace message.");
            log.Info("Test info message.");
            log.Warning("Test warning message.");
            log.Error("Test error message.");

            try
            {
                throw new ArgumentNullException();
            }
            catch(ArgumentNullException ex)
            {
                log.Exception(ex, "Test {0} exception message.", 123);
            }

            var logger = kernel.Get<ILogger>();

            logger.LogTrace("Test trace message.");
            logger.LogInfo("Test info message.");
            logger.LogWarning("Test warning message.");
            logger.LogError("Test error message.");

            try
            {
                throw new ArgumentNullException();
            }
            catch (ArgumentNullException ex)
            {
                logger.LogException(ex, "Test {0} exception message.", 123);
            }

        }
    }
}