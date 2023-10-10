namespace ShareInvest.Services;

public interface IUserRepository : IDisposable
{
    (string? securitiesId, string? pushKey) GetPushKey(string userId, string serialKey);
}