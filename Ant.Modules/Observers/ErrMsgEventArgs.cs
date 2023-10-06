namespace ShareInvest.Observers;

public class ErrMsgEventArgs : MsgEventArgs
{
    public string Msg
    {
        get;
    }
    public ErrMsgEventArgs(string msg)
    {
        Msg = msg;
    }
}