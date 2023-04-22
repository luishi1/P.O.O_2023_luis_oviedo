using System;

namespace app_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1;
            double y1;
            double x2;
            double y2;
            double r;
            Console.WriteLine("Ingrese un valor para X1");
            x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un valor para Y1");
            y1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un valor para X2");
            x2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese un valor para Y2");
            y2 = double.Parse(Console.ReadLine());
            r = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            //Math.Pow es un método en C# que calcula la potencia de un número
            //Math.Sqrt es un método que calcula la raíz cuadrada de un número
            Console.WriteLine(r + " Es la distancia que hay entre (" + x1 + ";" + y1+") y ("+x2 + ";" + y2 +")");

        }
    }
}
//crear un programa que permita al usuario calcular la distancia entre dos puntos en un plano cartesiano.