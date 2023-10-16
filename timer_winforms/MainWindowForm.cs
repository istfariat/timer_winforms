using Microsoft.VisualBasic.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace timer_winforms
{
    public partial class MainWindowForm : Form
    {

        public MainWindowForm()
        {
            InitializeComponent();
            ShowHistory();

            TimeTracker.DefineTimers();

            TimeTracker.reminderTimer.Tick += reminderTimer_Tick;
            TimeTracker.UserIdle += ShowIdleWindow;
            TimeTracker.mainTimer.Tick += ShowRunningTime;

            
            TimeTracker.ActiveWindowChange += ShowActiveWindow;
            TimeTracker.NewEntryAdded += ShowHistory;

            TimeTracker.reminderTimer.Start();
            //inactivityTimer.Start();

            listView2.Columns.Add("Program", 400, HorizontalAlignment.Center);
        }



        #region Form/Control Events


        void ShowActiveWindow()
        {
            string currentWindow = TimeTracker.GetActiveWindowTitle();
            label12.Text = currentWindow;
            listView2.Items.Add(currentWindow);
        }

        private void buttonStopStart_Click(object sender, EventArgs e)
        {
            if (TimeTracker.mainTimer.Enabled)
            {
                TimeTracker.StoptMainTimer();
            }
            else
            {
                TimeTracker.StartMainTimer();
            }
        }

        public ListView ListView1
        {
            get { return listViewHistory; }
            set { listViewHistory = value; }
        }

        private void listViewHistory_Click(object sender, EventArgs a)
        {
            EditEntryWindowForm editWindow = new EditEntryWindowForm(this);
            editWindow.entryIndex = TimeTracker.history.Count - listViewHistory.SelectedIndices[0] - 1;
            editWindow.Show();
        }


        private void textBoxField_Leave(object sender, EventArgs a)
        {
            TimeTracker.currentEntry.field = textBoxField.Text;
        }

        void textBoxSubject_Leave(object sender, EventArgs a)
        {
            TimeTracker.currentEntry.project = textBoxSubject.Text;
        }

        void textBoxStage_Leave(object sender, EventArgs a)
        {
            TimeTracker.currentEntry.stage = textBoxStage.Text;
        }


        private void dateTimePickerHistory_ValueChanged(object sender, EventArgs e)
        {
            TimeTracker.currentEntry.startTime = dateTimePickerStarttimeCurrent.Value;
        }


        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);
        //private void textBox4_GotFocus(object sender, EventArgs e)
        //{
        //    HideCaret(textBox4.Handle);
        //}

        private void textBox4_Enter(object sender, EventArgs e)
        {

        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            SettingsWindowForm settingsWindow = new SettingsWindowForm();
            settingsWindow.Show();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }


        void reminderTimer_Tick(object sender, EventArgs a)
        {
            ReminderWindowForm reminderWindow = new ReminderWindowForm(this);
            reminderWindow.Show();
        }


        private void ShowIdleWindow()
        {
            IdleNotificationWindowForm idleWindow = new IdleNotificationWindowForm();
            idleWindow.Show();
        }


        void ShowRunningTime(object sender, EventArgs a)
        {
            labelTimerRunning.Text = TimeTracker.TimeSpanToString(TimeTracker.currentEntry.duration);
        }
        #endregion

        #region Functions


        public void ShowHistory()
        {
            listViewHistory.Clear();
            TimeTracker.LoadEntry();

            for (int j = 0; j < TimeTracker.fields.Length; j++)
                listViewHistory.Columns.Add(TimeTracker.fields[j], 100, HorizontalAlignment.Center);


            for (int i = TimeTracker.history.Count - 1; i >= 0; i--)
            {
                
                listViewHistory.Items.Add(new ListViewItem(new string[] { TimeTracker.history[i].startTime.ToString(), TimeTracker.history[i].endTime.ToString(),
                                                                                    TimeTracker.history[i].duration.ToString(), TimeTracker.history[i].field,
                                                                                    TimeTracker.history[i].project, TimeTracker.history[i].stage }));
            }

        }

        #endregion
    }
}