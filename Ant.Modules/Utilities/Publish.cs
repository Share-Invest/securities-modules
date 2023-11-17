using Newtonsoft.Json;

using RestSharp;

using System.Diagnostics;
using System.Net;

namespace ShareInvest.Utilities;

public class Publish : RestClient
{
    public async Task ExecuteAsync(string program, string workingDirectory, string compile)
    {
        var fileVersionInfo = new Entities.FileVersionInfo
        {
            App = program[..^4],
            Path = program[^3..],
            FileName = program,
            Publish = DateTime.Now.Ticks,
            File = await File.ReadAllBytesAsync(Path.Combine(workingDirectory, compile, program))
        };
        await ExecuteAsync(fileVersionInfo.GetType().Name, fileVersionInfo);
    }
    public async Task ExecuteAsync(string program, string? exclusionPath = null)
    {
        foreach (var info in GetVersionInfo(program, exclusionPath))
        {
            var index = info.FileName.IndexOf(nameof(Publish).ToLowerInvariant());

            if (index < 0)
            {
                continue;
            }
            await ExecuteAsync(info.GetType().Name, new Entities.FileVersionInfo
            {
                App = program[..^4],
                Path = Path.GetDirectoryName(info.FileName)?[index..],
                FileName = Path.GetFileName(info.FileName),
                CompanyName = info.CompanyName,
                FileBuildPart = info.FileBuildPart,
                FileDescription = info.FileDescription,
                FileMajorPart = info.FileMajorPart,
                FileMinorPart = info.FileMinorPart,
                FilePrivatePart = info.FilePrivatePart,
                FileVersion = info.FileVersion,
                InternalName = info.InternalName,
                OriginalFileName = info.OriginalFilename,
                PrivateBuild = info.PrivateBuild,
                ProductBuildPart = info.ProductBuildPart,
                ProductMajorPart = info.ProductMajorPart,
                ProductMinorPart = info.ProductMinorPart,
                ProductName = info.ProductName,
                ProductPrivatePart = info.ProductPrivatePart,
                ProductVersion = info.ProductVersion,
                Publish = DateTime.Now.Ticks,
                File = await File.ReadAllBytesAsync(info.FileName)
            });
        }
    }
    public string? CommandLine
    {
        get; set;
    }
    public Publish(string path, string baseUrl, string accessToken) : base(baseUrl, configureDefaultHeaders: headers =>
    {
        headers.Add(KnownHeaders.Authorization, $"Bearer {accessToken}");
    })
    {
        cts = new CancellationTokenSource();

        this.path = path;
    }
    async Task ExecuteAsync(string route, Entities.FileVersionInfo ctor)
    {
        var request = new RestRequest(Parameter.TransformOutbound(route), Method.Post);

        request.AddJsonBody(JsonConvert.SerializeObject(ctor));

        var response = await ExecuteAsync(request, cts.Token);

        if (HttpStatusCode.OK != response.StatusCode)
        {
#if DEBUG
            Debug.WriteLine(new
            {
                response.Content,
                response.StatusCode
            });
#endif
        }
    }
    IEnumerable<FileVersionInfo> GetVersionInfo(string fileName, string? exclusionPath = null)
    {
        string? dirName = string.Empty;

        foreach (var file in Directory.EnumerateFiles(path, fileName, SearchOption.AllDirectories))
        {
            var info = FileVersionInfo.GetVersionInfo(file);

            if (string.IsNullOrEmpty(Cache.CompanyName) is false && Cache.CompanyName.Equals(info.CompanyName))
            {
                dirName = Path.GetDirectoryName(info.FileName);

                if (string.IsNullOrEmpty(dirName) is false && dirName.EndsWith(nameof(Publish), StringComparison.OrdinalIgnoreCase))
                {
#if DEBUG
                    Debug.WriteLine(JsonConvert.SerializeObject(info, Formatting.Indented));

                    Build(dirName);
#endif
                    break;
                }
            }
        }
        if (string.IsNullOrEmpty(dirName))
        {
            yield break;
        }
        foreach (var file in Directory.EnumerateFiles(dirName, "*", SearchOption.AllDirectories))
        {
            if (string.IsNullOrEmpty(exclusionPath) is false && file.StartsWith(exclusionPath, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
#if DEBUG
            Debug.WriteLine(file);
#endif            
            yield return FileVersionInfo.GetVersionInfo(file);
        }
    }
    void Build(string workingDirectory)
    {
        DirectoryInfo? directoryInfo;

        while (workingDirectory.Length > 0)
        {
            directoryInfo = Directory.GetParent(workingDirectory);

            if (directoryInfo != null)
            {
                workingDirectory = directoryInfo.FullName;

                if (directoryInfo?.GetFiles(Properties.Resources.CSPROJ, SearchOption.TopDirectoryOnly).Length > 0)
                {
                    break;
                }
            }
        }
        using (var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                Verb = Properties.Resources.ADMIN,
                FileName = Properties.Resources.POWERSHELL,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        })
        {
#if DEBUG
            process.OutputDataReceived += (sender, e) =>
            {
                Debug.WriteLine(e.Data);
            };
#endif
            if (process.Start())
            {
                process.BeginOutputReadLine();
                process.StandardInput.Write(CommandLine + Environment.NewLine);
                process.StandardInput.Close();
                process.WaitForExit();
            }
        }
    }
    readonly string path;
    readonly CancellationTokenSource cts;
}