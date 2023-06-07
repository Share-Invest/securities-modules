namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveTrDataEvent
{
    public string sScrNo;

    public string sRQName;

    public string sTrCode;

    public string sRecordName;

    public string sPrevNext;

    public int nDataLength;

    public string sErrorCode;

    public string sMessage;

    public string sSplmMsg;

    public _DKHOpenAPIEvents_OnReceiveTrDataEvent(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg)
    {
        this.sScrNo = sScrNo;
        this.sRQName = sRQName;
        this.sTrCode = sTrCode;
        this.sRecordName = sRecordName;
        this.sPrevNext = sPrevNext;
        this.nDataLength = nDataLength;
        this.sErrorCode = sErrorCode;
        this.sMessage = sMessage;
        this.sSplmMsg = sSplmMsg;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveTrDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e);