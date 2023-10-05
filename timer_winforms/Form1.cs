using System.ComponentModel;
using System.Diagnostics;

namespace timer_winforms
{
    public partial class Form1 : Form
    {

        static Stopwatch mainTimer = new Stopwatch();
        static System.Windows.Forms.Timer secTimer = new System.Windows.Forms.Timer();

        static string[] currentEntry = new string[6];

        static int x = 0;

        public Form1()
        {
            InitializeComponent();
            ShowHistory();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secTimer.Interval = 100;

            if (mainTimer.IsRunning)
            {                
                mainTimer.Stop();
                secTimer.Stop();
                string duration = mainTimer.Elapsed.ToString("c");
                currentEntry[1] = DateTime.Now.ToString();
                currentEntry[2] = duration.Substring(0, duration.Length - 8);

                //label1.Text = duration.Substring(0, duration.Length - 5); 
                Program.history.Add(currentEntry);
                
                SaveEntry(true);
                
                ShowHistory();

                mainTimer.Reset();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                Array.Clear(currentEntry);
            }
            else
            {
                mainTimer.Start();
                currentEntry[0] = DateTime.Now.ToString();
                secTimer.Start();
                secTimer.Tick += secTimer_Tick;

            }
        }

        public ListView ListView1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void listView1_Click(object sender, EventArgs a)
        {
            Form2 editWindow = new Form2();
            //editWindow.Form1 = this;
            
            editWindow.entryIndex = listView1.SelectedIndices[0];
            
            editWindow.Show();
        }

            private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                this.ActiveControl = null;
        }

        private void textBox1_Leave(object sender, EventArgs a)
        {
            //textBox1.ForeColor = Color.Red;
            //textBox1.BackColor = Color.White;
            currentEntry[3] = textBox1.Text;
            label5.Text = currentEntry[3];
        }


        //private void textBoxes_Leave(object sender, EventArgs e)
        //{
        //    TextBox txbox = sender as TextBox;
        //    txbox.SelectionLength = 0;
        //    currentEntry[3] = textBox1.Text;
        //}

        void textBox2_Leave(object sender, EventArgs a)
        {
            currentEntry[4] = textBox2.Text;
        }

        void textBox3_Leave(object sender, EventArgs a)
        {
            currentEntry[5] = textBox3.Text;
        }


        void secTimer_Tick(object sender, EventArgs a)
        {
            string duration2 = mainTimer.Elapsed.ToString("c");
            label2.Text = duration2.Substring(0, duration2.Length - 5);
            label6.Text = ActiveControl.ToString();
            //label5.Text = currentEntry[3];
            //label5.Update();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void ShowHistory() 
        {
            //Console.WriteLine("Here is the history:");
            //for (int i = 0; i < history.Count; i++)
            //{
            //if (selectionActive && selection == i)
            //{
            //    Console.WriteLine("Timer entry {0}: (selected)", i);
            //}
            //else
            //{
            //    Console.WriteLine("Timer entry {0}:", i);
            //}

            listView1.Clear();
            LoadEntry();

            for (int j = 0; j < Program.fields.Length; j++)
                listView1.Columns.Add(Program.fields[j], 100, HorizontalAlignment.Center);

            
            for (int i = 0; i < Program.history.Count; i++)
            {
                ListViewItem newItem = new ListViewItem (Program.history[i]);
                listView1.Items.Insert(0, newItem);
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


                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] currentLine = s.Split("\t");
                        Program.history.Add(currentLine);
                        //Console.WriteLine(s);
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
                        for (int j = 0; j < 6; j++)
                            sw.Write("{0}\t", Program.history[i][j]);
                        sw.Write("\n");
                    }
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Program.pathToSave, append))
                {
                    //for (int i = 0; i < history.Count; i++)
                    //{
                    //    for (int j = 0; j < 6; j++)
                    //        sw.Write("{0}\t", history[i][j]);
                    //    sw.Write("\n");
                    //}
                    for (int i = 0; i < currentEntry.Length; i++)
                    {
                        sw.Write("{0}\t", currentEntry[i]);
                        
                    }
                    sw.Write("\n");

                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string name1 = textBox1.Text;
            //label5.Text = name1;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string name2 = textBox1.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string name3 = textBox1.Text;
        }
    }

    //static void startTimer()
    //{
    //    if (mainTimer.IsRunning)
    //    {
    //        Console.WriteLine("Timer already running, it is {0} currently", RoundToSeconds(mainTimer.Elapsed));
    //    }
    //    else
    //    {
    //        string[] newEntry = new string[6];

    //        //LoadEntry();
    //        history.Add(newEntry);
    //        mainTimer.Start();
    //        history[history.Count - 1][0] = DateTime.Now.ToString();
    //        SaveEntry(true);
    //    }
    //}

    //static void stopTimer()
    //{
    //    if (mainTimer.IsRunning)
    //    {
    //        string roundedTime = RoundToSeconds(mainTimer.Elapsed);
    //        mainTimer.Stop();
    //        history[history.Count - 1][1] = DateTime.Now.ToString();
    //        history[history.Count - 1][2] = roundedTime;
    //        Console.WriteLine("Last entry was {0} long", roundedTime);
    //        mainTimer.Reset();
    //        SaveEntry();
    //    }
    //    else
    //    {
    //        Console.WriteLine("There is no timer runnig to stop");
    //    }

    //}
}