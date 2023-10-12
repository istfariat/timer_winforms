namespace timer_winforms
{
    partial class EditEntryWindowForm
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
            textBoxFieldEdit = new TextBox();
            textBoxProjectEdit = new TextBox();
            textBoxStageEdit = new TextBox();
            labelEndTime = new Label();
            labelStartTime = new Label();
            dateTimePickerStarttimeEdit = new DateTimePicker();
            dateTimePickerEndtimeEdit = new DateTimePicker();
            textBoxDurationEdit = new TextBox();
            labelDuration = new Label();
            SuspendLayout();
            // 
            // textBoxFieldEdit
            // 
            textBoxFieldEdit.Location = new Point(90, 73);
            textBoxFieldEdit.Name = "textBoxFieldEdit";
            textBoxFieldEdit.PlaceholderText = "Field";
            textBoxFieldEdit.Size = new Size(100, 23);
            textBoxFieldEdit.TabIndex = 2;
            textBoxFieldEdit.LostFocus += textBoxFieldEdit_LostFocus;
            // 
            // textBoxProjectEdit
            // 
            textBoxProjectEdit.Location = new Point(90, 121);
            textBoxProjectEdit.Name = "textBoxProjectEdit";
            textBoxProjectEdit.PlaceholderText = "Project";
            textBoxProjectEdit.Size = new Size(100, 23);
            textBoxProjectEdit.TabIndex = 2;
            textBoxProjectEdit.LostFocus += texttextBoxProjectEditBox3_LostFocus;
            // 
            // textBoxStageEdit
            // 
            textBoxStageEdit.Location = new Point(90, 179);
            textBoxStageEdit.Name = "textBoxStageEdit";
            textBoxStageEdit.PlaceholderText = "Stage";
            textBoxStageEdit.Size = new Size(100, 23);
            textBoxStageEdit.TabIndex = 2;
            textBoxStageEdit.LostFocus += textBoxStageEdit_LostFocus;
            // 
            // labelEndTime
            // 
            labelEndTime.AutoSize = true;
            labelEndTime.Location = new Point(360, 217);
            labelEndTime.Name = "labelEndTime";
            labelEndTime.Size = new Size(54, 15);
            labelEndTime.TabIndex = 4;
            labelEndTime.Text = "End time";
            // 
            // labelStartTime
            // 
            labelStartTime.AutoSize = true;
            labelStartTime.Location = new Point(350, 28);
            labelStartTime.Name = "labelStartTime";
            labelStartTime.Size = new Size(58, 15);
            labelStartTime.TabIndex = 4;
            labelStartTime.Text = "Start time";
            // 
            // dateTimePickerStarttimeEdit
            // 
            dateTimePickerStarttimeEdit.Format = DateTimePickerFormat.Time;
            dateTimePickerStarttimeEdit.Location = new Point(370, 46);
            dateTimePickerStarttimeEdit.Name = "dateTimePickerStarttimeEdit";
            dateTimePickerStarttimeEdit.Size = new Size(123, 23);
            dateTimePickerStarttimeEdit.TabIndex = 5;
            dateTimePickerStarttimeEdit.ValueChanged += dateTimePickerStarttimeEdit_ValueChanged;
            // 
            // dateTimePickerEndtimeEdit
            // 
            dateTimePickerEndtimeEdit.Format = DateTimePickerFormat.Time;
            dateTimePickerEndtimeEdit.Location = new Point(370, 248);
            dateTimePickerEndtimeEdit.Name = "dateTimePickerEndtimeEdit";
            dateTimePickerEndtimeEdit.Size = new Size(123, 23);
            dateTimePickerEndtimeEdit.TabIndex = 5;
            dateTimePickerEndtimeEdit.ValueChanged += dateTimePickerEndtimeEdit_ValueChanged;
            // 
            // textBoxDurationEdit
            // 
            textBoxDurationEdit.Location = new Point(562, 164);
            textBoxDurationEdit.Name = "textBoxDurationEdit";
            textBoxDurationEdit.Size = new Size(100, 23);
            textBoxDurationEdit.TabIndex = 6;
            // 
            // labelabelDurationl4
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(546, 129);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(52, 15);
            labelDuration.TabIndex = 4;
            labelDuration.Text = "duration";
            // 
            // EditEntryWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxDurationEdit);
            Controls.Add(dateTimePickerEndtimeEdit);
            Controls.Add(dateTimePickerStarttimeEdit);
            Controls.Add(labelStartTime);
            Controls.Add(labelDuration);
            Controls.Add(labelEndTime);
            Controls.Add(textBoxStageEdit);
            Controls.Add(textBoxProjectEdit);
            Controls.Add(textBoxFieldEdit);
            Name = "EditEntryWindow";
            Text = "EditEntryWindow";
            FormClosing += EditEntryWindow_FormClosing;
            Load += EditEntryWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        protected TextBox textBoxFieldEdit;
        private TextBox textBoxProjectEdit;
        private TextBox textBoxStageEdit;
        private Label labelEndTime;
        private Label labelStartTime;
        private DateTimePicker dateTimePickerStarttimeEdit;
        private DateTimePicker dateTimePickerEndtimeEdit;
        private TextBox textBoxDurationEdit;
        private Label labelDuration;
    }
}