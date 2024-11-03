using ShareInvest.RealType;

namespace ShareInvest.Observers;

public class FuturesOptionPriorityArgs(PriorityQuote quote) : MsgEventArgs
{
    public PriorityQuote Quote
    {
        get; set;
    }
        = quote;
}