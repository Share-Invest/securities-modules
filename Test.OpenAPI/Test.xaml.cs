using ShareInvest.Kiwoom;

using System.Windows;
using System.Windows.Interop;

namespace ShareInvest;

public partial class Test : Window
{
    public Test()
    {
        nint Handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        InitializeComponent();

        axAPI = new AxKHOpenAPI(Handle);

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
    readonly AxKHOpenAPI axAPI;
}