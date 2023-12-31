using ShareInvest.RealType;

namespace ShareInvest.Observers;

public class FuturesOptionPriorityArgs : MsgEventArgs
{
    public FuturesOptionPriorityArgs(FuturesOptionPriorityQuote quote)
    {
        Quote = quote;
    }
    public FuturesOptionPriorityQuote Quote
    {
        get; set;
    }
}