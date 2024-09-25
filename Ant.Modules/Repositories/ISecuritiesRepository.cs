using NetTopologySuite.Geometries;

using ShareInvest.Entities;
using ShareInvest.Entities.Analysis;
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

    Task<int> SaveChangesAsync(Entities.Kiwoom.Opt10004 stockQuote);

    Task<int> RecordsCommunicationsWithSecuritiesCorpAsync(OpenMessage message);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.Kiwoom.OPTKWFID item);

    Task<int> RecordFuturesInformationfromKiwoomSecuritiesAsync(Entities.Kiwoom.Opt50001 item);

    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<bool> AnyUserAsync(string userId);

    Task<bool> IsFirstContractAsync(string date, string accNo, string code);

    Task<bool> EventOccursInStockAsync(string key, string code, string price);

    Task<string> GetLatestDateAsync();

    Task<string> GetMarketIndexLatestDateAsync();

    Task<string> GetFuturesLatestDateAsync();

    Task<string?> GetFuturesCodeAsync();

    Task<string?> GetStockNameAsync(string code);

    Task<string> GetSimulationDataAsync(string code, string date);

    Task<byte[]> GetSimulationDataFileAsync(string code, string date);

    Task<Entities.Kiwoom.Opt10004?> GetStockQuoteAsync(string code);

    Task<ResponseGrowthRateRank?> RecommendedAmongRankedStockAsync(GrowthRateRank stock);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToOverallRankingAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToMarketCapAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToSalesAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToOpAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToNpAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToPerAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToPbrAsync(string latestDate, int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToRoeAsync(string latestDate, int rank);

    Task<AntStock[]> GetListByCompareToPreviousVolumeAsync(string latestDate);

    string? GetGrowthRateRankLatestDate();

    string? GetCodeToLookupNextFuturesDayChart(string date);

    string? GetCodeToLookupNextOptionsDayChart(string date);

    string? GetCodeToLookupNextMarketIndexDayChart(string date);

    string? GetCodeToLookupNextFuturesMinChart(string date);

    string? GetCodeToLookupNextOptionsMinChart(string date);

    string? GetCodeToLookupNextMarketIndexMinChart(string date);

    string? GetCodeToLookUpNextDailyChart(string date);

    string? GetCodeToLookUpNextMinuteChart(string date);

    string? GetCodeToLookUpNextStockQuote(string date);

    int SaveChanges<T>(T entity) where T : class;

    int SaveChanges<T>(IEnumerable<T> entities) where T : class;

    int LiquidateStocksHeld(ChejanBalance balance);

    Log[]? GetOpenMessagesByUserId(string userId);

    Log[]? GetOpenMessagesByUserId(string userId, long ticks);

    AntStockChat[] ContinuouslyViewChat(string? id, string code, long ticks);

    AntStockChat[] ContinuouslyViewChat(string? id, string code);

    AssetStatusBalance[] GetKiwoomBalances(string accNo, string date);

    AssetStatusChart[] GetPresumeAssetTrend(string accNo);

    EstimatedStock[] CollectionToAnalyzeGrowthPotential();

    AntFutures[] GetFutures(string latestDate);

    AntStock[] GetListByRate(string latestDate);

    AntStock[] GetListByListingDate(string latestDate);

    AntStock[] GetListByMarketCap(string latestDate);

    AntStock[] GetListByVolume(string lastestDate);

    IEnumerable<T> GetStocks<T>(string date) where T : struct;

    IEnumerable<string> GetSimulationDateList(string code);

    IEnumerable<AntOptionChart> GetOptionDailyChart(string code, string date, int period);

    IEnumerable<AntOptionChart> GetFuturesDailyChart(string code, string date, int period);

    IEnumerable<AntOptionChart> GetMarketIndexDailyChart(string code, string date, int period);

    IEnumerable<AntOption> GetOptionInfo(string latestDate, int previous);

    IEnumerable<DailyChart> GetDailyChart(string code, string date, int period);

    IEnumerable<StockThemeDetail> GetThemeDetail(string code);

    IDictionary<string, IEnumerable<StockThemeDetail>> GetThemeDetail();

    CoordinateUser[] GetClientApps(Point point, double distance, string? userName = null, string? userId = null);

    GrowthRateRank[] RecommendedAmongRankedStocks(string date);

    Indicators[] GetStrategicsScenario();

    Entities.Kiwoom.Opt50029[] GetFuturesMinuteChart(string code, string? dateTime, int period = 0x400);

    Entities.Kiwoom.Opt50029[] GetFuturesMinuteChart(string code, string startDate, string endDate);

    Entities.Kiwoom.Opt50001? GetOptionInfo(string code, string latestDate);

    OPT20003? GetStockIndex(string code, string latestDate);

    OPT20001? GetMarketIndex(string code, string latestDate);
}