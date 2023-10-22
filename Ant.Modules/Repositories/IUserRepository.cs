namespace ShareInvest.Repositories;

public interface IUserRepository
{
    IEnumerable<string> GetPushKeys();

    IEnumerable<(string? securitiesId, string? pushKey)> GetPushKeys(string userId, string serialKey);
}