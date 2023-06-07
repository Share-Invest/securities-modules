namespace ShareInvest.Events;

public class _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent
{
    public string sRealKey;

    public _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(string sRealKey)
    {
        this.sRealKey = sRealKey;
    }
}
public delegate void _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e);