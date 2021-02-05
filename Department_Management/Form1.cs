using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Department_Management
{
    public partial class Form1 : Form
    {


        public List<Country> Countries {get;set;}


        public Form1()
        {

            Countries = GetCountries();

            InitializeComponent();
        }

        private List<Country> GetCountries()
        {

            // agregar el formato csv
            var list = new List<Country>();
            list.Add(new Country()
            {
                idDept = "1",
                idMunicipio = "1",
                NameDept = "Antioquia",
                NameMunicipio = "Medellin",
                typeDept = "Municipio"
            });

            return list;
        }

        OpenFileDialog file = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {


            file.Filter = "CSV|*.csv";

            if (file.ShowDialog()==DialogResult.OK)

            {
                textBox1.Text = file.FileName;
                textBox2.Text = file.SafeFileName;

            } 


        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            // departamentos
            var depts = this.Countries;

            dataGridView1.DataSource = depts;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                MessageBox.Show(comboBox1.SelectedIndex.ToString());
            }



            if (comboBox1.SelectedIndex == 0)  { 
            dataGridView1.Columns["idDept"].Visible =true;
                dataGridView1.Columns["idMunicipio"].Visible = false;
                dataGridView1.Columns["idMunicipio"].Visible = false;

            }
        
        }
    }
}
