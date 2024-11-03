namespace ShareInvest.Observers;

public class OptionOrderMarginArgs(string classification) : MsgEventArgs
{
    public string Classification { get; } = classification;
}