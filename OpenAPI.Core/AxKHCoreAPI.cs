using Newtonsoft.Json;

using ShareInvest.Data;
using ShareInvest.Kiwoom;
using ShareInvest.Properties;

using System.Diagnostics;

namespace ShareInvest;

public sealed class AxKHCoreAPI : AxKHOpenAPI
{
    public TR[] TrInventory
    {
        get;
    }
    public override int CommRqData(string sRQName, string sTrCode, int nPrevNext, string sScreenNo)
    {


        return base.CommRqData(sRQName, sTrCode, nPrevNext, sScreenNo);
    }
    /// <summary>
    /// call the EnsureHandle method to inject it as a parameter.
    /// </summary>
    /// <param name="hWndParent"></param>
    public AxKHCoreAPI(nint hWndParent) : base(hWndParent)
    {
        path = Path.Combine(GetAPIModulePath(), nameof(Data));

        if (Directory.Exists(path))
        {
            TrInventory = InitializeTrInventory();
        }
        else
        {
            throw new DirectoryNotFoundException(@"https://www1.kiwoom.com/h/customer/download/VOpenApiInfoView");
        }
    }
    TR[] InitializeTrInventory()
    {
        var inventory = new Queue<TR>();

        foreach (var file in Directory.GetFiles(path, Resources.ENC, SearchOption.TopDirectoryOnly))
        {
            var fi = new FileInfo(file);

            if (fi.Exists)
            {
                var code = Path.GetFileNameWithoutExtension(fi.Name);

                inventory.Enqueue(new TR
                {
                    Code = code
                });
#if DEBUG
                Debug.WriteLine(JsonConvert.SerializeObject(new
                {
                    code,
                    fi.FullName
                }));
#endif
            }
        }
        return inventory.OrderBy(ks => ks.Code).ToArray();
    }
    readonly string path;
}