

using timer_winforms;

public class UserProperties
{
    private static string currentDir = Environment.CurrentDirectory;
    public static string pathToSave = "G:\\Projects\\Sharping\\Timer (cons)\\savefiles\\timerhistory.txt";
       
    public static bool END_TIME_SHIFT;

    public static int IDLE_INTERVAL = 1 * 60 * 1000; //user value in min to ms
    public static int TRASHHOLD_INTERVAL = 5; //user value in sec (once per window check tick)
    public static bool ENABLE_AUTO_TIMER = true;

    public static Dictionary<string, dynamic> Settings = new Dictionary<string, dynamic>()
    {
        {"SaveDirectory", currentDir + @"\timerhistory.txt"},
        {"IDLE_INTERVAL_MIN", 1},
        {"REMINDER_INTERVAL_MIN", 1},
        {"TRASHHOLD_INTERVAL_SEC", 5},
        {"ENABLE_AUTO_TIMER", false},
        {"END_TIME_SHIFT", false}
    };

    public static string test = "";

    public static void CheckSettings()
    {
        
        if (!File.Exists(currentDir + @"\Settings.txt"))
        {
            string[] keyList = Settings.Keys.ToArray();

            using (StreamWriter sw = new StreamWriter(currentDir + @"\Settings.txt"))
            {
                
                Array.Sort(keyList);
                foreach (var key in keyList)
                {
                    sw.WriteLine(key + "\t" + Settings[key]);
                }
            }
            return;
        }

        using (StreamReader sr = new StreamReader(currentDir + @"\Settings.txt"))
        {
            string[] line = sr.ReadLine().Split("\t");
            string propertyType = Settings[line[0]].GetType().ToString();
            //if (propertyType == "System.Boolean")
            //{
            //    line[1] = line[1].ToLower();
            //    test = line[1];
            //}
            
            Settings[line[0]] = line[1];
        }
    }
}