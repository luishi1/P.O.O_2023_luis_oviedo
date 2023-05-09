using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3_aprobacion
{
    internal class Program
    {
        class password
        {
            public int longitud { 
            get { return longitud; }
            set { longitud = value; }
            }

            public string contraseña
            {
                get { return contraseña; }
                set { contraseña = value; }
            }

            public password() { }

            public password (int longitud)
            {
                this.longitud = longitud;
                Random rnd = new Random();
                
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
