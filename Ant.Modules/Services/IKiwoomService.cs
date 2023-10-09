using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface IKiwoomService
{
    Task<int> RecordAssetStatusAsync(AccountBook assets);
}