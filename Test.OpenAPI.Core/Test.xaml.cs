using ShareInvest.Kiwoom;

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;

namespace ShareInvest;

public partial class Test : Window
{
    public Test()
    {
        nint handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        InitializeComponent();

        try
        {
            axAPI = new AxKHCoreAPI(handle);
        }
        catch (Exception e)
        {
            _ = new AxKHOpenAPI(handle);
#if DEBUG
            Debug.WriteLine(e.Message);
#endif
            axAPI = new AxKHCoreAPI(handle);
        }

        axAPI.OnEventConnect += (_, e) =>
        {
            if (e.nErrCode == 0)
            {
                tb.Text = "success";

                login_btn.IsEnabled = false;
            }
            else
            {
                tb.Text = "failure";
            }
        };
        tb.IsReadOnly = axAPI.Created;

        login_btn.IsEnabled = axAPI.Created;
    }
    void OnClick(object sender, RoutedEventArgs e)
    {
        axAPI.CommConnect();
    }
    readonly AxKHCoreAPI axAPI;
}