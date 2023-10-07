using ShareInvest.Entities;
using ShareInvest.Entities.Kiwoom;

namespace ShareInvest.Services;

public interface ISecuritiesService : IDisposable
{
    Task<int> RegisterUserAsync(Securities securities);

    int RecordsCommunicationsWithSecuritiesCorp(OpenMessage message);
}