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
            Program.history[entryIndex][3] = textBox2.Text;
            Program.history[entryIndex][4] = textBox3.Text;
            Program.history[entryIndex][5] = textBox4.Text;


            mainForm.SaveEntry();
            mainForm.ShowHistory();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox2.Text = Program.history[entryIndex][3];
            textBox3.Text = Program.history[entryIndex][4];
            textBox4.Text = Program.history[entryIndex][5];
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.mainForm
        //}


    }
}
