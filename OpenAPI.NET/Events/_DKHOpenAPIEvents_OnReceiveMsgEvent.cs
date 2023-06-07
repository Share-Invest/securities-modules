namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveMsgEvent
{
    public string sScrNo;

    public string sRQName;

    public string sTrCode;

    public string sMsg;

    public _DKHOpenAPIEvents_OnReceiveMsgEvent(string sScrNo, string sRQName, string sTrCode, string sMsg)
    {
        this.sScrNo = sScrNo;
        this.sRQName = sRQName;
        this.sTrCode = sTrCode;
        this.sMsg = sMsg;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveMsgEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e);