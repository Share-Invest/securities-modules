using ShareInvest.Entities.AnTalk;
using ShareInvest.Properties;

using Skender.Stock.Indicators;

using System.Globalization;

namespace ShareInvest.Utilities.TradingView;

public static class QuoteConvert
{
    public static IEnumerable<Quote> GetFuturesMinuteChart(Entities.Kiwoom.Opt50029[] chart)
    {
        return chart.Select(e => new Quote
        {
            Close = Math.Abs(Convert.ToDecimal(e.CurrentPrice)),
            High = Math.Abs(Convert.ToDecimal(e.HighPrice)),
            Open = Math.Abs(Convert.ToDecimal(e.OpenPrice)),
            Low = Math.Abs(Convert.ToDecimal(e.LowPrice)),
            Volume = Convert.ToDecimal(e.TradingVolume),
            Date = DateTime.TryParseExact(e.Time, Resources.DATETIME, null, DateTimeStyles.None, out DateTime dt) ? dt : DateTime.UnixEpoch
        });
    }

    public static IEnumerable<Quote> GetFuturesDailyChart(AntOptionChart[] dailyChart)
    {
        return dailyChart.Select(e => new Quote
        {
            Close = Math.Abs(Convert.ToDecimal(e.Current)),
            High = Math.Abs(Convert.ToDecimal(e.High)),
            Open = Math.Abs(Convert.ToDecimal(e.Open)),
            Low = Math.Abs(Convert.ToDecimal(e.Low)),
            Volume = Convert.ToDecimal(e.Volume),
            Date = DateTime.TryParseExact(e.Date, Resources.DATE, null, DateTimeStyles.None, out DateTime dt) ? dt : DateTime.UnixEpoch
        });
    }
}