using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.VisualStyles;
using timer_winforms;

public class TimeTracker
{
    
    public static List<(DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage)> history = new List<(DateTime, DateTime, TimeSpan, string, string, string)>();
    public static string[] fields = new string[6] { "Time started:\t", "Time ended:\t", "Duration:\t", "Field:\t\t", "Project:\t", "Stage:\t\t" };

    public static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) currentEntry;
    public static Settings UserSettings = UserProperties.CheckSettings();

    public static System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer();
    public static System.Windows.Forms.Timer reminderTimer = new System.Windows.Forms.Timer();
    public static System.Windows.Forms.Timer idleTimer = new System.Windows.Forms.Timer();

    public static string[] knownNames = new string[3] {"blender", "league of legends", "twitch"}; // placeholder

    public delegate void TrackerHandler();
    public static event TrackerHandler UserIdle;
    public static event TrackerHandler NewEntryAdded;
    public static event TrackerHandler AutoTimerStarted;

    
    public static void DefineTimers()
    {
        mainTimer.Interval = 100;            //0.1s
        reminderTimer.Interval = 20 * 1000;     //20s
        idleTimer.Interval = TimeTracker.UserSettings.IDLE_INTERVAL_MIN * 60 * 1000;
        //trashholdTimer.Interval = TRASHHOLD_INTERVAL;

        reminderTimer.Tick += reminderTimer_Tick;
        mainTimer.Tick += mainTimer_Tick;
        idleTimer.Tick += idleTimer_Tick;
        PlatformWin.TrashholdReached += CheckNewAutotime;
    }

   
    private static void CheckNewAutotime (string WindowTitle) // placeholder
    {
        //WindowTitle = WindowTitle.T();
        if (!TimeTracker.UserSettings.ENABLE_AUTO_TIMER) return;
        
        foreach (string name in knownNames)
        {
            if (WindowTitle.ToLower().Contains(name) && currentEntry.field != name) 
            {
                if (mainTimer.Enabled)
                    StoptMainTimer();

                currentEntry.project = name;
                currentEntry.field = string.Empty;
                currentEntry.stage = string.Empty;
                currentEntry.duration = TimeSpan.Zero;

                StartMainTimer();

                AutoTimerStarted?.Invoke();
            }
        }
    }

    public static void DeleteRunningEntry()
    {
        StoptMainTimer(true);
    }


    static void reminderTimer_Tick(object sender, EventArgs a)
    {

    }

    #region completed rework



    static void mainTimer_Tick(object sender, EventArgs a)
    {
        currentEntry.duration = DateTime.Now - currentEntry.startTime;
    }

    static void idleTimer_Tick(object sender, EventArgs a)
    {
        CheckIdleStatus();

    }

    public static void CheckIdleStatus()
    {
        if (PlatformWin.CheckIdle())
        {
            int idleTemp = (TimeTracker.UserSettings.IDLE_INTERVAL_MIN * 60 * 1000) - (int)PlatformWin.idleTime;
            if (idleTemp > 0)
                idleTimer.Interval = idleTemp;
            else
            {
                idleTimer.Interval = TimeTracker.UserSettings.IDLE_INTERVAL_MIN * 60 * 1000;
                UserIdle?.Invoke();
                idleTimer.Stop();
            }
        }
    }


    public static string CheckActiveWindow()
    {
        return PlatformWin.GetActiveWindowTitle();
    }


    public static void StartMainTimer()
    {
        

        reminderTimer.Stop();
        mainTimer.Start();
        idleTimer.Start();

        currentEntry.startTime = DateTime.Now;
    }

    public static void StoptMainTimer(bool deleteEntry = false, double idleTimeInSeconds = 0)
    {
        mainTimer.Stop();
        idleTimer.Stop();
        reminderTimer.Start();        

        if (idleTimeInSeconds > 0)
            currentEntry.endTime = DateTime.Now - TimeSpan.FromSeconds(idleTimeInSeconds);
        else currentEntry.endTime = DateTime.Now;
       
        currentEntry.duration = currentEntry.endTime - currentEntry.startTime;



        if (!deleteEntry)
        {
            history.Add(currentEntry);
            SaveEntry(true);
        }
        
    }

    public static void SortEntries()
    {
        history.Sort((x, y) => x.startTime.CompareTo(y.startTime));
    }


    public static void SaveEntry(bool append = false)
    {
        if (append)
        {
            using (StreamWriter sw = new StreamWriter(TimeTracker.UserSettings.SaveDirectory, append))
            {
                sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", currentEntry.startTime.ToString(), currentEntry.endTime.ToString(), TimeSpanToString(currentEntry.duration), currentEntry.field, currentEntry.project, currentEntry.stage);
            }
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(TimeTracker.UserSettings.SaveDirectory, append))
            {
                foreach (var entry in history)
                {
                    sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", entry.startTime.ToString(), entry.endTime.ToString(), TimeSpanToString(entry.duration, false), entry.field, entry.project, entry.stage);
                }
            }
        }
        NewEntryAdded?.Invoke();
    }

    public static void EditDateTime(int sourceEntryIndex, DateTime newDate, bool isEndTime)
    {
        (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) tempEntry = history[sourceEntryIndex];
        DateTime oldDate = tempEntry.startTime;
        bool sort = false;
        
        if (isEndTime)
            oldDate = tempEntry.endTime;

        if (oldDate == newDate)
            return;
        else
        {
            if (isEndTime)
            {
                tempEntry.endTime = newDate;
                EditDuration(sourceEntryIndex);
            }
            else
            {
                tempEntry.startTime = newDate;
                
                if (TimeTracker.UserSettings.END_TIME_SHIFT)
                {
                    tempEntry.endTime = tempEntry.endTime.Add(tempEntry.duration);
                }
                else
                {
                    EditDuration(sourceEntryIndex);
                    sort = true;
                }
            }
            
            history[sourceEntryIndex] = tempEntry;
            if (sort) 
                SortEntries();
            SaveEntry();
        }
    }

    public static void EditCurrStart(DateTime newStarttime)
    {
        if (newStarttime > DateTime.Now) return;
        currentEntry.startTime = newStarttime;
        currentEntry.duration = DateTime.Now - currentEntry.startTime;
    }

    public static void EditDuration(int sourceEntryIndex)
    {
        (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) tempEntry = history[sourceEntryIndex];

        tempEntry.duration = tempEntry.endTime - tempEntry.startTime;
        history[sourceEntryIndex] = tempEntry;
    }

    public static string TimeSpanToString(TimeSpan sourceTimeSpan, bool truncate = true)
    {
        string result = sourceTimeSpan.ToString("c");
        int charsToSub = 0;
        if (truncate) charsToSub = 8;
        return result.Substring(0, result.Length - charsToSub);
    }

    public static void LoadEntry()
    {
        if (!File.Exists(TimeTracker.UserSettings.SaveDirectory))
            return;

        using (StreamReader sr = File.OpenText(TimeTracker.UserSettings.SaveDirectory))
        {
            string s;
            history.Clear();

            while ((s = sr.ReadLine()) != null)
            {
                history.Add(ParseArrayToTuple(s.Split("\t")));
            }
        }
    }


    public static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) ParseArrayToTuple(string[] sourceArray)
    {
        (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) result;

        try
        {
            result.startTime = DateTime.Parse(sourceArray[0]);
            result.endTime = DateTime.Parse(sourceArray[1]);
            result.duration = TimeSpan.Parse(sourceArray[2]);

            result.field = sourceArray[3];
            result.project = sourceArray[4];
            result.stage = sourceArray[5];
        }
        catch
        {
            result.startTime = DateTime.Now;
            result.endTime = DateTime.Now;
            result.duration = TimeSpan.Zero;

            result.field = "ERROR";
            result.project = "ERROR";
            result.stage = "ERROR";
        }
        return result;
    }
    #endregion

}