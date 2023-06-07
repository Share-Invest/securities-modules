using ShareInvest.Interface;

namespace ShareInvest;

public class InvalidActiveXStateException : Exception
{
    public override string ToString() =>

        kind switch
        {
            ActiveXInvokeKind.MethodInvoke => $"AXInvalidMethodInvoke {name}",

            ActiveXInvokeKind.PropertyGet => $"AXInvalidPropertyGet {name}",

            ActiveXInvokeKind.PropertySet => $"AXInvalidMethodInvoke {name}",

            _ => base.ToString()
        };

    public InvalidActiveXStateException(string name, ActiveXInvokeKind kind)
    {
        this.name = name;
        this.kind = kind;
    }
    readonly string name;
    readonly ActiveXInvokeKind kind;
}