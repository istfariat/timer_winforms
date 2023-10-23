using System.Runtime.InteropServices;
using System.Text;

public class PlatformWin
{
    public static System.Windows.Forms.Timer windowCheckTimer = new System.Windows.Forms.Timer();
    private const int checkInterval = 1 * 1000;  //user value in sec to ms

    public static uint idleTime;

    //private const uint WINEVENT_OUTOFCONTEXT = 0;
    //private const uint EVENT_SYSTEM_FOREGROUND = 3;

    public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);
    //static WinEventDelegate dele = null;

    private static string prevWindow = "";
    private static int trashholdCounter = 0;

    public delegate void TrackerHandler(string WindowTitle);
    public static event TrackerHandler ActiveWindowChanged;
    public static event TrackerHandler TrashholdReached;


    [DllImport("user32.dll")]
    private static extern bool UnhookWinEvent(IntPtr hWinEventHook);


    //[DllImport("user32.dll")]
    //private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    [DllImport("user32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    private struct LASTINPUTINFO
    {
        public uint Size;
        public uint Time;
    }


    public static void DefineTimer()
    {
        windowCheckTimer.Tick += CheckWindow;
        
        windowCheckTimer.Interval = checkInterval;
        
        windowCheckTimer.Start();
    }

    private static void CheckWindow(object sender, EventArgs e)
    {
        string currentWindow = GetActiveWindowTitle();
        
        ActiveWindowChanged?.Invoke(currentWindow);

        if (prevWindow != currentWindow)
        {
            prevWindow = currentWindow;
            trashholdCounter = 0;
            return;
        }
           
        if (trashholdCounter < TimeTracker.TRASHHOLD_INTERVAL)
        {
            trashholdCounter++;
            if (trashholdCounter == TimeTracker.TRASHHOLD_INTERVAL)
            {
                TrashholdReached?.Invoke(currentWindow);
                return;
            }
            return;
        }
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

    //private static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    //{
    //    ActiveWindowChange?.Invoke();
    //}

    //public static void ActivateWindowTrack()
    //{
    //    dele = new WinEventDelegate(WinEventProc);
    //    IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);
    //}
    

    public static bool CheckIdle()
    {
        LASTINPUTINFO lastActive = new LASTINPUTINFO();
        lastActive.Size = (uint)Marshal.SizeOf(lastActive);
        uint eventTicks = (uint)Environment.TickCount;


        if (GetLastInputInfo(ref lastActive))
        {
            uint lastInput = lastActive.Time;
            idleTime = eventTicks - lastInput;
            return true;
        }
        return false;
    }
}