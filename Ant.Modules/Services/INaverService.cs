using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface INaverService
{
    Task<int> SaveStockThemeAsync(StockTheme theme);

    void SaveStockTheme(StockThemeDetail theme);
}