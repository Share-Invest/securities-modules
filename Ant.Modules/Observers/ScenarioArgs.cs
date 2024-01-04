using ShareInvest.Entities.TradingView;

namespace ShareInvest.Observers;

public class ScenarioArgs : MsgEventArgs
{
    public Marker ArrowMarker
    {
        get;
    }
    public ScenarioArgs(Marker arrowMarker)
    {
        ArrowMarker = arrowMarker;
    }
}