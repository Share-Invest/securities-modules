using ShareInvest.Entities;
using ShareInvest.Entities.Analysis;
using ShareInvest.Services.AnTalk;

namespace ShareInvest.Services;

public interface IAnalyticsService
{
    Task<IEnumerable<Analytics>> GetStocksInOrderOfRankAsync(TypeOfRankToOrder rankType, int startIndex, int endIndex);

    Task<Analytics[]> GetStocksInOrderOfRankAsync(TypeOfRankToOrder rankType);

    Task<Dictionary<string, NormalizeFinancialState[]>> GetFinancialStateAsync(string code, string date, int maxPrice, int minPrice);

    Task<int> ItemCountAsync();
}