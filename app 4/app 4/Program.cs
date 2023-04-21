using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_4
{
    internal class Program
    {
        static bool EsPrimo(int numero)
        {
            for (int i = 2; i < numero; i++)
            {
                if ((numero % i) == 0)
                {
                    // No es primo 🙁
                    return false;
                }
            }

            // Es primo 🙂
            return true;
        }
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("ingrese un numero ");
            num = int.Parse(Console.ReadLine());
            if (EsPrimo(num))
            {
               
            }
            else
            {
                //No es un número primo
            }
        }
    }
}
