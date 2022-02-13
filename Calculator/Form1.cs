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

namespace Calculator
{
    public partial class Form : System.Windows.Forms.Form
    {
        public class Anket{
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Father_name { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Number { get; set; }
            public bool Gender { get; set; }
            public DateTime Date_Born { get; set; }
            
        } 
        public Form()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            Anket anket = new Anket();
            anket.Name = tb_name.Text;
            anket.Surname = tb_surname.Text;
            anket.Father_name = tb_father.Text;
            anket.Country = tb_country.Text;
            anket.City = tb_city.Text;
            anket.Number = tb_number.Text;
            anket.Date_Born = dateTimePicker1.Value;

            if(Male.Checked == true)
            {
                anket.Gender = true;
            }
            else {
                anket.Gender = false;
            }
            
            var str = JsonConvert.SerializeObject(anket, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(tb_name.Text + ".json", str);

        }

        private void Load_Click(object sender, EventArgs e)
        {
            Anket anket = new Anket();
           
            var jsonStr = File.ReadAllText(tb_filename.Text + ".json");
            anket = JsonConvert.DeserializeObject<Anket>(jsonStr);
           
            tb_name.Text = anket.Name;
            tb_surname.Text = anket.Surname;
            tb_father.Text = anket.Father_name;
            tb_country.Text = anket.Country;
            tb_city.Text = anket.City;
            tb_number.Text = anket.Number;
            dateTimePicker1.Value = anket.Date_Born;
            if (anket.Gender == true)
            {
                Male.Checked = true;
                Female.Checked = false;
            }
            else
            {
                Female.Checked = true;
                Male.Checked = false;
            }
        }
    }
}
