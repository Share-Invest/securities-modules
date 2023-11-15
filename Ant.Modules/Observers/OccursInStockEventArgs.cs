namespace ShareInvest.Observers;

public class OccursInStockEventArgs : MsgEventArgs
{
    public OccursInStockEventArgs(string code)
    {
        Code = code;
    }
    public string Code
    {
        get;
    }
}