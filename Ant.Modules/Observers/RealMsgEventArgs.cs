namespace ShareInvest.Observers;

public class RealMsgEventArgs : MsgEventArgs
{
    public string Type
    {
        get;
    }
    public string Key
    {
        get;
    }
    public string Data
    {
        get;
    }
    public RealMsgEventArgs(string type, string key, string data)
    {
        Type = type;
        Key = key;
        Data = data;
    }
}