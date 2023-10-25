using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace timer_winforms
{
    public partial class SettingsWindowForm : Form
    {
        public SettingsWindowForm()
        {
            InitializeComponent();
            label2.Text = UserProperties.test;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SettingsWindowForm_Load(object sender, EventArgs e)
        {
            //dataGridView1 = new DataGridView();
            dataGridView1.Rows[dataGridView1.Rows.Add()].Cells[0].Value = "Save history to:";
            dataGridView1.Rows[0].Cells[1].Value = TimeTracker.UserSettings.SaveDirectory;
            dataGridView1.Rows[dataGridView1.Rows.Add()].Cells[1].Value = TimeTracker.UserSettings.SaveDirectory;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = Environment.CurrentDirectory;
        }
    }
}
