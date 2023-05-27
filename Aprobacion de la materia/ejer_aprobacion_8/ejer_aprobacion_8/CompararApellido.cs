using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    public class CompararApellido : IComparer<Persona>
    {
        public int Compare(Persona x, Persona y)
        {
            return string.Compare(x.apellido, y.apellido);
        }
    }
}
