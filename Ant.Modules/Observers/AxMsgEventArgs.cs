using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Observers;

public class AxMsgEventArgs(OpenMessage message) : MsgEventArgs
{
    public OpenMessage Message { get; } = message;
}