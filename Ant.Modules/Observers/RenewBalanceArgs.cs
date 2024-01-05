namespace ShareInvest.Observers;

public class RenewBalanceArgs : MsgEventArgs
{
    public string AccNo
    {
        get;
    }
    public RenewBalanceArgs(string accNo)
    {
        AccNo = accNo;
    }
}