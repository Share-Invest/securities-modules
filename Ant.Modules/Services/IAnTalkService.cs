using ShareInvest.Entities.AnTalk;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnTalkService
{
    Task<string?> GetStockNameAsync(string code);

    Task<AntStock[]> GetStockAsync(Order order);

    DailyChart[] GetDailyChart(string code, string? date, int period);
}