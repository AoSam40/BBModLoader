// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using BBmodLauncher2;

if (!File.Exists("./integrity.txt"))
{
    Console.WriteLine("Integrity file not found, make sure it exists in the same folder as this program.");
    goto End;
}
Console.WriteLine("                   BBCF Mod Loader Ver 2.0                    ");
Console.WriteLine("______________________________________________________________________");
settingshandler settingshand = new settingshandler();
pathchecker pathchecker = new pathchecker();
filehandler filehandler = new filehandler();
Process[] Processes = null;
string[] settings = settingshand.checksettings();
bool newset = false; 


if(!File.Exists("settings.txt") || File.ReadAllLines("settings.txt").Length == 0) newset = true;


if (Directory.Exists("./temp"))
{
    if (Directory.GetFiles("./temp", "*.*", SearchOption.AllDirectories).Length != 0) settings[3] = "y";
}

if (settings[3] == "y") 
{
    Console.WriteLine("Modded game found");
    Console.WriteLine("resetting...");
    goto vani;

}

if (!newset)
{ 
    Console.WriteLine("Press N to change file locations or press any other key to continue...");

    if(Console.ReadKey(true).Key == ConsoleKey.N) newset = true;
}



if (newset || settings[0] == "Mod folder:"|| !Directory.Exists(settings[0]))
{
    if(!Directory.Exists(settings[0]) && !newset) Console.WriteLine("Mod folder not found");
    Console.WriteLine("Please enter Mod folder path (folder named 'data')");
    readmod:
    string entry = Console.ReadLine();
    if (!entry.Contains("/data"))
    {
        Console.WriteLine("make sure it is a folder existing folder and named 'data'");
        goto readmod;
    }
    settingshand.writesettings("mod", entry);
}

if (newset || settings[1] == "BBCF folder: ")
{
    Console.WriteLine("Please enter BBCF folder path (folder named 'data')");
    readbb:
    string entry = Console.ReadLine();
    if (!pathchecker.checksturcture(entry))
    {
        Console.WriteLine("make sure it is the bbcf data folder");
        goto readbb;
    }
    settingshand.writesettings("bbcf", entry);
}
if (newset || settings[2] == "Steam folder: ")
{
    Console.WriteLine("Please enter Steam folder path (folder where 'Steam.sh' is located)");
    readsteam:
    string entry = Console.ReadLine();
    if (pathchecker.checksteam(entry))
    {
        Console.WriteLine("make sure to select the Steam folder with steam.sh in it");
        goto readsteam;
    }
    settingshand.writesettings("steam", entry);
}
if (newset || settings[3] == "modded?: ") settingshand.writesettings("modded?", "n");



Thread.BeginCriticalRegion();

filehandler.swapfiles();

Thread.EndCriticalRegion();

if(File.ReadAllLines("./backup.txt").Length != 0) settingshand.writesettings("modded?", "y");

settings = settingshand.checksettings();

Process.Start(settings[2] +"/steam.sh",@"steam://rungameid/586140");

Processes = Process.GetProcessesByName("BBCF");

Console.WriteLine("Starting BBCF");

while (Processes.Length < 1)
{
    Processes = Process.GetProcessesByName("BBCF");
    Console.WriteLine(".");
    Thread.Sleep(3000);
}
Console.WriteLine(".");
Console.WriteLine("BBCF is running...");

Processes[0].WaitForExit();



vani:

filehandler.resetfiles();

settingshand.writesettings("modded?", "n");


Console.WriteLine("Vanilla restored.");
Console.WriteLine("Zeiyah.");

End:
Thread.Sleep(3000);



