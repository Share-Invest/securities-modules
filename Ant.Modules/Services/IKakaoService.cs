using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface IKakaoService
{
    int SaveCallback(KakaoCallback callback);
}