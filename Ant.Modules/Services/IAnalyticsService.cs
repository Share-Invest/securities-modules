using ShareInvest.Entities;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnalyticsService
{
    Task<IEnumerable<Analytics>> GetStocksInOrderOfRankAsync(TypeOfRankToOrder rankType, int startIndex, int endIndex);

    Task<Analytics[]> GetStocksInOrderOfRankAsync(TypeOfRankToOrder rankType);

    Task<int> ItemCountAsync();
}