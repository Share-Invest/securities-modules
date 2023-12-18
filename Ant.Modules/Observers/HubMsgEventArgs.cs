using ShareInvest.Entities.Google;
using ShareInvest.Entities.TradingView;

namespace ShareInvest.Observers;

public class HubMsgEventArgs : MsgEventArgs
{
    public CoordinateStock Stock
    {
        get;
    }
    public OverviewCandleChart ChartData
    {
        get;
    }
    public HubMsgEventArgs(string code, string[] elements)
    {
        Stock = convertFunc(code, elements);

        ChartData = convertOverviewFunc(code, elements, Stock.Current);
    }
    readonly Func<string, string[], int, OverviewCandleChart> convertOverviewFunc = (code, elements, close) =>
    {
        return new OverviewCandleChart
        {
            Date = DateTime.Now.ToString("d"),
            Close = close,
            Volume = elements.Length == 43 && int.TryParse(elements[7], out int vol) ? Math.Abs(vol) : 0,
            Open = elements.Length == 43 && int.TryParse(elements[9], out int open) ? Math.Abs(open) : 0,
            High = elements.Length == 43 && int.TryParse(elements[0xA], out int high) ? Math.Abs(high) : 0,
            Low = elements.Length == 43 && int.TryParse(elements[0xB], out int low) ? Math.Abs(low) : 0
        };
    };
    readonly Func<string, string[], CoordinateStock> convertFunc = (code, elements) =>
    {
        return new CoordinateStock
        {
            Code = code,
            Current = Math.Abs(int.TryParse(elements[1], out int current) ? current : 0),
            Rate = Math.Abs(double.TryParse(elements[3], out double rate) ? rate * 1e-2 : 0),
            CompareToPreviousDay = Math.Abs(int.TryParse(elements[2], out int compareToPreviousDay) ? compareToPreviousDay : 0),
            CompareToPreviousSign = elements[elements.Length == 7 ? 6 : 0xC]
        };
    };
}