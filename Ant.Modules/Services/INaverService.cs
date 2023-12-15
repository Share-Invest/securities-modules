using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface INaverService
{
    int SaveStockTheme(StockTheme theme);

    void SaveStockTheme(StockThemeDetail theme);
}