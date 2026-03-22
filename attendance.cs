using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Globalization;
namespace AIPS_Portal
{
    public partial class attendance : Form
    {
        private readonly IMongoCollection<Attendance> _attendanceCollection;

        public attendance()
        {
            InitializeComponent();
            var client = new MongoClient(Config.MongoConnectionString);
            var database = client.GetDatabase("AIPS");         // replace with your DB name
            _attendanceCollection = database.GetCollection<Attendance>("attendances"); // collection name
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard nextPage = new Dashboard();
            nextPage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Students nextPage = new Students();
            nextPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nextPage = new Form1();
            nextPage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string reg = txtReg.Text.Trim();
            string className = cmbClass.Text.Trim();
            string selectedMonth = cmbMonth.Text.Trim();
            DateTime date = dateTimePicker1.Value.Date;

            DataTable dt = new DataTable();

            // filter by reg or class if entered
            var filter = Builders<Attendance>.Filter.Empty;

            if (!string.IsNullOrEmpty(reg))
                filter &= Builders<Attendance>.Filter.Eq(a => a.Reg, reg);

            if (!string.IsNullOrEmpty(className))
                filter &= Builders<Attendance>.Filter.Eq(a => a.Classes, className);

            var results = await _attendanceCollection.Find(filter).ToListAsync();

            // parse dates safely
            var parsedResults = results.Where(r => r.Date != DateTime.MinValue).ToList();

            // Case 1: reg + date
            if (!string.IsNullOrEmpty(reg) && string.IsNullOrEmpty(selectedMonth))
            {
                var result = parsedResults.FirstOrDefault(r => r.Reg == reg && r.Date.Date == date);

                dt.Columns.Add("Reg");
                dt.Columns.Add("Name");
                dt.Columns.Add("Date");
                dt.Columns.Add("Status");

                if (result != null)
                    dt.Rows.Add(result.Reg, result.Name, result.Date.ToString("dd-MMM-yyyy"), result.Status ? "✓" : "✗");
            }
            // Case 2: reg + month
            else if (!string.IsNullOrEmpty(reg) && !string.IsNullOrEmpty(selectedMonth))
            {
                int month = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month;
                int year = date.Year;

                var filtered = parsedResults.Where(r => r.Reg == reg && r.Date.Month == month && r.Date.Year == year)
                                            .OrderBy(r => r.Date);

                dt.Columns.Add("Date");
                dt.Columns.Add("Status");

                foreach (var record in filtered)
                    dt.Rows.Add(record.Date.ToString("dd-MMM-yyyy"), record.Status ? "✓" : "✗");
            }
            // Case 3: class + date
            else if (!string.IsNullOrEmpty(className) && string.IsNullOrEmpty(selectedMonth))
            {
                var filtered = parsedResults.Where(r => r.Classes == className && r.Date.Date == date);

                dt.Columns.Add("Reg");
                dt.Columns.Add("Name");
                dt.Columns.Add("Status");

                foreach (var record in filtered)
                    dt.Rows.Add(record.Reg, record.Name, record.Status ? "✓" : "✗");
            }
            // Case 4: class + month
            else if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(selectedMonth))
            {
                int month = DateTime.ParseExact(selectedMonth, "MMMM", CultureInfo.InvariantCulture).Month;
                int year = date.Year;
                var daysInMonth = DateTime.DaysInMonth(year, month);

                dt.Columns.Add("Reg");
                dt.Columns.Add("Name");
                for (int d = 1; d <= daysInMonth; d++)
                    dt.Columns.Add(d.ToString());

                var filtered = parsedResults.Where(r => r.Classes == className && r.Date.Month == month && r.Date.Year == year);

                var students = filtered.GroupBy(r => new { r.Reg, r.Name });

                foreach (var student in students)
                {
                    var row = dt.NewRow();
                    row["Reg"] = student.Key.Reg;
                    row["Name"] = student.Key.Name;

                    foreach (var record in student)
                    {
                        int day = record.Date.Day;
                        row[day.ToString()] = record.Status ? "✓" : "✗";
                    }

                    dt.Rows.Add(row);
                }
            }

            dataGridView1.DataSource = dt;
            // Apply formatting after binding
            if (dataGridView1.Columns.Contains("reg"))
            {
                dataGridView1.Columns["reg"].Width = 100;
                dataGridView1.Columns["reg"].Resizable = DataGridViewTriState.False;
            }
            if (dataGridView1.Columns.Contains("name"))
            {
                dataGridView1.Columns["name"].Width = 150;
                dataGridView1.Columns["name"].Resizable = DataGridViewTriState.False;
            }

            // Handle date columns (1–31)
            for (int day = 1; day <= 31; day++)
            {
                string colName = day.ToString();
                if (dataGridView1.Columns.Contains(colName))
                {
                    dataGridView1.Columns[colName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[colName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            // For cases with "Date" column instead of day numbers
            if (dataGridView1.Columns.Contains("date"))
            {
                dataGridView1.Columns["date"].Width = 120;
                dataGridView1.Columns["date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // For "Status" column (✓ / ✗)
            if (dataGridView1.Columns.Contains("status"))
            {
                dataGridView1.Columns["status"].Width = 70;
                dataGridView1.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Row height uniform
            dataGridView1.RowTemplate.Height = 25;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
    public class Attendance
        {
        [BsonId]  // maps Mongo _id
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("reg")]
        public string Reg { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("classes")]
        public string Classes { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }

        [BsonElement("date")]
        public string DateString { get; set; }   // raw from Mongo ("2025-09-05")

        [BsonIgnore]
        public DateTime Date
        {
            get
            {
                if (DateTime.TryParse(DateString, out DateTime parsed))
                    return parsed;
                return DateTime.MinValue;
            }
        }
    }

}