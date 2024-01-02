using ShareInvest.Entities;
using ShareInvest.Entities.Google;
using ShareInvest.Entities.Kakao;

namespace ShareInvest.Repositories;

public interface IUserRepository
{
    int RegisterTheFriends(string userId, IEnumerable<KakaoFriend> friends);

    int SaveCallback(KakaoCallback callback);

    string[] GetAccountsById(string userName);

    string[] GetFuturesAccount(Securities securities);

    KakaoFriend[] BringFriends(string userId);

    Securities[] RetrieveAccountsThatOwnFutures(string date);

    Securities[] GetSecuritiesById(string userName);

    Securities[] GetSecuritiesById();

    CoordinateUser[] GetClientCoordinates(IEnumerable<string> imageUrl, string? userName = null);

    IEnumerable<string> GetPushKeys();

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}