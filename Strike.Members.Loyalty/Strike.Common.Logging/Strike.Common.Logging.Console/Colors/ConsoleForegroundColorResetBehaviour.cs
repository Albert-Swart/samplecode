using System;
using UserInterface = System.Console;

namespace Strike.Common.Logging.Console.Colors
{
    public class ConsoleForegroundColorResetBehaviour : IConsoleColorResetBehaviour
    {
        private readonly ConsoleColor defaultColor;

        public ConsoleForegroundColorResetBehaviour(ConsoleColor defaultColor)
        {
            this.defaultColor = defaultColor;
        }

        public void Reset()
        {
            UserInterface.ForegroundColor = defaultColor;
        }
    }
}