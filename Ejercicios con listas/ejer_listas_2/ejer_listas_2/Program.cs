using System;
using System.Collections.Generic;

namespace ejer_listas_1
{
    class pantalla
    {
        public int recargar = 10;
        public int fallecimientos = 60;
        public int nacimientos = 30;

    }

    class persona
    {
        public string nombre;
        public string apellido;
        public int edad;
        public string nacionalidad;

        public string NombreCompleto
        {
            get
            {
                return nombre + ' ' + apellido;
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }
        }
        public string Nacionalidad
        {
            get
            {
                return nacionalidad;
            }
        }

        public persona(string nombre, string apellido, int edad , string nacionalidad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.nacionalidad = nacionalidad;
        }
        public void generar(string[] nombres, string[] apellidos, string[] nacionalidades, Random r1, List<persona> list)
        {
            string nombre = nombres[r1.Next(nombres.Length)];
            string apellido = apellidos[r1.Next(apellidos.Length)];
            string nacionalidad = nacionalidades[r1.Next(nacionalidades.Length)];

            list.Add(new persona(nombre, apellido, r1.Next(1, 80), nacionalidad));
        }

        public void mostrar(List<persona> list)
        {
            foreach (persona p in list)
            {
                Console.WriteLine(p.nombre + " " + p.apellido + " " + p.edad + " años ," + p.nacionalidad);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            pantalla pantalla = new pantalla();
            persona persona1 = new persona("ale", "Oviedo", 16 , "argentina");
            string[] nombres =
            { "Luis" , "Tobias" , "Thiago" , "Gaspar", "Lautaro" ,"Matias" ,"Gonzalo" ,"Felipe" ,"Luca" ,"Alejandro" ,
            "Nazareno" , "Joseph" ,"Gabriel" ,"Maximiliano" ,"Lucio" , "Santino" , "Mike" ,"Tamara" ,"Angie" ,"Azul" ,
            "Sofia" ,"Antonella" ,"Claudia" ,"Constanza" , "Ashley" , "Abraham" ,"Barack" ,"Will" ,"Shakira" , "Michael" , "Lionel"};

            string[] apellidos =
            { "Oviedo" , "Coman" , "Magdalena" , "Kappou", "Del campo" ,"Speranza" ,"Benavente" ,"Canepa" ,"Folco" ,"Maldonado" ,
            "Castro" , "Shupingagua" ,"Volcan" ,"Bocutti" ,"Dibman" , "Constantino" , "Noble" ,"Rojas" ,"Ventura" ,"Nusdeo" ,
            "Zabalsa" ,"Vega" ,"Vergara" ,"Blanca" , "Aguero" , "Lincoln" ,"Obama" ,"Smith" ,"Ripoll " ,"Jackson" , "Messi"};

            string[] nacionalidades ={ "Argentina" , "Brasil" , "Paraguay" };

            Random rand = new Random();

            List<persona> list = new List<persona>();

            DateTime hora = DateTime.Now;
            DateTime horaActual;

            DateTime nacimiento = DateTime.Now;
            DateTime muerte = DateTime.Now;
            DateTime recargar = DateTime.Now;

            bool nacer = true;
            bool morir = true;
            bool refresco = true;

           
            for (int i = 0; i < 15; i++)
            {
                persona1.generar(nombres, apellidos, nacionalidades, rand, list);
            }

            list.Sort((x, y) => x.apellido.CompareTo(y.apellido));
            list.Sort((x, y) => x.nacionalidad.CompareTo(y.nacionalidad));

            persona1.mostrar(list);
            while (true)
            {
                int arg = 0;
                int br = 0;
                int par = 0;

                horaActual = DateTime.Now;
                TimeSpan tiempo = horaActual - hora;
                TimeSpan nacimientos = horaActual - nacimiento;
                TimeSpan fallecimientos = horaActual - muerte;
                TimeSpan refresh = horaActual - recargar;

                if (refresh.Seconds % pantalla.recargar == 0 && refresco == false)
                {
                    Console.Clear();
                    foreach (persona p in list)
                    {
                        if (p.nacionalidad == "Argentina")
                        {
                            arg++;
                        }
                        if (p.nacionalidad == "Brasil")
                        {
                            br++;
                        }
                        if (p.nacionalidad == "Paraguay")
                        {
                            par++;
                        }
                    }
                    list.Sort((x, y) => x.apellido.CompareTo(y.apellido));
                    list.Sort((x, y) => x.nacionalidad.CompareTo(y.nacionalidad));

                    persona1.mostrar(list);
                    refresco = true;
                    recargar = DateTime.Now;

                    Console.WriteLine("");
                    Console.WriteLine("Argentina tiene una poblacion de " + arg + " personas");
                    Console.WriteLine("Brasil tiene una poblacion de " + br + " personas");
                    Console.WriteLine("Paraguay tiene una poblacion de " + par + " personas");
              
                    
                }
                if (refresh.Seconds == 1)
                {
                    refresco = false;
                  
                }

                if (nacimientos.Seconds % pantalla.nacimientos == 0 && nacer == false)
                {
                    persona1.generar(nombres, apellidos, nacionalidades, rand, list);

                    nacer = true;
                    nacimiento = DateTime.Now;
                }
                if (nacimientos.Seconds == 1)
                {
                    nacer = false;
                }


                if (fallecimientos.Seconds % pantalla.fallecimientos == 0 && morir == false)
                {
                    int random = rand.Next(0, list.Count);
                    list.RemoveAt(random);   
                    morir = true;
                    muerte = DateTime.Now;
                }
                if (fallecimientos.Seconds == 1)
                {
                    morir = false;
                }
            }
        }
    }
}
//Ejercicio 2
//Mismo caso anterior pero ahora tenemos 3 paises, Argentina, Paraguay y Brasil. 
//Sumado a esto en cada pais van a nacer personas pero el tiempo para cada pais va a ser random
//1. Mostrar la informacion anterior pero ordenada por apellido y dividida por pais
//2. Informar cuantas personas hay en cada pais

