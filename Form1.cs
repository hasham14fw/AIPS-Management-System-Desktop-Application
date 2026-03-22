using MongoDB.Bson;
using MongoDB.Driver;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;

namespace AIPS_Portal
{
    public partial class Form1 : Form
    {
        private IMongoClient client;
        private IMongoDatabase database;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new MongoClient(Config.MongoConnectionString);
            database = client.GetDatabase("AIPS");
            cmbExamType.Items.AddRange(new string[]
               {"January", "February", "March", "April", "May", "June","July", "August", "September", "October", "November", "December","Final"
            });

            List<string> classList = new List<string>();
            string[] sections = { "A", "B", "C", "D" };

            // NUR and PREP remain as-is
            foreach (var section in sections)
            {
                classList.Add($"NUR {section}");
                classList.Add($"PREP {section}");
            }

            // 1 to 10
            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            foreach (var number in numbers)
            {
                foreach (var section in sections)
                {
                    classList.Add($"{number} {section}");
                }
            }

            cmbClass.Items.AddRange(classList.ToArray());


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Students nextPage = new Students();
            nextPage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard nextPage = new Dashboard();
            nextPage.Show();
            this.Hide();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == null)
            {
                MessageBox.Show("Please select a class before loading students.");
                return;
            }

            string selectedClass = cmbClass.SelectedItem.ToString();

            var studentsCollection = database.GetCollection<BsonDocument>("students");
            var filter = Builders<BsonDocument>.Filter.Eq("classes", selectedClass);
            var students = studentsCollection.Find(filter).ToList();

            dataGridViewMarks.Rows.Clear();
            dataGridViewMarks.Columns.Clear();

            // Add columns
            dataGridViewMarks.Columns.Add("reg", "Reg");
            dataGridViewMarks.Columns.Add("name", "Name");
            for (int i = 1; i <= 10; i++)
            {
                dataGridViewMarks.Columns.Add($"Subject{i}", $"S{i}");
            }
            dataGridViewMarks.Columns.Add("TotalMax", "T M");
            dataGridViewMarks.Columns.Add("TotalObt", "O M");
            dataGridViewMarks.Columns.Add("Percentage", "Per");
            dataGridViewMarks.Columns.Add("Position", "Pos");

            // Make RegNo and Name editable so users can add manual entries
            dataGridViewMarks.Columns["reg"].ReadOnly = false;
            dataGridViewMarks.Columns["name"].ReadOnly = false;

            // Add row for Subject Names
            dataGridViewMarks.Rows.Add();
            dataGridViewMarks.Rows[0].Cells[0].Value = "Subject";
            dataGridViewMarks.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;

            // Add row for Total Marks
            dataGridViewMarks.Rows.Add();
            dataGridViewMarks.Rows[1].Cells[0].Value = "Total";
            dataGridViewMarks.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;

            // Add student rows
            int rowIndex = 2;
            foreach (var student in students)
            {
                dataGridViewMarks.Rows.Add();
                dataGridViewMarks.Rows[rowIndex].Cells[0].Value = student["reg"].AsString;
                dataGridViewMarks.Rows[rowIndex].Cells[1].Value = student["name"].AsString;
                rowIndex++;
            }

            MessageBox.Show($"Loaded {students.Count} students of class {selectedClass}. Now you can enter marks in front of each student name.");
            // Adjust column widths: keep Name wide, others narrow
            foreach (DataGridViewColumn column in dataGridViewMarks.Columns)
            {
                if (column.Name == "name")
                {
                    column.Width = 200; // keep Name readable
                }
                else if (column.Name == "reg")
                {
                    column.Width = 110;
                }
                else
                {
                    column.Width = 95; // narrow for all other columns
                }
            }

        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            dataGridViewMarks.Rows.Clear();
            dataGridViewMarks.Columns.Clear();

            // Add columns
            dataGridViewMarks.Columns.Add("reg", "Reg");
            dataGridViewMarks.Columns.Add("name", "Name");
            for (int i = 1; i <= 10; i++)
            {
                dataGridViewMarks.Columns.Add($"Subject{i}", $"S{i}");
            }
            dataGridViewMarks.Columns.Add("TotalMax", "T M");
            dataGridViewMarks.Columns.Add("TotalObt", "O M");
            dataGridViewMarks.Columns.Add("Percentage", "Per");
            dataGridViewMarks.Columns.Add("Position", "Pos");

