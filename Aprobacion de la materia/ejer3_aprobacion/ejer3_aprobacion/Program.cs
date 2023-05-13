using System;


namespace ejer3_aprobacion
{
    internal class Program
    {
        class password
        {

            public int longitud;
            public string contraseña;
            public static Random rnd = new Random();

            public int Longitud 
            { 
            get { return longitud; }
            set { longitud = value; }
            }

            public string Contraseña
            {
                get { return contraseña; }
            }

            public password()
            {
                longitud = 8;
                contraseña = generarpassword(longitud);
            }
            public password (int longitud)
            {
                this.longitud = longitud;
                contraseña = generarpassword(longitud);
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

            public static string generarpassword(int longitud)
            {
                string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                char[] contraseña = new char[longitud];

                for (int i = 0; i < longitud; i++) { 
                    contraseña[i] = caracteres[rnd.Next(caracteres.Length)];
                }

                return new string(contraseña);
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
