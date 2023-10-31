using NetTopologySuite.Geometries;

using ShareInvest.Entities;
using ShareInvest.Entities.Google;
using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Repositories;

public interface ISecuritiesRepository
{
    Task<IEnumerable<string>> GetStocksAsync(Point point, double distance);

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(Point point, double currentDistance, double previousDistance);

    Task<int> RegisterUserAsync(Securities securities);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.Kiwoom.OPTKWFID item);

    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<string> GetLatestDateAsync();

    IEnumerable<T> GetStocks<T>(string date) where T : struct;

    int RecordsCommunicationsWithSecuritiesCorp(Entities.Kiwoom.OpenMessage message);
}