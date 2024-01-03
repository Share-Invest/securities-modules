using ShareInvest.RealType;

namespace ShareInvest.Observers;

public class FuturesOptionPriorityArgs : MsgEventArgs
{
    public FuturesOptionPriorityArgs(PriorityQuote quote)
    {
        Quote = quote;
    }
    public PriorityQuote Quote
    {
        get; set;
    }
}