using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string sexo { get; set; }

        public string diferenciarGenero()
        {
            if (nombre == "Evelyn" || nombre == "Tamara" || nombre == "Claudia" || nombre == "Angie" || nombre == "Azul"
            || nombre == "Sofia" || nombre == "Emma" || nombre == "Graciela" || nombre == "Estella" || nombre == "Sandra")
            {
                sexo = "Mujer";
                return sexo;
            }
            else
            {
                sexo = "Hombre";
                return sexo;
            }
        }
    }
}
