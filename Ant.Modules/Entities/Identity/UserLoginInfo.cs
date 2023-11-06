namespace ShareInvest.Entities.Identity;

public struct UserLoginInfo
{
    public string LoginProvider
    {
        get; set;
    }
    public string ProviderKey
    {
        get; set;
    }
}