using ShareInvest.RealType;

namespace ShareInvest.Observers;

public class FuturesQuoteArgs(FuturesQuoteBalance quote) : MsgEventArgs
{
    public FuturesQuoteBalance Quote
    {
        get;
    }
        = quote;
}