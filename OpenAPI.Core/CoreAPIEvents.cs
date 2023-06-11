using ShareInvest.Events;

namespace ShareInvest;

public sealed partial class AxKHCoreAPI
{
    void OnEventCoreConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
    {

    }
    void OnReceiveCoreMessage(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
    {
    }
    void OnReceiveCoreTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
    {

    }
    void OnReceiveCoreRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
    {

    }
    void OnReceiveCoreChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
    {

    }
    void OnReceiveCoreTrCondition(object _, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
    {
        throw new NotImplementedException("no plans to implement.");
    }
    void OnReceiveCoreRealCondition(object _, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
    {
        throw new NotImplementedException("no plans to implement.");
    }
    void OnReceiveCoreConditionVersion(object _, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
    {
        throw new NotImplementedException("no plans to implement.");
    }
}