using ShareInvest.Entities;
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

    Task<IEnumerable<AntFutures>> GetFuturesAsync();

    Task<AntStock[]> GetStockAsync(Order order);

    Task<Entities.Kiwoom.Opt10004?> GetStockQuoteAsync(string code);

    IAsyncEnumerable<(DateTime dateTime, bool moreThanBefore, Quote quote, Indicators indicator)> GetSimulationDataAsync(string code, string date, IEnumerable<Quote> quotes, CancellationToken? stoppingToken = null);

    AntStockChat[] ContinuouslyViewChat(string? id, string code, long ticks);

    Indicators[] GetStrategicsScenario();

    DailyChart[] GetDailyChart(string code, int period, string? date = null);
    /// <summary>
    /// <param name="dateTime">dateTimeFormat: yyyyMMddHHmmss</param>
    /// </summary>
    IEnumerable<T> GetFuturesMinuteChart<T>(string code, string? dateTime = null, int period = 0x400) where T : class;

    IEnumerable<T> GetFuturesMinuteChart<T>(string code, DateTime startDate, DateTime endDate) where T : class;

    IEnumerable<string> GetSimulationDateList(string code);

    event EventHandler<MsgEventArgs> QuoteSend;
}