namespace ShareInvest.Observers;

public class AssetsEventArgs(string accNo) : MsgEventArgs
{
    public string AccNo { get; } = accNo;
}