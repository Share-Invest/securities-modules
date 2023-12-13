using ShareInvest.Entities;

namespace ShareInvest.Observers;

public class ThemeEventArgs : EventArgs
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