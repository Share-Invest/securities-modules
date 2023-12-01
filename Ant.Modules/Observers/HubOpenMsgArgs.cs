using Newtonsoft.Json;

using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Observers;

public class HubOpenMsgArgs : MsgEventArgs
{
    public HubOpenMsgArgs(string serialKey, string json)
    {
        var msg = JsonConvert.DeserializeObject<OpenMessage>(json);

        if (msg != null)
        {
            msg.Lookup = DateTime.Now.Ticks;
        }
        else
        {
            msg = new OpenMessage { SerialKey = serialKey };
        }
        Message = msg;
    }
    public OpenMessage Message
    {
        get;
    }
}