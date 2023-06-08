using ShareInvest.Properties;
using System.Diagnostics;
using System.IO.Compression;

namespace ShareInvest
{
    class OpenAPI
    {
        internal async Task InstallAsync()
        {
            var fileFullName = Path.Combine(path, Resources.ZIP);

            await File.WriteAllBytesAsync(fileFullName, Resources.OpenAPIx64);

            ZipFile.ExtractToDirectory(fileFullName, path, true);

            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Resources.INSTALL,
                    WorkingDirectory = path,
                    Verb = Resources.ADMIN,
                    UseShellExecute = true,
                    CreateNoWindow = true
                }
            })
            {
                if (process.Start())
                {
                    process.WaitForExit();
                }
            }
            File.Delete(fileFullName);
        }
        internal OpenAPI()
        {
            var directory = new DirectoryInfo($@"C:\{nameof(OpenAPI)}");

            if (directory.Exists is false)
            {
                directory.Create();
            }
            path = directory.FullName;
        }
        readonly string path;
    }
}