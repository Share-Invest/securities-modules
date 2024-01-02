namespace ShareInvest.Observers;

public class HubMarkerArgs : MsgEventArgs
{
    public HubMarkerArgs(DateTime dateTime, bool position)
    {
        DateTime = dateTime;
        Position = position;
    }
    public DateTime DateTime
    {
        get;
    }
    public bool Position
    {
        get; set;
    }
}