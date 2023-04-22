using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_10
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int opcion, opcion2;
            double grados;
            double C;
            double F;
            double K;
            double conversion;
            while (true)
            {
            Console.Clear();
            Console.WriteLine("    ESCALAS TERMONOMETRICAS ");
            Console.WriteLine("ingrese un valor para la conversion");
            grados = double.Parse(Console.ReadLine());
            Console.WriteLine("elija la opcion que es el valor que ingreso");
            Console.WriteLine("1 . Celcius");
            Console.WriteLine("2 . Kelvin");
            Console.WriteLine("3 . Fahrenheit");
            opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese que accion quiere realizar");
                    Console.WriteLine("1 . Quiere transformar Celcius a Kelvin");
                    Console.WriteLine("2 . Quiere transformar Celcius a Fahrenheit");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 1)
                    {
                        conversion = grados + 273;
                        Console.WriteLine("transformamos "+ grados + "°C a " + conversion + "°K");
                        Console.ReadKey();
                    }
                    if (opcion2 == 2)
                    {
                        conversion = grados * 1.8 + 32;
                        Console.WriteLine("transformamos " + grados + "°C a " + conversion + "°F");
                        Console.ReadKey();
                    }
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese que accion quiere realizar");
                    Console.WriteLine("1 . Quiere transformar Kelvin a Celcius");
                    Console.WriteLine("2 . Quiere transformar Kelvin a Fahrenheit");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 1)
                    {
                        conversion = grados - 273;
                        Console.WriteLine("transformamos " + grados + "°K a " + conversion + "°C");
                        Console.ReadKey();
                    }
                    if (opcion2 == 2)
                    {
                        conversion = (grados-273) * 1.8 + 32;
                        Console.WriteLine("transformamos " + grados + "°K a " + conversion + "°F");
                        Console.ReadKey();
                    }
                }
                if (opcion == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese que accion quiere realizar");
                    Console.WriteLine("1 . Quiere transformar Fahrenheit a Celcius");
                    Console.WriteLine("2 . Quiere transformar Fahrenheit a Kelvin");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 1)
                    {
                        conversion = (grados-32) / 1.8;
                        Console.WriteLine("transformamos " + grados + "°F a " + conversion + "°C");
                        Console.ReadKey();
                    }
                    if (opcion2 == 2)
                    {
                        conversion = (grados - 32) * 5/9 + 273;
                        Console.WriteLine("transformamos " + grados + "°F a " + conversion + "°K");
                        Console.ReadKey();
                    }
                }
            }
    }
    }
}
//Crear un programa que permita al usuario convertir una cantidad de una unidad de medida a otra, por ejemplo, de metros a pies
