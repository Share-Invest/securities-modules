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
    public bool DecideOnPosition(long seedMoney = 0, int quantity = 0, double price = double.NaN, string? code = null)
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
        if (seedMoney > 0)
        {
            double margin = double.MaxValue, commission = double.MaxValue;

            switch (code?[..3])
            {
                case "101":
                    margin = price * Service.KospiTransactionMultiplier * Service.KospiConsignmentMarginRate;
                    commission = price * Service.KospiTransactionMultiplier * Service.Commission;
                    break;

                case "106":
                    margin = price * Service.KosdaqTransactionMultiplier * Service.KosdaqConsignmentMarginRate;
                    commission = price * Service.KosdaqTransactionMultiplier * Service.Commission;
                    break;
            }
            if (margin + commission < seedMoney - Math.Abs(quantity * margin))
            {
                return Position != 0;
            }
        }
        return quantity switch
        {
            > 0 when Position > 0 => false,
            < 0 when Position < 0 => false,
            _ => Position != 0
        };
    }
}