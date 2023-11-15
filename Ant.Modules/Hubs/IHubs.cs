namespace ShareInvest.Hubs;

public interface IHubs
{
    Task AddToGroupAsync(string groupName);

    Task RemoveFromGroupAsync(string groupName);

    Task TransmitConclusionInformationAsync(string code, string data);

    Task InstructToRenewAssetStatusAsync(string accNo);

    Task EventOccursInStockAsync(string code);
}