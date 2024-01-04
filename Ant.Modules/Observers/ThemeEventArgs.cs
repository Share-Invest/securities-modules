using ShareInvest.Entities;

namespace ShareInvest.Observers;

public class ThemeEventArgs : MsgEventArgs
{
    public object Convey
    {
        get;
    }
    public ThemeEventArgs(StockTheme theme)
    {
        Convey = theme;
    }
    public ThemeEventArgs(StockThemeDetail detail)
    {
        Convey = detail;
    }
    public ThemeEventArgs(string name)
    {
        Convey = name;
    }
}