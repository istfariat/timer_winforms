﻿using Microsoft.VisualBasic.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace timer_winforms
{
    public partial class Form1 : Form
    {

        //static Stopwatch mainTimer = new Stopwatch();
        static System.Windows.Forms.Timer secTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer reminderTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer inactivityTimer = new System.Windows.Forms.Timer();
        static System.Windows.Forms.Timer trashholdTimer = new System.Windows.Forms.Timer();


        static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) currentEntry;
        List<string>[] knownNames = new List<string>[3];

        int idleInterval = 5 * 60 * 1000;       //user value in min to ms



        WinEventDelegate dele = null;

        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        private string GetActiveWindowTitle()
        {
            //string utf8String;
            //string propEncodeString = string.Empty;

            //byte[] utf8_Bytes = new byte[utf8String.Length];
            //for (int i = 0; i < utf8String.Length; ++i)
            //{
            //    utf8_Bytes[i] = (byte)utf8String[i];
            //}

            //propEncodeString = Encoding.UTF8.GetString(utf8_Bytes, 0, utf8_Bytes.Length);


            const int nChars = 256;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                UnhookWinEvent(handle);
                listView2.Items.Add(Buff.ToString());
                //byte[] textBytes = Encoding.UTF8.GetBytes(Buff.ToString());
                //return Encoding.UTF8.GetString(textBytes);
                return Buff.ToString();
            }
            UnhookWinEvent(handle);
            return null;


        }

        public void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            label12.Text = GetActiveWindowTitle();
        }

        public Form1()
        {
            InitializeComponent();
            ShowHistory();


            secTimer.Interval = 100;            //0.1s
            reminderTimer.Interval = 10000;     //10s
            inactivityTimer.Interval = idleInterval;

            reminderTimer.Tick += reminderTimer_Tick;
            secTimer.Tick += secTimer_Tick;
            inactivityTimer.Tick += inactivityTimer_Tick;

            reminderTimer.Start();
            inactivityTimer.Start();

            listView2.Columns.Add("Program", 400, HorizontalAlignment.Center);
            label5.Text = "ололо";
            label11.Text = inactivityTimer.Interval.ToString();

            dele = new WinEventDelegate(WinEventProc);
            IntPtr m_hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, dele, 0, 0, WINEVENT_OUTOFCONTEXT);

        }

        #region Form/Control Events
        private void button1_Click(object sender, EventArgs e)
        {
            if (secTimer.Enabled)
            {
                StoptMainTimer();
            }
            else
            {
                StartMainTimer();
            }
        }

        public ListView ListView1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void listView1_Click(object sender, EventArgs a)
        {

            //label7.Text = listView1.SelectedIndices[0].ToString();
            //label6.Text = (Program.history.Count - listView1.SelectedIndices[0] - 1).ToString();
            Form2 editWindow = new Form2(this);
            editWindow.entryIndex = Program.history.Count - listView1.SelectedIndices[0] - 1;
            editWindow.Show();
        }


        private void textBox1_Leave(object sender, EventArgs a)
        {
            currentEntry.field = textBox1.Text;
            //label5.Text = currentEntry.field;
        }


        //private void textBoxes_Leave(object sender, EventArgs e)
        //{
        //    TextBox txbox = sender as TextBox;
        //    txbox.SelectionLength = 0;
        //    currentEntry[3] = textBox1.Text;
        //}

        void textBox2_Leave(object sender, EventArgs a)
        {
            currentEntry.project = textBox2.Text;
        }

        void textBox3_Leave(object sender, EventArgs a)
        {
            currentEntry.stage = textBox3.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            currentEntry.startTime = dateTimePicker1.Value;
        }


        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);
        private void textBox4_GotFocus(object sender, EventArgs e)
        {
            HideCaret(textBox4.Handle);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form3 settingsWindow = new Form3(this);
            Form3 settingsWindow = new Form3();
            //settingsWindow.entryIndex = Program.history.Count - listView1.SelectedIndices[0] - 1;
            settingsWindow.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label9.Text = "pressed";
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


        void reminderTimer_Tick(object sender, EventArgs a)
        {
            Form4 reminderWindow = new Form4(this);
            reminderWindow.Show();
        }


        void secTimer_Tick(object sender, EventArgs a)
        {
            //string duration2 = mainTimer.Elapsed.ToString("c");


            currentEntry.duration = DateTime.Now - currentEntry.startTime;
            //label6.Text = ActiveControl.ToString();
            label2.Text = currentEntry.duration.ToString("c");
            //label5.Text = currentEntry.field;
            //label5.Update();
        }


        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private void inactivityTimer_Tick(object sender, EventArgs a)
        {
            //uint idleTime = 0;
            LASTINPUTINFO lastActive = new LASTINPUTINFO();
            lastActive.Size = (uint)Marshal.SizeOf(lastActive);
            uint eventTicks = (uint)Environment.TickCount;


            if (GetLastInputInfo(ref lastActive))
            {
                uint lastInput = lastActive.Time;
                uint idleTime = eventTicks - lastInput;
                int idleTemp = idleInterval - (int)idleTime;
                if (idleTemp > 0)
                    inactivityTimer.Interval = idleTemp;
                else inactivityTimer.Interval = idleInterval;


                //label10.Text = (idleTime / 1000).ToString();
                //label11.Text = inactivityTimer.Interval.ToString();

            }
            //DateTime lastActive = DateTime.Now;
            //int nextInactiveCheck = inactivityTimer.Interval - lastActive;
        }

        struct LASTINPUTINFO
        {
            public uint Size;
            public uint Time;
        }


        #endregion

        #region Functions
        public void StartMainTimer()
        {
            reminderTimer.Stop();
            secTimer.Start();

            currentEntry.startTime = DateTime.Now;
            dateTimePicker1.Value = currentEntry.startTime;
            label9.Text = "";                                       // PLACEHOLDER

        }

        private void StoptMainTimer()
        {
            secTimer.Stop();
            reminderTimer.Start();

            currentEntry.endTime = DateTime.Now;
            currentEntry.duration = currentEntry.endTime - currentEntry.startTime;
            Program.history.Add(currentEntry);

            label2.Text = TimeSpanToString(currentEntry.duration);

            SaveEntry(true);
            ShowHistory();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        public void ShowHistory()
        {
            listView1.Clear();
            LoadEntry();

            for (int j = 0; j < Program.fields.Length; j++)
                listView1.Columns.Add(Program.fields[j], 100, HorizontalAlignment.Center);


            for (int i = Program.history.Count - 1; i >= 0; i--)
            {
                //foreach (var x in Program.history[i])
                //    listView1.x.
                //listView1.Items.Add(new ListViewItem(Program.history[i].ToString())); // ??????
                listView1.Items.Add(new ListViewItem(new string[] { Program.history[i].startTime.ToString(), Program.history[i].endTime.ToString(),
                                                                                    Program.history[i].duration.ToString(), Program.history[i].field,
                                                                                    Program.history[i].project, Program.history[i].stage }));
            }

        }

        public void LoadEntry()
        {
            //if (!File.Exists(pathToSave))
            //{
            //    Console.WriteLine("There is no file to load.");
            //}
            //else
            //{
            // Open the file to read from.
            using (StreamReader sr = File.OpenText(Program.pathToSave))
            {
                string s;
                Program.history.Clear();

                while ((s = sr.ReadLine()) != null)
                {
                    Program.history.Add(ParseArrayToTuple(s.Split("\t")));
                }
            }
            //}
        }


        public void SaveEntry(bool append = false)
        {
            if (!File.Exists(Program.pathToSave))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(Program.pathToSave))
                {
                    for (int i = 0; i < Program.history.Count; i++)
                    {
                        sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", currentEntry.startTime.ToString(), currentEntry.endTime.ToString(), TimeSpanToString(currentEntry.duration), currentEntry.field, currentEntry.project, currentEntry.stage);
                    }
                }
            }
            else if (append)
            {
                using (StreamWriter sw = new StreamWriter(Program.pathToSave, append))
                {
                    sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", currentEntry.startTime.ToString(), currentEntry.endTime.ToString(), TimeSpanToString(currentEntry.duration), currentEntry.field, currentEntry.project, currentEntry.stage);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Program.pathToSave, append))
                {
                    for (int i = 0; i < Program.history.Count; i++)
                    {
                        sw.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\n", Program.history[i].startTime.ToString(), Program.history[i].endTime.ToString(), TimeSpanToString(Program.history[i].duration), Program.history[i].field, Program.history[i].project, Program.history[i].stage);
                    }
                }
            }

        }



        static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) ParseArrayToTuple(string[] sourceArray)
        {
            (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) result;

            result.startTime = DateTime.Parse(sourceArray[0]);
            result.endTime = DateTime.Parse(sourceArray[1]);
            result.duration = TimeSpan.Parse(sourceArray[2]);

            result.field = sourceArray[3];
            result.project = sourceArray[4];
            result.stage = sourceArray[5];

            return result;
        }

        private static string TimeSpanToString(TimeSpan sourceTimeSpan)
        {
            string result = sourceTimeSpan.ToString("c");
            return result = result.Substring(0, result.Length - 8);
        }

        #endregion



    }

    //class ForegroundTracker
    //{
    //    // Delegate and imports from pinvoke.net:

    //    delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType,
    //        IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

    //    [DllImport("user32.dll")]
    //    static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr
    //       hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
    //       uint idThread, uint dwFlags);

    //    [DllImport("user32.dll")]
    //    static extern bool UnhookWinEvent(IntPtr hWinEventHook);

    //    // Constants from winuser.h
    //    const uint EVENT_SYSTEM_FOREGROUND = 3;
    //    const uint WINEVENT_OUTOFCONTEXT = 0;

    //    // Need to ensure delegate is not collected while we're using it,
    //    // storing it in a class field is simplest way to do this.
    //    static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);

    //    public static void Main()
    //    {
    //        // Listen for foreground changes across all processes/threads on current desktop...
    //        IntPtr hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND, IntPtr.Zero,
    //                procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);

    //        // MessageBox provides the necessary mesage loop that SetWinEventHook requires.
    //        MessageBox.Show("Tracking focus, close message box to exit.");

    //        UnhookWinEvent(hhook);
    //    }

    //    static void WinEventProc(IntPtr hWinEventHook, uint eventType,
    //        IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
    //    {
    //        Console.WriteLine("Foreground changed to {0:x8}", hwnd.ToInt32());
    //    }
    //}
}