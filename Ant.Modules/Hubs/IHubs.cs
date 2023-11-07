namespace ShareInvest.Hubs;

public interface IHubs
{
    Task AddToGroupAsync(string groupName);

    Task RemoveFromGroupAsync(string groupName);

    Task TransmitConclusionInformationAsync(string code, string data);

    Task InstructToRenewAssetStatus(string accNo);
}