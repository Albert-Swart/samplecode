namespace Strike.Members.Loyalty.Accounts
{
    public interface IExpectAccountMemberName
    {
        IExpectLoyaltyPointMemberPrimaryMsisdn WithMemberName(string name);
    }
}