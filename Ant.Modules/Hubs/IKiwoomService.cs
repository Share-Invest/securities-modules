namespace ShareInvest.Hubs;

public interface IKiwoomService : IDisposable
{
    Task OnConnectedAsync();

    Task OnDisconnectedAsync();
}