using ShareInvest.Entities;

using Skender.Stock.Indicators;

namespace ShareInvest.Utilities.TradingView;

public abstract class Chart
{
    public abstract (Series atrStop, Series superTrend, object indicator) UpdateFuturesIndicator(string code, Indicators? indicator = null);

    public abstract (object? macd, object? signal, object? histogram) InitializedMacdData(MacdResult[]? macd = null);

    public abstract (object? linear, object? slope) InitializedSlopeData(IEnumerable<SlopeResult>? slope = null);

    public abstract object InitializedVolumeData(IEnumerable<Quote> quotes);

    public abstract object InitializedCandlestickData(IEnumerable<Quote> quotes);

    public abstract IEnumerable<(bool isBullish, object atrStop)> InitializedAtrStopEnumerator(AtrStopResult[]? atrStop = null);

    public abstract IEnumerable<(bool isBullish, object superTrend)> InitializedSuperTrendEnumerator(SuperTrendResult[]? superTrend = null);

    public Chart(string code)
    {
        this.code = code;
    }
    protected readonly string code;
}