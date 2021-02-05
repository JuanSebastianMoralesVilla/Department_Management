using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Department_Management
{
    public partial class Form1 : Form
    {
        private string path;
        public Form1()
        {
            path = @"C: \Users\user\Desktop\Department_Management\Department_Management\data\DIVIPOLA - _C_digos_municipios.csv";

            InitializeComponent();
        }

        /*
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
        */
        OpenFileDialog file = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {


            file.Filter = "CSV|*.csv";

            if (file.ShowDialog()==DialogResult.OK)

            {
                textBox1.Text = file.FileName;
                path = file.FileName;
                textBox2.Text = file.SafeFileName;
                MessageBox.Show("  Datos cargados correctamente");
                loadGrid();
            } 


        }

        
        private void loadGrid()
        {
            try
            {
                Console.WriteLine("Entre");
                var reader = new StreamReader(File.OpenRead(path));
                string line = reader.ReadLine();
                line = reader.ReadLine();
                List<AllTowns> towns = new List<AllTowns>();
                while (!string.IsNullOrEmpty(line))
                {
                    string[] array = line.Split(',');
                    int idDepartment = Int32.Parse(array[0]);
                    int idTown = Int32.Parse(array[1]);
                    string nameDepartment = (array[2]);
                    string nameTown = (array[3]);
                    string type = (array[4]);
                    AllTowns all = new AllTowns(idDepartment, idTown, nameDepartment, nameTown, type);
                    Console.WriteLine(all.ToString());
                    towns.Add(all);
                    line = reader.ReadLine();
                }
                dataGridView1.DataSource = towns;
            }
            catch (Exception wtf)
            {
                Console.WriteLine(wtf.ToString());
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
            // departamentos
        {

           
            
            loadGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reporte 1. Con base en un combobox (lista de opciones desplegable) donde estén todos los valores posibles de los tipos, 
           // permita que el usuario seleccione un tipo y filtre los datos de manera que en la tabla donde se despliegan,
              //  solamente queden las filas cuya columna tipo sea la seleccionada.

            // tarea 1.1

            if (comboBox1.SelectedIndex == 0)  {
                dataGridView1.Columns["idDepartment"].Visible = true;
                dataGridView1.Columns["idTown"].Visible = false;
                dataGridView1.Columns["nameDepartment"].Visible = false;
                dataGridView1.Columns["nameTown"].Visible = false;
                dataGridView1.Columns["type"].Visible = false;
            }


            if (comboBox1.SelectedIndex == 1)
            {
                dataGridView1.Columns["idDepartment"].Visible = false;
                dataGridView1.Columns["idTown"].Visible = true;
                dataGridView1.Columns["nameDepartment"].Visible = false;
                dataGridView1.Columns["nameTown"].Visible = false;
                dataGridView1.Columns["type"].Visible = false;

            }

            if (comboBox1.SelectedIndex == 2)
            {
                dataGridView1.Columns["idDepartment"].Visible = false;
                dataGridView1.Columns["idTown"].Visible = false;
                dataGridView1.Columns["nameDepartment"].Visible = true;
                dataGridView1.Columns["nameTown"].Visible = false;
                dataGridView1.Columns["type"].Visible = false;

            }

            if (comboBox1.SelectedIndex == 3)
            {
                dataGridView1.Columns["idDepartment"].Visible = false;
                dataGridView1.Columns["idTown"].Visible = false;
                dataGridView1.Columns["nameDepartment"].Visible = false;
                dataGridView1.Columns["nameTown"].Visible = true;
                dataGridView1.Columns["type"].Visible = false;
            }

            if (comboBox1.SelectedIndex == 4)
            {
                dataGridView1.Columns["idDepartment"].Visible = false;
                dataGridView1.Columns["idTown"].Visible = false;
                dataGridView1.Columns["nameDepartment"].Visible = false;
                dataGridView1.Columns["nameTown"].Visible = false;
                dataGridView1.Columns["type"].Visible =true;

            }
            if (comboBox1.SelectedIndex == 5)
            {
                dataGridView1.Columns["idDepartment"].Visible = true;
                dataGridView1.Columns["idTown"].Visible = true;
                dataGridView1.Columns["nameDepartment"].Visible = true;
                dataGridView1.Columns["nameTown"].Visible = true;
                dataGridView1.Columns["type"].Visible = true;

            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
