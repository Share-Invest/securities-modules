using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    Task<int> SaveStockThemeAsync(IEnumerable<StockThemeDetail>? themes);

    int SaveStockTheme(StockTheme theme);
}