using ShareInvest.Entities;
using ShareInvest.Entities.Kakao;

namespace ShareInvest.Services;

public interface IKakaoService
{
    Task<KakaoFriendInventory> BringFriendsAsync(string userId);

    Task<int> RegisterTheFriendsAsync(KakaoFriendInventory inventory);

    int SaveCallback(KakaoCallback callback);
}