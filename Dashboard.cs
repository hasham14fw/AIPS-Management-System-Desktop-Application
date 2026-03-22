using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Windows.Forms;

namespace AIPS_Portal

{

    public partial class Dashboard : Form
    {
        string accountSid = Config.TwilioAccountSid; // <-- replace this
        string authToken = Config.TwilioAuthToken;   // <-- replace this
        string twilioWhatsAppNumber = Config.TwilioWhatsAppNumber; // or your approved number

        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private async void button5_Click(object sender, EventArgs e)
        {
            var client = new MongoClient(Config.MongoConnectionString);
            var database = client.GetDatabase("AIPS");
            var collection = database.GetCollection<News>("news");

            var newsItem = new News
            {
                Content = richTextBox1.Text.Trim(),
                Date = DateTime.Now
            };

            try
            {
                await collection.InsertOneAsync(newsItem);
                System.Windows.Forms.MessageBox.Show("News uploaded successfully!");
                richTextBox1.Clear();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class News
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("content")]
            public string Content { get; set; }

            [BsonElement("date")]
            public DateTime Date { get; set; }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Teacher nextPage = new Teacher();
            nextPage.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clsses nextPage = new clsses();
            nextPage.Show();
            this.Hide();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
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
        }

        private async void button6_Click(object sender, EventArgs e)
        {

            string selectedClass = cmbClass.SelectedItem?.ToString();
            string messageBody = Messages.Text.Trim();

            if (string.IsNullOrEmpty(selectedClass) || string.IsNullOrEmpty(messageBody))
            {
                //System.Windows.Forms.MessageBox.Show("Please enter a message and select a class.");
                return;
            }

            try
            {
                var client = new MongoClient(Config.MongoConnectionString);
                var database = client.GetDatabase("AIPS");
                var collection = database.GetCollection<Student>("students");

                FilterDefinition<Student> filter;
                if (selectedClass == "All")
                    filter = Builders<Student>.Filter.Empty;
                else
                    filter = Builders<Student>.Filter.Eq(s => s.Classes, selectedClass);

                var students = await collection.Find(filter).ToListAsync();

                TwilioClient.Init(accountSid, authToken);

                int success = 0, failed = 0;

                foreach (var student in students)
                {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(student.Contact))
                        {
                            string formattedContact = student.Contact.StartsWith("+")
                                ? student.Contact
                                : "+92" + student.Contact.TrimStart('0');

                            var message = MessageResource.Create(
                                from: new PhoneNumber(twilioWhatsAppNumber),
                                to: new PhoneNumber("whatsapp:" + formattedContact),
                                body: $"Dear {student.Name}, {messageBody}"
                            );

                            success++;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed for {student.Contact}: {ex.Message}");
                        failed++;
                    }
                }

                System.Windows.Forms.MessageBox.Show($"Messages sent: {success}, Failed: {failed}");
                Messages.Clear();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        public class Student
        {
            [BsonId]
            public ObjectId Id { get; set; }

            [BsonElement("reg")]
            public string Reg { get; set; }

            [BsonElement("name")]
            public string Name { get; set; }

            [BsonElement("password")]
            public string Password { get; set; }

            [BsonElement("fname")]
            public string FName { get; set; }

            [BsonElement("contact")]
            public string Contact { get; set; }

            [BsonElement("classes")]
            public string Classes { get; set; }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            attendance nextPage = new attendance();
            nextPage.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           admission nextPage = new admission();
            nextPage.Show();
            this.Hide();
        }
    }
}
    



