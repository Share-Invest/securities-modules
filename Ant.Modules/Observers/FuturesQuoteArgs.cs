using ShareInvest.RealType;

namespace ShareInvest.Observers;

public class FuturesQuoteArgs : MsgEventArgs
{
    public FuturesQuoteArgs(FuturesQuoteBalance quote)
    {
        Quote = quote;
    }
    public FuturesQuoteBalance Quote
    {
        get;
    }
}