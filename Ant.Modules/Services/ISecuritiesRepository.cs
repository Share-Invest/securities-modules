using ShareInvest.Entities;
using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Services;

public interface ISecuritiesRepository : IDisposable
{
    Task<int> RegisterUserAsync(Securities securities);

    Task<int> RecordStockInformationfromKiwoomSecuritiesAsync(Entities.OPTKWFID item);

    Task<int> RecordAssetStatusAsync(AccountBook assets);

    int RecordsCommunicationsWithSecuritiesCorp(OpenMessage message);
}