using Newtonsoft.Json;
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
using System.Xml;
using System.Xml.Serialization;

namespace List_survey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Database> databases = new List<Database>();
        StringBuilder stringBuilder = new StringBuilder();

        private void Form1_Load(object sender, EventArgs e)
        {
          

           
            
        }

        private void NametextBox1_MouseEnter(object sender, EventArgs e)
        {
            if (NametextBox1.Text == "Name")
            {
                NametextBox1.Text = null;
                NametextBox1.ForeColor = Color.Black;
            }
        }

        private void NametextBox1_MouseLeave(object sender, EventArgs e)
        {
            if (NametextBox1.Text == "")
            {
                NametextBox1.Text = "Name";
                NametextBox1.ForeColor = Color.LightGray;
            }
        }

        private void SurnametextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (SurnametextBox2.Text == "Surname")
            {
                SurnametextBox2.Text = null;
                SurnametextBox2.ForeColor = Color.Black;
            }


        }

        private void SurnametextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (SurnametextBox2.Text == "")
            {
                SurnametextBox2.Text = "Surname";
                SurnametextBox2.ForeColor = Color.LightGray;
            }
        }

        private void FatherNametextBox3_MouseEnter(object sender, EventArgs e)
        {
            if (FatherNametextBox3.Text == "Your Father's name")
            {
                FatherNametextBox3.Text = null;
                FatherNametextBox3.ForeColor = Color.Black;
            }
        }

        private void FatherNametextBox3_MouseLeave(object sender, EventArgs e)
        {
            if (FatherNametextBox3.Text == "")
            {
                FatherNametextBox3.Text = "Your Father's name";
                FatherNametextBox3.ForeColor = Color.LightGray;
            }
        }


        private void TelephoneNumbertextBox3_MouseEnter(object sender, EventArgs e)
        {
            if (TelephoneNumbertextBox1.Text == "Telephone number")
            {
                TelephoneNumbertextBox1.Text = null;
                TelephoneNumbertextBox1.ForeColor = Color.Black;
            }
        }

        private void TelephoneNumbertextBox3_MouseLeave(object sender, EventArgs e)
        {
            if (TelephoneNumbertextBox1.Text == "")
            {
                TelephoneNumbertextBox1.Text = "Telephone number";
                TelephoneNumbertextBox1.ForeColor = Color.LightGray;
            }
        }

        private void EmailAddresstextBox3_MouseEnter(object sender, EventArgs e)
        {
            if (EmailtextBox2.Text == "Email address")
            {
                EmailtextBox2.Text = null;
                EmailtextBox2.ForeColor = Color.Black;
            }
        }

        private void EmailAddresstextBox3_MouseLeave(object sender, EventArgs e)
        {
            if (EmailtextBox2.Text == "")
            {
                EmailtextBox2.Text = "Email address";
                EmailtextBox2.ForeColor = Color.LightGray;
            }
        }

        private void SaveAS_MouseLeave(object sender, EventArgs e)
        {
            if (Saveastextbox4.Text == "")
            {
                Saveastextbox4.Text = "Save as";
                Saveastextbox4.ForeColor = Color.LightGray;
            }
        }

        private void SaveAS_MouseEnter(object sender, EventArgs e)
        {
            if (Saveastextbox4.Text == "Save as")
            {
                Saveastextbox4.Text = null;
                Saveastextbox4.ForeColor = Color.Black;
            }
        }

        void AddData()
        {
            databases.Add(new Database(NametextBox1.Text, SurnametextBox2.Text, FatherNametextBox3.Text, BithdaydateTimePicker1.Text, EmailtextBox2.Text, TelephoneNumbertextBox1.Text)
            {
                Name = NametextBox1.Text,
                Surname = SurnametextBox2.Text,
                YourFatherName = FatherNametextBox3.Text,
                DateTime = BithdaydateTimePicker1.Text,
                EmailAddress = EmailtextBox2.Text,
                TelephoneNumber = TelephoneNumbertextBox1.Text

            });



            listbox();






        }

        void listbox()
        {
            foreach (var item in databases)
            {
                if (!NamelistBox1.Items.Contains(item.Name))
                {
                    NamelistBox1.Items.Add(item.Name);
                }

                if (!SurnamelistBox1.Items.Contains(item.Surname))
                {
                    SurnamelistBox1.Items.Add(item.Surname);
                }

                if (!FatherlistBox1.Items.Contains(item.YourFatherName))
                {
                    FatherlistBox1.Items.Add(item.YourFatherName);
                }

                if (!BithdaylistBox2.Items.Contains(item.DateTime))
                {
                    BithdaylistBox2.Items.Add(item.DateTime);
                }

                if (!PhonenumberlistBox3.Items.Contains(item.TelephoneNumber))
                {
                    PhonenumberlistBox3.Items.Add(item.TelephoneNumber);
                }

                if (!EmaillistBox4.Items.Contains(item.EmailAddress))
                {
                    EmaillistBox4.Items.Add(item.EmailAddress);
                }
            }
        }
        void SaveData()

        {
    
    
            var xml = new XmlSerializer(typeof(List<Database>));
            using (var fs = new FileStream($"{Saveastextbox4.Text}.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, databases);
            }


          

        }

        void ReadData()
        {
            Database database = null;

            var xml = new XmlSerializer(typeof(List<Database>));

            using (var fs = new FileStream($"{Saveastextbox4.Text}.xml", FileMode.OpenOrCreate))
            {
                database = xml.Deserialize(fs) as Database;
               
            }

            foreach (var item in databases)
            {
                richTextBox1.Text = $" \n {item.ID.ToString()} \n {item.Name} \n {item.Surname} \n {item.YourFatherName} \n {item.TelephoneNumber} \n{item.EmailAddress} \n{item.DateTime} \n";


                if (stringBuilder.ToString().Trim().Length == 0 || !stringBuilder.ToString().Contains(richTextBox1.Text))
                {

                    stringBuilder.Append(richTextBox1.Text);
                }


                richTextBox1.Text = stringBuilder.ToString();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load($"{Saveastextbox4.Text}.xml");

            var root = doc.DocumentElement;


            string j = JsonConvert.SerializeXmlNode(doc);

        }
        private void Addbutton1_Click(object sender, EventArgs e)
        {
            AddData();
        }

        private void Savebutton1_Click(object sender, EventArgs e)
        {
            SaveData();
            ReadData();
        }

        private void Loadbutton1_Click(object sender, EventArgs e)
        {
           

    


        }

        private void Updatebutton1_Click(object sender, EventArgs e)
        {
            if (NamelistBox1.SelectedIndex==-1)
            {
                NametextBox1.Text = NametextBox1.Text;
            }
            if (NamelistBox1.SelectedIndex != -1)
            {
                NametextBox1.Text = NamelistBox1.SelectedItem.ToString();
            }


            if (SurnamelistBox1.SelectedIndex == -1)
            {
                SurnametextBox2.Text = SurnametextBox2.Text;
            }
            if (SurnamelistBox1.SelectedIndex != -1)
            { 
            
                SurnametextBox2.Text = SurnamelistBox1.SelectedItem.ToString();
            }


            if (FatherlistBox1.SelectedIndex == -1)
            {
                FatherNametextBox3.Text = FatherNametextBox3.Text;
            }
            if (FatherlistBox1.SelectedIndex != -1)
            {
                FatherNametextBox3.Text = FatherlistBox1.SelectedItem.ToString();
            }

            if (BithdaylistBox2.SelectedIndex != -1)
            {
                BithdaydateTimePicker1.Text = BithdaylistBox2.SelectedItem.ToString();
            }
            if (BithdaylistBox2.SelectedIndex == -1)
            {
                BithdaydateTimePicker1.Text = BithdaydateTimePicker1.Text;
            }

            if (PhonenumberlistBox3.SelectedIndex != -1)
            {
                TelephoneNumbertextBox1.Text = PhonenumberlistBox3.SelectedItem.ToString();
            }
            if (PhonenumberlistBox3.SelectedIndex == -1)
            {
                TelephoneNumbertextBox1.Text = TelephoneNumbertextBox1.Text;
            }

            if (EmaillistBox4.SelectedIndex != -1)
            {
                EmailtextBox2.Text = EmaillistBox4.SelectedItem.ToString();
            }
            if (EmaillistBox4.SelectedIndex == -1)
            {
                EmailtextBox2.Text = EmailtextBox2.Text;
            }




        }
    }
}
