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

        axAPI = new AxKHCoreAPI(handle);

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
            tb.Text = data.Count.ToString("N0");
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

            tb.Text = Guide.ErrorCode[result];
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
                for (int i = 0; i < tr.Input?.Length; i++)
                {
                    axAPI.SetInputValue(tr.Input[i], "005930");
                }
                var errCode = axAPI.CommRqData(tr.Name, tr.Code, 0, "1234");

                tb.Text = Guide.ErrorCode[errCode];
            }
        }
    }
    readonly AxKHCoreAPI axAPI;
}