using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface ISecuritiesService : IDisposable
{
    Task<int> RegisterUserAsync(Securities securities);
}