            // Make RegNo and Name editable for manual entry
            dataGridViewMarks.Columns["reg"].ReadOnly = false;
            dataGridViewMarks.Columns["name"].ReadOnly = false;

            // Add row for Subject Names
            dataGridViewMarks.Rows.Add();
            dataGridViewMarks.Rows[0].Cells[0].Value = "Subject";
            dataGridViewMarks.Rows[0].DefaultCellStyle.BackColor = Color.LightGray;

            // Add row for Total Marks
            dataGridViewMarks.Rows.Add();
            dataGridViewMarks.Rows[1].Cells[0].Value = "Total";
            dataGridViewMarks.Rows[1].DefaultCellStyle.BackColor = Color.LightGray;

            MessageBox.Show("Grid initialized for manual entry. You can now add students' registration, name, and marks. (New rows can be added at the bottom).");
            
            // Adjust column widths: keep Name wide, others narrow
            foreach (DataGridViewColumn column in dataGridViewMarks.Columns)
            {
                if (column.Name == "name")
                {
                    column.Width = 200; // keep Name readable
                }
                else if (column.Name == "reg")
                {
                    column.Width = 110;
                }
                else
                {
                    column.Width = 95; // narrow for all other columns
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == null || cmbExamType.SelectedItem == null)
            {
                MessageBox.Show("Please select both Class and Exam Type before saving.");
                return;
            }

            string selectedClass = cmbClass.SelectedItem.ToString();
            string examType = cmbExamType.SelectedItem.ToString();
            DateTime examDate = dtpExamDate.Value;

            var resultsCollection = database.GetCollection<BsonDocument>("detailedResults");

            List<string> subjectNames = new List<string>();
            for (int col = 2; col < 12; col++)
            {
                var subject = dataGridViewMarks.Rows[0].Cells[col].Value?.ToString();
                subjectNames.Add(string.IsNullOrEmpty(subject) ? $"S{col - 1}" : subject);
            }

            Dictionary<string, int> totalMarksPerSubject = new Dictionary<string, int>();
            int totalMaxSum = 0;
            for (int col = 2; col < 12; col++)
            {
                int totalMark = int.TryParse(dataGridViewMarks.Rows[1].Cells[col].Value?.ToString(), out int tm) ? tm : 0;
                if (totalMark > 0)
                {
                    totalMarksPerSubject[subjectNames[col - 2]] = totalMark;
                    totalMaxSum += totalMark;
                }
            }

            for (int row = 2; row < dataGridViewMarks.Rows.Count; row++)
            {
                string rollNo = dataGridViewMarks.Rows[row].Cells[0].Value?.ToString();
                string name = dataGridViewMarks.Rows[row].Cells[1].Value?.ToString();
                if (string.IsNullOrEmpty(rollNo) || string.IsNullOrEmpty(name))
                    continue;

                var marks = new BsonDocument();
                int totalObtSum = 0;
                int totalPossibleMarks = 0;

                for (int col = 2; col < 12; col++)
                {
                    string subject = subjectNames[col - 2];

                    // Only consider if total marks for subject is defined
                    if (totalMarksPerSubject.ContainsKey(subject))
                    {
                        int mark = int.TryParse(dataGridViewMarks.Rows[row].Cells[col].Value?.ToString(), out int m) ? m : 0;

                        // Only store if mark is entered
                        if (mark > 0)
                        {
                            marks[subject] = mark;
                            totalObtSum += mark;
                        }

                        totalPossibleMarks += totalMarksPerSubject[subject];
                    }
                }

                double percentage = totalPossibleMarks > 0 ? (totalObtSum / (double)totalPossibleMarks) * 100 : 0;

                var resultDoc = new BsonDocument
        {
            { "name", name },
            { "reg", rollNo },
            { "examType", examType },
            { "examDate", examDate },
            { "class", selectedClass },
            { "marks", marks },
            { "totalMarksPerSubject", new BsonDocument(totalMarksPerSubject) },
            { "totalMaxSum", totalPossibleMarks },
            { "totalObtainedSum", totalObtSum },
            { "percentage", percentage },
            { "position", dataGridViewMarks.Rows[row].Cells[15].Value?.ToString() ?? "" }
        };

                resultsCollection.InsertOne(resultDoc);
            }

            MessageBox.Show("Results saved successfully to the database!");
        }


