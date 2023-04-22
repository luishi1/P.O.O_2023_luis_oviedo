using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app5
{
    internal class Program
    {
        static bool adivinada(string palabra, string letras)
        {
            foreach (char letra in palabra)
            {
                if (!letras.Contains(letra.ToString()))
                {
                    return false;
                }
            }

            return true;
        }

        static string obtenerPalabra(string palabra, string letras)
        {
            string palabraAdivinada = "";

            foreach (char letra in palabra)
            {
                if (letras.Contains(letra.ToString()))
                {
                    palabraAdivinada += letra;
                }
                else
                {
                    palabraAdivinada += "_ ";
                }
            }

            return palabraAdivinada;
        }
        static void Main(string[] args)
        {
            //char admite operadores de comparación, igualdad, incremento y decremento. Además, en el caso de los operandos char, los operadores aritméticos y lógicos bit a bit realizan una operación en los códigos de caracteres correspondientes y producen el resultado del tipo int.
            string[] palabras = { "manzana" , "amor" , "ordinario" , "dos" , "encantador" , "informacion" , "conocer" , "brillo" , "comediantes" , "renacer" };
            string palabraOculta = palabras[new Random().Next(0, palabras.Length)];//genera cualquier de las opciones que posee el array de palabras
            int intentos = 6; //cantidad de intentos posibles
            string letras = "";
            //mientras los intentos sean mayores a 0 y la funcion adivinada tire falso se cumple
            while (intentos > 0 && !adivinada(palabraOculta, letras))
            {
                Console.Clear();
                Console.WriteLine("Ingrese una letra para adivinar la palabra oculta");
                //KeyChar propiedad para muestrear pulsaciones de tecla en tiempo de ejecución y para modificar las pulsaciones de tecla en circunstancias especiales en tiempo de ejecución.
                //ingresamos la letra de la palbra
                //readkey y que key char sirven para que solo ingree un digitoen caso que quiera entregar mas
                char letraingresada = Console.ReadKey().KeyChar; 
                Console.WriteLine();

                //variaciones
                if (palabraOculta.Contains(letraingresada))
                {
                    Console.WriteLine("Letra correcta");
                    letras += letraingresada;
                }
                else
                {
                    Console.WriteLine("Letra incorrecta");
                    intentos--;
                }
                Console.WriteLine("Te quedan "+ intentos +" intentos");
                Console.WriteLine("Palabra adivinada: " + obtenerPalabra(palabraOculta, letras));
                Console.ReadKey();


                if (adivinada(palabraOculta, letras))
                {
                    Console.WriteLine("Felicidades acertaste la palabra " + palabraOculta);
                }
                else
                {
                    Console.WriteLine("Mal ahi no lograste adivinar la palabra , la palabra era "+ palabraOculta );
                }
            }
        }
    }
}
