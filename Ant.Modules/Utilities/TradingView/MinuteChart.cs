using Skender.Stock.Indicators;

namespace ShareInvest.Utilities.TradingView;

public class MinuteChart : Chart
{
    public override IEnumerable<(bool isBullish, object superTrend)> InitializedSuperTrendEnumerator()
    {
        Queue<object> data = new();

        var superTrend = Cache.GetIndicators(code)?.SuperTrend?.ToArray();

        for (int index = 0; index < superTrend?.Length; index++)
        {
            var time = (superTrend[index].Date.Ticks - Cache.Epoch) / 10_000 / 1_000;

            if (index > 0 && superTrend[index - 1].UpperBand != null != (superTrend[index].UpperBand != null))
            {
                yield return (superTrend[index - 1].UpperBand == null, data);

                data.Clear();
            }
            data.Enqueue(new
            {
                time,
                value = superTrend[index].SuperTrend
            });
        }
        yield return (superTrend?[^1].UpperBand == null, data);
    }
    public override IEnumerable<(bool isBullish, object atrStop)> InitializedAtrStopEnumerator()
    {
        Queue<object> data = new();

        var atrStop = Cache.GetIndicators(code)?.AtrStop?.ToArray();

        for (int index = 0; index < atrStop?.Length; index++)
        {
            var time = (atrStop[index].Date.Ticks - Cache.Epoch) / 10_000 / 1_000;

            if (index > 0 && atrStop[index - 1].BuyStop != null != (atrStop[index].BuyStop != null))
            {
                yield return (atrStop[index - 1].SellStop == null, data);

                data.Clear();
            }
            data.Enqueue(new
            {
                time,
                value = atrStop[index].AtrStop
            });
        }
        yield return (atrStop?[^1].SellStop == null, data);
    }
    public override object InitializedCandlestickData(IEnumerable<Quote> quotes)
    {
        return from e in quotes
               select new
               {
                   time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
                   open = e.Open,
                   high = e.High,
                   low = e.Low,
                   close = e.Close
               };
    }
    public override object InitializedVolumeData(IEnumerable<Quote> quotes)
    {
        var quoteArr = quotes.ToArray();

        return quoteArr.Select((e, index) => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Volume,
            color = index > 0 && quoteArr[index - 1].Volume < e.Volume ? "#F00" : "#00F"
        });
    }
    public override (object? linear, object? slope) InitializedSlopeData()
    {
        var slope = Cache.GetIndicators(code)?.Slope;

        var linearData = slope?.Where(e => e.Line != null).Select(e => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Line
        });
        var slopeData = slope?.Select(e => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Slope
        });
        return (linearData, slopeData);
    }
    public override (object? macd, object? signal, object? histogram) InitializedMacdData()
    {
        var macd = Cache.GetIndicators(code)?.Macd?.ToArray();

        var macdHistogramData = macd?.Select((e, index) => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Histogram,
            color = index > 0 && macd[index - 1].Histogram < e.Histogram ? (e.Histogram > 0 ? "#F00" : "#00BFFF") : (e.Histogram > 0 ? "#800000" : "#00F")
        });
        var macdData = macd?.Select(e => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Macd
        });
        var macdSignalData = macd?.Select(e => new
        {
            time = (e.Date.Ticks - Cache.Epoch) / 10_000 / 1_000,
            value = e.Signal
        });
        return (macdData, macdSignalData, macdHistogramData);
    }
    public MinuteChart(string code) : base(code)
    {

    }
}