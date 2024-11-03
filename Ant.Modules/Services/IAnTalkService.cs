using ShareInvest.Entities;
using ShareInvest.Entities.Analysis;
using ShareInvest.Entities.AnTalk;
using ShareInvest.Services.AnTalk;

using Skender.Stock.Indicators;

namespace ShareInvest.Services;

public interface IAnTalkService
{
    Task SendMessageAsync(AntStockChat stockChat);

    Task<int> SaveChangesAsync<T>(T entity) where T : class;

    Task<byte[]> GetSimulationDataFileAsync(string code, string date);

    Task<string?> GetLatestDateAsync();

    Task<string?> GetFuturesCodeAsync();

    Task<string?> GetStockNameAsync(string code);

    Task<IEnumerable<AntOption>> GetOptionInfoAsync(int previous);

    Task<IEnumerable<AntFutures>> GetFuturesAsync();

    Task<AntStock[]> GetStockAsync(Order order);

    Task<Entities.Kiwoom.Opw20015[]> GetOptionOrderMarginAsync(string classification);

    Task<Entities.Kiwoom.OPT20003?> GetStockIndexAsync(string code);

    Task<Entities.Kiwoom.OPT20001?> GetMarketIndexAsync(string code);

    Task<EstimatedStock[]> AnalyzeGrowthPotentialAsync();

    Task<Entities.Kiwoom.Opt50001?> GetOptionInfoAsync(string code);

    Task<Entities.Kiwoom.Opt10004?> GetStockQuoteAsync(string code);

    Task<Entities.Kiwoom.Opt10003[]> GetStockConclusionAsync(string code);

    Task<ResponseGrowthRateRank?> RecommendedAmongRankedStockAsync(GrowthRateRank stock);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToOverallRankingAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToMarketCapAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToSalesAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToOpAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToNpAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToPerAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToPbrAsync(int rank);

    Task<ResponseGrowthRateRank?> RecommendStocksAccordingToRoeAsync(int rank);

    IAsyncEnumerable<(DateTime dateTime, bool moreThanBefore, Quote quote, Indicators indicator)> GetSimulationDataAsync(string code, string date, IEnumerable<Quote> quotes, CancellationToken? stoppingToken = null);

    AntStockChat[] ContinuouslyViewChat(string? id, string code, long ticks);

    Indicators[] GetStrategicsScenario();

    AntOptionChart[] GetOptionDailyChart(string code, int period, string? date = null);

    AntOptionChart[] GetFuturesDailyChart(string code, int period, string? date = null);

    AntOptionChart[] GetMarketIndexDailyChart(string code, int period, string? date = null);

    DailyChart[] GetDailyChart(string code, int period, string? date = null);

    /// <summary>
    /// <param name="dateTime">dateTimeFormat: yyyyMMddHHmmss</param>
    /// </summary>
    IEnumerable<T> GetFuturesMinuteChart<T>(string code, string? dateTime = null, int period = 0x400) where T : class;

    IEnumerable<T> GetFuturesMinuteChart<T>(string code, DateTime startDate, DateTime endDate) where T : class;

    IEnumerable<string> GetSimulationDateList(string code);

    IEnumerable<GrowthRateRank> RecommendedAmongRankedStocks(int count, bool inOrder);

    event EventHandler<MsgEventArgs> QuoteSend;
}