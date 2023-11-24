namespace ShareInvest.Services.AnTalk;

public enum Order
{
    ListingDate = 'L',
    MarketCap = 'C',
    Rate = 'R',
    Volume = 'V',
    CompareToPreviousVolume = 'P' + 'V'
}