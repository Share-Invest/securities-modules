using ShareInvest.Entities;
using ShareInvest.Entities.Google;

namespace ShareInvest.Repositories;

public interface IUserRepository
{
    int SaveCallback(KakaoCallback callback);

    string[] GetAccountsById(string userName);

    Securities[] GetSecuritiesById(string userName);

    Securities[] GetSecuritiesById();

    CoordinateUser[] GetClientCoordinates(IEnumerable<string> imageUrl, string? userName = null);

    IEnumerable<string> GetPushKeys();

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}