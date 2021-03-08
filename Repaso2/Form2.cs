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
    public partial class Form2 : Form
    {
        List<Alquiler> alquileres = new List<Alquiler>();
        public Form2()
        {
            InitializeComponent();
            Leer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alquiler alqTemp = new Alquiler();
            alqTemp.Nit = Int32.Parse(textBox1.Text);
            alqTemp.Placa = Int32.Parse(textBox2.Text);
            alqTemp.Inicio = monthCalendar1.SelectionStart;
            alqTemp.Fin = monthCalendar2.SelectionStart;
            alqTemp.Kilometros = Int32.Parse(textBox3.Text);
            alquileres.Add(alqTemp);
            FileStream stream = new FileStream("alquiler.txt", FileMode.OpenOrCreate, FileAccess.Write);

            StreamWriter writer = new StreamWriter(stream);

            foreach (var a in alquileres)
            {
                writer.WriteLine(a.Nit);
                writer.WriteLine(a.Placa);
                writer.WriteLine(a.Inicio);
                writer.WriteLine(a.Fin);
                writer.WriteLine(a.Kilometros);
            }
            writer.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void Leer()
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
                alquileres.Add(alqTemp);

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
