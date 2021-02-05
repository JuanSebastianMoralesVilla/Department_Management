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
            var list= new List<Country>();
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
                MessageBox.Show("  Datos cargados correctamente");

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
            //Reporte 1. Con base en un combobox (lista de opciones desplegable) donde estén todos los valores posibles de los tipos, 
           // permita que el usuario seleccione un tipo y filtre los datos de manera que en la tabla donde se despliegan,
              //  solamente queden las filas cuya columna tipo sea la seleccionada.

            // tarea 1.1

            if (comboBox1.SelectedIndex == 0)  { 
            dataGridView1.Columns["idDept"].Visible =true;
                dataGridView1.Columns["idMunicipio"].Visible = false;
                dataGridView1.Columns["NameDept"].Visible = false;
                dataGridView1.Columns["NameMunicipio"].Visible = false;
                dataGridView1.Columns["typeDept"].Visible = false;
            
            }


            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.Columns["idDept"].Visible = false;
                dataGridView1.Columns["idMunicipio"].Visible = true;
                dataGridView1.Columns["NameDept"].Visible = false;
                dataGridView1.Columns["NameMunicipio"].Visible = false;
                dataGridView1.Columns["typeDept"].Visible = false;

            }

            if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.Columns["idDept"].Visible = false;
                dataGridView1.Columns["idMunicipio"].Visible = false;
                dataGridView1.Columns["NameDept"].Visible = true;
                dataGridView1.Columns["NameMunicipio"].Visible = false;
                dataGridView1.Columns["typeDept"].Visible = false;

            }

            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns["idDept"].Visible = false;
                dataGridView1.Columns["idMunicipio"].Visible = false;
                dataGridView1.Columns["NameDept"].Visible = false;
                dataGridView1.Columns["NameMunicipio"].Visible = true;
                dataGridView1.Columns["typeDept"].Visible = false;

            }

            if (comboBox1.SelectedIndex == 4)
            {
                dataGridView1.Columns["idDept"].Visible = false;
                dataGridView1.Columns["idMunicipio"].Visible = false;
                dataGridView1.Columns["NameDept"].Visible = false;
                dataGridView1.Columns["NameMunicipio"].Visible =false;
                dataGridView1.Columns["typeDept"].Visible = true;

            }
            if (comboBox1.SelectedIndex == 5)
            {
                dataGridView1.Columns["idDept"].Visible = true;
                dataGridView1.Columns["idMunicipio"].Visible = true;
                dataGridView1.Columns["NameDept"].Visible = true;
                dataGridView1.Columns["NameMunicipio"].Visible = true;
                dataGridView1.Columns["typeDept"].Visible = true;

            }

        }
    }
}
