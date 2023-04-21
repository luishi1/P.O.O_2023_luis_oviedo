using System;

namespace app3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rd = new Random();
            int random = rd.Next(1, 100);
            int numero;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("JUGUEMOS  UN JUEGO INGRESE UN NUMERO DEL 1 AL 100 Y SI LO ADIVINA GANA :)");
                numero = int.Parse(Console.ReadLine());

                if (numero == random)
                {
                    Console.WriteLine("FELICIDADES GANASTE");
                    break;
                }

                Console.WriteLine("FALLASTE VUELVA A INTENTAR");
                Console.ReadKey();

            }
        }
    }
}
//Crear un programa que simule un juego de adivinanza de números, en el que el usuario debe adivinar un número generado aleatoriamente por el programa.
