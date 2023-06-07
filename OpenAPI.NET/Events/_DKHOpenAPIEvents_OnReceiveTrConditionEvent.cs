namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveTrConditionEvent
{
    public string sScrNo;

    public string strCodeList;

    public string strConditionName;

    public int nIndex;

    public int nNext;

    public _DKHOpenAPIEvents_OnReceiveTrConditionEvent(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext)
    {
        this.sScrNo = sScrNo;
        this.strCodeList = strCodeList;
        this.strConditionName = strConditionName;
        this.nIndex = nIndex;
        this.nNext = nNext;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e);