namespace ShareInvest.Entities.Google.Firebase;

public class CloudMulticastMessage : CloudMessage
{
    public IReadOnlyList<string>? Tokens
    {
        get; set;
    }
}