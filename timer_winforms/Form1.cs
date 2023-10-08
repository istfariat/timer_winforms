using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace timer_winforms
{
    public partial class Form1 : Form
    {

        //static Stopwatch mainTimer = new Stopwatch();
        static System.Windows.Forms.Timer secTimer = new System.Windows.Forms.Timer();

        static (DateTime startTime, DateTime endTime, TimeSpan duration, string field, string project, string stage) currentEntry;

        //static int x = 0;

        public Form1()
        {
            InitializeComponent();
            ShowHistory();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            secTimer.Interval = 100;

            if (secTimer.Enabled)
            {
                //mainTimer.Stop();
                secTimer.Stop();

                currentEntry.endTime = DateTime.Now;
                currentEntry.duration = currentEntry.endTime - currentEntry.startTime;
                //string duration = currentEntry.duration.ToString("c");

                label2.Text = currentEntry.duration.ToString("c");
                Program.history.Add(currentEntry);

                SaveEntry(true);

                ShowHistory();

                //mainTimer.Reset();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                //Array.Clear(currentEntry);
                //currentEntry.Item1.
            }
            else
            {
                //mainTimer.Start();
                currentEntry.startTime = DateTime.Now;
                secTimer.Start();
                secTimer.Tick += secTimer_Tick;
                dateTimePicker1.Value = currentEntry.startTime;

            }
        }

        public ListView ListView1
        {
            get { return listView1; }
            set { listView1 = value; }
        }

        private void listView1_Click(object sender, EventArgs a)
        {

            label7.Text = listView1.SelectedIndices[0].ToString();
            label6.Text = (Program.history.Count - listView1.SelectedIndices[0] - 1).ToString();
            Form2 editWindow = new Form2(this);
            editWindow.entryIndex = Program.history.Count - listView1.SelectedIndices[0] - 1;
            editWindow.Show();
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
                this.ActiveControl = null;
        }

        private void textBox1_Leave(object sender, EventArgs a)
        {
            currentEntry.field = textBox1.Text;
            label5.Text = currentEntry.field;
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


        void secTimer_Tick(object sender, EventArgs a)
        {
            //string duration2 = mainTimer.Elapsed.ToString("c");


            currentEntry.duration = DateTime.Now - currentEntry.startTime;
            //label6.Text = ActiveControl.ToString();
            label2.Text = currentEntry.duration.ToString("c");
            //label5.Text = currentEntry.field;
            //label5.Update();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            currentEntry.startTime = dateTimePicker1.Value;            
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

        private void Form1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
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

    }
}