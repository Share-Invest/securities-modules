using ShareInvest.Events;
using ShareInvest.Interface;

using System.Runtime.InteropServices;

namespace ShareInvest.Kiwoom;

[ClassInterface(ClassInterfaceType.None)]
public class AxKHOpenAPIEventMulticaster : _DKHOpenAPIEvents
{
    public virtual void OnReceiveTrData(string sScrNo, string sRQName, string sTrCode, string sRecordName, string sPrevNext, int nDataLength, string sErrorCode, string sMessage, string sSplmMsg)
    {
        parent.RaiseOnOnReceiveTrData(parent, new _DKHOpenAPIEvents_OnReceiveTrDataEvent(sScrNo, sRQName, sTrCode, sRecordName, sPrevNext, nDataLength, sErrorCode, sMessage, sSplmMsg));
    }
    public virtual void OnReceiveRealData(string sRealKey, string sRealType, string sRealData)
    {
        parent.RaiseOnOnReceiveRealData(parent, new _DKHOpenAPIEvents_OnReceiveRealDataEvent(sRealKey, sRealType, sRealData));
    }
    public virtual void OnReceiveMsg(string sScrNo, string sRQName, string sTrCode, string sMsg)
    {
        parent.RaiseOnOnReceiveMsg(parent, new _DKHOpenAPIEvents_OnReceiveMsgEvent(sScrNo, sRQName, sTrCode, sMsg));
    }
    public virtual void OnReceiveChejanData(string sGubun, int nItemCnt, string sFIdList)
    {
        parent.RaiseOnOnReceiveChejanData(parent, new _DKHOpenAPIEvents_OnReceiveChejanDataEvent(sGubun, nItemCnt, sFIdList));
    }
    public virtual void OnEventConnect(int nErrCode)
    {
        parent.RaiseOnOnEventConnect(parent, new _DKHOpenAPIEvents_OnEventConnectEvent(nErrCode));
    }
    public virtual void OnReceiveInvestRealData(string sRealKey)
    {
        parent.RaiseOnOnReceiveInvestRealData(parent, new _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent(sRealKey));
    }
    public virtual void OnReceiveRealCondition(string sTrCode, string strType, string strConditionName, string strConditionIndex)
    {
        parent.RaiseOnOnReceiveRealCondition(parent, new _DKHOpenAPIEvents_OnReceiveRealConditionEvent(sTrCode, strType, strConditionName, strConditionIndex));
    }
    public virtual void OnReceiveTrCondition(string sScrNo, string strCodeList, string strConditionName, int nIndex, int nNext)
    {
        parent.RaiseOnOnReceiveTrCondition(parent, new _DKHOpenAPIEvents_OnReceiveTrConditionEvent(sScrNo, strCodeList, strConditionName, nIndex, nNext));
    }
    public virtual void OnReceiveConditionVer(int lRet, string sMsg)
    {
        parent.RaiseOnOnReceiveConditionVer(parent, new _DKHOpenAPIEvents_OnReceiveConditionVerEvent(lRet, sMsg));
    }
    public AxKHOpenAPIEventMulticaster(AxKHOpenAPI parent)
    {
        this.parent = parent;
    }
    readonly AxKHOpenAPI parent;
}