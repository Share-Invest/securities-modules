using ShareInvest.Entities.Kiwoom;
using ShareInvest.Interface;

namespace ShareInvest.Services;

public interface IKiwoomService
{
    Task<int> RecordAssetStatusAsync(IAccountBook assets);

    Task<int> RecordAssetStatusAsync(ChejanDerivatives chejan);

    Task<bool> IsFirstContractAsync(ChejanConclusion conclusion);

    int LiquidateStocksHeld(ChejanBalance balance);
}