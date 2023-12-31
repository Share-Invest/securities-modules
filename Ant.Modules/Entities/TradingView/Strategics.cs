namespace ShareInvest.Entities.TradingView;

public struct Strategics
{
    public DateTime DateTime
    {
        get; set;
    }
    public DateTime JustBefore
    {
        get; set;
    }
    public int Position
    {
        get; private set;
    }
    public IEnumerable<double> Histogram
    {
        get; set;
    }
    public IEnumerable<double> Slope
    {
        get; set;
    }
    /// <summary>
    /// -1.BuyStop
    /// 1.SellStop
    /// </summary>
    public int AtrStop
    {
        get; set;
    }
    /// <summary>
    /// -1.bearish
    /// 1.bullish
    /// </summary>
    public int SuperTrend
    {
        get; set;
    }
    public bool DecideOnPosition
    {
        get
        {
            Position = AtrStop + SuperTrend;

            if (Position == 0 || (DateTime - JustBefore).TotalSeconds <= 1)
            {
                return false;
            }
            IEnumerable<double>[] continuity = new[]
            {
                Histogram,
                Slope
            };
            if (Position < 0)
            {
                continuity = new[]
                {
                    Histogram.Reverse(),
                    Slope.Reverse()
                };
            }
            foreach (var arr in continuity)
            {
                if (arr.Zip(arr.Skip(1), (current, next) => current < next).All(e => e))
                {
                    continue;
                }
                return false;
            }
            return Position != 0;
        }
    }
}