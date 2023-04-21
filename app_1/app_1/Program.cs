using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_1
{
    class numero
    {
        public float num;
        
        public numero(float num)
        {
            this.num = num;
        }

        public void promedio(List<numero> list)
        {
            float total = 0;
            float cantidad = list.Count;
            for (int i = 0; i < cantidad; i++)
            {
                total = total + list[i].num;
            }
            float promedio = total / cantidad;
            Console.WriteLine("Cantidad de datos ingresados :" , cantidad);
            Console.WriteLine("Suma de los numeros en total es :", total);
            Console.WriteLine("El promedio es :", promedio);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            numero numeral = new numero(2);
            float num;
            int opcion;
            List<numero> list = new List<numero>();
            while (true)
            {

                Console.WriteLine("ELIJA LA OPCION (por favor valores validos)");
                Console.WriteLine("1.Ingresar numero");
                Console.WriteLine("2.Calcular promedio");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingresa un numero");
                    num = float.Parse(Console.ReadLine());
                    list.Add(new numero(num));
                    Console.ReadKey();
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Datos ingresados");
                    numeral.promedio(list);
                    Console.ReadKey();

                }



            }
            
        }
    }
}
