using System.Windows;

namespace ShareInvest;

public partial class CoreWindow : Window
{
    public CoreWindow()
    {
        Content = new AxKHCoreAPIControl();

        InitializeComponent();

        Hide();
    }
}