using ShareInvest.Entities;

namespace ShareInvest.Repositories;

public interface IFileVersionInfoRepository : IDisposable
{
    IEnumerable<FileVersionInfo>? GetFileVersions(string app);

    int Save(FileVersionInfo fileVersionInfo);

    FileVersionInfo? CheckFileVersions(string app, string name, string path);
}