namespace ShareInvest.Hubs;

public interface IKiwoomHub
{
    Task OnConnectedAsync(string userIdentifier, string serialKey);

    Task OnDisconnectedAsync(string userIdentifier, string serialKey);
}