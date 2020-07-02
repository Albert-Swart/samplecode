namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IRejectorRule<TContext, TValue>
    {
        bool RejectValue(TContext context, TValue value);
    }
}