using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Twilio.TwiML.Voice;

namespace AIPS_Portal
{

    public partial class Students : Form
    {

        private IMongoCollection<Student> _studentCollection;

        public Students()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void reg_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard nextPage = new Dashboard();
            nextPage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 nextPage = new Form1();
            nextPage.Show();
            this.Hide();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }



        private void Students_Load(object sender, EventArgs e)
        {
            var client = new MongoClient(Config.MongoConnectionString);
            var database = client.GetDatabase("AIPS");
            _studentCollection = database.GetCollection<Student>("students");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;

            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // ✅ Add View Button Column if not already added
            if (!dataGridView1.Columns.Contains("View"))
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "View";
                btn.HeaderText = "Action";
                btn.Text = "View";
                btn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btn);
            }

            // Populate class list
            List<string> classList = new List<string>();
            string[] sections = { "A", "B", "C", "D" };

            foreach (var section in sections)
            {
                classList.Add($"NUR {section}");
                classList.Add($"PREP {section}");
            }

            string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            foreach (var number in numbers)
            {
                foreach (var section in sections)
                {
                    classList.Add($"{number} {section}");
                }
            }

            sclass.Items.AddRange(classList.ToArray());

            desg.Items.Clear();
            desg.Items.Add("Student");
            desg.Items.Add("Teacher");
            desg.SelectedIndex = 0;
        }




        private void contact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //add.PerformClick(); // triggers your add_Click logic
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }


        }

        private void reg_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void cnic_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void fname_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void classes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void classes_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void fcnic_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void dob_TextChanged(object sender, EventArgs e)
        {

        }

        private void dob_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                this.SelectNextControl((Control)sender, false, true, true, true);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedType = desg.SelectedItem?.ToString() ?? "Student";

                if (selectedType == "Student")
                {
                    var filterBuilder = Builders<Student>.Filter;
                    var filter = FilterDefinition<Student>.Empty;
                    List<FilterDefinition<Student>> filters = new List<FilterDefinition<Student>>();

                    if (!string.IsNullOrWhiteSpace(sname.Text))
                        filters.Add(filterBuilder.Regex(s => s.Name, new BsonRegularExpression(sname.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sreg.Text))
                        filters.Add(filterBuilder.Regex(s => s.Reg, new BsonRegularExpression(sreg.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(scnic.Text))
                        filters.Add(filterBuilder.Regex(s => s.CNIC, new BsonRegularExpression(scnic.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sfname.Text))
                        filters.Add(filterBuilder.Regex(s => s.FName, new BsonRegularExpression(sfname.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sfcnic.Text))
                        filters.Add(filterBuilder.Regex(s => s.FCNIC, new BsonRegularExpression(sfcnic.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sclass.Text))
                        filters.Add(filterBuilder.Regex(s => s.Classes, new BsonRegularExpression(sclass.Text.Trim(), "i")));

                    if (filters.Count > 0)
                        filter = filterBuilder.And(filters);

                    // ✅ Always ToList()
                    var students = _studentCollection.Find(filter).ToList();

                    dataGridView1.DataSource = null;  // clear old binding
                    dataGridView1.DataSource = students;

                    // Hide sensitive columns
                    if (dataGridView1.Columns.Contains("Id"))
                        dataGridView1.Columns["Id"].Visible = false;
                    if (dataGridView1.Columns.Contains("Password"))
                        dataGridView1.Columns["Password"].Visible = false;
                    if (dataGridView1.Columns.Contains("DOB"))
                        dataGridView1.Columns["DOB"].Visible = false;
                }
                else if (selectedType == "Teacher")
                {
                    var client = new MongoClient(Config.MongoConnectionString);
                    var database = client.GetDatabase("AIPS");
                    var teacherCollection = database.GetCollection<TeacherModel>("teachers");

                    var filterBuilder = Builders<TeacherModel>.Filter;
                    var filter = FilterDefinition<TeacherModel>.Empty;
                    List<FilterDefinition<TeacherModel>> filters = new List<FilterDefinition<TeacherModel>>();

                    if (!string.IsNullOrWhiteSpace(sname.Text))
                        filters.Add(filterBuilder.Regex(t => t.Name, new BsonRegularExpression(sname.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sreg.Text))
                        filters.Add(filterBuilder.Regex(t => t.Reg, new BsonRegularExpression(sreg.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sfname.Text))
                        filters.Add(filterBuilder.Regex(t => t.FName, new BsonRegularExpression(sfname.Text.Trim(), "i")));

                    if (!string.IsNullOrWhiteSpace(sclass.Text))
                        filters.Add(filterBuilder.Regex(t => t.Classes, new BsonRegularExpression(sclass.Text.Trim(), "i")));

                    if (filters.Count > 0)
                        filter = filterBuilder.And(filters);

                    var teachers = teacherCollection.Find(filter).ToList();

                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = teachers;

                    if (dataGridView1.Columns.Contains("Id"))
                        dataGridView1.Columns["Id"].Visible = false;
                    if (dataGridView1.Columns.Contains("Password"))
                        dataGridView1.Columns["Password"].Visible = false;
                }

                // ✅ Clear search inputs after search
                sname.Clear();
                sreg.Clear();
                scnic.Clear();
                sfname.Clear();
                sfcnic.Clear();
                sclass.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void button3_Click(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string regNumber = reg.Text.Trim();
                string newPassword = spass.Text.Trim();

                if (string.IsNullOrEmpty(regNumber) || string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Please enter both Registration Number and New Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hash the new password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Create update definition
                var filter = Builders<Student>.Filter.Eq(s => s.Reg, regNumber);
                var update = Builders<Student>.Update.Set(s => s.Password, hashedPassword);

                var result = _studentCollection.UpdateOne(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Student not found with given Reg number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Clear textboxes after update attempt
                reg.Clear();
                spass.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Still clear textboxes if error occurs
                reg.Clear();
                spass.Clear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string regNumber = treg.Text.Trim();
                string newPassword = tpass.Text.Trim();

                if (string.IsNullOrEmpty(regNumber) || string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.Show("Please enter both Teacher Reg Number and New Password.",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hash the new password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

                // Use the global client if you already have one, otherwise create a new one
                var client = new MongoClient(Config.MongoConnectionString);
                var database = client.GetDatabase("AIPS");
                var teacherCollection = database.GetCollection<TeacherModel>("teachers");
                var filter = Builders<TeacherModel>.Filter.Eq(t => t.Reg, regNumber);
                var update = Builders<TeacherModel>.Update.Set(t => t.Password, hashedPassword);


                var result = teacherCollection.UpdateOne(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("✅ Teacher password updated successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("❌ Teacher not found with given Reg number.",
                                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Always clear inputs and set focus
                treg.Clear();
                tpass.Clear();
                treg.Focus();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private bool _recordFormOpen = false;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header or invalid rows
            if (e.RowIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "View")
                return;

            if (_recordFormOpen) return; // Prevent multiple instances

            var rowData = dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (rowData is Student student)
            {
                _recordFormOpen = true; // Set flag

                RecordForm recordForm = new RecordForm(student);
                recordForm.FormClosed += (s, args) =>
                {
                    _recordFormOpen = false; // Reset flag when closed
                    this.Show(); // Show Students form again
                };

                this.Hide();
                recordForm.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
           admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }

    public class TeacherModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("reg")]
        public string Reg { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("contact")]
        public string Contact { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("fname")]
        public string FName { get; set; }

        [BsonElement("classes")]
        public string Classes { get; set; }
    }


    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("reg")]
        public string Reg { get; set; }

        [BsonElement("cnic")]
        public string CNIC { get; set; }

        [BsonElement("fname")]
        public string FName { get; set; }

        [BsonElement("fcnic")]
        public string FCNIC { get; set; }

        [BsonElement("classes")]
        public string Classes { get; set; }

        [BsonElement("dob")]
        public string DOB { get; set; }

        [BsonElement("contact")]
        public string Contact { get; set; }

        [BsonElement("password")]
        [BsonIgnoreIfNull]
        public string Password { get; set; }

    }
}

