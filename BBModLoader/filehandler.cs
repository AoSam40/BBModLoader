using System.Linq.Expressions;
using System.Net;

namespace BBmodLauncher2;

public class filehandler
{
    static settingshandler settingshand = new settingshandler();
    static string[] settings = settingshand.checksettings();
    
    
    private string modpath = settings[0];
    private string gamepath = settings[1];
    private string temppath = "./temp";
    List<String> movedfiles = new List<String>();   
    List<String> modfiles = new List<string>();
    
    
    public void swapfiles()
    {
        
        if (!Directory.Exists(temppath)) Directory.CreateDirectory(temppath);
        Console.WriteLine(modpath);
        
        
        
        List<String> modfiles = Directory.GetFileSystemEntries(modpath).ToList();
        Console.WriteLine(modfiles.Count);
      

        foreach (string filename in modfiles)
        {
            Console.WriteLine(filename);
            try
            {
                if (File.Exists(filename.Replace(modpath, gamepath))) //does the gamefile with the same name as modfile exist?      
                {
                    File.Move(filename.Replace(modpath, gamepath), filename.Replace(modpath, temppath)); // move from game to temp
                    File.Move(filename, filename.Replace(modpath, gamepath)); // move from mod  to game
                    movedfiles.Add(filename.Replace(modpath, gamepath));
                }
                else
                {
                    File.Move(filename, filename.Replace(modpath, gamepath)); // move from mod to game, if no equivalent file is found
                    movedfiles.Add(filename.Replace(modpath, gamepath));
                }
            }
            catch
            {
                  resetfiles();
                  break;
            }

        }
        if (!File.Exists("./backup.txt")) File.Create("./backup.txt");
        File.WriteAllLines("./backup.txt", movedfiles);
        
        
        
        
    }
    public void resetfiles()
    {
        movedfiles = File.ReadLines("./backup.txt").ToList();
        foreach (string filename in movedfiles)
        {
            if (File.Exists(filename.Replace(gamepath, temppath)))
            {
                File.Move(filename, filename.Replace(gamepath, modpath));   
                File.Move(filename.Replace(gamepath,temppath), filename);   
            }
            else
            {
                File.Move(filename, filename.Replace(gamepath, modpath));
            }
        }
        
    }
}