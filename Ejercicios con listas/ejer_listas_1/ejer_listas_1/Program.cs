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

        public persona(string nombre, string apellido , int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }
        public void generar(string[] nombres , string[] apellidos , Random r1 , List<persona>list)
        {
            string nombre = nombres[r1.Next(nombres.Length)];
            string apellido = apellidos[r1.Next(apellidos.Length)];

            list.Add(new persona(nombre , apellido , r1.Next(1,80)));
        }

        public void mostrar(List<persona> list)
        {
            foreach (persona p in list)
            {
                Console.WriteLine(p.nombre +" "+ p.apellido + " " + p.edad +" años");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            pantalla pantalla = new pantalla();
            persona persona1 = new persona("ale" , "Oviedo" , 16);
            string[] nombres = 
            { "Luis" , "Tobias" , "Thiago" , "Gaspar", "Lautaro" ,"Matias" ,"Gonzalo" ,"Felipe" ,"Luca" ,"Alejandro" ,
            "Nazareno" , "Joseph" ,"Gabriel" ,"Maximiliano" ,"Lucio" , "Santino" , "Mike" ,"Tamara" ,"Angie" ,"Azul" ,
            "Sofia" ,"Antonella" ,"Claudia" ,"Constanza" , "Ashley" , "Abraham" ,"Barack" ,"Will" ,"Shakira" , "Michael" , "Lionel"};

            string[] apellidos = 
            { "Oviedo" , "Coman" , "Magdalena" , "Kappou", "Del campo" ,"Speranza" ,"Benavente" ,"Canepa" ,"Folco" ,"Maldonado" ,
            "Castro" , "Shupingagua" ,"Volcan" ,"Bocutti" ,"Dibman" , "Constantino" , "Noble" ,"Rojas" ,"Ventura" ,"Nusdeo" , 
            "Zabalsa" ,"Vega" ,"Vergara" ,"Blanca" , "Aguero" , "Lincoln" ,"Obama" ,"Smith" ,"Ripoll " ,"Jackson" , "Messi"};

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

            for (int i = 0; i < 5; i++)
            {
                persona1.generar(nombres ,apellidos , rand , list);
            }

            list.Sort((x, y) => x.apellido.CompareTo(y.apellido));
            persona1.mostrar(list);
            Console.WriteLine("Argentina tiene una poblacion de " + list.Count + " personas");

            while (true)
            {
                horaActual = DateTime.Now;
                TimeSpan tiempo = horaActual - hora;
                TimeSpan nacimientos = horaActual - nacimiento;
                TimeSpan fallecimientos = horaActual - muerte;
                TimeSpan refresh = horaActual - recargar;

                if (refresh.Seconds % pantalla.recargar == 0 && refresco == false)
                {
                    Console.Clear();
                    list.Sort((x, y) => x.apellido.CompareTo(y.apellido));
                    persona1.mostrar(list);
                    refresco = true;
                    recargar = DateTime.Now;
                    Console.WriteLine("Argentina tiene una poblacion de " + list.Count + " personas");
                }
                if (refresh.Seconds == 1)
                {
                    refresco = false;
                }

                if (nacimientos.Seconds % pantalla.nacimientos == 0 && nacer == false)
                {
                    persona1.generar(nombres, apellidos, rand, list);
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
//Ejercicio 1
//En argentina tenemos personas que nacen cada 30 segundos y personas que fallecen cada 60 segundos. 
//1.Crear personas con nombres y apellidos random;
//2.Mostrar la lista de personas cada 10 segundos para que se pueda refrescar la informacion que tenemos
//3. Informar siempre cuantas personas tiene Argentina.

