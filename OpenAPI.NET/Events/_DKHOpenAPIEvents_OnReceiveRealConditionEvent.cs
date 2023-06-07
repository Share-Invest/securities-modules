namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveRealConditionEvent
{
    public string sTrCode;

    public string strType;

    public string strConditionName;

    public string strConditionIndex;

    public _DKHOpenAPIEvents_OnReceiveRealConditionEvent(string sTrCode, string strType, string strConditionName, string strConditionIndex)
    {
        this.sTrCode = sTrCode;
        this.strType = strType;
        this.strConditionName = strConditionName;
        this.strConditionIndex = strConditionIndex;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e);