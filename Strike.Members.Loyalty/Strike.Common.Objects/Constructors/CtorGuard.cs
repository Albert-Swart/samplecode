using System;

namespace Strike.Common.Objects.Constructors
{
    public static class CtorGuard
    {
        public static T NotNull<T>(T argument, string argumentName)
        {
            if (argument == null)
                throw new ArgumentNullException(argumentName);

            return argument;
        }
    }
}