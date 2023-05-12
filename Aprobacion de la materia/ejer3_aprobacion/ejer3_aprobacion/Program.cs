using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer3_aprobacion
{
    internal class Program
    {
        class password
        {

            public int longitud = 8;
            public string contraseña;

            public int Longitud 
            { 
            get { return longitud; }
            set { longitud = value; }
            }

            public string Contraseña
            {
                get { return contraseña; }
            }

            public password() { }

            public password (int longitud)
            {
                this.longitud = longitud;
                generarpassword();
            }

            public bool esfuerte()
            {
                int cantmayus = 0;
                int cantminus = 0;
                int numeros = 0;

                foreach (char caracter in contraseña)
                {
                    if (char.IsLower(caracter))
                    {
                        cantminus++;
                    }
                    else if (char.IsUpper(caracter))
                    {
                        cantmayus++;
                    }
                    if (char.IsDigit(caracter))
                    {
                        numeros++;
                    }
                }
                return cantmayus > 1 && cantminus > 2 && numeros > 5;
            }

            public void generarpassword()
            {
                string opa = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random rnd = new Random();
                char[] passwordARRAY = new char[longitud];

                for (int i = 0; i < longitud; i++)
                {
                    passwordARRAY[i] = opa[rnd.Next(opa.Length)];
                }

                contraseña = new string(passwordARRAY);
            }
        }

        static void Main(string[] args)
        {
            int cantidad;
            int longitud;

            Console.Write("Ingrese la longitud del Array: ");
            cantidad = int.Parse(Console.ReadLine());

            Console.Write("Ingrese la longitud para la contraseña: ");
            longitud = int.Parse(Console.ReadLine());


            password[] contraseñas = new password[cantidad];
            bool[] Contrafuertepregunta = new bool[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                contraseñas[i] = new password(longitud);
                Contrafuertepregunta[i] = contraseñas[i].esfuerte();
            }
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine("Contraseña {0}: {1}  ||  Es fuerte: {2}", i + 1, contraseñas[i].Contraseña, Contrafuertepregunta[i]);
            }

            Console.ReadKey();
        }   
    }
}

//falta que la contraseña sea random a la hora de crearse
