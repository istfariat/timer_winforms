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
            components = new System.ComponentModel.Container();
            openFileDialog1 = new OpenFileDialog();
            checkBoxAutoTime = new CheckBox();
            checkBoxEndTimeShift = new CheckBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBoxSavePath = new TextBox();
            labelSavePath = new Label();
            checkBoxReminder = new CheckBox();
            labelRemindTime = new Label();
            labelReminderCheck = new Label();
            labelIdleInt = new Label();
            labelAutotimer = new Label();
            labelTimeShift = new Label();
            labelTreshhold = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            buttonSaveSettings = new Button();
            numericUpDownReminder = new NumericUpDown();
            numericUpDownIdle = new NumericUpDown();
            numericUpDownThreshold = new NumericUpDown();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReminder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIdle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreshold).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.FileOk += openFileDialog1_FileOk;
            // 
            // checkBoxAutoTime
            // 
            checkBoxAutoTime.Anchor = AnchorStyles.None;
            checkBoxAutoTime.AutoSize = true;
            checkBoxAutoTime.Location = new Point(321, 115);
            checkBoxAutoTime.Name = "checkBoxAutoTime";
            checkBoxAutoTime.Size = new Size(15, 14);
            checkBoxAutoTime.TabIndex = 6;
            checkBoxAutoTime.UseVisualStyleBackColor = true;
            checkBoxAutoTime.CheckedChanged += checkBoxAutoTime_CheckedChanged;
            // 
            // checkBoxEndTimeShift
            // 
            checkBoxEndTimeShift.Anchor = AnchorStyles.None;
            checkBoxEndTimeShift.AutoSize = true;
            checkBoxEndTimeShift.Location = new Point(321, 187);
            checkBoxEndTimeShift.Name = "checkBoxEndTimeShift";
            checkBoxEndTimeShift.Size = new Size(15, 14);
            checkBoxEndTimeShift.TabIndex = 7;
            checkBoxEndTimeShift.UseVisualStyleBackColor = true;
            checkBoxEndTimeShift.CheckedChanged += checkBoxEndTimeShift_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.6666679F));
            tableLayoutPanel1.Controls.Add(numericUpDownThreshold, 1, 5);
            tableLayoutPanel1.Controls.Add(textBoxSavePath, 1, 0);
            tableLayoutPanel1.Controls.Add(numericUpDownIdle, 1, 3);
            tableLayoutPanel1.Controls.Add(labelSavePath, 0, 0);
            tableLayoutPanel1.Controls.Add(numericUpDownReminder, 1, 2);
            tableLayoutPanel1.Controls.Add(checkBoxReminder, 1, 1);
            tableLayoutPanel1.Controls.Add(labelRemindTime, 0, 2);
            tableLayoutPanel1.Controls.Add(labelReminderCheck, 0, 1);
            tableLayoutPanel1.Controls.Add(labelIdleInt, 0, 3);
            tableLayoutPanel1.Controls.Add(labelAutotimer, 0, 4);
            tableLayoutPanel1.Controls.Add(labelTimeShift, 0, 6);
            tableLayoutPanel1.Controls.Add(labelTreshhold, 0, 5);
            tableLayoutPanel1.Controls.Add(checkBoxAutoTime, 1, 4);
            tableLayoutPanel1.Controls.Add(checkBoxEndTimeShift, 1, 6);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(416, 226);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // textBoxSavePath
            // 
            textBoxSavePath.Anchor = AnchorStyles.Left;
            textBoxSavePath.Location = new Point(245, 4);
            textBoxSavePath.Name = "textBoxSavePath";
            textBoxSavePath.ReadOnly = true;
            textBoxSavePath.Size = new Size(167, 23);
            textBoxSavePath.TabIndex = 10;
            textBoxSavePath.Click += textBoxSavePath_Click;
            // 
            // labelSavePath
            // 
            labelSavePath.Anchor = AnchorStyles.Left;
            labelSavePath.AutoSize = true;
            labelSavePath.Location = new Point(4, 8);
            labelSavePath.Name = "labelSavePath";
            labelSavePath.Size = new Size(92, 15);
            labelSavePath.TabIndex = 0;
            labelSavePath.Text = "Path to savefiles";
            // 
            // checkBoxReminder
            // 
            checkBoxReminder.Anchor = AnchorStyles.None;
            checkBoxReminder.AutoSize = true;
            checkBoxReminder.Location = new Point(321, 34);
            checkBoxReminder.Name = "checkBoxReminder";
            checkBoxReminder.Size = new Size(15, 14);
            checkBoxReminder.TabIndex = 15;
            checkBoxReminder.UseVisualStyleBackColor = true;
            checkBoxReminder.CheckedChanged += checkBoxReminder_CheckedChanged;
            // 
            // labelRemindTime
            // 
            labelRemindTime.Anchor = AnchorStyles.Left;
            labelRemindTime.AutoSize = true;
            labelRemindTime.Location = new Point(4, 59);
            labelRemindTime.Name = "labelRemindTime";
            labelRemindTime.Size = new Size(127, 15);
            labelRemindTime.TabIndex = 11;
            labelRemindTime.Text = "Reminder interval, min";
            // 
            // labelReminderCheck
            // 
            labelReminderCheck.Anchor = AnchorStyles.Left;
            labelReminderCheck.AutoSize = true;
            labelReminderCheck.Location = new Point(4, 33);
            labelReminderCheck.Name = "labelReminderCheck";
            labelReminderCheck.Size = new Size(93, 15);
            labelReminderCheck.TabIndex = 12;
            labelReminderCheck.Text = "Enable reminder";
            // 
            // labelIdleInt
            // 
            labelIdleInt.Anchor = AnchorStyles.Left;
            labelIdleInt.AutoSize = true;
            labelIdleInt.Location = new Point(4, 89);
            labelIdleInt.Name = "labelIdleInt";
            labelIdleInt.Size = new Size(95, 15);
            labelIdleInt.TabIndex = 12;
            labelIdleInt.Text = "Idle interval, min";
            // 
            // labelAutotimer
            // 
            labelAutotimer.Anchor = AnchorStyles.Left;
            labelAutotimer.AutoSize = true;
            labelAutotimer.Location = new Point(4, 114);
            labelAutotimer.Name = "labelAutotimer";
            labelAutotimer.Size = new Size(97, 15);
            labelAutotimer.TabIndex = 12;
            labelAutotimer.Text = "Enable autotimer";
            // 
            // labelTimeShift
            // 
            labelTimeShift.Anchor = AnchorStyles.Left;
            labelTimeShift.AutoSize = true;
            labelTimeShift.Location = new Point(4, 179);
            labelTimeShift.Name = "labelTimeShift";
            labelTimeShift.Size = new Size(216, 30);
            labelTimeShift.TabIndex = 12;
            labelTimeShift.Text = "Change endtime when starttime edited instead of duration";
            // 
            // labelTreshhold
            // 
            labelTreshhold.Anchor = AnchorStyles.Left;
            labelTreshhold.AutoSize = true;
            labelTreshhold.Location = new Point(4, 140);
            labelTreshhold.Name = "labelTreshhold";
            labelTreshhold.Size = new Size(137, 15);
            labelTreshhold.TabIndex = 12;
            labelTreshhold.Text = "Autotimer threshold, sec";
            // 
            // buttonSaveSettings
            // 
            buttonSaveSettings.Location = new Point(186, 308);
            buttonSaveSettings.Name = "buttonSaveSettings";
            buttonSaveSettings.Size = new Size(95, 37);
            buttonSaveSettings.TabIndex = 9;
            buttonSaveSettings.Text = "Save Settings";
            buttonSaveSettings.UseVisualStyleBackColor = true;
            buttonSaveSettings.Click += buttonSaveSettings_Click;
            // 
            // numericUpDownReminder
            // 
            numericUpDownReminder.Anchor = AnchorStyles.Left;
            numericUpDownReminder.Location = new Point(245, 55);
            numericUpDownReminder.Name = "numericUpDownReminder";
            numericUpDownReminder.Size = new Size(167, 23);
            numericUpDownReminder.TabIndex = 10;
            // 
            // numericUpDownIdle
            // 
            numericUpDownIdle.Anchor = AnchorStyles.Left;
            numericUpDownIdle.Location = new Point(245, 85);
            numericUpDownIdle.Name = "numericUpDownIdle";
            numericUpDownIdle.Size = new Size(167, 23);
            numericUpDownIdle.TabIndex = 10;
            // 
            // numericUpDownThreshold
            // 
            numericUpDownThreshold.Anchor = AnchorStyles.Left;
            numericUpDownThreshold.Location = new Point(245, 136);
            numericUpDownThreshold.Name = "numericUpDownThreshold";
            numericUpDownThreshold.Size = new Size(167, 23);
            numericUpDownThreshold.TabIndex = 10;
            // 
            // SettingsWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 617);
            Controls.Add(buttonSaveSettings);
            Controls.Add(tableLayoutPanel1);
            Name = "SettingsWindowForm";
            Text = "Settings";
            Load += SettingsWindowForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownReminder).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownIdle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreshold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Label labelIdleInt;
        private CheckBox checkBoxAutoTime;
        private CheckBox checkBoxEndTimeShift;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSavePath;
        private TextBox textBoxSavePath;
        private System.Windows.Forms.Timer timer1;
        private Label labelRemindTime;
        private Label labelReminderCheck;
        private Label labelTreshhold;
        private Label labelAutotimer;
        private Label labelTimeShift;
        private CheckBox checkBoxReminder;
        private Button buttonSaveSettings;
        private NumericUpDown numericUpDownReminder;
        private NumericUpDown numericUpDownIdle;
        private NumericUpDown numericUpDownThreshold;
    }
}