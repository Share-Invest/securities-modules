using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    Task<HighGrowthRateTheme[]> GetThemesWithHighGrowthRateAsync();

    TreeMapStock[] GetStocksCategorizedByTheme(HighGrowthRateTheme[] themeGroup, string latestDate);

    int SaveStockTheme(IEnumerable<StockThemeDetail>? themes);

    int SaveStockTheme(StockTheme theme);
}