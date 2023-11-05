using NetTopologySuite.Geometries;

using ShareInvest.Entities;
using ShareInvest.Entities.AnTalk;
using ShareInvest.Entities.Google;
using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Repositories;

public interface ISecuritiesRepository
{
    Task<IEnumerable<string>> GetStocksAsync(Point point, double distance);

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(Point point, double currentDistance, double previousDistance);

    Task<int> RegisterUserAsync(Securities securities);

    Task<int> SaveChangesAsync(MultiOpt10081 dailyChart);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.Kiwoom.OPTKWFID item);

    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<bool> EventOccursInStockAsync(string key, string code, string price);

    Task<string> GetLatestDateAsync();

    IEnumerable<T> GetStocks<T>(string date) where T : struct;

    IEnumerable<AntStock> GetListByMarketCap(string latestDate);

    int RecordsCommunicationsWithSecuritiesCorp(Entities.Kiwoom.OpenMessage message);

    string? GetCodeToLookUpNext(string date);
}