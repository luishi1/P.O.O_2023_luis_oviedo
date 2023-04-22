using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_4
{
    internal class Program
    {
        
            static bool Primo(int num)
            {
                if (num <= 1)
                {
                    return false;
                }
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            static void Main(string[] args)
            {

                Console.Write("Ingrese un numero: ");
                int limite = int.Parse(Console.ReadLine());

                Console.WriteLine("La lista de números primos hasta " + limite + " es:");

                for (int num = 2; num <= limite; num++)
                {
                    if (Primo(num))
                    {
                    Console.WriteLine(num);
                    }
                }
            }
        }
    }

