namespace ShareInvest.RealTypes;

/// <summary>장시작시간</summary>
public enum MarketOperation
{
    장시작전 = 0,
    장마감전_동시호가 = 2,
    장시작 = 3,
    장종료_예상지수종료 = 4,
    장마감 = 8,
    장종료_시간외종료 = 9,
    시간외_종가매매_시작 = 'a',
    시간외_종가매매_종료 = 'b',
    시간외_단일가_매매시작 = 'c',
    시간외_단일가_매매종료 = 'd',
    선옵_장마감전_동시호가_시작 = 's',
    선옵_장마감전_동시호가_종료 = 'e'
}
public static class Market
{
    /// <summary>장시작시간</summary>
    /// <param name="gubun">[215] = 장운영구분</param>
    /// <returns><see cref="MarketOperation"/></returns>
    public static MarketOperation GetOperation(string? gubun)
    {
        if (gubun?.Length == 1)
        {
            var index = char.IsDigit(gubun[0]) ? Convert.ToInt32(gubun) : Convert.ToChar(gubun);

            if (Enum.IsDefined(typeof(MarketOperation), index))
            {
                return (MarketOperation)index;
            }
        }
        return MarketOperation.장종료_시간외종료;
    }
    /// <summary>market classification code used by Kiwoom Securities</summary>
    public static Dictionary<string, string> MarketCode
    {
        get => new()
        {
            {
                "코스피", "0"
            },
            {
                "코스닥", "10"
            },
            {
                "ELW", "3"
            },
            {
                "ETF", "8"
            },
            {
                "KONEX", "50"
            },
            {
                "뮤추얼펀드", "4"
            },
            {
                "신주인수권", "5"
            },
            {
                "리츠", "6"
            },
            {
                "하이얼펀드", "9"
            },
            {
                "K-OTC", "30"
            }
        };
    }
}