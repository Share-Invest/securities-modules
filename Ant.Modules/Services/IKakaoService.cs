using ShareInvest.Entities;
using ShareInvest.Entities.Kakao;

namespace ShareInvest.Services;

public interface IKakaoService
{
    Task<int> RegisterTheFriendsAsync(KakaoFriendInventory inventory);

    int SaveCallback(KakaoCallback callback);
}