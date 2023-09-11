using ShareInvest.Entities;

namespace ShareInvest.Services;

public interface IFileService : IDisposable
{
    IEnumerable<FileVersionInfo>? GetFileVersions(string app);

    Task<FileInfo?> Save(FileVersionInfo fileVersionInfo);

    (string?, FileVersionInfo?) CheckFileVersions(string app, string name, string path);
}