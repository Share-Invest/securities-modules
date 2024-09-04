namespace ShareInvest.Observers;

public class HubMarkerArgs(DateTime dateTime, bool position) : MsgEventArgs
{
    public DateTime DateTime { get; } = dateTime;

    public bool Position { get; set; } = position;
}