using ShareInvest.Entities;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnalyticsService
{
    Task<Analytics[]> GetStocksInOrderOfRankAsync(TypeOfRankToOrder rankType);
}