using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms.VisualStyles;
using timer_winforms;

public class TimeTracker
{
    
    public static List<(DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage)> history = new List<(DateTime, DateTime, TimeSpan, string, string, string)>();
    public static string[] fields = new string[6] { "Time started:\t", "Time ended:\t", "Duration:\t", "Field:\t\t", "Project:\t", "Stage:\t\t" };
    public static List<string>[] knownNames = new List<string>[3];
    public static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) currentEntry;

    public static System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer();
    public static System.Windows.Forms.Timer reminderTimer = new System.Windows.Forms.Timer();
    public static System.Windows.Forms.Timer idleTimer = new System.Windows.Forms.Timer();
    public static System.Windows.Forms.Timer trashholdTimer = new System.Windows.Forms.Timer();



    public static string pathToSave = "G:\\Projects\\Sharping\\Timer (cons)\\savefiles\\timerhistory.txt";
    public static string settingsPath = "G:\\Projects\\Sharping\\Timer (cons)\\savefiles\\settings.txt";
    static bool END_TIME_SHIFT;
    public static int IDLE_INTERVAL = 1 * 60 * 1000; //user value in min to ms

    public delegate void TrackerHandler();
    public static event TrackerHandler UserIdle;
    public static event TrackerHandler NewEntryAdded;

    
    public static void DefineTimers()
    {
        mainTimer.Interval = 100;            //0.1s
        reminderTimer.Interval = 20 * 1000;     //20s
        idleTimer.Interval = IDLE_INTERVAL;

        reminderTimer.Tick += reminderTimer_Tick;
        mainTimer.Tick += mainTimer_Tick;
        idleTimer.Tick += idleTimer_Tick;
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
        if (PlatformWin.test())
        {
            int idleTemp = IDLE_INTERVAL - (int)PlatformWin.idleTime;
            if (idleTemp > 0)
                idleTimer.Interval = idleTemp;
            else
            {
                idleTimer.Interval = IDLE_INTERVAL;
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

    public static void StoptMainTimer()
    {
        mainTimer.Stop();
        idleTimer.Stop();
        reminderTimer.Start();        

        currentEntry.endTime = DateTime.Now;
        currentEntry.duration = currentEntry.endTime - currentEntry.startTime;
        
        history.Add(currentEntry);

        SaveEntry(true);
    }

    public static void SortEntries()
    {
        history.Sort((x, y) => x.startTime.CompareTo(y.startTime));
    }


    public static void SaveEntry(bool append = false)
    {
        if (append)
        {
            using (StreamWriter sw = new StreamWriter(pathToSave, append))
            {
                sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", currentEntry.startTime.ToString(), currentEntry.endTime.ToString(), TimeSpanToString(currentEntry.duration), currentEntry.field, currentEntry.project, currentEntry.stage);
            }
        }
        else
        {
            using (StreamWriter sw = new StreamWriter(pathToSave, append))
            {
                for (int i = 0; i < history.Count; i++)
                {
                    sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", history[i].startTime.ToString(), history[i].endTime.ToString(), TimeSpanToString(history[i].duration, false), history[i].field, history[i].project, history[i].stage);
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
                
                if (END_TIME_SHIFT)
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
        if (!File.Exists(pathToSave))
            return;

        using (StreamReader sr = File.OpenText(pathToSave))
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