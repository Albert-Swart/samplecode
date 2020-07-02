namespace Sample
{
    public static partial class NamedBindings
    {
        public static class Balances
        {
            public static class DepositBehaviour
            {
                public const string Allow = "AllowUpdates";
                public const string Ignore = "IgnoreUpdates";
            }

            public static class RetrievalBehaviour
            {
                public const string Allow = "AllowReads";
                public const string Dissalow = "DisallowReads";
            }
        }
    }
}