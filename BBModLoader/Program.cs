// See https://aka.ms/new-console-template for more information

using BBmodLauncher2;

Console.WriteLine("BBCF Mod Launcher Ver 2.0");
settingshandler settingshand = new settingshandler();
pathchecker pathchecker = new pathchecker();
string[] settings = settingshand.checksettings();
bool newset = false; 

if(!File.Exists("settings.txt") || File.ReadAllLines("settings.txt").Length == 0) newset = true;

if (newset || settings[0] == "")
{
    Console.WriteLine("Please enter Mod folder path (folder named 'data')");
    readmod:
    string entry = Console.ReadLine();
    if (!entry.Contains("\\data"))
    {
        Console.WriteLine("make sure it is a folder named 'data'");
        goto readmod;
    }
    settingshand.writesettings("mod", entry);
}
if (newset || settings[1] == "")
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
if (newset || settings[2] == "")
{
    Console.WriteLine("Please enter Steam folder path (folder named 'data')");
    readsteam:
    string entry = Console.ReadLine();
    if (pathchecker.checksteam(entry))
    {
        Console.WriteLine("make sure to select the Steam folder with steam.exe in it");
        goto readsteam;
    }
    settingshand.writesettings("steam", entry);
}
if (newset || settings[3] == "")settingshand.writesettings("modded?", "n");




foreach (string s in settings)
{
    Console.WriteLine(s);
}

Console.Read();
