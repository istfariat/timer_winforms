namespace timer_winforms
{
    partial class SettingsWindowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            settingName = new DataGridViewTextBoxColumn();
            settingValue = new DataGridViewTextBoxColumn();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            panel1 = new Panel();
            panel2 = new Panel();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            checkBoxAutoTime = new CheckBox();
            checkBoxEndTimeShift = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { settingName, settingValue });
            dataGridView1.Location = new Point(274, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(254, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // settingName
            // 
            settingName.HeaderText = "Option";
            settingName.Name = "settingName";
            settingName.ReadOnly = true;
            // 
            // settingValue
            // 
            settingValue.HeaderText = "Value";
            settingValue.Name = "settingValue";
            // 
            // button1
            // 
            button1.Location = new Point(651, 53);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(308, 321);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 73);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 27);
            panel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(122, 85);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(122, 53);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(621, 188);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // checkBoxAutoTime
            // 
            checkBoxAutoTime.AutoSize = true;
            checkBoxAutoTime.Location = new Point(347, 30);
            checkBoxAutoTime.Name = "checkBoxAutoTime";
            checkBoxAutoTime.Size = new Size(103, 19);
            checkBoxAutoTime.TabIndex = 6;
            checkBoxAutoTime.Text = "AutoTimer ON";
            checkBoxAutoTime.UseVisualStyleBackColor = true;
            checkBoxAutoTime.CheckedChanged += checkBoxAutoTime_CheckedChanged;
            // 
            // checkBoxEndTimeShift
            // 
            checkBoxEndTimeShift.AutoSize = true;
            checkBoxEndTimeShift.Location = new Point(346, 57);
            checkBoxEndTimeShift.Name = "checkBoxEndTimeShift";
            checkBoxEndTimeShift.Size = new Size(250, 19);
            checkBoxEndTimeShift.TabIndex = 7;
            checkBoxEndTimeShift.Text = "Shift endtime when is starttime is changed";
            checkBoxEndTimeShift.UseVisualStyleBackColor = true;
            checkBoxEndTimeShift.CheckedChanged += checkBoxEndTimeShift_CheckedChanged;
            // 
            // SettingsWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(checkBoxEndTimeShift);
            Controls.Add(checkBoxAutoTime);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "SettingsWindowForm";
            Text = "Settings";
            Load += SettingsWindowForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn settingName;
        private DataGridViewTextBoxColumn settingValue;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxAutoTime;
        private CheckBox checkBoxEndTimeShift;
    }
}