namespace ShareInvest.Services;

public interface IKiwoomHubService
{
    void OnConnectedAsync(string userIdentifier, string serialKey);

    void OnDisconnectedAsync(string userIdentifier, string serialKey);
}