using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    class Calculo
    {
        string nombre;
        int placa;
        string marca;
        string modelo;
        string color;
        float precio_por_Kilometro;
        DateTime fecha_de_Devolucion;
        float total_a_pagar;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Placa { get => placa; set => placa = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Color { get => color; set => color = value; }
        public float Precio_por_Kilometro { get => precio_por_Kilometro; set => precio_por_Kilometro = value; }
        public DateTime Fecha_de_Devolucion { get => fecha_de_Devolucion; set => fecha_de_Devolucion = value; }
        public float Total_a_pagar { get => total_a_pagar; set => total_a_pagar = value; }
    }
}
