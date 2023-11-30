using ShareInvest.Entities.Google;
using ShareInvest.Entities.Google.Maps;

namespace ShareInvest.Hubs;

public interface IMapHub
{
    Task<CoordinateStock[]> GetStocksAsync();

    Task<IEnumerable<string>> GetStocksAsync(MapStatus status, double distance);

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(MapStatus status, double currentDistance, double previousDistance);

    CoordinateUser[] GetClientApps(MapStatus status, double distance, string? userName = null);

    void OnConnected(string userIdentifier);

    void OnDisconnected(string userIdentifier);
}