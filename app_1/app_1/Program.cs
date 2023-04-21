using System;
using System.Collections.Generic;

namespace app_1
{
    class numero
    {
        public int num;
        
        public numero(int num)
        {
            this.num = num;
        }

        public void promedio(List<numero> list)
        {
            int total = 0;
            float promedio;
            foreach (numero n in list)
            {
                total = total + n.num;
            }
            promedio = total / list.Count;
            Console.WriteLine("La suma total de todos los numeros es : " + total);
            Console.WriteLine("El promedio es: "+ promedio);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            numero numero1 = new numero(1);
            int cant = 0;
            int num;
            List<numero> list = new List<numero>();

            Console.WriteLine("Ingrese cuantos numeros decide ingresar");
            cant = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < cant; i++) { 
            
                Console.WriteLine("Ingrese un numero");
                num = int.Parse(Console.ReadLine());
                list.Add(new numero(num));
                Console.WriteLine("Numero ingresado correctamente");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Datos ingresados");
            Console.WriteLine("cantidad de numeros: "+cant);
            numero1.promedio(list);
            

        }
    }
}
