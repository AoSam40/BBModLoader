namespace BBmodLauncher2;

public class pathchecker
{
    static settingshandler settingshand = new settingshandler();
    string[] settings = settingshand.checksettings();
    
    public bool checksturcture(string path)
    {
        string[] integrity = File.ReadAllLines("integrity.txt");
        int max = integrity.Length;
        float i = 0;
        float percent = 0;

        foreach (string s in integrity)
        {
            string g = s.Replace('\\', '/');
            if (File.Exists(path + g.Replace("/BlazBlue Centralfiction/data", ""))) i++; 
        }
        percent = i/max*100;
        
        Console.WriteLine("Integrity: " + percent + "%" );
        if (percent > 75) return true;
        return false;
    }

    public bool checksteam(string path)
    {
        if (Directory.Exists(path + "steam.sh")) return true;
        return false;
    }
}