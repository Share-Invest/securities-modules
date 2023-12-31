namespace ShareInvest.Observers;

public class HubMarkerArgs : MsgEventArgs
{
    public HubMarkerArgs(object marker)
    {
        Marker = marker;
    }
    public object Marker
    {
        get;
    }
}