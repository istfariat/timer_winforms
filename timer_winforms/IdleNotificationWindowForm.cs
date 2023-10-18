using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timer_winforms
{
    public partial class IdleNotificationWindowForm : Form
    {
        private System.Windows.Forms.Timer minuteTimer = new System.Windows.Forms.Timer();
        int idleDuration = TimeTracker.IDLE_INTERVAL / 60000;
        string idleSince = (DateTime.Now - TimeSpan.FromMilliseconds((double)TimeTracker.IDLE_INTERVAL)).ToLongTimeString();

        public delegate void IdleNotification();
        public static event IdleNotification DiscardTime;

        public IdleNotificationWindowForm()
        {
            InitializeComponent();

            TimeTracker.idleTimer.Stop();

            minuteTimer.Interval = 60 / 60 * 1000; //1 min
            minuteTimer.Tick += IdleMsgUpdate;

            minuteTimer.Start();

            labelIdleMsg.Text = "You've been idle since " + idleSince + " (" + idleDuration + " min)";
        }

        private void IdleMsgUpdate(object sender, EventArgs e)
        {
            idleDuration++;
            labelIdleMsg.Text = "You've been idle since " + idleSince + " (" + idleDuration + " min)";
        }

        private void IdleNotificationWindowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            minuteTimer.Stop();
        }

        private void buttonIdleContinueEntry_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonIdleDiscardEntry_Click(object sender, EventArgs e)
        {
            DiscardTime();
            this.Close();
        }
    }
}
