namespace AIPS_Portal
{
    partial class Teacher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher));
            panel1 = new Panel();
            add = new Button();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            button6 = new Button();
            button9 = new Button();
            button5 = new Button();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            button10 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(add);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel3);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(265, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(1630, 887);
            panel1.TabIndex = 8;
            // 
            // add
            // 
            add.BackColor = Color.FromArgb(224, 224, 224);
            add.BackgroundImageLayout = ImageLayout.None;
            add.FlatStyle = FlatStyle.Popup;
            add.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add.ForeColor = Color.FromArgb(0, 0, 64);
            add.Image = Properties.Resources.Search1;
            add.ImageAlign = ContentAlignment.MiddleLeft;
            add.Location = new Point(1432, 126);
            add.Name = "add";
            add.Size = new Size(188, 33);
            add.TabIndex = 10;
            add.Text = "Add Records";
            add.TextAlign = ContentAlignment.MiddleRight;
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.InactiveCaptionText;
            dataGridView1.Location = new Point(15, 165);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1605, 707);
            dataGridView1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 0, 64);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(15, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(1605, 58);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(0, 9);
            label3.Name = "label3";
            label3.Size = new Size(320, 36);
            label3.TabIndex = 7;
            label3.Text = "Add Teachers Records";
            // 
            // panel2
            // 
            panel2.Controls.Add(button10);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(-1, -2);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 995);
            panel2.TabIndex = 9;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.White;
            button6.Image = Properties.Resources.attend;
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(0, 365);
            button6.Name = "button6";
            button6.Size = new Size(219, 29);
            button6.TabIndex = 13;
            button6.Text = "Attendance";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(0, 0, 64);
            button9.BackgroundImageLayout = ImageLayout.None;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.FromArgb(255, 128, 0);
            button9.Image = Properties.Resources.Attendence_Logo;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(4, 331);
            button9.Name = "button9";
            button9.Size = new Size(215, 29);
            button9.TabIndex = 11;
            button9.Text = "Teachers    ";
            button9.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.Staff__1_;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(4, 297);
            button5.Name = "button5";
            button5.Size = new Size(215, 29);
            button5.TabIndex = 7;
            button5.Text = "Students    ";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.LOGO_removebg_preview;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(62, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 142);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 0, 64);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Image = Properties.Resources.Logout__1_;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(13, 924);
            button3.Name = "button3";
            button3.Size = new Size(195, 41);
            button3.TabIndex = 6;
            button3.Text = "Logout";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(0, 0, 64);
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Image = Properties.Resources.Staff__1_;
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(2, 227);
            button4.Name = "button4";
            button4.Size = new Size(217, 29);
            button4.TabIndex = 5;
            button4.Text = "Search       ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.Attendence_Logo;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(4, 262);
            button2.Name = "button2";
            button2.Size = new Size(215, 29);
            button2.TabIndex = 4;
            button2.Text = "Marks        ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.Home1_removebg_preview__1__remov__1_;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(2, 192);
            button1.Name = "button1";
            button1.Size = new Size(217, 29);
            button1.TabIndex = 3;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(266, 37);
            label1.Name = "label1";
            label1.Size = new Size(466, 36);
            label1.TabIndex = 10;
            label1.Text = "Allama Iqbal Public High School";
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(0, 0, 64);
            button10.BackgroundImageLayout = ImageLayout.None;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.White;
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(2, 400);
            button10.Name = "button10";
            button10.Size = new Size(217, 29);
            button10.TabIndex = 18;
            button10.Text = "Admissions ";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // Teacher
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1924, 994);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Teacher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Teacher";
            WindowState = FormWindowState.Maximized;
            Load += Teacher_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button add;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Label label3;
        private Panel panel2;
        private Button button9;
        private Button button5;
        private PictureBox pictureBox1;
        private Button button3;
        private Button button4;
        private Button button2;
        private Button button1;
        private Label label1;
        private Button button6;
        private Button button10;
    }
}