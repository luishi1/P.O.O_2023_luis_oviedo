using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ejer5_aprobacion
{
    internal class Program
    {
        class Serie
        {
            //constantes
           

            //variables
            public string titulo;
            public int num_temp = 3;
            public bool entregado = false;
            public string genero;
            public string creador;

            //atributos y constructores
            public string Titulo
            {
                get { return titulo; }
                set { titulo = value; }
            }

            public int Num_temp
            {
                get { return num_temp; }
                set { num_temp = value; }
            }

            public string Genero
            {
                get { return genero; }
                set { genero = value; }
            }

            public string Creador
            {
                get { return creador; }
                set { creador = value; }
            }

            public Serie()
            {
                this.titulo = Titulo;
                this.num_temp = Num_temp;
                this.genero = Genero;
                this.creador = Creador;
            }

            public Serie(string titulo, string creador)
            {
                this.titulo = titulo;
                this.num_temp = Num_temp;
                this.genero = Genero;
                this.creador = creador;
            }

            public Serie(string titulo, int num_temp, string genero, string creador)
            {
                this.titulo = titulo;
                this.num_temp = num_temp;
                this.genero = genero;
                this.creador = creador;
            }

            //crear 
            static public Serie nuevaserie(string titulo, string creador)
            {
                return new Serie(titulo, creador);
            }
            static public Serie nuevaserie(string titulo, int num_temp, string genero, string creador)
            {
                return new Serie(titulo, num_temp, genero, creador);
            }

        }
        class Videojuego
        {

            //variables
            public string titulo;
            public int horas = 10 ;
            public bool entregado = false;
            public string genero;
            public string compania;


            //atributos y constructores
            public string Titulo
            {
                get { return titulo; }
                set { titulo = value; }
            }

            public int Horas
            {
                get { return horas; }
                set { horas = value; }
            }

            public string Genero
            {
                get { return genero; }
                set { genero = value; }
            }

            public string Compania
            {
                get { return compania; }
                set { compania = value; }
            }



            public Videojuego()
            {
                this.titulo = Titulo;
                this.horas = Horas;
                this.genero = Genero;
                this.compania = Compania;
            }

            public Videojuego(string titulo, int horasEstimadas)
            {
                this.titulo = titulo;
                this.horas = horasEstimadas;
                this.genero = Genero;
                this.compania = Compania;
            }

            public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
            {
                this.titulo = titulo;
                this.horas = horasEstimadas;
                this.genero = Genero;
            }

            //crear 
            static public Videojuego nuevojuego(string titulo, int horasEstimadas)
            {
                return new Videojuego(titulo, horasEstimadas);
            }
            static public Videojuego nuevojuego(string titulo, int horasEstimadas, string genero, string compania)
            {
                return new Videojuego(titulo, horasEstimadas, genero, compania);
            }


        }

        //clase interfaz
        class interfaz
        {
            //entregar y devolver
            static public void entregar(Videojuego J)
            {
                J.entregado = true;
            }
            static public void entregar(Serie s)
            {
                s.entregado = true;
            }
            static public void devolver(Videojuego J)
            {
                J.entregado = false;
            }
            static public void devolver(Serie s)
            {
                s.entregado = false;
            }

            //boleanos
            static public bool Entregado(Videojuego J)
            {
                return J.entregado;
            }
            static public bool Entregado(Serie s)
            {
                return s.entregado;
            }

            //comparaciones
            static public int compareTo(Videojuego[] juegos)
            {
                int juegoconmashoras = 0;
                int mayorhoras = juegos[0].horas;

                for (int i = 0; i < 5; i++)
                {
                    if (mayorhoras < juegos[i].horas)
                    {
                        juegoconmashoras = i;
                        mayorhoras = juegos[i].horas;
                    }
                }
                return juegoconmashoras;
            }
            static public int compareTo(Serie[] series)
            {
                int serieconmastemp = 0;
                int mastemps = series[0].num_temp;

                for (int i = 0; i < 5; i++)
                {
                    if (mastemps < series[i].num_temp)
                    {
                        serieconmastemp = i;
                        mastemps = series[i].num_temp;
                    }
                }
                return serieconmastemp;
            }
        }
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            //string titulo, int num_temp, string genero, string creador
            series[0] = Serie.nuevaserie("Adventure Time", 10 , "Acción/Aventura", "Pendleton Ward");
            series[1] = Serie.nuevaserie("The Mentalist", 7 , "Crimen" , "Bruno Heller ");
            series[2] = Serie.nuevaserie("Regular Show", 8 , "Acción/Aventura" ,"J. G. Quintel");
            series[3] = Serie.nuevaserie("Ben 10", 4 , "Superheroes" , "Man of Action");
            series[4] = Serie.nuevaserie("The Office", 9 , "Comedia" ,"Ricky Gervais y Stephen Merchant");

            videojuegos[0] = Videojuego.nuevojuego("The Legend of Zelda: Breath of the Wild", 50);
            videojuegos[1] = Videojuego.nuevojuego("Grand Theft Auto V", 40);
            videojuegos[2] = Videojuego.nuevojuego("The Witcher 3: Wild Hunt", 60);
            videojuegos[3] = Videojuego.nuevojuego("Super Mario Odyssey", 30);
            videojuegos[4] = Videojuego.nuevojuego("Red Dead Redemption 2", 80);

            interfaz.entregar(series[1]);
            interfaz.entregar(series[3]);
            interfaz.entregar(videojuegos[2]);
            interfaz.entregar(videojuegos[4]);
            interfaz.entregar(series[0]);

            List<int> seriesEN = new List<int>();
            List<int> juegosEN = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (interfaz.Entregado(series[i]))
                {
                    seriesEN.Add(i);
                }
                if (interfaz.Entregado(videojuegos[i]))
                {
                    juegosEN.Add(i);
                }
            }

            Console.WriteLine("Videojuegos Entregados " + juegosEN.Count());
            foreach (int i in juegosEN)
            {
                Console.WriteLine(videojuegos[i].Titulo);
            }

            Console.WriteLine("");

            Console.WriteLine("Series Entregadas " + seriesEN.Count());
            foreach (int i in seriesEN)
            {
                Console.WriteLine(series[i].Titulo);
            }

            Console.WriteLine("");
            Console.WriteLine("La serie con mas cantidad de temporadas es " + series[interfaz.compareTo(series)].Titulo + " con un total de " + series[interfaz.compareTo(series)].num_temp + " Temporadas");
            Console.WriteLine("");
            Console.WriteLine("El videojuego con mas horas es " + videojuegos[interfaz.compareTo(videojuegos)].Titulo + " con un total de "  + videojuegos[interfaz.compareTo(videojuegos)].horas + " horas");
            Console.ReadKey();
        }
    }
}
