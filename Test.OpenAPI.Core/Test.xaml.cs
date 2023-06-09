using Newtonsoft.Json;

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

        axAPI = new AxKHCoreAPI(handle);

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
        tb.IsReadOnly = false;

        login_btn.IsEnabled = axAPI.Created;
    }
    void OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(tb.Text))
        {
            axAPI.CommConnect();
        }
        else
        {
            var tr = axAPI.GetTrData(tb.Text);
#if DEBUG
            Debug.WriteLine(JsonConvert.SerializeObject(tr, Formatting.Indented));
#endif
        }
    }
    readonly AxKHCoreAPI axAPI;
}