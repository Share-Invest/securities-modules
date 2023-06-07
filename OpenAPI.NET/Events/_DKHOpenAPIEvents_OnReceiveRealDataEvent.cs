namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveRealDataEvent
{
    public string sRealKey;

    public string sRealType;

    public string sRealData;

    public _DKHOpenAPIEvents_OnReceiveRealDataEvent(string sRealKey, string sRealType, string sRealData)
    {
        this.sRealKey = sRealKey;
        this.sRealType = sRealType;
        this.sRealData = sRealData;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e);