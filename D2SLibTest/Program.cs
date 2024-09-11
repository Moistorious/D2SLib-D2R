using D2SLib;
using D2SLib.IO;
using D2SLib.Model.Save;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

//D2S character = D2S.Read(File.ReadAllBytes("C:\\Users\\ShadowEvil\\Downloads\\Amazon.d2s"));
const string saveFolder = @"C:\Users\Tiama\Saved Games\Diablo II Resurrected\mods\D2RMM\";
const string characterName = "ZZZZAP";
var backupCount = 0;
var charFile = $"{saveFolder}{characterName}.d2s";
string backupFile;
do
{
    backupCount++;
    backupFile = $"{charFile}.bak{backupCount}";
} while (File.Exists(backupFile));

File.Copy(charFile, backupFile);

D2S character = Core.ReadD2S(File.ReadAllBytes(charFile));
character.MapId -= 1;
Console.WriteLine(character.MapId);
File.WriteAllBytes(charFile, Core.WriteD2S(character));
/*
var zx = character.Quests.Nightmare.ActV.SiegeOnHarrogath.RewardPending;


D2I items = Core.ReadD2I("C:\\Users\\Tiama\\Saved Games\\Diablo II Resurrected\\mods\\D2RMM\\SharedStashSoftCoreV2.d2i", 99);

const int width = 16;
const int height = 13;


bool[][] grid = new bool [height][];

for (int i = 0; i < height; i++)
{
    grid[i] = Enumerable.Repeat(false, width).ToArray<bool>();
}

foreach(var item in items.Tabs[0].Items.Items)
{
    D2SLib.Model.Data.DataRow? itemType = ResourceFilesData.Instance.MetaData.ItemsData.GetByCode(item.Code);
    var w = Int32.Parse(itemType["invwidth"].Value);
    var h = Int32.Parse(itemType["invheight"].Value);
    for(int x = 0; x < w; x++)
    {
        for (int y = 0; y < h; y++)
        {
            grid[item.Y + y][item.X + x] = true;
        }
    }
    
}

Console.WriteLine(new string('-', width + 2));
for (int x = 0; x < height; x++)
{
    Console.Write("|");
    for(int y = 0; y < width; y++)
    {
        Console.Write(grid[x][y] ? "*" : " ");
    }
    Console.Write("|\n");
}

Console.WriteLine(new string('-', width + 2));

//Console.WriteLine(character.Name);
//var item = items.Tabs[0].Items.Items[0];

var formatter = new BinaryFormatter();

using (var stream = new MemoryStream())
{
    formatter.Serialize(stream, items.Tabs[0].Items);
    //items.Tabs[0].Items.Items.Clear();

    var itembytes = stream.ToArray();
    File.WriteAllBytes("C:\\Users\\Tiama\\Saved Games\\Diablo II Resurrected\\mods\\D2RMM\\updated.item", itembytes);
}
var filestream = new FileStream("C:\\Users\\Tiama\\Saved Games\\Diablo II Resurrected\\mods\\D2RMM\\updated.item", FileMode.Open);
var z = (ItemList)formatter.Deserialize(filestream);

*/

//D2SLib.Model.Data.DataRow? itemType = ResourceFilesData.Instance.MetaData.ItemsData.GetByCode(item.Code);

//D2SLib.Model.Data.DataCell z = itemType["name"];


//var bytes = Core.WriteD2I(items, 101);

//File.WriteAllBytes("C:\\Users\\Tiama\\Saved Games\\Diablo II Resurrected\\mods\\D2RMM\\updated.d2i", bytes);


Console.ReadKey();