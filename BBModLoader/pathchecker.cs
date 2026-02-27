namespace BBmodLauncher2;

public class pathchecker
{
    static settingshandler settingshand = new settingshandler();
    string[] settings = settingshand.checksettings();
    
    public bool checksturcture(string path)
    {
        string[] integrity = File.ReadAllLines("integrity.txt");

        foreach (string s in integrity)
        {
            if (!Directory.Exists(path + "\\" +s)) return false;
        }
        return true;
    }

    public bool checksteam(string path)
    {
        if (Directory.Exists(path + "steam.exe")) return true;
        return false;
    }
}