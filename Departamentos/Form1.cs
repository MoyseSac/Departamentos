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
namespace Departamentos
{
    public partial class Form1 : Form
    {
        List<Departamento> depas = new List<Departamento>();

        public Form1()
        {
            InitializeComponent();
        }



        private void comboBox1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\Moise\\source\\repos\\Departamentos\\Departamentos\\bin\\Debug\\Departamentos.txt");
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (!EsID(line)) {
                        comboBox1.Items.Add(line);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private bool EsID(string line) {

            return line.Length == 4 && line.All(char.IsDigit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargarDepartamentos();
            escribirTemperatura();

        }

        private void escribirTemperatura()
        {
            cargarCalendario();
            string fileName = "Temperaturas.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(stream))
            {
                if (comboBox1.SelectedItem == null || textTemperatura ==null)
                {
                    labelCombo.Text = "Debe llenar toda la informacion";
                }
                else {
                    string dep = comboBox1.SelectedItem.ToString();
                    writer.WriteLine(dep);
                    DateTime fecha;
                    fecha = dateTimePicker1.Value;
                    writer.WriteLine(fecha);   
                    int temp = Convert.ToInt32(textTemperatura.Text);  
                    writer.WriteLine(temp);
                }

            }
        }


        private void cargarCalendario(){

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }

        private void cargarDepartamentos() {

            string fileName = "Departamentos.txt";
            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {

                Departamento depa = new Departamento();
                depa.Id= Convert.ToInt16(reader.ReadLine());
                depa.NombreDep = reader.ReadLine(); 
                depas.Add(depa);

            }
            reader.Close();
        }
    }
}
