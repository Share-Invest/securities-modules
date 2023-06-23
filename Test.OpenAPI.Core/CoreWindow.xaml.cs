using System.Windows;

namespace ShareInvest;

public partial class CoreWindow : Window
{
    public CoreWindow()
    {
        var control = new AxKHCoreAPIControl();

        Content = control;

        InitializeComponent();

        Hide();
    }
}