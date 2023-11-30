using NetTopologySuite.Geometries;

using ShareInvest.Entities;
using ShareInvest.Entities.AnTalk;
using ShareInvest.Entities.Google;
using ShareInvest.Entities.Kiwoom;
using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Repositories;

public interface ISecuritiesRepository
{
    Task<(string name, AssetStatusTrend assetsTrend)?> GetPresumeKiwoomAssetAsync(string accNo);

    Task<IEnumerable<string>> GetStocksAsync(Point point, double distance);

    Task<IEnumerable<CoordinateStock>> GetStocksAsync(Point point, double currentDistance, double previousDistance);

    Task<int> RegisterUserAsync(Securities securities);

    Task<int> RegisterPositionAsync(Entities.Position position);

    Task<int> SaveChangesAsync(MultiOpt10081 dailyChart);

    Task<int> SaveChangesAsync(Entities.Kiwoom.Opt10004 stockQuote);

    Task<int> RecordsCommunicationsWithSecuritiesCorpAsync(OpenMessage message);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.Kiwoom.OPTKWFID item);

    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<bool> AnyUserAsync(string userId);

    Task<bool> IsFirstContractAsync(string date, string accNo, string code);

    Task<bool> EventOccursInStockAsync(string key, string code, string price);

    Task<string> GetLatestDateAsync();

    Task<string?> GetStockNameAsync(string code);

    Task<Entities.Kiwoom.Opt10004?> GetStockQuoteAsync(string code);

    Task<AntStock[]> GetListByCompareToPreviousVolumeAsync(string latestDate);

    AntStock[] GetListByRate(string latestDate);

    AntStock[] GetListByListingDate(string latestDate);

    AntStock[] GetListByMarketCap(string latestDate);

    AntStock[] GetListByVolume(string lastestDate);

    IEnumerable<T> GetStocks<T>(string date) where T : struct;

    IEnumerable<DailyChart> GetDailyChart(string code, string date, int period);

    string? GetCodeToLookUpNextDailyChart(string date);

    string? GetCodeToLookUpNextStockQuote(string date);

    int LiquidateStocksHeld(ChejanBalance balance);

    Log[]? GetOpenMessagesByUserId(string userId);

    Log[]? GetOpenMessagesByUserId(string userId, long ticks);

    AntStockChat[] ContinuouslyViewChat(string? id, string code, long ticks);

    AntStockChat[] ContinuouslyViewChat(string? id, string code);

    AssetStatusBalance[] GetKiwoomBalances(string accNo, string date);

    AssetStatusChart[] GetPresumeAssetTrend(string accNo);

    CoordinateUser[] GetClientApps(Point point, double distance, string? userName = null);
}