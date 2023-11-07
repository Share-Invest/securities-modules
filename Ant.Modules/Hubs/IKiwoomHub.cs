using ShareInvest.Entities.Google.Firebase;

namespace ShareInvest.Hubs;

public interface IKiwoomHub
{
    Task SendAllAsync(string key, string data, Notification notification);

    Task OnConnectedAsync(string userIdentifier, string serialKey);

    Task OnDisconnectedAsync(string userIdentifier, string serialKey);

    Task<object> CheckOneSAccountAsync(string userName);
}