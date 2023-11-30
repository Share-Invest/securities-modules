using ShareInvest.Entities;
using ShareInvest.Entities.Google;

namespace ShareInvest.Repositories;

public interface IUserRepository
{
    int SaveCallback(KakaoCallback callback);

    string[] GetAccountsById(string userName);

    Securities[] GetSecuritiesById(string userName);

    Securities[] GetSecuritiesById();

    CoordinateUser[] GetClientCoordinates(string userName, string? imageUrl);

    IEnumerable<string> GetPushKeys();

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}