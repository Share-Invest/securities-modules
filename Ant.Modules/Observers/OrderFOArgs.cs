using ShareInvest.OpenAPI;

namespace ShareInvest.Observers;

public class OrderFOArgs(OrderFO orderFO) : MsgEventArgs
{
    public OrderFO OrderFO { get; } = orderFO;
}