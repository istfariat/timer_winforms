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
            PlatformWin.ActivateWindowTrack();

            TimeTracker.reminderTimer.Tick += reminderTimer_Tick;
            TimeTracker.UserIdle += ShowIdleWindow;
            TimeTracker.mainTimer.Tick += ShowRunningTime;


            PlatformWin.ActiveWindowChange += ShowActiveWindow;
            TimeTracker.NewEntryAdded += ShowHistory;
            IdleNotificationWindowForm.DiscardTime += DiscardEntry;

            TimeTracker.reminderTimer.Start();
            //inactivityTimer.Start();

            listView2.Columns.Add("Program", 400, HorizontalAlignment.Center);
        }



        #region Form/Control Events

        private void ResetFields()
        {
            labelTimerRunning.Text = "00:00:00";
            textBoxField.Text = string.Empty;
            textBoxSubject.Text = string.Empty;
            textBoxStage.Text = string.Empty;
        }

        private void DiscardEntry()
        {
            TimeTracker.StoptMainTimer(true);
            ResetFields();
        }


        void ShowActiveWindow()
        {
            string currentWindow = PlatformWin.GetActiveWindowTitle();
            label12.Text = currentWindow;
            listView2.Items.Add(currentWindow);
        }

        private void buttonStopStart_Click(object sender, EventArgs e)
        {
            if (TimeTracker.mainTimer.Enabled)
            {
                TimeTracker.StoptMainTimer();
                ResetFields();
            }
            else
            {
                TimeTracker.StartMainTimer();
                TimeTracker.currentEntry.field = textBoxField.Text;
                TimeTracker.currentEntry.project = textBoxSubject.Text;
                TimeTracker.currentEntry.stage = textBoxStage.Text;
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
            TimeTracker.EditCurrStart(dateTimePickerStarttimeCurrent.Value);
            dateTimePickerStarttimeCurrent.Value = TimeTracker.currentEntry.startTime;
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
            ReminderWindowForm reminderWindow = new ReminderWindowForm();
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

            foreach (var field in TimeTracker.fields)
                listViewHistory.Columns.Add(field, 100, HorizontalAlignment.Center);

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