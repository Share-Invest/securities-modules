using Newtonsoft.Json;

using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Observers;

public class HubOpenMsgArgs : MsgEventArgs
{
    public OpenMessage Message
    {
        get;
    }
    public HubOpenMsgArgs(string json)
    {
        if (JsonConvert.DeserializeObject<OpenMessage>(json) is OpenMessage msg)
        {
            msg.Lookup = DateTime.Now.Ticks;

            Message = msg;
        }
        else
        {
            throw new InvalidCastException(json);
        }
    }
    public HubOpenMsgArgs(OpenMessage message)
    {
        Message = message;
    }
}