namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveChejanDataEvent
{
    public string sGubun;

    public int nItemCnt;

    public string sFIdList;

    public _DKHOpenAPIEvents_OnReceiveChejanDataEvent(string sGubun, int nItemCnt, string sFIdList)
    {
        this.sGubun = sGubun;
        this.nItemCnt = nItemCnt;
        this.sFIdList = sFIdList;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e);