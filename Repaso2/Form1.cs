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

namespace Repaso2
{
    public partial class Form1 : Form
    {
        List<Vehiculo> vehiculos = new List<Vehiculo>();
        public Form1()
        {
            InitializeComponent();
            Leer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            bool existe = vehiculos.Exists(v => v.Placa == Convert.ToInt32(textBox1.Text));

            //si existe indicarlo con un Messagebox
            if (existe)
            {
                MessageBox.Show("Esa placa ya existe", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Vehiculo vehiculo = new Vehiculo();

                vehiculo.Placa = Convert.ToInt32(textBox1.Text);
                vehiculo.Marca = textBox2.Text;
                vehiculo.Modelo = textBox3.Text;
                vehiculo.Color = textBox4.Text;
                vehiculo.Precio = float.Parse(textBox5.Text);
                vehiculos.Add(vehiculo);
                guardar();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
            private void Leer()
            {
                FileStream stream = new FileStream(@"..\..\vehiculos.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);

                while (reader.Peek() > -1)
                {
                    Vehiculo vehiculoTemp = new Vehiculo();
                    vehiculoTemp.Placa = Int32.Parse(reader.ReadLine());
                    vehiculoTemp.Marca = reader.ReadLine();
                    vehiculoTemp.Modelo = reader.ReadLine();
                    vehiculoTemp.Color = reader.ReadLine();
                    vehiculoTemp.Precio = float.Parse(reader.ReadLine());

                    vehiculos.Add(vehiculoTemp);

                }
                reader.Close();
            }

            private void button3_Click(object sender, EventArgs e)
            {
                Form3 f3 = new Form3();
                this.Hide();
                f3.ShowDialog();
                this.Close();
            }
            private void guardar()
            {
                FileStream stream = new FileStream(@"..\..\vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);

                StreamWriter writer = new StreamWriter(stream);

                foreach (var v in vehiculos)
                {
                    writer.WriteLine(v.Placa);
                    writer.WriteLine(v.Marca);
                    writer.WriteLine(v.Modelo);
                    writer.WriteLine(v.Color);
                    writer.WriteLine(v.Precio);
                }
                writer.Close();
            }
        
    }
}
