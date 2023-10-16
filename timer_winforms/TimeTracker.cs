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
    public static int IDLE_INTERVAL = 5 * 60 * 1000; //user value in min to ms

    public delegate void TrackerHandler();
    public static event TrackerHandler UserIdle;
    public static event TrackerHandler ActiveWindowChange;
    public static event TrackerHandler NewEntryAdded;

    private const uint WINEVENT_OUTOFCONTEXT = 0;
    private const uint EVENT_SYSTEM_FOREGROUND = 3;
    public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    static WinEventDelegate dele = null;


    public static void DefineTimers()
    {
        mainTimer.Interval = 100;            //0.1s
        reminderTimer.Interval = 20 * 1000;     //20s
        idleTimer.Interval = IDLE_INTERVAL;


        reminderTimer.Tick += reminderTimer_Tick;
        mainTimer.Tick += mainTimer_Tick;
        idleTimer.Tick += idleTimer_Tick;




        dele = new WinEventDelegate(WinEventProc);
        IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
    }


    //public struct TimeEntry
    //{
    //    public DateTime startTime;
    //    public DateTime endTime;
    //    public TimeSpan duration;
    //    public string field;
    //    public string project;
    //    public string stage;
    //}


    

    [DllImport("user32.dll")]
    public static extern bool UnhookWinEvent(IntPtr hWinEventHook);


    [DllImport("user32.dll")]
    public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll")]
    public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    public struct LASTINPUTINFO
    {
        public uint Size;
        public uint Time;
    }


    public static string GetActiveWindowTitle()
    {
        const int nChars = 256;
        IntPtr handle = IntPtr.Zero;
        StringBuilder Buff = new StringBuilder(nChars);
        handle = GetForegroundWindow();

        if (GetWindowText(handle, Buff, nChars) > 0)
        {
            UnhookWinEvent(handle);
            return Buff.ToString();
        }
        UnhookWinEvent(handle);
        return null;
    }

    public static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    {
        ActiveWindowChange?.Invoke();
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
        LASTINPUTINFO lastActive = new LASTINPUTINFO();
        lastActive.Size = (uint)Marshal.SizeOf(lastActive);
        uint eventTicks = (uint)Environment.TickCount;


        if (GetLastInputInfo(ref lastActive))
        {
            uint lastInput = lastActive.Time;
            uint idleTime = eventTicks - lastInput;
            int idleTemp = IDLE_INTERVAL - (int)idleTime;
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