using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Threading;

namespace ShareInvest;

public partial class AxKHCoreAPIControl : UserControl
{
    public AxKHCoreAPIControl()
    {
        nint handle = new WindowInteropHelper(Application.Current.MainWindow).EnsureHandle();

        timer = new DispatcherTimer
        {
            Interval = new TimeSpan(0, 0, 1)
        };
        menu = new System.Windows.Forms.ContextMenuStrip
        {
            Cursor = System.Windows.Forms.Cursors.Hand
        };
        icons = new Icon[]
        {
            Properties.Resources.bright,
            Properties.Resources.dark,
            Properties.Resources.disable
        };
        notifyIcon = new System.Windows.Forms.NotifyIcon
        {
            ContextMenuStrip = menu,
            Visible = true,
            Text = Environment.UserDomainName,
            Icon = icons[^1],
            BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        };
        timer.Tick += OnReceiveTick;

        InitializeComponent();

        notifyIcon.Text = Properties.Resources.COPYRIGHT;

        axAPI = new AxKHCoreAPI(handle, Process.x86);

        timer.Start();
    }
    void OnReceiveTick(object? _, EventArgs e)
    {
        var now = DateTime.Now;

        if (IsConnected)
        {
            notifyIcon.Icon = icons[now.Second % 2];
        }
        else
        {
            if (now.Second == 0x3A && now.Minute % 2 == 0 && IsNotInspectionTime(now))
            {
                IsConnected = axAPI.CommConnect(0x259);

                if (IsConnected)
                {
                    Delay.Instance.Run();
                }
            }
            notifyIcon.Icon = icons[^1];
        }
    }
    bool IsNotInspectionTime(DateTime now)
    {
        return (now.Hour == 5 || now.Hour == 6 && now.Minute < 0x35) is false &&
            System.Diagnostics.Process.GetProcessesByName("opstarter").Length == 0 &&
            axAPI.GetConnectState() == 0;
    }
    bool IsConnected
    {
        get; set;
    }
    readonly Icon[] icons;
    readonly AxKHCoreAPI axAPI;
    readonly DispatcherTimer timer;
    readonly System.Windows.Forms.NotifyIcon notifyIcon;
    readonly System.Windows.Forms.ContextMenuStrip menu;
}