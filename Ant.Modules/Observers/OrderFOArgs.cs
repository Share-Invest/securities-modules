using ShareInvest.OpenAPI;

namespace ShareInvest.Observers;

public class OrderFOArgs : MsgEventArgs
{
    public OrderFOArgs(OrderFO orderFO)
    {
        OrderFO = orderFO;
    }
    public OrderFO OrderFO
    {
        get;
    }
}