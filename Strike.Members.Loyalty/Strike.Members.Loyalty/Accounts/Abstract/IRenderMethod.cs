namespace Strike.PowerPlay.Loyalty.Accounts
{
    public interface IRenderMethod<T> where T : class
    {
        string Render(T obj);
    }
}