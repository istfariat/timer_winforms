namespace timer_winforms
{
    partial class IdleNotificationWindowForm
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
            labelIdleMsg = new Label();
            buttonIdleContinueEntry = new Button();
            buttonIdleDiscardEntry = new Button();
            buttonIdleDiscardCont = new Button();
            buttonIdleContinueAsNew = new Button();
            SuspendLayout();
            // 
            // labelIdleMsg
            // 
            labelIdleMsg.AutoSize = true;
            labelIdleMsg.Location = new Point(25, 52);
            labelIdleMsg.Name = "labelIdleMsg";
            labelIdleMsg.Size = new Size(184, 15);
            labelIdleMsg.TabIndex = 0;
            labelIdleMsg.Text = "You were idle since 12:00 (17 min)";
            labelIdleMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonIdleContinueEntry
            // 
            buttonIdleContinueEntry.Location = new Point(53, 146);
            buttonIdleContinueEntry.Name = "buttonIdleContinueEntry";
            buttonIdleContinueEntry.Size = new Size(129, 38);
            buttonIdleContinueEntry.TabIndex = 1;
            buttonIdleContinueEntry.Text = "Continue entry";
            buttonIdleContinueEntry.UseVisualStyleBackColor = true;
            buttonIdleContinueEntry.Click += buttonIdleContinueEntry_Click;
            // 
            // buttonIdleDiscardEntry
            // 
            buttonIdleDiscardEntry.Location = new Point(53, 190);
            buttonIdleDiscardEntry.Name = "buttonIdleDiscardEntry";
            buttonIdleDiscardEntry.Size = new Size(129, 39);
            buttonIdleDiscardEntry.TabIndex = 2;
            buttonIdleDiscardEntry.Text = "Discard entry";
            buttonIdleDiscardEntry.UseVisualStyleBackColor = true;
            buttonIdleDiscardEntry.Click += buttonIdleDiscardEntry_Click;
            // 
            // buttonIdleDiscardCont
            // 
            buttonIdleDiscardCont.Location = new Point(53, 235);
            buttonIdleDiscardCont.Name = "buttonIdleDiscardCont";
            buttonIdleDiscardCont.Size = new Size(129, 39);
            buttonIdleDiscardCont.TabIndex = 2;
            buttonIdleDiscardCont.Text = "Discard entry & continue";
            buttonIdleDiscardCont.UseVisualStyleBackColor = true;
            buttonIdleDiscardCont.Click += buttonIdleDiscardCont_Click;
            // 
            // buttonIdleContinueAsNew
            // 
            buttonIdleContinueAsNew.Location = new Point(53, 280);
            buttonIdleContinueAsNew.Name = "buttonIdleContinueAsNew";
            buttonIdleContinueAsNew.Size = new Size(129, 39);
            buttonIdleContinueAsNew.TabIndex = 2;
            buttonIdleContinueAsNew.Text = "Continue as new entry";
            buttonIdleContinueAsNew.UseVisualStyleBackColor = true;
            buttonIdleContinueAsNew.Click += buttonIdleContinueAsNew_Click;
            // 
            // IdleNotificationWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(236, 401);
            Controls.Add(buttonIdleContinueAsNew);
            Controls.Add(buttonIdleDiscardCont);
            Controls.Add(buttonIdleDiscardEntry);
            Controls.Add(buttonIdleContinueEntry);
            Controls.Add(labelIdleMsg);
            Name = "IdleNotificationWindowForm";
            Text = "IdleNotificationForm";
            FormClosing += IdleNotificationWindowForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelIdleMsg;
        private Button buttonIdleContinueEntry;
        private Button buttonIdleDiscardEntry;
        private Button buttonIdleDiscardCont;
        private Button buttonIdleContinueAsNew;
    }
}