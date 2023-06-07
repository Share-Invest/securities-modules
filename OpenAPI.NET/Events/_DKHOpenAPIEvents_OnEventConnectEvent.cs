namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnEventConnectEvent
{
    public int nErrCode;

    public _DKHOpenAPIEvents_OnEventConnectEvent(int nErrCode)
    {
        this.nErrCode = nErrCode;
    }
}
public delegate void _DKHOpenAPIEvents_OnEventConnectEventHandler(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e);