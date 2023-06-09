using ShareInvest.Kiwoom;

namespace ShareInvest;

public sealed class AxKHCoreAPI : AxKHOpenAPI
{
    /// <summary>
    /// call the EnsureHandle method to inject it as a parameter.
    /// </summary>
    /// <param name="hWndParent"></param>
    public AxKHCoreAPI(nint hWndParent) : base(hWndParent)
    {
        path = Path.Combine(GetAPIModulePath(), nameof(Data));
    }
    readonly string path;
}