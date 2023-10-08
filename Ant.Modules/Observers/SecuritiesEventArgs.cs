using ShareInvest.Entities;

namespace ShareInvest.Observers;

public class SecuritiesEventArgs : MsgEventArgs
{
    public Securities Securities
    {
        get;
    }
    public SecuritiesEventArgs(Securities securities)
    {
        Securities = securities;
    }
}