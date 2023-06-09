﻿using ShareInvest.Kiwoom;
using ShareInvest.Properties;

using System.IO.Compression;
using System.Text;

namespace ShareInvest;

public sealed partial class AxKHCoreAPI : AxKHOpenAPI
{
    public TR[] TrInventory
    {
        get;
    }
    /// <summary>insert a market code, the corresponding code list will be returned.</summary>
    /// <param name="marketCode"><see cref="MarketCode"/></param>
    /// <returns>code list</returns>
    public IEnumerable<string> GetCodeListByMarket(MarketCode marketCode)
    {
        return GetCodeListByMarket(((int)marketCode).ToString()).Split(';');
    }
    /// <summary><see cref="Tr.OPTKWFID"/></summary>
    /// <param name="sArrCode">Code Inventory</param>
    /// <param name="nCodeCount">Code Inventory Count</param>
    /// <param name="nTypeFlag">Stock:0, Futures:3</param>
    /// <param name="sRQName">sRQName</param>
    /// <param name="sScreenNo">sScreenNo</param>
    /// <returns><see cref="Guide.Error"/>ErrorCode</returns>
    public int CommKwRqData(string sArrCode, int nCodeCount, int nTypeFlag, string sRQName, string sScreenNo)
    {
        return CommKwRqData(sArrCode, 0, nCodeCount, nTypeFlag, sRQName, sScreenNo);
    }
    /// <summary>deliver the TR code, can receive INPUT and OUTPUT returns.</summary>
    /// <param name="sTrCode">see KOA Studio TR list.</param>
    /// <returns><see cref="TR"></see></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public TR GetTrData(string sTrCode)
    {
        var tr = Array.Find(TrInventory, m => sTrCode.Equals(m.Code, StringComparison.OrdinalIgnoreCase))

            ?? throw new FileNotFoundException(Resources.MODULE);

        if (string.IsNullOrEmpty(tr.Name))
        {
            if (string.IsNullOrEmpty(tr.Code))
            {
                throw new FileNotFoundException(Resources.MODULE);
            }
            using (var file = File.OpenRead(Path.Combine(path, string.Concat(tr.Code, Resources.ENC[1..]))))
            {
                using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
                {
                    foreach (var entry in zip.Entries)
                    {
                        if (sTrCode.Equals(Path.GetFileNameWithoutExtension(entry.Name), StringComparison.OrdinalIgnoreCase) is false)
                        {
                            continue;
                        }
                        InitializeTR(tr, entry);
                    }
                }
            }
        }
        return tr;
    }
    /// <summary>should not be used to customize.</summary>
    /// <param name="milliseconds"/>
    /// <returns><see cref="Guide.Error"/></returns>
    public bool CommConnect(int milliseconds)
    {
        OnReceiveChejanData += OnReceiveCoreChejanData;
        OnReceiveRealData += OnReceiveCoreRealData;
        OnReceiveTrData += OnReceiveCoreTrData;
        OnEventConnect += OnEventCoreConnect;
        OnReceiveMsg += OnReceiveCoreMessage;
#if DEBUG
        OnReceiveConditionVer += OnReceiveCoreConditionVersion;
        OnReceiveRealCondition += OnReceiveCoreRealCondition;
        OnReceiveTrCondition += OnReceiveCoreTrCondition;
#endif
        Delay.Instance.Milliseconds = milliseconds;

        return CommConnect() == 0;
    }
    /// <summary>call the EnsureHandle method to inject it as a parameter.</summary>
    /// <param name="hWndParent"></param>
    public AxKHCoreAPI(nint hWndParent, Process process = Process.x64) : base(hWndParent, process)
    {
        path = Path.Combine(GetAPIModulePath(), Resources.DATA);

        if (Directory.Exists(path))
        {
            TrInventory = InitializeTrInventory();
        }
        else
        {
            throw new DirectoryNotFoundException(Resources.MODULE);
        }
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
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
            }
        }
        return inventory.OrderBy(ks => ks.Code).ToArray();
    }
    static string[] GetKeyNames(string str)
    {
        var sections = new Queue<string>();

        foreach (var line in str.Split("\r\n", StringSplitOptions.RemoveEmptyEntries))
        {
            int pos = line.IndexOf('=');

            if (pos != -1)
            {
                sections.Enqueue(line[..pos].Trim());
            }
        }
        return sections.ToArray();
    }
    static void InitializeTR(TR tr, ZipArchiveEntry entry)
    {
        var buffer = new byte[0x4000];

        using (var stream = entry.Open())
        {
            stream.Read(buffer, 0, buffer.Length);

            var text = Encoding.GetEncoding(0x3B5).GetString(buffer);

            int nPos = 0, nPosEnd = 0;

            nPos = text.IndexOf(Resources.INPUT, nPos);
            nPos = text.IndexOf(Resources.START, nPos);
            nPos += Resources.START.Length;
            nPosEnd = text.IndexOf("\r\n", nPos);

            tr.Name = text[nPos..nPosEnd];

            nPos = nPosEnd + "\r\n".Length;
            nPosEnd = text.IndexOf(Resources.END, nPos);

            tr.Input = GetKeyNames(text[nPos..nPosEnd]);

            nPos = nPosEnd;
            nPos = text.IndexOf(Resources.OUTPUT, nPos);
            nPos = text.IndexOf(Resources.START, nPos);
            nPosEnd = text.IndexOf('=', nPos);

            var name = text.Substring(nPos + 7, nPosEnd - nPos - 7);

            nPos = nPosEnd + 1;
            nPosEnd = text.IndexOf("\r\n", nPos);

            var classification = text[nPos..nPosEnd];

            nPos = nPosEnd + "\r\n".Length;
            nPosEnd = text.IndexOf(Resources.END, nPos);

            var contents = text[nPos..nPosEnd];

            if (classification == Resources.SINGLE)
            {
                tr.SingleData = GetKeyNames(contents);

                nPos = nPosEnd + "\r\n".Length;
                nPos = text.IndexOf(Resources.START, nPos);

                if (nPos != -1)
                {
                    nPosEnd = text.IndexOf("\r\n", nPos);
                    nPos = nPosEnd + "\r\n".Length;
                    nPosEnd = text.IndexOf(Resources.END, nPos);

                    tr.MultiData = GetKeyNames(text[nPos..nPosEnd]);
                }
            }
            else
                tr.MultiData = GetKeyNames(contents);
        }
    }
    readonly string path;
}