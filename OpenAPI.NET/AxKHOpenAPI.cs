using ShareInvest.Events;
using ShareInvest.Interface;

using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace ShareInvest.Kiwoom;

public class AxKHOpenAPI
{
    public event _DKHOpenAPIEvents_OnReceiveTrDataEventHandler? OnReceiveTrData;

    public event _DKHOpenAPIEvents_OnReceiveRealDataEventHandler? OnReceiveRealData;

    public event _DKHOpenAPIEvents_OnReceiveMsgEventHandler? OnReceiveMsg;

    public event _DKHOpenAPIEvents_OnReceiveChejanDataEventHandler? OnReceiveChejanData;

    public event _DKHOpenAPIEvents_OnEventConnectEventHandler? OnEventConnect;

    public event _DKHOpenAPIEvents_OnReceiveInvestRealDataEventHandler? OnReceiveInvestRealData;

    public event _DKHOpenAPIEvents_OnReceiveRealConditionEventHandler? OnReceiveRealCondition;

    public event _DKHOpenAPIEvents_OnReceiveTrConditionEventHandler? OnReceiveTrCondition;

    public event _DKHOpenAPIEvents_OnReceiveConditionVerEventHandler? OnReceiveConditionVer;

    public bool Created
    {
        get;
    }
    public AxKHOpenAPI(IntPtr hWndParent)
    {
        string clsid = Environment.Is64BitProcess ? x64 : x86;

        if (!Created)
        {
            if (AtlAxWinInit())
            {
                hWndContainer = CreateWindowEx(0, "AtlAxWin", clsid, WS_VISIBLE | WS_CHILD, -100, -100, 20, 20, hWndParent, (IntPtr)9001, IntPtr.Zero, IntPtr.Zero);

                if (hWndContainer != IntPtr.Zero)
                {
                    try
                    {
                        _ = AtlAxGetControl(hWndContainer, out object pUnknown);

                        if (pUnknown != null)
                        {
                            ocx = (_DKHOpenAPI)pUnknown;

                            if (ocx != null)
                            {
                                Guid guidEvents = typeof(_DKHOpenAPIEvents).GUID;

                                ((IConnectionPointContainer)pUnknown).FindConnectionPoint(ref guidEvents, out _pConnectionPoint);

                                if (_pConnectionPoint != null)
                                {
                                    _pConnectionPoint.Advise(new AxKHOpenAPIEventMulticaster(this), out _nCookie);

                                    Created = true;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        DestroyWindow(hWndContainer);

                        hWndContainer = IntPtr.Zero;
                    }
                }
            }
        }
    }
    public virtual int CommConnect()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommConnect), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.CommConnect();
    }
    public virtual void CommTerminate()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommTerminate), ActiveXInvokeKind.MethodInvoke);
        }
        ocx.CommTerminate();
    }
    public virtual int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommRqData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
    }
    public virtual string GetLoginInfo(string sTag)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetLoginInfo), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetLoginInfo(sTag);
    }
    public virtual int SendOrder(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sOrgOrderNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SendOrder), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SendOrder(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sOrgOrderNo);
    }
    public virtual int SendOrderFO(string sRQName, string sScreenNo, string sAccNo, string sCode, int lOrdKind, string sSlbyTp, string sOrdTp, int lQty, string sPrice, string sOrgOrdNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SendOrderFO), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SendOrderFO(sRQName, sScreenNo, sAccNo, sCode, lOrdKind, sSlbyTp, sOrdTp, lQty, sPrice, sOrgOrdNo);
    }
    public virtual void SetInputValue(string sID, string sValue)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SetInputValue), ActiveXInvokeKind.MethodInvoke);
        }
        ocx.SetInputValue(sID, sValue);
    }
    public virtual int SetOutputFID(string sID)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SetOutputFID), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SetOutputFID(sID);
    }
    public virtual string CommGetData(string sJongmokCode, string sRealType, string sFieldName, int nIndex, string sInnerFieldName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommGetData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.CommGetData(sJongmokCode, sRealType, sFieldName, nIndex, sInnerFieldName);
    }
    public virtual void DisconnectRealData(string sScnNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(DisconnectRealData), ActiveXInvokeKind.MethodInvoke);
        }
        ocx.DisconnectRealData(sScnNo);
    }
    public virtual int GetRepeatCnt(string sTrCode, string sRecordName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetRepeatCnt), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetRepeatCnt(sTrCode, sRecordName);
    }
    public virtual int CommKwRqData(string sArrCode, int bNext, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommKwRqData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.CommKwRqData(sArrCode, bNext, nCodeCount, nTypeFlag, sRQName, sScreenNo);
    }
    public virtual string GetAPIModulePath()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetAPIModulePath), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetAPIModulePath();
    }
    public virtual string GetCodeListByMarket(string sMarket)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetCodeListByMarket), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetCodeListByMarket(sMarket);
    }
    public virtual int GetConnectState()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetConnectState), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetConnectState();
    }
    public virtual string GetMasterCodeName(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterCodeName), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterCodeName(sTrCode);
    }
    public virtual int GetMasterListedStockCnt(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterListedStockCnt), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterListedStockCnt(sTrCode);
    }
    public virtual string GetMasterConstruction(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterConstruction), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterConstruction(sTrCode);
    }
    public virtual string GetMasterListedStockDate(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterListedStockDate), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterListedStockDate(sTrCode);
    }
    public virtual string GetMasterLastPrice(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterLastPrice), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterLastPrice(sTrCode);
    }
    public virtual string GetMasterStockState(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMasterStockState), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMasterStockState(sTrCode);
    }
    public virtual int GetDataCount(string strRecordName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetDataCount), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetDataCount(strRecordName);
    }
    public virtual string GetOutputValue(string strRecordName, int nRepeatIdx, int nItemIdx)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetOutputValue), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetOutputValue(strRecordName, nRepeatIdx, nItemIdx);
    }
    public virtual string GetCommData(string strTrCode, string strRecordName, int nIndex, string strItemName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetCommData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetCommData(strTrCode, strRecordName, nIndex, strItemName);
    }
    public virtual string GetCommRealData(string sTrCode, int nFid)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetCommRealData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetCommRealData(sTrCode, nFid);
    }
    public virtual string GetChejanData(int nFid)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetChejanData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetChejanData(nFid);
    }
    public virtual string GetThemeGroupList(int nType)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetThemeGroupList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetThemeGroupList(nType);
    }
    public virtual string GetThemeGroupCode(string strThemeCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetThemeGroupCode), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetThemeGroupCode(strThemeCode);
    }
    public virtual string GetFutureList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetFutureList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetFutureList();
    }
    public virtual string GetFutureCodeByIndex(int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetFutureCodeByIndex), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetFutureCodeByIndex(nIndex);
    }
    public virtual string GetActPriceList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetActPriceList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetActPriceList();
    }
    public virtual string GetMonthList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMonthList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMonthList();
    }
    public virtual string GetOptionCode(string strActPrice, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetOptionCode), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetOptionCode(strActPrice, nCp, strMonth);
    }
    public virtual string GetOptionCodeByMonth(string sTrCode, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetOptionCodeByMonth), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetOptionCodeByMonth(sTrCode, nCp, strMonth);
    }
    public virtual string GetOptionCodeByActPrice(string sTrCode, int nCp, int nTick)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetOptionCodeByActPrice), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetOptionCodeByActPrice(sTrCode, nCp, nTick);
    }
    public virtual string GetSFutureList(string strBaseAssetCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSFutureList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSFutureList(strBaseAssetCode);
    }
    public virtual string GetSFutureCodeByIndex(string strBaseAssetCode, int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSFutureCodeByIndex), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSFutureCodeByIndex(strBaseAssetCode, nIndex);
    }
    public virtual string GetSActPriceList(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSActPriceList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSActPriceList(strBaseAssetGb);
    }
    public virtual string GetSMonthList(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSMonthList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSMonthList(strBaseAssetGb);
    }
    public virtual string GetSOptionCode(string strBaseAssetGb, string strActPrice, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSOptionCode), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSOptionCode(strBaseAssetGb, strActPrice, nCp, strMonth);
    }
    public virtual string GetSOptionCodeByMonth(string strBaseAssetGb, string sTrCode, int nCp, string strMonth)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSOptionCodeByMonth), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSOptionCodeByMonth(strBaseAssetGb, sTrCode, nCp, strMonth);
    }
    public virtual string GetSOptionCodeByActPrice(string strBaseAssetGb, string sTrCode, int nCp, int nTick)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSOptionCodeByActPrice), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSOptionCodeByActPrice(strBaseAssetGb, sTrCode, nCp, nTick);
    }
    public virtual string GetSFOBasisAssetList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSFOBasisAssetList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSFOBasisAssetList();
    }
    public virtual string GetOptionATM()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetOptionATM), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetOptionATM();
    }
    public virtual string GetSOptionATM(string strBaseAssetGb)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetSOptionATM), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetSOptionATM(strBaseAssetGb);
    }
    public virtual string GetBranchCodeName()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetBranchCodeName), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetBranchCodeName();
    }
    public virtual int CommInvestRqData(string sMarketGb, string sRQName, string sScreenNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(CommInvestRqData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.CommInvestRqData(sMarketGb, sRQName, sScreenNo);
    }
    public virtual int SendOrderCredit(string sRQName, string sScreenNo, string sAccNo, int nOrderType, string sCode, int nQty, int nPrice, string sHogaGb, string sCreditGb, string sLoanDate, string sOrgOrderNo)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SendOrderCredit), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SendOrderCredit(sRQName, sScreenNo, sAccNo, nOrderType, sCode, nQty, nPrice, sHogaGb, sCreditGb, sLoanDate, sOrgOrderNo);
    }
    public virtual string KOA_Functions(string sFunctionName, string sParam)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(KOA_Functions), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.KOA_Functions(sFunctionName, sParam);
    }
    public virtual int SetInfoData(string sInfoData)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SetInfoData), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SetInfoData(sInfoData);
    }
    public virtual int SetRealReg(string strScreenNo, string strCodeList, string strFidList, string strOptType)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SetRealReg), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SetRealReg(strScreenNo, strCodeList, strFidList, strOptType);
    }
    public virtual int GetConditionLoad()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetConditionLoad), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetConditionLoad();
    }
    public virtual string GetConditionNameList()
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetConditionNameList), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetConditionNameList();
    }
    public virtual int SendCondition(string strScrNo, string strConditionName, int nIndex, int nSearch)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SendCondition), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.SendCondition(strScrNo, strConditionName, nIndex, nSearch);
    }
    public virtual void SendConditionStop(string strScrNo, string strConditionName, int nIndex)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SendConditionStop), ActiveXInvokeKind.MethodInvoke);
        }
        ocx.SendConditionStop(strScrNo, strConditionName, nIndex);
    }
    public virtual object GetCommDataEx(string strTrCode, string strRecordName)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetCommDataEx), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetCommDataEx(strTrCode, strRecordName);
    }
    public virtual void SetRealRemove(string strScrNo, string strDelCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(SetRealRemove), ActiveXInvokeKind.MethodInvoke);
        }
        ocx.SetRealRemove(strScrNo, strDelCode);
    }
    public virtual int GetMarketType(string sTrCode)
    {
        if (ocx == null)
        {
            throw new InvalidActiveXStateException(nameof(GetMarketType), ActiveXInvokeKind.MethodInvoke);
        }
        return ocx.GetMarketType(sTrCode);
    }
    internal void RaiseOnOnReceiveTrData(object sender, _DKHOpenAPIEvents_OnReceiveTrDataEvent e)
    {
        OnReceiveTrData?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveRealData(object sender, _DKHOpenAPIEvents_OnReceiveRealDataEvent e)
    {
        OnReceiveRealData?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveMsg(object sender, _DKHOpenAPIEvents_OnReceiveMsgEvent e)
    {
        OnReceiveMsg?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveChejanData(object sender, _DKHOpenAPIEvents_OnReceiveChejanDataEvent e)
    {
        OnReceiveChejanData?.Invoke(sender, e);
    }
    internal void RaiseOnOnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
    {
        OnEventConnect?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveInvestRealData(object sender, _DKHOpenAPIEvents_OnReceiveInvestRealDataEvent e)
    {
        OnReceiveInvestRealData?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveRealCondition(object sender, _DKHOpenAPIEvents_OnReceiveRealConditionEvent e)
    {
        OnReceiveRealCondition?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveTrCondition(object sender, _DKHOpenAPIEvents_OnReceiveTrConditionEvent e)
    {
        OnReceiveTrCondition?.Invoke(sender, e);
    }
    internal void RaiseOnOnReceiveConditionVer(object sender, _DKHOpenAPIEvents_OnReceiveConditionVerEvent e)
    {
        OnReceiveConditionVer?.Invoke(sender, e);
    }
    [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern bool AtlAxWinInit();

    [DllImport("Atl.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern int AtlAxGetControl(IntPtr h, [MarshalAs(UnmanagedType.IUnknown)] out object pp);

    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern IntPtr CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    static extern bool DestroyWindow(IntPtr hWnd);

    const string x64 = "{0f3a0d96-1432-4d05-a1ac-220e202bb52c}";
    const string x86 = "{a1574a0d-6bfa-4bd7-9020-ded88711818d}";

    const int WS_VISIBLE = 0x10000000;
    const int WS_CHILD = 0x40000000;

    readonly int _nCookie = 0;

    readonly _DKHOpenAPI? ocx;
    readonly IConnectionPoint? _pConnectionPoint;

    readonly IntPtr hWndContainer = IntPtr.Zero;
}