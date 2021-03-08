using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repaso2
{
    class Alquiler
    {
        int nit;
        int placa;
        DateTime inicio;
        DateTime fin;
        int kilometros;

        public int Nit { get => nit; set => nit = value; }
        public int Placa { get => placa; set => placa = value; }
        public DateTime Inicio { get => inicio; set => inicio = value; }
        public DateTime Fin { get => fin; set => fin = value; }
        public int Kilometros { get => kilometros; set => kilometros = value; }
    }
}
