namespace ShareInvest.Utilities.TradingView;

public static class ArrowMarker
{
    public static object CreateForMinuteChart(DateTime dateTime, bool longPosition, bool square, string? text = null)
    {
        return new
        {
            time = (dateTime.Ticks - Cache.Epoch) / 10_000 / 1_000,
            position = longPosition ? "belowBar" : "aboveBar",
            color = longPosition ? "#8B0000" : "#2196F3",
            shape = square ? "circle" : (longPosition ? "arrowUp" : "arrowDown"),
            text = string.IsNullOrEmpty(text) ? string.Empty : text
        };
    }
}