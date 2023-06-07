namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveConditionVerEvent
{
    public int lRet;

    public string sMsg;

    public _DKHOpenAPIEvents_OnReceiveConditionVerEvent(int lRet, string sMsg)
    {
        this.lRet = lRet;
        this.sMsg = sMsg;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e);