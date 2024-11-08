namespace ShareInvest.Observers;

public class RealMsgEventArgs(string type, string key, string data) : MsgEventArgs
{
    public string Type { get; } = type;

    public string Key { get; } = key;

    public string Data { get; } = data;
}