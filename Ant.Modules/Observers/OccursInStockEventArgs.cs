namespace ShareInvest.Observers;

public class OccursInStockEventArgs(string code) : MsgEventArgs
{
    public string Code { get; } = code;
}