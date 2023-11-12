namespace ShareInvest.Observers;

public class AssetsEventArgs : MsgEventArgs
{
    public string AccNo
    {
        get;
    }
    public AssetsEventArgs(string accNo)
    {
        AccNo = accNo;
    }
}