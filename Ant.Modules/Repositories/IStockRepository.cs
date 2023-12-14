using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IStockRepository
{
    TreeMapStock[] GetStocks(string latestDate);

    int SaveStockTheme(IEnumerable<StockThemeDetail>? themes);

    int SaveStockTheme(StockTheme theme);
}