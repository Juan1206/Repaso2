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
    public partial class Form3 : Form
    {
        List<Cliente> l1 = new List<Cliente>();
        List<Vehiculo> l2 = new List<Vehiculo>();
        List<Alquiler> l3 = new List<Alquiler>();
        List<Calculo> datos = new List<Calculo>();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            this.Hide();
            fm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Leer();
            Leer2();
            Leer3();
            Mostrar();
            Mostrar2();
        }
        private void Leer()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Cliente clienteTemp = new Cliente();

                clienteTemp.Nit = Int32.Parse(reader.ReadLine());
                clienteTemp.Nombre = reader.ReadLine();
                clienteTemp.Direccion = reader.ReadLine();
                l1.Add(clienteTemp);

            }
            reader.Close();
        }
        private void Leer2()
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

                l2.Add(vehiculoTemp);

            }
            reader.Close();
        }
        private void Leer3()
        {
            FileStream stream = new FileStream("alquiler.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alquiler alqTemp = new Alquiler();
                alqTemp.Nit = Int32.Parse(reader.ReadLine());
                alqTemp.Placa = Int32.Parse(reader.ReadLine());
                alqTemp.Inicio = Convert.ToDateTime(reader.ReadLine());
                alqTemp.Fin = Convert.ToDateTime(reader.ReadLine());
                alqTemp.Kilometros = Int32.Parse(reader.ReadLine());
                l3.Add(alqTemp);

            }
            reader.Close();
        }
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = l1;
            dataGridView1.Refresh();
        }
        private void Mostrar2()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = l2;
            dataGridView2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < l2.Count; i++)
            {
                for (int j = 0; j < l3.Count; j++)
                {                 
                    if (l2[i].Placa == l3[j].Placa)
                    {
                        Calculo dato = new Calculo();
                        //guardamos el número de empleado
                        dato.Placa = l2[i].Placa;
                        dato.Nombre = l1[j].Nombre;
                        dato.Marca= l2[i].Marca;
                        dato.Modelo = l2[i].Modelo;
                        dato.Color = l2[i].Color;
                        dato.Precio_por_Kilometro = l2[i].Precio;
                        dato.Fecha_de_Devolucion = l3[j].Fin;
                        dato.Total_a_pagar = l2[i].Precio * l3[j].Kilometros;

                        ////Guardamos en la lista 
                        datos.Add(dato);
                    }
                }
            }
            //Mostrar en el gridview la lista de empleadoSueldos
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = datos;
            dataGridView3.Refresh();

        }
    }
}
