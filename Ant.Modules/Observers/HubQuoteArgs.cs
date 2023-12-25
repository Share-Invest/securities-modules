using Skender.Stock.Indicators;

namespace ShareInvest.Observers;

public class HubQuoteArgs : MsgEventArgs
{
    public (object candleData, object volumeData) ObjData
    {
        get;
    }
    public HubQuoteArgs(Quote quote, bool moreThanBefore)
    {
        var time = (quote.Date.Ticks - Cache.Epoch) / 10_000 / 1_000;

        ObjData = (new
        {
            open = quote.Open,
            high = quote.High,
            low = quote.Low,
            close = quote.Close,
            time
        },
        new
        {
            color = moreThanBefore ? "#F00" : "#00F",
            value = quote.Volume,
            time
        });
    }
}