using ShareInvest.Entities.Kiwoom;
using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Services;

public interface IKiwoomService
{
    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<int> RecordAssetStatusAsync(ChejanConclusion chejan);

    Task<int> RecordAssetStatusAsync(ChejanBalance chejan);

    Task<int> RecordAssetStatusAsync(ChejanDerivatives chejan);
}