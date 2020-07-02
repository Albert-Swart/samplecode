using System;

namespace Strike.Common.Objects.Assertions
{
    public static class Assert
    {
        public static void NotNull(object argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);
        }

        public static void SameValue(string expected, string actual, string message)
        {
            if (actual != expected)
                throw new ArgumentException(message);
        }
    }
}
