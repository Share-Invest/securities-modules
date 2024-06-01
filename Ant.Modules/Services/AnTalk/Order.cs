namespace ShareInvest.Services.AnTalk;

public enum Order
{
    ListingDate = 'L',
    MarketCap = 'C',
    Rate = 'R',
    Volume = 'V',
    CompareToPreviousVolume = 'P' + 'V'
}

/// <summary>ASCII</summary>
public enum TypeOfRankToOrder
{
    PBR = 'B',
    PER = 'E',
    /// <summary>82</summary>
    ROE = 'R',
    MarketCap = 'C',
    Sales = 'S',
    /// <summary>79</summary>
    OperatingProfit = 'O',
    NetProfit = 'N',
    /// <summary>161</summary>
    OverallRanking = 'O' + 'R'
}