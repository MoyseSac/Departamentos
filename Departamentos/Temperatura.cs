using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos
{
    internal class Temperatura
    {

        int fecha;
        string nombreDep;
        int temp;

        public int Fecha { get => fecha; set => fecha = value; }
        public string NombreDep { get => nombreDep; set => nombreDep = value; }
        public int Temp { get => temp; set => temp = value; }
    }
}
