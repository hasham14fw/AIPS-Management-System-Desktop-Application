using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AIPS_Portal.Dashboard;
using System.Xml.Linq;
using MongoDB.Driver;
using System.Windows.Forms;
using AIPS_Portal; // Ensure this is included


namespace AIPS_Portal
{


    public partial class RecordForm : Form
    {
        private Student _student;
        private readonly IMongoCollection<Student> _studentCollection;
        public RecordForm(Student student)
        {
            InitializeComponent();
            _student = student;

            var client = new MongoClient(Config.MongoConnectionString);
            var database = client.GetDatabase("AIPS");
            _studentCollection = database.GetCollection<Student>("students");
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void record_Load(object sender, EventArgs e)
        {

            // Fill textboxes/labels with student info
            reg.Text = _student.Reg;
            name.Text = _student.Name;
            cnic.Text = _student.CNIC;
            fname.Text = _student.FName;
            fcnic.Text = _student.FCNIC;
            classes.Text = _student.Classes;
            contact.Text = _student.Contact;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void add_Click(object sender, EventArgs e)
        {

            try
            {
                var filter = Builders<Student>.Filter.Eq(s => s.Reg, _student.Reg);

                var update = Builders<Student>.Update
                    .Set(s => s.Name, name.Text.Trim())
                    .Set(s => s.CNIC, cnic.Text.Trim())
                    .Set(s => s.FName, fname.Text.Trim())
                    .Set(s => s.FCNIC, fcnic.Text.Trim())
                    .Set(s => s.Classes, classes.Text.Trim())
                    .Set(s => s.Contact, contact.Text.Trim());

                var result = await _studentCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Student record updated successfully!");
                }
                else
                {
                    MessageBox.Show("No changes were made.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
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

        private void button7_Click(object sender, EventArgs e)
        {
            admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
}


