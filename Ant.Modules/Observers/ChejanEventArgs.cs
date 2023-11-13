using Newtonsoft.Json;

namespace ShareInvest.Observers;

public class ChejanEventArgs : MsgEventArgs
{
    public ChejanEventArgs(Type type, string json)
    {
        Convey = JsonConvert.DeserializeObject(json, type);
    }
    public object? Convey
    {
        get;
    }
}