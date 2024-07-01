using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Observers;

public class TransmissionEventArgs(TR tr) : MsgEventArgs
{
    public TR Transmission
    {
        get;
    }
        = tr;
}