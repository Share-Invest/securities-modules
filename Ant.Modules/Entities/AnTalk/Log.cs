namespace ShareInvest.Entities.AnTalk;

public enum LogClassification
{
    Kiwoom = 'K'
}
public struct Log
{
    public DateTime DateTime
    {
        get; set;
    }
    public string AccNo
    {
        get; set;
    }
    public string Code
    {
        get; set;
    }
    public string Title
    {
        get; set;
    }
    public string SubTitle
    {
        get; set;
    }
    public LogClassification Classification
    {
        get; set;
    }
}