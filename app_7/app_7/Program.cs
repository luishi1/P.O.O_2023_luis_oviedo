using System;

namespace app_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cantidad;
            int maximo;
            int minimo;
            Console.Write("Ingrese la cantidad de numero que va a ingresar: ");
            cantidad = int.Parse(Console.ReadLine());
            int[] numeros = new int[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Ingrese un numero: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            maximo = numeros[0];
            minimo = numeros[0];

            //ordenamientos php
            for (int i = 1; i < cantidad; i++)
            {
                if (numeros[i] > maximo)
                {
                    maximo = numeros[i];
                }

                if (numeros[i] < minimo)
                {
                    minimo = numeros[i];
                }
            }

            Console.WriteLine("El numero más grande es: "+ maximo);
            Console.WriteLine("El numero más pequeño es: "+ minimo);
        }
    }
}
//7. Crear un programa que permita al usuario ingresar una serie de números y determine cuál es el número más grande y
//cuál es el número más pequeño.
