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
        public Form1()
        {
            InitializeComponent();
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
    }
}
