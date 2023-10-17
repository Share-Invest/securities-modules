using NetTopologySuite.Geometries;

using ShareInvest.Entities;
using ShareInvest.Entities.Google;
using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Repositories;

public interface ISecuritiesRepository : IDisposable
{
    Task<int> RegisterUserAsync(Securities securities);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.OPTKWFID item);

    Task<int> RecordAssetStatusAsync(AccountBook assets);

    Task<string> GetLatestDateAsync();

    IEnumerable<T> GetStocks<T>(string date) where T : struct;

    IEnumerable<CoordinateStock> GetStocks(Point point, double farthest, string date);

    int RecordsCommunicationsWithSecuritiesCorp(OpenMessage message);
}