using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IAnalyticsRepository
{
    Analytics[] GetInOrderOfMarketCap(string? latestDate);
}