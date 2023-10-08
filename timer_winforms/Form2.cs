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
    public partial class Form2 : Form
    {

        public int entryIndex;
        private (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) tempEntry;

        //public Form2()
        //{
        //    InitializeComponent();

        //    textBox2.Text = Program.history[entryIndex][3];
        //    textBox3.Text = Program.history[entryIndex][4];
        //    textBox4.Text = Program.history[entryIndex][5];

        //}

        private Form1 mainForm = null;
        public Form2(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = entryIndex.ToString();
            //int row = mainForm.ListView1.SelectedIndices();
        }


        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            
        }


        private void textBox4_LostFocus(object sender, EventArgs e)
        {
            
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempEntry.field = textBox2.Text;
            tempEntry.project = textBox3.Text;
            tempEntry.stage = textBox4.Text;
            

            Program.history[entryIndex] = tempEntry;

            mainForm.SaveEntry();
            mainForm.ShowHistory();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            tempEntry = Program.history[entryIndex];


            textBox2.Text = tempEntry.field;
            textBox3.Text = tempEntry.project;
            textBox4.Text = tempEntry.stage;
            dateTimePicker1.Value = tempEntry.startTime;
            dateTimePicker2.Value = tempEntry.endTime;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tempEntry.startTime = dateTimePicker1.Value;
            tempEntry.duration = tempEntry.endTime - tempEntry.startTime;
            textBox1.Text = tempEntry.duration.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            tempEntry.endTime = dateTimePicker2.Value;
            tempEntry.duration = tempEntry.endTime - tempEntry.startTime;
            textBox1.Text = tempEntry.duration.ToString();
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.mainForm
        //}


    }
}
