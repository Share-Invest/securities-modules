namespace ShareInvest.Tr;

public class Transaction
{
    public Dictionary<string, string>? InputValue
    {
        get => inputValue;
    }
    public string? TrCode
    {
        get; set;
    }
    public string? RQName
    {
        get; set;
    }
    public int PrevNext
    {
        get; set;
    }
    public string ScreenNo
    {
        get => LookupScreenNo;
    }
    protected internal virtual string LookupScreenNo
    {
        get
        {
            if (count++ == 0x95)
            {
                count = 0;
            }
            return (0xBB8 + count).ToString("D4");
        }
    }
    static uint count;

    readonly Dictionary<string, string> inputValue = new();
}