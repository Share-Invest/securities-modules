using ShareInvest.Entities.TradingView;

namespace ShareInvest.Utilities.TradingView;

public class Futures
{
    public int TransactionMultiplier
    {
        get
        {
            if (string.IsNullOrEmpty(Balance.Code))
            {
                return 0;
            }
            return Balance.Code[2] == '1' ? Service.KospiTransactionMultiplier : Service.KosdaqTransactionMultiplier;
        }
    }
    public Simulation Balance
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
        Balance.CumulativeRevenue += (long)(TransactionMultiplier * liquidateReserves() - Service.Commission * transactionPrice * TransactionMultiplier);
        Balance.HoldingQuantity += quantity;
    }
    public Futures(string code, string date, string? strategics = null)
    {
        Balance = new Simulation
        {
            Code = code,
            Date = date,
            Strategics = strategics ?? string.Empty
        };
    }
}