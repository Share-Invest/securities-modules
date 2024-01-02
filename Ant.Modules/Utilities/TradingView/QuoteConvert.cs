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
            Volume = Convert.ToDecimal(e.VolumeOfTransaction),
            Date = DateTime.TryParseExact(e.Time, Resources.DATETIME, null, DateTimeStyles.None, out DateTime dt) ? dt : DateTime.UnixEpoch
        });
    }
}