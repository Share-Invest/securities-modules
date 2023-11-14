using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Observers;

public class TrMsgEventArgs : MsgEventArgs
{
    public TrMsgEventArgs(TR tr, string json)
    {
        Json = json;
        HubMethodName = tr.GetType().Name;
    }
    public string HubMethodName
    {
        get;
    }
    public string Json
    {
        get;
    }
}