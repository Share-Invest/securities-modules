namespace ShareInvest;

public class TR
{
    /// <summary>sTrCode</summary>
    public string? Code
    {
        get; internal set;
    }
    /// <summary>sRQName</summary>
    public string? Name
    {
        get; internal set;
    }
    /// <summary>INPUT sID</summary>
    public string[]? Input
    {
        get; internal set;
    }
    /// <summary>OUTPUT 싱글데이터 strItemName</summary>
    public string[]? SingleData
    {
        get; internal set;
    }
    /// <summary>OUTPUT 멀티데이터 strItemName</summary>
    public string[]? MultiData
    {
        get; internal set;
    }
}
/// <summary>market event code used by Kiwoom Securities</summary>
public enum MarketEvent
{
    유상증자 = 1,
    무상증자 = 2,
    배당락 = 4,
    액면분할 = 8,
    액면병합 = 0x10,
    기업합병 = 0x20,
    감자 = 0x40,
    권리락 = 0x100
}