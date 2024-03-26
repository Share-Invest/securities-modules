using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    Task<HighGrowthRateTheme[]> GetThemesWithHighGrowthRateAsync();

    Task<TreeMapStock[]> GetStocksCategorizedByThemeAsync(HighGrowthRateTheme[] themeGroup);

    Task<Dictionary<string, StockTheme[]>> ExpressTheMarketByThemeAsync();

    Task<bool> ExistFinancialStatementsAsync(FinancialStatements fs);

    int SaveFinancialStatements(FinancialStatements fs);

    int SaveStockTheme(IEnumerable<StockThemeDetail>? themes);

    int SaveStockTheme(StockTheme theme);
}