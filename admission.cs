using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;
namespace AIPS_Portal
{
    public partial class admission : Form
    {
        private readonly IMongoCollection<BsonDocument> _admissionCollection;
        public admission()
        {
            InitializeComponent();

            // Connect to MongoDB (replace with your connection string + DB name)
            var client = new MongoClient(Config.MongoConnectionString);
            var database = client.GetDatabase("AIPS");
            _admissionCollection = database.GetCollection<BsonDocument>("admission");

            LoadAdmissions();
            StyleGrid();

        }
        private void LoadAdmissions()
        {
            var documents = _admissionCollection.Find(new BsonDocument()).ToList();

            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Father");
            table.Columns.Add("Contact");
            table.Columns.Add("School");
            table.Columns.Add("Class");
            table.Columns.Add("Address");
            table.Columns.Add("Date");

            foreach (var doc in documents)
            {
                table.Rows.Add(
                    doc.GetValue("name", "").ToString(),
                    doc.GetValue("fname", "").ToString(),
                    doc.GetValue("contact", "").ToString(),
                    doc.GetValue("school", "").ToString(),
                    doc.GetValue("classApplied", "").ToString(),
                    doc.GetValue("address", "").ToString(),
                    Convert.ToDateTime(doc.GetValue("date", DateTime.MinValue)).ToString("dd-MM-yyyy HH:mm")
                );
            }

            dataGridView1.DataSource = table;
        }

        private void StyleGrid()
        {
            // Header styling
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row styling
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.White;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Read-only and no selection
            dataGridView1.ReadOnly = true;
            dataGridView1.ClearSelection();
            dataGridView1.MultiSelect = false;
            dataGridView1.CurrentCell = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

            // Auto size
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 35;

            // Adjust specific column widths
            dataGridView1.Columns["Student Name"].FillWeight = 200;  // Make Name wider
            dataGridView1.Columns["Home Address"].FillWeight = 250;  // More space for address
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void admission_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }
    }
}
