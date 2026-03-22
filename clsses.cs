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



namespace AIPS_Portal
{
    public partial class clsses : Form
    {
        private IMongoDatabase database;
        public clsses()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clsses_Load(object sender, EventArgs e)
        {
            var client = new MongoClient(Config.MongoConnectionString);
            database = client.GetDatabase("AIPS");

            List<string> classList = new List<string>();
            string[] sections = { "A", "B", "C", "D" };

            foreach (var section in sections)
            {
                classList.Add($"NUR {section}");
                classList.Add($"PREP {section}");
            }

            for (int i = 1; i <= 10; i++)
            {
                foreach (var section in sections)
                {
                    classList.Add($"{i} {section}");
                }
            }

            cmbClass.Items.AddRange(classList.ToArray());

            // Add DataGridView columns
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;         // Text color
            dataGridView1.DefaultCellStyle.BackColor = Color.White;         // Cell background
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add("reg", "Reg #");
            dataGridView1.Columns.Add("name", "Name");
            dataGridView1.Columns.Add("password", "Password");
            dataGridView1.Columns.Add("cnic", "CNIC");
            dataGridView1.Columns.Add("fname", "Father Name");
            dataGridView1.Columns.Add("fcnic", "Father CNIC");
            dataGridView1.Columns.Add("dob", "Date of Birth");
            dataGridView1.Columns.Add("contact", "Contact");

        }


        private void button5_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedItem == null)
            {
                MessageBox.Show("Please select a class.");
                return;
            }

            var selectedClass = cmbClass.SelectedItem.ToString();
            var studentsCollection = database.GetCollection<BsonDocument>("students");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string reg = row.Cells["reg"].Value?.ToString()?.Trim();
                string name = row.Cells["name"].Value?.ToString()?.Trim();
                string password = row.Cells["password"].Value?.ToString()?.Trim();
                string fname = row.Cells["fname"].Value?.ToString()?.Trim();
                string contact = row.Cells["contact"].Value?.ToString()?.Trim();

                if (string.IsNullOrWhiteSpace(reg) || string.IsNullOrWhiteSpace(name) ||
                    string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fname) ||
                    string.IsNullOrWhiteSpace(contact))
                {
                    MessageBox.Show("Required fields missing in one or more rows.");
                    return;
                }

                // Optional fields
                string cnic = row.Cells["cnic"].Value?.ToString()?.Trim() ?? "";
                string fcnic = row.Cells["fcnic"].Value?.ToString()?.Trim() ?? "";
                string dob = row.Cells["dob"].Value?.ToString()?.Trim() ?? "";

                // Hash the password securely
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                // Create student document
                var studentDoc = new BsonDocument
        {
            { "reg", reg },
            { "name", name },
            { "password", hashedPassword },
            { "fname", fname },
            { "contact", contact },
            { "classes", selectedClass }
        };

                // Add optional fields if present
                if (!string.IsNullOrEmpty(cnic)) studentDoc.Add("cnic", cnic);
                if (!string.IsNullOrEmpty(fcnic)) studentDoc.Add("fcnic", fcnic);
                if (!string.IsNullOrEmpty(dob)) studentDoc.Add("dob", dob);

                studentsCollection.InsertOne(studentDoc);
            }

            MessageBox.Show("Students added successfully!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //record nextPage = new record();
            //nextPage.Show();
            //this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
}


