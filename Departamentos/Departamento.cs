using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Departamentos
{
    internal class Departamento
    {
        int id;
        string nombreDep;

        public int Id { get => id; set => id = value; }
        public string NombreDep { get => nombreDep; set => nombreDep = value; }
    }
}
