using ShareInvest.Entities.Google.Firebase;
using ShareInvest.OpenAPI;

namespace ShareInvest.Hubs;

public interface IKiwoomHub
{
    Task SendAllAsync(string key, string data, Notification notification);

    Task OnConnectedAsync(string userIdentifier, string serialKey);

    Task OnDisconnectedAsync(string userIdentifier, string serialKey);

    Task CheckOneSAccountAsync();

    Task SendFuturesOrderAsync(OrderFO orderFO);

    Task<object> CheckOneSAccountAsync(string userName);
}