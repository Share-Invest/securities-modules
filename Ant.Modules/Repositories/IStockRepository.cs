using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    Task<int> SaveStockThemeAsync(IEnumerable<StockThemeDetail>? themes);

    TreeMapStock[] GetStocks(string latestDate);

    int SaveStockTheme(StockTheme theme);
}