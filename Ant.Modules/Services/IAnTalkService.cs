using ShareInvest.Entities.AnTalk;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnTalkService
{
    Task SendMessageAsync(AntStockChat stockChat);

    Task<string?> GetStockNameAsync(string code);

    Task<AntStock[]> GetStockAsync(Order order);

    Task<Entities.Kiwoom.Opt10004?> GetStockQuoteAsync(string code);

    AntStockChat[] ContinuouslyViewChat(string? id, string code, long ticks);

    DailyChart[] GetDailyChart(string code, string? date, int period);
}