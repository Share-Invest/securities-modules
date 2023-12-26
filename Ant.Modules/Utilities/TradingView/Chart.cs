using Skender.Stock.Indicators;

namespace ShareInvest.Utilities.TradingView;

public abstract class Chart
{
    public abstract (Series atrStop, Series superTrend, object indicator) UpdateFuturesIndicator(string code);

    public abstract (object? macd, object? signal, object? histogram) InitializedMacdData();

    public abstract (object? linear, object? slope) InitializedSlopeData();

    public abstract object InitializedVolumeData(IEnumerable<Quote> quotes);

    public abstract object InitializedCandlestickData(IEnumerable<Quote> quotes);

    public abstract IEnumerable<(bool isBullish, object atrStop)> InitializedAtrStopEnumerator();

    public abstract IEnumerable<(bool isBullish, object superTrend)> InitializedSuperTrendEnumerator();

    public Chart(string code)
    {
        this.code = code;
    }
    protected readonly string code;
}