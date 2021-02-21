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
using System.Windows.Forms.DataVisualization.Charting;

namespace Department_Management
{
    public partial class Form1 : Form
    {
        private string path;
        private Country colombia;
        public Form1()
        {
            path = @"C: \Users\user\Desktop\Department_Management\Department_Management\data\DIVIPOLA - _C_digos_municipios.csv";
            colombia = new Country();
            InitializeComponent();
        }

       

        // abrir archivo buscarlo
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
                colombia = new Country();
                loadGrid();
                // mostrar grafica
                chartData();
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
                    colombia.add(idDepartment, idTown, nameDepartment, nameTown, type);
                    //Console.WriteLine(all.ToString());
                    towns.Add(all);
                    line = reader.ReadLine();
                }
                dataGridView1.DataSource = towns;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
            }
            catch (Exception wtf)
            {
                Console.WriteLine(wtf.ToString());
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
            
        {

           // cargar datos
            
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


        private void chartData() {

            // vectores con datos
            // name dept es nombre de dpeartamentos
            string[] namedept = colombia.getDepartments();
            int[] cantDep = colombia.getAmmount();
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Palette = ChartColorPalette.Excel;
            
            chart1.Titles.Add("Cantidad de municipios en colombia por departamento");

            for (int i = 0; i< namedept.Length;i++) {
                Series serie= chart1.Series.Add(namedept[i]);
                serie.Label = cantDep[i].ToString();
                serie.Points.AddXY(i,cantDep[i]);
                //serie.BorderWidth = 3;
                //serie.BorderWidth = 3;
            }

        }

        // combo box para filtrar datos por tipo
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //filtrar por municipio, isla, area no municipalizad
            int index = comboBox2.SelectedIndex;
            List<AllTowns> townsGrid = new List<AllTowns>();
            List<Department> departments = colombia.departments;
            foreach (Department department in departments)
            {
                List<Town> towns = department.towns;
                foreach (Town town in towns)
                {
                    int idDepartment = department.id;
                    int idTown = town.id;
                    string nameDepartment = department.name;
                    string nameTown = town.name;
                    string type = town.type;
                    bool add = false;
                    switch (index)
                    {
                        case 0:
                            Console.WriteLine(type);
                            if (type.Equals(Town.MUNICIPIO))
                            {
                                add = true;
                            }
                            break;
                        case 1:
                            if (type.Equals(Town.ISLA))
                            {
                                add = true;
                            }
                            break;
                        case 2:
                            if (type.Equals(Town.NO_MUNICIPALIZADA))
                            {
                                add = true;
                            }
                            break;
                        default:
                            add = true;
                            break;
                    }
                    if (add)
                    {
                        AllTowns all = new AllTowns(idDepartment, idTown, nameDepartment, nameTown, type);
                        townsGrid.Add(all);
                    }
                }
            }
            dataGridView1.DataSource = townsGrid;

        }
    }

}
