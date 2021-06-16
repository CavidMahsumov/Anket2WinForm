using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassTask
{
    public partial class Form1 : Form
    {
        public bool isClikde { get; set; } = false;
        public Form1()
        {
            InitializeComponent();
            listBox1.Text = string.Empty;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.DisplayMember = "Name";
            listBox1.Items.Add(new Human
            {
                Name = NameTextBox.Text,
                Email = emailtextbox.Text,
                Phone = Phonetextbox.Text,
                Surname = SurnameTextBox.Text,
                date = dateTimePicker1.Value


            });
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Human
            {
                Name = NameTextBox.Text,
                date = dateTimePicker1.Value,
                Email = emailtextbox.Text,
                Phone = Phonetextbox.Text,
                Surname = SurnameTextBox.Text
            });
            listBox1.DisplayMember = "Name";

            if (!isClikde)
            {
                button1.Location = new Point(293, 336);
                button2.Location = new Point(293, 273);
                isClikde =true;

            }
            else
            {
                button2.Location = new Point(293, 336);
                button1.Location = new Point(293, 273);
                isClikde = false;
            }
            NameTextBox.Text = string.Empty;
            SurnameTextBox.Text = string.Empty;
            emailtextbox.Text = string.Empty;
            Phonetextbox.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                var human = item as Human;
                if (File.Exists(JsonName.Text))
                {
                    JsonFileHelper.JSONDeSerialization(ref human, JsonName.Text);

                }
                NameTextBox.Text = human.Name;
                SurnameTextBox.Text = human.Surname;
                emailtextbox.Text = human.Email;
                Phonetextbox.Text = human.Phone;
                dateTimePicker1.Value = human.date;


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in listBox1.SelectedItems)
            {
                var human = item as Human;
                stringBuilder.Append($"{human.Name}");
            }
            stringBuilder.Append(".json");
            JsonName.Text = stringBuilder.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                var human = item as Human;
                JsonFileHelper.JSONSerialization(human, JsonName.Text);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    var human = item as Human;
                    listBox1.Items.Remove(human);
                    human.Name = NameTextBox.Text;
                    human.Surname = SurnameTextBox.Text;
                    human.date = dateTimePicker1.Value;
                    human.Email = emailtextbox.Text;
                    human.Phone = Phonetextbox.Text;
                    listBox1.Items.Add(human);
                    NameTextBox.Text = string.Empty;
                    SurnameTextBox.Text = string.Empty;
                    emailtextbox.Text = string.Empty;
                    Phonetextbox.Text = string.Empty;
                    dateTimePicker1.Value = DateTime.Now;
                }

            }
            catch (Exception)
            {

            }
           

            if (!isClikde)
            {
                button1.Location = new Point(293, 336);
                button2.Location = new Point(293, 273);
                isClikde = true;
            }
            else
            {
                button2.Location = new Point(293, 336);
                button1.Location = new Point(293, 273);
                isClikde = false;


            }
        }
    }
}
