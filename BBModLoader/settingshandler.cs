namespace BBmodLauncher2;

public class settingshandler
{
    private string setdir = "settings.txt";
    public string[] checksettings()
    {
        if (!File.Exists(setdir) || File.ReadAllLines("settings.txt").Length == 0)
        {
            File.Create(setdir).Close();
            return new string[0];
        }
        else
        {
            string[] settinglines = File.ReadAllLines(setdir);
            settinglines[0] = settinglines[0].Replace("Mod folder: ", "");
            settinglines[1] = settinglines[1].Replace("BBCF folder: ", "");
            settinglines[2] = settinglines[2].Replace("Steam folder: ", "");
            settinglines[3] = settinglines[3].Replace("modded?: ", "");
            return settinglines;
        }
    }

    public void writesettings(String setting, String value)
    {
        string[] settings = new string[4]; // 0 -> Mod folder; 1 -> BBCF folder; 2 -> Steam folder; 3 -> modded?
        if (!File.Exists(setdir))
        {
            File.Create(setdir).Close();
            settings[0] = "Mod folder: ";
            settings[1] = "BBCF folder: ";
            settings[2] = "Steam folder: ";
            settings[3] = "modded?: ";
        }
        else
        {
            settings = File.ReadAllLines(setdir);
            if (settings.Length == 0)
            {
                settings = new string[4];
                settings[0] = "Mod folder: ";
                settings[1] = "BBCF folder: ";
                settings[2] = "Steam folder: ";
                settings[3] = "modded?: ";
            }
        }
       

        switch (setting)
        {
            case "mod":
                settings[0] = "Mod folder: " + value;
                break;
            case "bbcf":
                settings[1] = "BBCF folder: " + value;
                break;
            case "steam":
                settings[2] = "Steam folder: " + value;
                break;
            case "modded?":
                settings[3] ="modded?: " + value;
                break;
        }
        
        
        File.WriteAllLines(setdir, settings);
    }
}