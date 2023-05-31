using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_9
{
    public class Espectador
    {
        public string nombre;
        public int edad;
        public int dinero;

        public Espectador(string nombre, int edad, int dinero)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dinero = dinero;
        }
    }
}
