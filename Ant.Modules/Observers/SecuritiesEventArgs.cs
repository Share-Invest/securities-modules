using ShareInvest.Entities;

namespace ShareInvest.Observers;

public class SecuritiesEventArgs(Securities securities) : MsgEventArgs
{
    public Securities Securities
    {
        get;
    }
        = securities;
}