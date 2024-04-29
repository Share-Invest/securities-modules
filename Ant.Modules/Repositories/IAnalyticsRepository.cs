using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IAnalyticsRepository
{
    Task<int> ItemCountAsync(string? latestDate);

    Analytics[] GetInOrderOfMarketCap(IDictionary<string, IEnumerable<StockThemeDetail>> themes, string? latestDate);

    Analytics[] GetInOrderOfMarketCap(string? latestDate, int startIndex, int endIndex);
}