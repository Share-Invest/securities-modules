using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Observers;

public class TransmissionEventArgs : MsgEventArgs
{
    public TR Transmission
    {
        get;
    }
    public TransmissionEventArgs(TR tr)
    {
        Transmission = tr;
    }
}