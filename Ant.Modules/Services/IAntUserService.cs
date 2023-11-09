namespace ShareInvest.Services;

public interface IAntUserService
{
    Task<string?> GetExternalLoginTokenAsync<T>(T user) where T : class;
}