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
    public partial class Form4 : Form
    {
        static System.Windows.Forms.Timer closeTimer = new System.Windows.Forms.Timer();

        private Form1 mainForm = null;
        public Form4(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();

            closeTimer.Interval = 5000;
            closeTimer.Tick += closeTimer_Tick;
            closeTimer.Start();
        }

        private void closeTimer_Tick(object sender, EventArgs a)
        {
            WindowClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowClose(); 
            mainForm.StartMainTimer();
        }

        private void WindowClose ()
        {
            closeTimer.Stop();
            this.Close();
        }
    }
}