        private void button7_Click(object sender, EventArgs e)
        {
            {
                // Validate subject names and total marks row
                List<string> subjectNames = new List<string>();
                for (int col = 2; col < 12; col++)
                {
                    var subject = dataGridViewMarks.Rows[0].Cells[col].Value?.ToString();
                    subjectNames.Add(string.IsNullOrEmpty(subject) ? $"Subject{col - 1}" : subject);
                }

                Dictionary<string, int> totalMarksPerSubject = new Dictionary<string, int>();
                int totalMaxSum = 0;
                for (int col = 2; col < 12; col++)
                {
                    int totalMark = int.TryParse(dataGridViewMarks.Rows[1].Cells[col].Value?.ToString(), out int tm) ? tm : 0;
                    totalMarksPerSubject[subjectNames[col - 2]] = totalMark;
                    totalMaxSum += totalMark;
                }

                // Calculate for each student row
                for (int row = 2; row < dataGridViewMarks.Rows.Count; row++)
                {
                    int totalObtSum = 0;
                    for (int col = 2; col < 12; col++)
                    {
                        int mark = int.TryParse(dataGridViewMarks.Rows[row].Cells[col].Value?.ToString(), out int m) ? m : 0;
                        totalObtSum += mark;
                    }

                    double percentage = totalMaxSum > 0 ? (totalObtSum / (double)totalMaxSum) * 100 : 0;

                    // Update GridView columns for teacher to verify
                    dataGridViewMarks.Rows[row].Cells[12].Value = totalMaxSum;
                    dataGridViewMarks.Rows[row].Cells[13].Value = totalObtSum;
                    dataGridViewMarks.Rows[row].Cells[14].Value = $"{percentage:F2}%";
                }

                // Calculate position
                var studentScopes = new List<Tuple<int, int>>(); // row index, total marks
                for (int row = 2; row < dataGridViewMarks.Rows.Count; row++)
                {
                    string name = dataGridViewMarks.Rows[row].Cells[1].Value?.ToString();
                    if (string.IsNullOrWhiteSpace(name)) continue;

                    if (int.TryParse(dataGridViewMarks.Rows[row].Cells[13].Value?.ToString(), out int obt))
                    {
                        studentScopes.Add(new Tuple<int, int>(row, obt));
                    }
                }

                // Sort marks ascending initially, later used in descending context
                var ranked = studentScopes.OrderByDescending(s => s.Item2).ToList();
                int currentRank = 1;
                for (int i = 0; i < ranked.Count; i++)
                {
                    if (i > 0 && ranked[i].Item2 < ranked[i - 1].Item2)
                    {
                        currentRank = i + 1;
                    }
                    string posText = currentRank.ToString();
                    if (posText.EndsWith("1") && !posText.EndsWith("11")) posText += "st";
                    else if (posText.EndsWith("2") && !posText.EndsWith("12")) posText += "nd";
                    else if (posText.EndsWith("3") && !posText.EndsWith("13")) posText += "rd";
                    else posText += "th";

                    dataGridViewMarks.Rows[ranked[i].Item1].Cells[15].Value = posText;
                }

                MessageBox.Show("Totals, percentages, and positions calculated successfully.\nPlease review before saving.");
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }

        private void dataGridViewMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbClass.Text))
                {
                    MessageBox.Show("Please select a class first.");
                    return;
                }

                string selectedClass = cmbClass.Text.Trim();
                string examType = cmbExamType.Text.Trim();
                string baseFolder = @"D:\AIPS Result";
                string classFolder = Path.Combine(baseFolder, selectedClass);
                if (!Directory.Exists(classFolder)) Directory.CreateDirectory(classFolder);

                string pdfPath = Path.Combine(classFolder, $"ResultCards_{selectedClass}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

                // Subject names from first row
                List<string> subjectNames = new List<string>();
                for (int col = 2; col < 12; col++)
                {
                    var subject = dataGridViewMarks.Rows[0].Cells[col].Value?.ToString();
                    subjectNames.Add(string.IsNullOrEmpty(subject) ? $"Sub{col - 1}" : subject);
                }

                // Initialize PDF Document
                // A4 size: 595 x 842 points
                var doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();

                // Create a table with 1 column to fit 2 cards stacked vertically per page
                var pdfTable = new iTextSharp.text.pdf.PdfPTable(1);
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;

                int cardsProcessed = 0;

                // Loop students
                for (int row = 2; row < dataGridViewMarks.Rows.Count; row++)
                {
                    string reg = dataGridViewMarks.Rows[row].Cells[0].Value?.ToString();
                    string name = dataGridViewMarks.Rows[row].Cells[1].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(reg) || string.IsNullOrWhiteSpace(name))
                        continue;

                    // Fetch data
                    string totalMaxStr = dataGridViewMarks.Rows[row].Cells[12].Value?.ToString();
                    string totalObtStr = dataGridViewMarks.Rows[row].Cells[13].Value?.ToString();
                    string percentageStr = dataGridViewMarks.Rows[row].Cells[14].Value?.ToString() ?? "0%";
                    string positionStr = dataGridViewMarks.Rows[row].Cells[15].Value?.ToString() ?? "-";

                    int.TryParse(totalMaxStr, out int totalMax);
                    int.TryParse(totalObtStr, out int totalObt);

                    // --- GENERATE CARD IMAGE ---
                    // High resolution canvas
                    int width = 900;
                    
                    int activeSubjects = 0;
                    for (int col = 2; col < 12; col++)
                    {
                        string tMarkStr = dataGridViewMarks.Rows[1].Cells[col].Value?.ToString();
                        string oMarkStr = dataGridViewMarks.Rows[row].Cells[col].Value?.ToString();
                        int.TryParse(tMarkStr, out int tM);
                        int.TryParse(oMarkStr, out int oM);
                        if (tM == 0 && oM == 0 && string.IsNullOrEmpty(oMarkStr)) continue;
                        activeSubjects++;
                    }
                    
                    // Maintain a consistent bottom padding by matching table layout math:
                    // tableY(260) + headerRow(45) + dataRows(45*N) + gap(20) + cardFooterHeight(80) + padding(50)
                    int height = 260 + 45 + (activeSubjects * 45) + 20 + 80 + 50;

                    using (Bitmap bmp = new Bitmap(width, height))
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                        g.Clear(Color.White);

                        // 1. Decorative Border
                        int borderThickness = 10;
                        Color primaryColor = Color.FromArgb(0, 51, 102); // Deep Navy
                        Color accentColor = Color.FromArgb(255, 102, 0); // Orange detail
                        
                        using (Pen borderPen = new Pen(primaryColor, borderThickness))
                        {
                            g.DrawRectangle(borderPen, 0, 0, width, height);
                        }

                        // 2. Beautiful Header Background with Gradient
                        Rectangle headerRect = new Rectangle(borderThickness, borderThickness, width - (2 * borderThickness), 160);
                        using (LinearGradientBrush headerBrush = new LinearGradientBrush(headerRect, primaryColor, Color.RoyalBlue, 45f))
                        {
                            g.FillRectangle(headerBrush, headerRect);
                        }

                        // 3. School Name & Title
                        Font titleFont = new Font("Times New Roman", 22, FontStyle.Bold);
                        Font subtitleFont = new Font("Times New Roman", 16, FontStyle.Regular);
                        Font infoFont = new Font("Times New Roman", 14, FontStyle.Bold);
                        Font tableHeaderFont = new Font("Times New Roman", 13, FontStyle.Bold);
                        Font tableRowFont = new Font("Times New Roman", 13, FontStyle.Regular);
                        Font footerFont = new Font("Times New Roman", 9, FontStyle.Italic);

                        // 4. Logo
                        int logoCircleX = 15;
                        int logoCircleY = 15;
                        int logoCircleSize = 140;
                        int logoImageSize = 140; // Same size as circle
                        int logoOffset = (logoCircleSize - logoImageSize) / 2;

                        g.FillEllipse(Brushes.White, logoCircleX, logoCircleY, logoCircleSize, logoCircleSize);

                        string logoPath = Path.Combine(Application.StartupPath, "logo.png");
                        if (File.Exists(logoPath))
                        {
                            using (Image logo = Image.FromFile(logoPath))
                            {
                                g.DrawImage(logo, logoCircleX + logoOffset, logoCircleY + logoOffset, logoImageSize, logoImageSize);
                            }
                        }

                        // 3. School Name & Title (Adjusted to avoid overlapping with Logo)
                        // Logo ends at logoCircleX + logoCircleSize = 155. Let's start text area after that.
                        float textStartX = 170;
                        float availableWidth = width - textStartX;

                        SizeF titleSize = g.MeasureString("Allama Iqbal Public High School", titleFont);
                        float titleX = textStartX + (availableWidth - titleSize.Width) / 2;
                        g.DrawString("Allama Iqbal Public High School", titleFont, Brushes.White, new PointF(titleX, 50));
                        
                        SizeF subSize = g.MeasureString("ACADEMIC RESULT CARD", subtitleFont);
                        float subX = textStartX + (availableWidth - subSize.Width) / 2;
                        g.DrawString("ACADEMIC RESULT CARD", subtitleFont, Brushes.LightGray, new PointF(subX, 125));

                        // 5. Student Info Bar (Below Header)
                        int infoBarY = 180;
                        g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), borderThickness, infoBarY, width - (2 * borderThickness), 60);
                        
                        Brush infoBrush = Brushes.Black;
                        g.DrawString($"Name: {name}", infoFont, infoBrush, 50, infoBarY + 15);
                        g.DrawString($"Reg No: {reg}", infoFont, infoBrush, 400, infoBarY + 15);
                        g.DrawString($"Class: {selectedClass}", infoFont, infoBrush, 650, infoBarY + 15);

                        // 6. Styled Table
                        int tableY = 260;
                        int col1W = 400; // Subject
                        int col2W = 200; // Total
                        int col3W = 200; // Obtained
                        int rowH = 45;
                        int tableX = 50;

                        // Table Header
                        Rectangle headerRowRect = new Rectangle(tableX, tableY, col1W + col2W + col3W, rowH);
                        g.FillRectangle(new SolidBrush(primaryColor), headerRowRect);
                        
                        StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                        StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

                        g.DrawString("SUBJECT", tableHeaderFont, Brushes.White, new Rectangle(tableX, tableY, col1W, rowH), leftFormat);
                        g.DrawString("TOTAL", tableHeaderFont, Brushes.White, new Rectangle(tableX + col1W, tableY, col2W, rowH), centerFormat);
                        g.DrawString("OBTAINED", tableHeaderFont, Brushes.White, new Rectangle(tableX + col1W + col2W, tableY, col3W, rowH), centerFormat);

                        int currentY = tableY + rowH;

                        // Table Rows
                        for (int col = 2; col < 12; col++)
                        {
                            string subject = subjectNames[col - 2];
                            string tMarkStr = dataGridViewMarks.Rows[1].Cells[col].Value?.ToString();
                            string oMarkStr = dataGridViewMarks.Rows[row].Cells[col].Value?.ToString();

                            int.TryParse(tMarkStr, out int tM);
                            int.TryParse(oMarkStr, out int oM);
                            
                            // Only show if there are marks
                            if (tM == 0 && oM == 0 && string.IsNullOrEmpty(oMarkStr)) continue;

                            if (col % 2 != 0)
                            {
                                g.FillRectangle(new SolidBrush(Color.AliceBlue), tableX, currentY, col1W + col2W + col3W, rowH);
                            }

                            g.DrawString(subject, tableRowFont, Brushes.Black, new Rectangle(tableX + 10, currentY, col1W - 10, rowH), leftFormat);
                            g.DrawString(tM.ToString(), tableRowFont, Brushes.Black, new Rectangle(tableX + col1W, currentY, col2W, rowH), centerFormat);
                            g.DrawString(oM.ToString(), tableRowFont, Brushes.Black, new Rectangle(tableX + col1W + col2W, currentY, col3W, rowH), centerFormat);

                            g.DrawLine(Pens.LightGray, tableX, currentY + rowH, tableX + col1W + col2W + col3W, currentY + rowH);

                            currentY += rowH;
                        }

                        // Add Navy Blue Table Border and Column Separators
                        using (Pen tableBorderPen = new Pen(primaryColor, 2))
                        {
                            g.DrawRectangle(tableBorderPen, tableX, tableY, col1W + col2W + col3W, currentY - tableY);
                            g.DrawLine(tableBorderPen, tableX + col1W, tableY, tableX + col1W, currentY);
                            g.DrawLine(tableBorderPen, tableX + col1W + col2W, tableY, tableX + col1W + col2W, currentY);
                        }

                        // 7. Footer / Summary
                        int footerY = currentY + 20;
                        int cardFooterHeight = 80;
                        Rectangle footerRect = new Rectangle(tableX, footerY, col1W + col2W + col3W, cardFooterHeight);
                        g.FillRectangle(new SolidBrush(Color.Lavender), footerRect);
                        g.DrawRectangle(new Pen(primaryColor, 2), footerRect);

                        float halfWidth = (col1W + col2W + col3W) / 2f;
                        float halfHeight = cardFooterHeight / 2f;
                        
                        StringFormat leftAlign = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };
                        StringFormat rightAlign = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
                        float padding = 20f;
                        
                        // Top line: Total Marks (Left), Obtained Marks (Right)
                        g.DrawString($"Total Marks: {totalMax}", infoFont, Brushes.Black, new RectangleF(tableX + padding, footerY, halfWidth - padding, halfHeight), leftAlign);
                        g.DrawString($"Obtained Marks: {totalObt}", infoFont, Brushes.Black, new RectangleF(tableX + halfWidth, footerY, halfWidth - padding, halfHeight), rightAlign);
                        
                        // Bottom line: Percentage (Left), Position (Right)
                        g.DrawString($"Percentage: {percentageStr}", infoFont, Brushes.DarkGreen, new RectangleF(tableX + padding, footerY + halfHeight, halfWidth - padding, halfHeight), leftAlign);
                        g.DrawString($"Position: {positionStr}", infoFont, Brushes.Maroon, new RectangleF(tableX + halfWidth, footerY + halfHeight, halfWidth - padding, halfHeight), rightAlign);

                        // Footer Text
                        string footerText = "Powered By Allama Iqbal Public Schools.";
                        g.DrawString(footerText, footerFont, Brushes.Gray, 30, height - 25);

                        // --- ADD TO PDF ---
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bmp.Save(ms, ImageFormat.Png);
                            iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(ms.ToArray());
                            
                            // Scale Image to Fit 2 per Page
                            // A4 Width = 595, Height = 842
                            // Margins 10 results in 575 x 822 printable area
                            // We want max height approx 400-410 to fit two.
                            
                            float maxWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                            float maxHeight = (doc.PageSize.Height - doc.TopMargin - doc.BottomMargin) / 2.05f; // Slightly less than half to ensure fit

                            pdfImage.ScaleToFit(maxWidth, maxHeight);

                            // Add to table cell
                            iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(pdfImage);
                            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
                            cell.Padding = 5f;
                            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;

                            pdfTable.AddCell(cell);
                        }
                    } // End Graphics/Bitmap

                    cardsProcessed++;
                }

                // If last page has one card, add empty cell to complete logic if needed (not needed for 1 col table but good for consistency/safety)
                
                doc.Add(pdfTable);
                doc.Close();

                // --- GENERATE TEACHER RESULT PNG ---
                string teacherImagePath = Path.Combine(classFolder, $"TeacherResult_{selectedClass}_{DateTime.Now:yyyyMMdd_HHmmss}.png");

                // Calculate Averages and Count Active Subjects
                var subjectStats = new Dictionary<string, (double TotalMarks, int StudentCount)>();
                int activeSubjectCount = 0;
                
                foreach (var subject in subjectNames)
                {
                    if (!subjectStats.ContainsKey(subject))
                        subjectStats[subject] = (0, 0);
                }

                for (int r = 2; r < dataGridViewMarks.Rows.Count; r++)
                {
                    for (int c = 2; c < 12; c++)
                    {
                        if (c - 2 < subjectNames.Count)
                        {
                            string subject = subjectNames[c - 2];
                            var cellVal = dataGridViewMarks.Rows[r].Cells[c].Value;
                            if (cellVal != null && double.TryParse(cellVal.ToString(), out double m))
                            {
                                var current = subjectStats[subject];
                                subjectStats[subject] = (current.TotalMarks + m, current.StudentCount + 1);
                            }
                        }
                    }
                }

                // Count active subjects for dynamic height
                foreach (var subject in subjectNames)
                {
                    if (subjectStats[subject].StudentCount > 0)
                        activeSubjectCount++;
                }

                // Layout Dimensions
                int outerMargin = 30; // Space outer the border
                int contentWidth = 900;
                int topSectionHeight = 260; // Header(160) + Spacing + InfoBar + Spacing(to 260)
                int tableHeaderHeight = 50;
                int rowHeight = 50;
                int footerHeight = 60; // Space for "Powered By"

                int tableHeight = tableHeaderHeight + (activeSubjectCount * rowHeight);
                int contentHeight = topSectionHeight + tableHeight + footerHeight;

                int imgWidth = contentWidth + (2 * outerMargin);
                int imgHeight = contentHeight + (2 * outerMargin);
                
                using (Bitmap tBmp = new Bitmap(imgWidth, imgHeight))
                using (Graphics tg = Graphics.FromImage(tBmp))
                {
                    tg.SmoothingMode = SmoothingMode.HighQuality;
                    tg.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    tg.Clear(Color.White);

                    // Apply Margin Offset
                    tg.TranslateTransform(outerMargin, outerMargin);

                    // 1. Decorative Border
                    int borderThickness = 10;
                    Color primaryColor = Color.FromArgb(0, 51, 102); // Deep Navy
                    
                    using (Pen borderPen = new Pen(primaryColor, borderThickness))
                    {
                        // Draw Border around content
                        tg.DrawRectangle(borderPen, 0, 0, contentWidth, contentHeight);
                    }

                    // 2. Header Background (Dark Navy Gradient)
                    Rectangle tHeaderRect = new Rectangle(borderThickness, borderThickness, contentWidth - (2 * borderThickness), 160);
                    using (LinearGradientBrush headerBrush = new LinearGradientBrush(tHeaderRect, primaryColor, Color.RoyalBlue, 45f))
                    {
                        tg.FillRectangle(headerBrush, tHeaderRect);
                    }

                    // 3. Fonts
                    Font titleFont = new Font("Times New Roman", 26, FontStyle.Bold);
                    Font subtitleFont = new Font("Times New Roman", 22, FontStyle.Bold); 
                    Font infoFont = new Font("Times New Roman", 15, FontStyle.Bold);
                    Font tableHeaderFont = new Font("Times New Roman", 14, FontStyle.Bold);
                    Font tableRowFont = new Font("Times New Roman", 14, FontStyle.Regular);

                    // 4. Logo (Left Side)
                    int logoCircleX = 20;
                    int logoCircleY = 20;
                    int logoCircleSize = 140;
                    int logoImageSize = 140;
                    int logoOffset = (logoCircleSize - logoImageSize) / 2;

                    tg.FillEllipse(Brushes.White, logoCircleX, logoCircleY, logoCircleSize, logoCircleSize);
                    string logoPath = Path.Combine(Application.StartupPath, "logo.png");
                    if (File.Exists(logoPath))
                    {
                        using (Image logo = Image.FromFile(logoPath))
                        {
                            tg.DrawImage(logo, logoCircleX + logoOffset, logoCircleY + logoOffset, logoImageSize, logoImageSize);
                        }
                    }

                    // 5. School Name & Title
                    float textStartX = 180;
                    float availableWidth = contentWidth - textStartX;

                    SizeF titleSize = tg.MeasureString("Allama Iqbal Public High School", titleFont);
                    float titleX = textStartX + (availableWidth - titleSize.Width) / 2;
                    tg.DrawString("Allama Iqbal Public High School", titleFont, Brushes.White, new PointF(titleX, 30));

                    Color headingColor = Color.FromArgb(255, 255, 255); // White
                    SizeF subSize = tg.MeasureString("TEACHER RESULT REPORT", subtitleFont);
                    float subX = textStartX + (availableWidth - subSize.Width) / 2;
                    
                    tg.DrawString("TEACHER RESULT REPORT", subtitleFont, new SolidBrush(headingColor), new PointF(subX, 100));

                    // 6. Info Bar
                    int infoBarY = 180;
                    tg.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), borderThickness, infoBarY, contentWidth - (2 * borderThickness), 50);

                    string infoText = $"Class: {selectedClass}   |   Exam: {examType}   |   Date: {DateTime.Now:dd-MMM-yyyy}";
                    SizeF infoSize = tg.MeasureString(infoText, infoFont);
                    float infoX = (contentWidth - infoSize.Width) / 2;
                    tg.DrawString(infoText, infoFont, Brushes.Black, infoX, infoBarY + 12);

                    // 7. Table Setup
                    int tableY = 260; // topSectionHeight
                    int col1W = 500; // Subject Name
                    int col2W = 300; // Average
                    int tableX = 50;
                    
                    StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    StringFormat leftFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center };

                    // Table Header
                    Rectangle headerRowRect = new Rectangle(tableX, tableY, col1W + col2W, tableHeaderHeight);
                    tg.FillRectangle(new SolidBrush(primaryColor), headerRowRect);

                    tg.DrawString("SUBJECT", tableHeaderFont, Brushes.White, new Rectangle(tableX + 20, tableY, col1W - 20, tableHeaderHeight), leftFormat);
                    tg.DrawString("CLASS AVERAGE", tableHeaderFont, Brushes.White, new Rectangle(tableX + col1W, tableY, col2W, tableHeaderHeight), centerFormat);

                    // Table Rows
                    int currentY = tableY + tableHeaderHeight;
                    using (Pen tablePen = new Pen(primaryColor, 1))
                    {
                        foreach (var subject in subjectNames)
                        {
                            var stats = subjectStats.ContainsKey(subject) ? subjectStats[subject] : (0, 0);
                            
                            // Skip empty subjects
                            if (stats.StudentCount == 0) continue;

                            double avg = stats.StudentCount > 0 ? stats.TotalMarks / stats.StudentCount : 0;

                            // Determine Row Color
                            Brush rowBrush = Brushes.White;
                            Brush textBrush = Brushes.Black;

                            if (avg > 85) rowBrush = new SolidBrush(Color.FromArgb(200, 255, 200));
                            else if (avg < 70) rowBrush = new SolidBrush(Color.FromArgb(255, 200, 200));

                            // Background
                            tg.FillRectangle(rowBrush, tableX, currentY, col1W + col2W, rowHeight);
                            
                            // Borders
                            tg.DrawRectangle(tablePen, tableX, currentY, col1W + col2W, rowHeight);
                            tg.DrawLine(tablePen, tableX + col1W, currentY, tableX + col1W, currentY + rowHeight);

                            tg.DrawString(subject, tableRowFont, textBrush, new Rectangle(tableX + 20, currentY, col1W - 20, rowHeight), leftFormat);
                            tg.DrawString(avg.ToString("F2") + "%", tableRowFont, textBrush, new Rectangle(tableX + col1W, currentY, col2W, rowHeight), centerFormat);

                            currentY += rowHeight;
                        }
                    }
                    
                    // Final Bottom Line for table
                    tg.DrawLine(new Pen(primaryColor, 2), tableX, currentY, tableX + col1W + col2W, currentY);

                    // Footer Text
                    tg.DrawString("Powered By AIPS.", new Font("Times New Roman", 10, FontStyle.Italic), Brushes.Gray, 30, contentHeight - 30);

                    // Save as PNG
                    tBmp.Save(teacherImagePath, ImageFormat.Png);
                }

                MessageBox.Show($"Success! generated :\n1. Student Cards: {pdfPath}\n2. Teacher Result: {teacherImagePath}");
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", classFolder);
                }
                catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
}

