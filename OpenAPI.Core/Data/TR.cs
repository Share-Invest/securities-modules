namespace ShareInvest.Data;

public class TR
{
    public string? Code
    {
        get; internal set;
    }
    public string? Name
    {
        get; internal set;
    }
    public Dictionary<string, string>? Input
    {
        get; internal set;
    }
    public string[]? SingleData
    {
        get; internal set;
    }
    public string[]? MultiData
    {
        get; internal set;
    }
}