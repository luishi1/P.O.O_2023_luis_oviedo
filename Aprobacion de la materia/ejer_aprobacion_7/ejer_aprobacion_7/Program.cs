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
    class Raices
    {
        public double a;
        public double b;
        public double c;

        public Raices( double a , double b , double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }


        public double getDescriminante()
        {
            double descriminante = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            return descriminante;
        }
        public void obtenerRaices()
        {
            double descriminante = getDescriminante();
            if (descriminante  >= 0)
            {
            double x1 = ( -b + descriminante) / a * 2;
            double x2 = (-b - descriminante) / a * 2;

                if (x1 == x2)
                {
                    Console.WriteLine("El resultado es " + x1);
                }
                else if( x1 != x2)
                {
                    Console.WriteLine("El resultado es " + x1 + " y " + x2);
                }    
            }
            else
            {
                Console.WriteLine("No tiene raices reales");
            }
        }

        // public void obtenerRaiz()
        // {
        // double descriminante = getDescriminante();
        // if (tieneRaiz())
        // {
        // double x = -b / a * 2;
        // Console.WriteLine("tiene una unica raiz que es" + x);
        // }
        // else
        // {
        // Console.WriteLine("No tiene raiz unica");
        // }
        // }

        public bool tieneRaices() 
        {
            double descriminante = getDescriminante();
            return descriminante >= 0;
        }
        public bool tieneRaiz()
        {
            double descriminante = getDescriminante();
            return descriminante == 0;
        }

        public void calcular()
        {
            double descriminante = getDescriminante();
            if (tieneRaices())
            {
                obtenerRaices();
            }
            else if (tieneRaiz())
            {
                obtenerRaices();
            }
            else
            {
                Console.WriteLine("la ecuacion no posee una solucion que pertenezca al conjunto de los numeros Reales");
            }
        }
    }


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