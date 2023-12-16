using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    Task<HighGrowthRateTheme[]> GetThemesWithHighGrowthRateAsync();

    Task<TreeMapStock[]> GetStocksCategorizedByThemeAsync(HighGrowthRateTheme[] themeGroup);

    int SaveStockTheme(IEnumerable<StockThemeDetail>? themes);

    int SaveStockTheme(StockTheme theme);
}