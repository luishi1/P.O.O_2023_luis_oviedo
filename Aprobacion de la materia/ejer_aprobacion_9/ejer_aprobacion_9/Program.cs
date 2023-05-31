using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cine salaCine = new Cine("Los Guardianes de la Galaxia VOL.3" , 780);
            Console.WriteLine("SALA 1 --> PELICULA : " + salaCine.titulo);
            salaCine.Simulacion();
        }
    }
}
