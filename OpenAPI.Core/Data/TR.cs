namespace ShareInvest.Data;

public class TR
{
    /// <summary>
    /// sTrCode
    /// </summary>
    public string? Code
    {
        get; internal set;
    }
    /// <summary>
    /// sRQName
    /// </summary>
    public string? Name
    {
        get; internal set;
    }
    /// <summary>
    /// Input sID
    /// </summary>
    public string[]? Input
    {
        get; internal set;
    }
    /// <summary>
    /// OUTPUT 싱글데이터 strItemName
    /// </summary>
    public string[]? SingleData
    {
        get; internal set;
    }
    /// <summary>
    /// OUTPUT 멀티데이터 strItemName
    /// </summary>
    public string[]? MultiData
    {
        get; internal set;
    }
}