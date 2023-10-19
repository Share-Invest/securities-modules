using ShareInvest.Entities.Google;
using ShareInvest.Entities.Google.Maps;

namespace ShareInvest.Hubs;

public interface IMapHub
{
    Task<CoordinateStock[]> GetStocksAsync();

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(MapStatus status, double farthest);

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(MapStatus cacheMapStatus, DistanceFromCenter cacheDistance, MapStatus mapStatus, DistanceFromCenter distance);

    void OnConnected(string userIdentifier);

    void OnDisconnected(string userIdentifier);
}