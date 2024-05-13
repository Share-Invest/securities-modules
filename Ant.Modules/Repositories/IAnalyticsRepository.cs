using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IAnalyticsRepository
{
    Task<int> ItemCountAsync(string? latestDate);

    FinancialStatements[] GetFinancialState(string code, string date);

    Analytics[] GetInOrderOfMarketCap(IDictionary<string, IEnumerable<StockThemeDetail>> themes, string? latestDate);

    Analytics[] GetInOrderOfMarketCap(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfSales(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfOp(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfNp(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfPer(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfPbr(string? latestDate, int startIndex, int endIndex);

    Analytics[] GetInOrderOfRoe(string? latestDate, int startIndex, int endIndex);
}