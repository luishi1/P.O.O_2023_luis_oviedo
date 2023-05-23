using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a;
            double b;
            double c;
            while(true) 
            {
                Console.Clear();
                Console.WriteLine("Ingrese valores para los siguientes numeros");
                Console.Write("Valor para A: ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Valor para B: ");
                b = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.Write("Valor para C: ");
                c = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                Console.Clear();
                Raices ecuacion = new Raices(a , b , c);
                ecuacion.calcular();
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para ingresar otros valores");
                Console.ReadKey();
            }
        }
    }
}
//comento la funcion de tener una raiz por que esta al pedo pero la hice solo por que la pedia el ejer xd
//no se si esta bien asi creo que si
