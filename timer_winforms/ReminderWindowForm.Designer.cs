namespace timer_winforms
{
    partial class ReminderWindowForm
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
            buttonStartFromReminder = new Button();
            labelReminderMsg = new Label();
            SuspendLayout();
            // 
            // buttonStartFromReminder
            // 
            buttonStartFromReminder.Location = new Point(75, 80);
            buttonStartFromReminder.Name = "buttonStartFromReminder";
            buttonStartFromReminder.Size = new Size(150, 50);
            buttonStartFromReminder.TabIndex = 0;
            buttonStartFromReminder.Text = "Start tracking";
            buttonStartFromReminder.UseVisualStyleBackColor = true;
            buttonStartFromReminder.Click += buttonStartFromReminder_Click;
            // 
            // labelReminderMsg
            // 
            labelReminderMsg.AutoSize = true;
            labelReminderMsg.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelReminderMsg.Location = new Point(12, 27);
            labelReminderMsg.Name = "labelReminderMsg";
            labelReminderMsg.Size = new Size(267, 25);
            labelReminderMsg.TabIndex = 1;
            labelReminderMsg.Text = "Dont forget to track your time!";
            // 
            // ReminderWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 141);
            Controls.Add(labelReminderMsg);
            Controls.Add(buttonStartFromReminder);
            Name = "ReminderWindowForm";
            StartPosition = FormStartPosition.Manual;
            Text = "ReminderWindowForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonStartFromReminder;
        private Label labelReminderMsg;
    }
}