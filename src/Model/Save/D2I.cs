using D2SLib.IO;
using System.Buffers.Binary;

namespace D2SLib.Model.Save;

public sealed class D2I : IDisposable
{

    public List<StashTab> Tabs = new List<StashTab>();

    /* C:\Users\Tiama\Saved Games\Diablo II Resurrected\mods\D2RMM\SharedStashSoftCoreV2.d2i (2024-06-08 11:40:51 AM)
   StartOffset(h): 00000000, EndOffset(h): 0000003F, Length(h): 00000040 */


    private D2I(IBitReader reader, uint version)
    {
        while(reader.Length() > reader.Position)
        {
            Tabs.Add(StashTab.Read(reader));
        }
    }

    public Header Header { get; }
    //public ItemList ItemList { get; }

    public void Write(IBitWriter writer)
    {
        foreach(var tab in Tabs)
        {
            var bytes = StashTab.Write(tab);
            writer.WriteBytes(bytes);
        }
        
    }



    public static D2I Read(IBitReader reader, uint version) => new(reader, version);

    public static D2I Read(ReadOnlySpan<byte> bytes, uint version)
    {
        using var reader = new BitReader(bytes);
        return new D2I(reader, version);
    }

    public static byte[] Write(D2I d2i, uint version)
    {
        using var writer = new BitWriter();
        d2i.Write(writer);
        return writer.ToArray();
    }

    public void Dispose() => Tabs.ForEach(tab=> tab.Dispose());
}
