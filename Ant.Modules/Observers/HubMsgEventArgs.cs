using ShareInvest.Entities.Google;

namespace ShareInvest.Observers;

public class HubMsgEventArgs : MsgEventArgs
{
    public CoordinateStock Stock
    {
        get;
    }
    public HubMsgEventArgs(string code, string[] elements)
    {
        Stock = convertFunc(code, elements);
    }
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