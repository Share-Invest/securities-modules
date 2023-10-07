using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Observers;

public class AxMsgEventArgs : MsgEventArgs
{
    public OpenMessage Message
    {
        get;
    }
    public AxMsgEventArgs(OpenMessage message)
    {
        Message = message;
    }
}