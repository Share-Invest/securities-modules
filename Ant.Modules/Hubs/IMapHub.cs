using ShareInvest.Entities.Google;

namespace ShareInvest.Hubs;

public interface IMapHub
{
    Task<CoordinateStock[]> GetStocksAsync();

    void OnConnected(string userIdentifier);

    void OnDisconnected(string userIdentifier);
}