namespace timer_winforms
{
    partial class MainWindowForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonStopStart = new Button();
            textBoxField = new TextBox();
            labelTimerRunning = new Label();
            listViewHistory = new ListView();
            textBoxSubject = new TextBox();
            textBoxStage = new TextBox();
 
            buttonSettings = new Button();
            label8 = new Label();
            dateTimePickerStarttimeCurrent = new DateTimePicker();
            
            
            label12 = new Label();
            listView2 = new ListView();
            
            SuspendLayout();
            // 
            // button1
            // 
            buttonStopStart.Location = new Point(343, 162);
            buttonStopStart.Name = "button1";
            buttonStopStart.Size = new Size(114, 44);
            buttonStopStart.TabIndex = 0;
            buttonStopStart.Text = "start/stop";
            buttonStopStart.UseVisualStyleBackColor = true;
            buttonStopStart.Click += StartStopButton_Click;
            // 
            // textBox1
            // 
            textBoxField.Location = new Point(141, 52);
            textBoxField.Name = "textBox1";
            textBoxField.PlaceholderText = "Field";
            textBoxField.Size = new Size(100, 23);
            textBoxField.TabIndex = 5;
            textBoxField.Leave += textBox1_Leave;
            // 
            // label2
            // 
            labelTimerRunning.AutoSize = true;
            labelTimerRunning.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelTimerRunning.Location = new Point(359, 112);
            labelTimerRunning.Name = "label2";
            labelTimerRunning.Size = new Size(86, 28);
            labelTimerRunning.TabIndex = 3;
            labelTimerRunning.Text = "00:00:00";
            // 
            // listView1
            // 
            listViewHistory.FullRowSelect = true;
            listViewHistory.Location = new Point(42, 246);
            listViewHistory.MultiSelect = false;
            listViewHistory.Name = "listView1";
            listViewHistory.Size = new Size(721, 97);
            listViewHistory.TabIndex = 4;
            listViewHistory.UseCompatibleStateImageBehavior = false;
            listViewHistory.View = View.Details;
            listViewHistory.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listViewHistory.Click += listView1_Click;
            // 
            // textBox2
            // 
            textBoxSubject.Location = new Point(141, 93);
            textBoxSubject.Name = "textBox2";
            textBoxSubject.PlaceholderText = "Subject";
            textBoxSubject.Size = new Size(100, 23);
            textBoxSubject.TabIndex = 5;
            textBoxSubject.Leave += textBox2_Leave;
            // 
            // textBox3
            // 
            textBoxStage.Location = new Point(141, 135);
            textBoxStage.Name = "textBox3";
            textBoxStage.PlaceholderText = "Stage";
            textBoxStage.Size = new Size(100, 23);
            textBoxStage.TabIndex = 5;
            textBoxStage.Leave += textBox3_Leave;
 
         
            // 
            // button2
            // 
            buttonSettings.Location = new Point(673, 27);
            buttonSettings.Name = "button2";
            buttonSettings.Size = new Size(64, 45);
            buttonSettings.TabIndex = 0;
            buttonSettings.Text = "settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(440, 73);
            label8.Name = "label8";
            label8.Size = new Size(101, 28);
            label8.TabIndex = 3;
            label8.Text = "Start time:";
            // 
            // dateTimePicker1
            // 
            dateTimePickerStarttimeCurrent.Format = DateTimePickerFormat.Time;
            dateTimePickerStarttimeCurrent.Location = new Point(547, 78);
            dateTimePickerStarttimeCurrent.Name = "dateTimePicker1";
            dateTimePickerStarttimeCurrent.Size = new Size(200, 23);
            dateTimePickerStarttimeCurrent.TabIndex = 7;
            dateTimePickerStarttimeCurrent.ValueChanged += dateTimePicker1_ValueChanged;
            
            
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(197, 411);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 12;
            label12.Text = "label12";
            // 
            // listView2
            // 
            listView2.Location = new Point(71, 439);
            listView2.Name = "listView2";
            listView2.Size = new Size(490, 214);
            listView2.TabIndex = 13;
            listView2.UseCompatibleStateImageBehavior = false;
           
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 749);
           
            Controls.Add(listView2);
            Controls.Add(label12);
          
            
            Controls.Add(dateTimePickerStarttimeCurrent);
           
            Controls.Add(textBoxStage);
            Controls.Add(textBoxSubject);
            Controls.Add(listViewHistory);
  
            
            Controls.Add(label8);
    
          
            Controls.Add(labelTimerRunning);
            Controls.Add(textBoxField);
            Controls.Add(buttonSettings);
            Controls.Add(buttonStopStart);
            Name = "Form1";
            Text = "Form1";
            Click += Form1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStopStart;
        private Button buttonSettings;
        private TextBox textBoxField;
        private TextBox textBoxSubject;
        private TextBox textBoxStage;
        private DateTimePicker dateTimePickerStarttimeCurrent;
        private Label labelTimerRunning;
        private ListView listViewHistory;
       
        private Label label8;     
        private Label label12;
        private ListView listView2;
      
    }
}