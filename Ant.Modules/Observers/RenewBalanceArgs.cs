namespace ShareInvest.Observers;

public class RenewBalanceArgs(string accNo) : MsgEventArgs
{
    public string AccNo { get; } = accNo;
}