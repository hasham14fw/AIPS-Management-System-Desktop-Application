namespace AIPS_Portal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            button12 = new Button();
            button7 = new Button();
            button6 = new Button();
            cmbExamType = new ComboBox();
            dtpExamDate = new DateTimePicker();
            label3 = new Label();
            dataGridViewMarks = new DataGridView();
            cmbClass = new ComboBox();
            label2 = new Label();
            button3 = new Button();
            btnManual = new Button();
            label1 = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button8 = new Button();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button4 = new Button();
            button2 = new Button();
            button5 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button7);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(cmbExamType);
            panel1.Controls.Add(dtpExamDate);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dataGridViewMarks);
            panel1.Controls.Add(cmbClass);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(btnManual);
            panel1.Location = new Point(266, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(1630, 887);
            panel1.TabIndex = 0;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(0, 0, 64);
            button12.BackgroundImageLayout = ImageLayout.None;
            button12.FlatStyle = FlatStyle.Popup;
            button12.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button12.ForeColor = Color.FromArgb(224, 224, 224);
            button12.ImageAlign = ContentAlignment.MiddleLeft;
            button12.Location = new Point(1402, 59);
            button12.Name = "button12";
            button12.Size = new Size(195, 33);
            button12.TabIndex = 13;
            button12.Text = "Document ";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(0, 0, 64);
            button7.BackgroundImageLayout = ImageLayout.None;
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.FromArgb(224, 224, 224);
            button7.ImageAlign = ContentAlignment.MiddleLeft;
            button7.Location = new Point(1402, 18);
            button7.Name = "button7";
            button7.Size = new Size(195, 33);
            button7.TabIndex = 12;
            button7.Text = "Calculation";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(0, 0, 64);
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.FromArgb(224, 224, 224);
            button6.ImageAlign = ContentAlignment.MiddleLeft;
            button6.Location = new Point(1402, 98);
            button6.Name = "button6";
            button6.Size = new Size(195, 33);
            button6.TabIndex = 11;
            button6.Text = "Save Marks";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // cmbExamType
            // 
            cmbExamType.FormattingEnabled = true;
            cmbExamType.Location = new Point(1169, 97);
            cmbExamType.Name = "cmbExamType";
            cmbExamType.Size = new Size(212, 33);
            cmbExamType.TabIndex = 10;
            // 
            // dtpExamDate
            // 
            dtpExamDate.Location = new Point(849, 97);
            dtpExamDate.Name = "dtpExamDate";
            dtpExamDate.Size = new Size(300, 31);
            dtpExamDate.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(0, 0, 64);
            label3.Location = new Point(36, 56);
            label3.Name = "label3";
            label3.Size = new Size(175, 36);
            label3.TabIndex = 8;
            label3.Text = "Select Class";
            // 
            // dataGridViewMarks
            // 
            dataGridViewMarks.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewMarks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarks.Location = new Point(0, 156);
            dataGridViewMarks.Name = "dataGridViewMarks";
            dataGridViewMarks.RowHeadersWidth = 62;
            dataGridViewMarks.Size = new Size(1630, 731);
            dataGridViewMarks.TabIndex = 7;
            dataGridViewMarks.CellContentClick += dataGridViewMarks_CellContentClick;
            // 
            // cmbClass
            // 
            cmbClass.FormattingEnabled = true;
            cmbClass.Location = new Point(36, 95);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(328, 33);
            cmbClass.TabIndex = 6;
            cmbClass.SelectedIndexChanged += cmbClass_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 0, 64);
            label2.Location = new Point(707, 18);
            label2.Name = "label2";
            label2.Size = new Size(294, 41);
            label2.TabIndex = 5;
            label2.Text = "Search Your Class";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(224, 224, 224);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(0, 0, 64);
            button3.Image = Properties.Resources.Search1;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(370, 95);
            button3.Name = "button3";
            button3.Size = new Size(119, 33);
            button3.TabIndex = 4;
            button3.Text = "Search";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // btnManual
            // 
            btnManual.BackColor = Color.FromArgb(224, 224, 224);
            btnManual.BackgroundImageLayout = ImageLayout.None;
            btnManual.FlatStyle = FlatStyle.Popup;
            btnManual.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnManual.ForeColor = Color.FromArgb(0, 0, 64);
            btnManual.ImageAlign = ContentAlignment.MiddleLeft;
            btnManual.Location = new Point(500, 95);
            btnManual.Name = "btnManual";
            btnManual.Size = new Size(150, 33);
            btnManual.TabIndex = 15;
            btnManual.Text = "Manual Entry";
            btnManual.UseVisualStyleBackColor = false;
            btnManual.Click += btnManual_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(266, 28);
            label1.Name = "label1";
            label1.Size = new Size(466, 36);
            label1.TabIndex = 2;
            label1.Text = "Allama Iqbal Public High School";
            // 
            // panel3
            // 
            panel3.Location = new Point(264, 221);
            panel3.Name = "panel3";
            panel3.Size = new Size(1632, 11);
            panel3.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Controls.Add(button11);
            panel2.Controls.Add(button10);
            panel2.Controls.Add(button9);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button5);
            panel2.Location = new Point(-1, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(261, 981);
            panel2.TabIndex = 8;
            panel2.Paint += panel2_Paint_1;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(0, 0, 64);
            button11.BackgroundImageLayout = ImageLayout.None;
            button11.FlatStyle = FlatStyle.Popup;
            button11.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.White;
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.ImageAlign = ContentAlignment.MiddleLeft;
            button11.Location = new Point(0, 402);
            button11.Name = "button11";
            button11.Size = new Size(225, 29);
            button11.TabIndex = 18;
            button11.Text = "Admissions ";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(0, 0, 64);
            button10.BackgroundImageLayout = ImageLayout.None;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button10.ForeColor = Color.White;
            button10.Image = Properties.Resources.attend;
            button10.ImageAlign = ContentAlignment.MiddleLeft;
            button10.Location = new Point(0, 367);
            button10.Name = "button10";
            button10.Size = new Size(225, 29);
            button10.TabIndex = 13;
            button10.Text = "Attendance";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(0, 0, 64);
            button9.BackgroundImageLayout = ImageLayout.None;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button9.ForeColor = Color.White;
            button9.Image = Properties.Resources.Attendence_Logo;
            button9.ImageAlign = ContentAlignment.MiddleLeft;
            button9.Location = new Point(0, 332);
            button9.Name = "button9";
            button9.Size = new Size(225, 29);
            button9.TabIndex = 9;
            button9.Text = "Teachers    ";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(0, 0, 64);
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.White;
            button8.Image = Properties.Resources.Staff__1_;
            button8.ImageAlign = ContentAlignment.MiddleLeft;
            button8.Location = new Point(0, 297);
            button8.Name = "button8";
            button8.Size = new Size(225, 29);
            button8.TabIndex = 8;
            button8.Text = "Students    ";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
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
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 0, 64);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.Logout__1_;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(4, 910);
            button1.Name = "button1";
            button1.Size = new Size(195, 41);
            button1.TabIndex = 6;
            button1.Text = "Logout";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            button4.Location = new Point(0, 227);
            button4.Name = "button4";
            button4.Size = new Size(225, 29);
            button4.TabIndex = 5;
            button4.Text = "Search      ";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 0, 64);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.FromArgb(255, 128, 0);
            button2.Image = Properties.Resources.Attendence_Logo;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 262);
            button2.Name = "button2";
            button2.Size = new Size(225, 29);
            button2.TabIndex = 4;
            button2.Text = "Marks       ";
            button2.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(0, 0, 64);
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Image = Properties.Resources.Home1_removebg_preview__1__remov__1_;
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(-1, 192);
            button5.Name = "button5";
            button5.Size = new Size(226, 29);
            button5.TabIndex = 3;
            button5.Text = "Dashboard       ";
            button5.TextAlign = ContentAlignment.MiddleRight;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1924, 994);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarks).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button button3;
        private ComboBox cmbClass;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private DataGridView dataGridViewMarks;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button4;
        private Button button2;
        private Button button5;
        private ComboBox cmbExamType;
        private DateTimePicker dtpExamDate;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button12;
        private Button button11;
        private Button btnManual;
    }
}
