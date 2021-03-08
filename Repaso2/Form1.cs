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

            //VERIFICAR SI YA EXISTE EL VEHICULO A TRAVEZ DE LA PLACA
            for (int i = 0; i < vehiculos.Count; i++)
            {
                if (Int32.Parse(textBox1.Text) == vehiculos[i].Placa)
                {
                    MessageBox.Show(" este vehiculo ya existe en el sistema!");
                }
                else
                {
                    Vehiculo vehiculoTemp = new Vehiculo();
                    vehiculoTemp.Placa = Int32.Parse(textBox1.Text);
                    vehiculoTemp.Marca = textBox2.Text;
                    vehiculoTemp.Modelo = textBox3.Text;
                    vehiculoTemp.Color = textBox4.Text;
                    vehiculoTemp.Precio = float.Parse(textBox5.Text);
                    vehiculos.Add(vehiculoTemp);

                    FileStream stream = new FileStream("vehiculos.txt", FileMode.OpenOrCreate, FileAccess.Write);

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

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

        }
        private void Leer()
        {
            FileStream stream = new FileStream("vehiculos.txt", FileMode.Open, FileAccess.Read);
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
    }
}
