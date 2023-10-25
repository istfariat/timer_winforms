

using System.Text.Json;
using System.Windows.Forms;
using timer_winforms;

public class Settings
{
    public  string? SaveDirectory { get; set; }
    public  int IDLE_INTERVAL_MIN { get; set; }
    public  int REMINDER_INTERVAL_MIN { get; set; }
    public  int TRASHHOLD_INTERVAL_SEC { get; set; }
    public  bool ENABLE_AUTO_TIMER { get; set; }
    public  bool END_TIME_SHIFT { get; set; }
}

public class UserProperties
{
    private static Settings UserSettings = new Settings()
    {
        SaveDirectory = Environment.CurrentDirectory + @"\timerhistory.txt",
        IDLE_INTERVAL_MIN = 1,
        REMINDER_INTERVAL_MIN = 1,
        TRASHHOLD_INTERVAL_SEC = 5,
        ENABLE_AUTO_TIMER = false,
        END_TIME_SHIFT = false
    };
    private static string currentDir = Environment.CurrentDirectory;
    //public static string pathToSave = "G:\\Projects\\Sharping\\Timer (cons)\\savefiles\\timerhistory.txt";
       
    //public static bool END_TIME_SHIFT;

    //public static int IDLE_INTERVAL = 1 * 60 * 1000; //user value in min to ms
    //public static int TRASHHOLD_INTERVAL = 5; //user value in sec (once per window check tick)
    //public static bool ENABLE_AUTO_TIMER = true;

    //public static Dictionary<string, dynamic> Settings = new Dictionary<string, dynamic>()
    //{
    //    {"SaveDirectory", currentDir + @"\timerhistory.txt"},
    //    {"IDLE_INTERVAL_MIN", 1},
    //    {"REMINDER_INTERVAL_MIN", 1},
    //    {"TRASHHOLD_INTERVAL_SEC", 5},
    //    {"ENABLE_AUTO_TIMER", false},
    //    {"END_TIME_SHIFT", false}
    //};

    public static string test = "";

    public static Settings CheckSettings()
    {
        string json = JsonSerializer.Serialize(UserSettings);

        if (!File.Exists(currentDir + @"\Settings.json"))
        {
            //string[] keyList = Settings.Keys.ToArray();

            using (StreamWriter sw = new StreamWriter(currentDir + @"\Settings.json"))
            {

                //Array.Sort(keyList);
                //foreach (var key in keyList)
                //{
                //    sw.WriteLine(key + "\t" + Settings[key]);
                //}

                
                sw.WriteLine(json);
            }
            //return;
        }

        using (StreamReader sr = new StreamReader(currentDir + @"\Settings.json"))
        {
            //string[] line = sr.ReadLine().Split("\t");
            //var propertyType = Settings[line[0]].GetType();
            //if (propertyType == "System.Boolean")
            //{
            //    line[1] = line[1].ToLower();
            //    test = line[1];
            //}

            //Settings[line[0]] = (propertyType)line[1];


            string jsonR = sr.ReadToEnd();


            Settings UserSettings = JsonSerializer.Deserialize<Settings>(jsonR)!;

            test = UserSettings.SaveDirectory;

            return UserSettings;
            //foreach (var kvp in deserializedDictionary)
            //{
            //    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            //}
        }
    }
    
}