namespace timer_winforms
{
    partial class Form1
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
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            listView1 = new ListView();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox4 = new TextBox();
            button2 = new Button();
            label8 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button3 = new Button();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            listView2 = new ListView();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(343, 162);
            button1.Name = "button1";
            button1.Size = new Size(114, 44);
            button1.TabIndex = 0;
            button1.Text = "start/stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 52);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Field";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            textBox1.Leave += textBox1_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(359, 112);
            label2.Name = "label2";
            label2.Size = new Size(86, 28);
            label2.TabIndex = 3;
            label2.Text = "00:00:00";
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.Location = new Point(42, 246);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(721, 97);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.Click += listView1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(141, 93);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Subject";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 5;
            textBox2.Leave += textBox2_Leave;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 135);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Stage";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 5;
            textBox3.Leave += textBox3_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(51, 47);
            label1.Name = "label1";
            label1.Size = new Size(58, 28);
            label1.TabIndex = 3;
            label1.Text = "Field:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(51, 93);
            label3.Name = "label3";
            label3.Size = new Size(81, 28);
            label3.TabIndex = 3;
            label3.Text = "Subject:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(51, 135);
            label4.Name = "label4";
            label4.Size = new Size(65, 28);
            label4.TabIndex = 3;
            label4.Text = "Stage:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(320, 44);
            label5.Name = "label5";
            label5.Size = new Size(76, 28);
            label5.TabIndex = 3;
            label5.Text = "name 1";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(141, 373);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 3;
            label6.Text = "label2";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(71, 209);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 3;
            label7.Text = "label2";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Location = new Point(517, 27);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(100, 16);
            textBox4.TabIndex = 6;
            textBox4.TabStop = false;
            textBox4.Text = "test";
            textBox4.Enter += textBox4_Enter;
            textBox4.GotFocus += textBox4_GotFocus;
            // 
            // button2
            // 
            button2.Location = new Point(673, 27);
            button2.Name = "button2";
            button2.Size = new Size(64, 45);
            button2.TabIndex = 0;
            button2.Text = "settings";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            dateTimePicker1.Format = DateTimePickerFormat.Time;
            dateTimePicker1.Location = new Point(547, 78);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button3
            // 
            button3.Location = new Point(615, 174);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 8;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(627, 145);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 9;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(573, 373);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 10;
            label10.Text = "label10";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(573, 400);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 11;
            label11.Text = "label11";
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
            listView2.Location = new Point(261, 349);
            listView2.Name = "listView2";
            listView2.Size = new Size(280, 77);
            listView2.TabIndex = 13;
            listView2.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listView2);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(button3);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(listView1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Click += Form1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private ListView listView1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox4;
        private Button button2;
        private Label label8;
        private DateTimePicker dateTimePicker1;
        private Button button3;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private ListView listView2;
    }
}