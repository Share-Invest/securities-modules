namespace ShareInvest.Observers;

public class ChejanEventArgs : MsgEventArgs
{
    public ChejanType Type
    {
        get;
    }
    public Dictionary<string, string> Data
    {
        get;
    }
    public ChejanEventArgs(ChejanType type, Dictionary<string, string> data)
    {
        Type = type;
        Data = data;
    }
}