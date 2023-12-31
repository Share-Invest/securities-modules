using ShareInvest.Entities.TradingView;

namespace ShareInvest.Utilities.TradingView;

public class Futures
{
    public FuturesBalance Balance
    {
        get;
    }
    public void Calculate(int quantity, double transactionPrice)
    {
        double liquidateReserves()
        {
            if (Balance.HoldingQuantity > 0 && quantity < 0)
            {
                var purchasePrice = transactionPrice - Balance.PurchasePrice;

                if (quantity + Balance.HoldingQuantity == 0)
                {
                    Balance.PurchasePrice = double.NegativeZero;
                }
                return purchasePrice;
            }
            if (Balance.HoldingQuantity < 0 && quantity > 0)
            {
                var purchasePrice = Balance.PurchasePrice - transactionPrice;

                if (quantity + Balance.HoldingQuantity == 0)
                {
                    Balance.PurchasePrice = double.NegativeZero;
                }
                return purchasePrice;
            }
            if (quantity != 0 && transactionPrice != 0)
            {
                Balance.PurchasePrice =

                    (Balance.PurchasePrice * Math.Abs(Balance.HoldingQuantity) + transactionPrice) / (Math.Abs(Balance.HoldingQuantity) + Math.Abs(quantity));
            }
            return double.NegativeZero;
        }
        Balance.CumulativeRevenue += (long)(transactionMultiplier * liquidateReserves() - commission * transactionPrice * transactionMultiplier);
        Balance.HoldingQuantity += quantity;
    }
    public Futures(string code, string date)
    {
        Balance = new FuturesBalance
        {
            Code = code,
            Date = date
        };
    }
    const int transactionMultiplier = 250_000;
    const double commission = 3e-5;
}