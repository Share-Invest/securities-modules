namespace ShareInvest.Services;

public interface IKiwoomHubService
{
    Task OnConnectedAsync(string userIdentifier, string serialKey);

    Task OnDisconnectedAsync(string userIdentifier, string serialKey);
}