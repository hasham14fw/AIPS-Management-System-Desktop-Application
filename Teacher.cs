using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Windows.Forms;
using BCrypt.Net;
namespace AIPS_Portal
{
    public partial class Teacher : Form
    {
        private IMongoDatabase database;

        public Teacher()
        {
            InitializeComponent();

            // Initialize MongoDB connection only once
            var client = new MongoClient(Config.MongoConnectionString);
            database = client.GetDatabase("AIPS");
        }

        private async void add_Click(object sender, EventArgs e)  // ✅ Marked async
        {
            var collection = database.GetCollection<BsonDocument>("teachers");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string reg = row.Cells["reg"].Value?.ToString()?.Trim();
                string name = row.Cells["name"].Value?.ToString()?.Trim();
                string cls = row.Cells["classes"].Value?.ToString()?.Trim();
                string contact = row.Cells["contact"].Value?.ToString()?.Trim();
                string passwordRaw = row.Cells["password"].Value?.ToString();

                string cnic = row.Cells["cnic"].Value?.ToString();
                string fcnic = row.Cells["fcnic"].Value?.ToString();
                string fname = row.Cells["fname"].Value?.ToString();
                string dob = row.Cells["dob"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(reg) ||
                    string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(cls) ||
                    string.IsNullOrWhiteSpace(contact) ||
                    string.IsNullOrWhiteSpace(passwordRaw))
                {
                    MessageBox.Show($"⚠️ Skipping row with missing required data.");
                    continue;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(passwordRaw);

                var teacherDoc = new BsonDocument
                {
                    { "reg", reg },
                    { "name", name },
                    { "classes", cls },
                    { "contact", contact },
                    { "password", hashedPassword }
                };

                if (!string.IsNullOrWhiteSpace(cnic)) teacherDoc.Add("cnic", cnic);
                if (!string.IsNullOrWhiteSpace(fcnic)) teacherDoc.Add("fcnic", fcnic);
                if (!string.IsNullOrWhiteSpace(fname)) teacherDoc.Add("fname", fname);
                if (!string.IsNullOrWhiteSpace(dob)) teacherDoc.Add("dob", dob);

                try
                {
                    await collection.InsertOneAsync(teacherDoc); // ✅ Now allowed
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error inserting row: {ex.Message}");
                }
            }

            MessageBox.Show("✅ All valid teacher records added successfully!");
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;         // Text color
            dataGridView1.DefaultCellStyle.BackColor = Color.White;         // Cell background
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ColumnCount = 9;

            dataGridView1.Columns[0].Name = "reg";
            dataGridView1.Columns[0].HeaderText = "Reg";

            dataGridView1.Columns[1].Name = "name";
            dataGridView1.Columns[1].HeaderText = "Name";

            dataGridView1.Columns[2].Name = "cnic";
            dataGridView1.Columns[2].HeaderText = "CNIC";

            dataGridView1.Columns[3].Name = "fcnic";
            dataGridView1.Columns[3].HeaderText = "F CNIC";

            dataGridView1.Columns[4].Name = "fname";
            dataGridView1.Columns[4].HeaderText = "F Name";

            dataGridView1.Columns[5].Name = "dob";
            dataGridView1.Columns[5].HeaderText = "DOB";

            dataGridView1.Columns[6].Name = "classes";
            dataGridView1.Columns[6].HeaderText = "Class";

            dataGridView1.Columns[7].Name = "contact";
            dataGridView1.Columns[7].HeaderText = "Contact";

            dataGridView1.Columns[8].Name = "password";
            dataGridView1.Columns[8].HeaderText = "Password";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nextPage = new Form1();
            nextPage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Students nextPage = new Students();
            nextPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard nextPage = new Dashboard();
            nextPage.Show();
            this.Hide();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
}
