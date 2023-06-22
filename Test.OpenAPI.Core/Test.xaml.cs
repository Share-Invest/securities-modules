using Newtonsoft.Json;

using ShareInvest.Tr;

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;

namespace ShareInvest;

public partial class Test : Window
{
    public Test()
    {
        nint handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        InitializeComponent();

        axAPI = new AxKHCoreAPI(handle, Process.x86);

        axAPI.OnReceiveTrData += (_, e) =>
        {
            var tr = axAPI.GetTrData(e.sTrCode);

            var data = new Dictionary<string, string>();

            for (int i = 0; i < tr.SingleData?.Length; i++)
            {
                data[tr.SingleData[i]] = axAPI.GetCommData(e.sTrCode, e.sRQName, 0, tr.SingleData[i]).Trim();
            }
            for (int cnt = 0; cnt < axAPI.GetRepeatCnt(e.sTrCode, e.sRecordName); cnt++)
            {
                for (int i = 0; i < tr.MultiData?.Length; i++)
                {
                    data[tr.MultiData[i]] = axAPI.GetCommData(e.sTrCode, e.sRQName, cnt, tr.MultiData[i]).Trim();
                }
            }
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
        };
        axAPI.OnEventConnect += (_, e) =>
        {
            if (e.nErrCode == 0)
            {
                btn.Content = "TrCode Submit";
            }
            tb.IsReadOnly = e.nErrCode != 0;
        };
        tb.IsReadOnly = true;

        btn.IsEnabled = axAPI.Created;
    }
    void OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(tb.Text))
        {
            if (axAPI.GetConnectState() == 1)
            {
                return;
            }
            var result = axAPI.CommConnect();

            tb.Text = Guide.Error[result];
        }
        else
        {
            var exists = Array.Exists(axAPI.TrInventory, m => tb.Text.Equals(m.Code, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                var tr = axAPI.GetTrData(tb.Text);

                if (string.IsNullOrEmpty(tr.Name) || string.IsNullOrEmpty(tr.Code))
                {
                    return;
                }
                var codeList = new List<string>(axAPI.GetCodeListByMarket(MarketCode.코스피));

                codeList.AddRange(axAPI.GetCodeListByMarket(MarketCode.코스닥));

                foreach (var inventory in OPTKWFID.GetCodeInventory(codeList))
                {
                    var s = new OPTKWFID
                    {
                        RQName = tr.Name
                    };
                    var errCode = axAPI.CommKwRqData(inventory.Item1, inventory.Item2, s.PrevNext, s.RQName, s.ScreenNo);

                    tb.Text = Guide.Error[errCode];
                }
            }
        }
    }
    readonly AxKHCoreAPI axAPI;
}