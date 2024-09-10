namespace Employee_Management_Application
{
    partial class EMA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EMA));
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            pictureBox7 = new PictureBox();
            pictureBox8 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1 = new Panel();
            button6 = new Button();
            button5 = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            label9 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            label7 = new Label();
            management1 = new Management();
            chart1 = new Chart();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Gainsboro;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 5;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial Rounded MT Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(94, 297);
            button1.Name = "button1";
            button1.Size = new Size(189, 76);
            button1.TabIndex = 0;
            button1.Text = "DASHBOARD";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 5;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Arial Rounded MT Bold", 13.8F);
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(94, 440);
            button2.Name = "button2";
            button2.Size = new Size(189, 76);
            button2.TabIndex = 1;
            button2.Text = "MANAGE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(95, 824);
            button4.Name = "button4";
            button4.Size = new Size(188, 44);
            button4.TabIndex = 4;
            button4.Text = "Log out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.White;
            pictureBox7.Image = Properties.Resources.procrastination;
            pictureBox7.Location = new Point(67, 17);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(106, 122);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 8;
            pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.White;
            pictureBox8.Image = Properties.Resources.accessibility;
            pictureBox8.Location = new Point(49, 17);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(95, 122);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 9;
            pictureBox8.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(31, 159);
            label1.Name = "label1";
            label1.Size = new Size(269, 38);
            label1.TabIndex = 12;
            label1.Text = "TOTAL EMPLOYEES";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(49, 159);
            label2.Name = "label2";
            label2.Size = new Size(276, 38);
            label2.TabIndex = 13;
            label2.Text = "ACTIVE EMPLOYEES";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(67, 159);
            label3.Name = "label3";
            label3.Size = new Size(306, 38);
            label3.TabIndex = 14;
            label3.Text = "INACTIVE EMPLOYEES";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(272, 47);
            label4.Name = "label4";
            label4.Size = new Size(125, 38);
            label4.TabIndex = 15;
            label4.Text = "Number";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(277, 47);
            label6.Name = "label6";
            label6.Size = new Size(125, 38);
            label6.TabIndex = 17;
            label6.Text = "Number";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSlateGray;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button2);
            panel1.Location = new Point(12, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(383, 964);
            panel1.TabIndex = 19;
            panel1.Paint += panel1_Paint;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.Location = new Point(94, 897);
            button6.Name = "button6";
            button6.Size = new Size(189, 44);
            button6.TabIndex = 24;
            button6.Text = "Exit";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.Gainsboro;
            button5.FlatAppearance.BorderColor = Color.White;
            button5.FlatAppearance.BorderSize = 5;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Arial Rounded MT Bold", 13.8F);
            button5.ForeColor = SystemColors.ActiveCaptionText;
            button5.Location = new Point(94, 581);
            button5.Name = "button5";
            button5.Size = new Size(189, 76);
            button5.TabIndex = 5;
            button5.Text = "HELP";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.worker;
            pictureBox2.Location = new Point(94, 72);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(189, 150);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.to_do_list;
            pictureBox1.Location = new Point(79, 42);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(98, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(401, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(1511, 291);
            panel2.TabIndex = 20;
            panel2.Paint += panel2_Paint;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label3);
            panel6.Controls.Add(pictureBox7);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(1066, 25);
            panel6.Name = "panel6";
            panel6.Size = new Size(415, 235);
            panel6.TabIndex = 25;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(pictureBox8);
            panel5.Location = new Point(544, 25);
            panel5.Name = "panel5";
            panel5.Size = new Size(415, 235);
            panel5.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(265, 47);
            label9.Name = "label9";
            label9.Size = new Size(125, 38);
            label9.TabIndex = 15;
            label9.Text = "Number";
            label9.Click += label9_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(20, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(415, 235);
            panel4.TabIndex = 23;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkSlateGray;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label7);
            panel3.Location = new Point(13, 6);
            panel3.Name = "panel3";
            panel3.Size = new Size(1899, 45);
            panel3.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(3, 2);
            label7.Name = "label7";
            label7.Size = new Size(262, 23);
            label7.TabIndex = 22;
            label7.Text = "Employee Management System";
            // 
            // management1
            // 
            management1.Location = new Point(401, 354);
            management1.Name = "management1";
            management1.Size = new Size(1511, 680);
            management1.TabIndex = 23;
            management1.Load += management1_Load;
            // 
            // chart1
            // 
            chart1.Location = new Point(421, 371);
            chart1.Name = "chart1";
            chart1.Size = new Size(1448, 650);
            chart1.TabIndex = 24;
            // 
            // EMA
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1902, 1033);
            Controls.Add(chart1);
            Controls.Add(management1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EMA";
            Text = "EMA";
            FormClosing += EMA_FormClosing;
            Load += EMA_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button4;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private System.Windows.Forms.Timer timer1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Label label7;
        private Panel panel4;
        private Panel panel6;
        private Panel panel5;
        private Label label9;
        private Management management1;
        private PictureBox pictureBox2;
        private Button button6;
        private Button button5;
        private Chart chart1;
    }
}