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
        public Form2()
        {
            InitializeComponent();

            
        }

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



        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.mainForm
        //}


    }
}
