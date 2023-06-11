using System.Text;

namespace ShareInvest.Tr;

public class OPTKWFID : Transaction
{
    /// <summary>list and return the code according to the OPTKWFID request.</summary>
    /// <param name="codeList"/>
    /// <returns>(inventory, count)</returns>
    public static IEnumerable<(string, int)> GetCodeInventory(IEnumerable<string> codeList)
    {
        int index = 0;
        var sb = new StringBuilder(0x100);
        var codeStack = new Queue<StringBuilder>(0x10);

        foreach (var code in codeList)
        {
            if (string.IsNullOrEmpty(code))
            {
                continue;
            }
            if (index++ % 0x63 == 0x62)
            {
                codeStack.Enqueue(sb.Append(code));

                sb = new StringBuilder();
            }
            sb.Append(code).Append(';');
        }
        codeStack.Enqueue(sb.Remove(sb.Length - 1, 1));

        while (codeStack.TryDequeue(out StringBuilder? pop))
        {
            if (pop.Length > 5 && pop.ToString() is string listOfStocks)
            {
                yield return (listOfStocks, listOfStocks.Split(';').Length);
            }
        }
    }
    protected internal override string LookupScreenNo
    {
        get => (Count++ + 0x1B58).ToString("D4");
    }
    uint Count
    {
        get; set;
    }
}