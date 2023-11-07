using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IUserRepository
{
    int SaveCallback(KakaoCallback callback);

    string[] GetAccountsById(string userName);

    Securities[] GetSecuritiesById(string userName);

    IEnumerable<string> GetPushKeys();

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}