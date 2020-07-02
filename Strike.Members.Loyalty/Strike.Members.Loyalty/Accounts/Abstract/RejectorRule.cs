namespace Strike.PowerPlay.Loyalty.Accounts
{
    public abstract class RejectorRule<TContext, TValue> : IRejectorRule<TContext, TValue>, IRejectionReason
    {
        public abstract string Reason { get; }

        public abstract bool RejectValue(TContext context, TValue value);
    }
}