using ShareInvest.Entities;
using ShareInvest.Entities.Kakao;

namespace ShareInvest.Services;

public interface IKakaoService
{
    Task<KakaoFriendInventory> BringFriendsAsync(string userId);

    Task<int> RegisterTheFriendsAsync(KakaoFriendInventory inventory);

    Securities[] RetrieveAccountsThatOwnFutures(string date);

    int SaveCallback(KakaoCallback callback);
}