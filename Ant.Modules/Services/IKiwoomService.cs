using ShareInvest.OpenAPI.Entity;

namespace ShareInvest.Services;

public interface IKiwoomService
{
    Task<int> RecordAssetStatusAsync(IAccountBook assets);
}