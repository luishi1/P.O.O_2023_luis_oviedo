using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
            private const int numtemp = 3;
            private const bool entregadooo = false;

            //variables
            public string titulo;
            public int num_temp;
            public bool entregado;
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

            }

            public Serie(string titulo , string creador)
            {
                this.titulo = titulo;
                this.num_temp = numtemp;
                this.genero = "";
                this.creador = creador;            
                this.entregado = entregadooo;
            }
            
            public Serie(string titulo, int num_temp , string genero , string creador)
            {
                this.titulo = titulo;
                this.num_temp = num_temp;
                this.genero = genero;
                this.creador = creador;
                this.entregado = entregadooo;
            }
        }
        class Videojuego
        {
            //constantes
            private const int horasdef = 10;
            private const bool entregadef = false;

            //variables
            public string titulo;
            public int horas;
            public bool entregado;
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
                this.titulo = "";
                this.horas = horasdef;
                this.entregado = entregadef;
                this.genero = "";
                this.compania = "";
            }

            public Videojuego(string titulo, int horasEstimadas)
            {
                this.titulo = titulo;
                this.horas = horasEstimadas;
                this.entregado = entregadef;
                this.genero = "";
                this.compania = "";
            }

            public Videojuego(string titulo, int horasEstimadas, string genero, string compania)
            {
                this.titulo = titulo;
                this.horas = horasEstimadas;
                this.entregado = entregadef;
                this.genero = "";
            }
        }
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            series[0] = new Serie("Adventure Time", "Pendleton Ward");
            series[1] = new Serie("The Mentalist", "Bruno Heller ");
            series[2] = new Serie("Regular Show", "J. G. Quintel");
            series[3] = new Serie("Ben 10", "Man of Action");
            series[4] = new Serie("The Office", "Ricky Gervais y Stephen Merchant");

            videojuegos[0] = new Videojuego("The Legend of Zelda: Breath of the Wild", 50);
            videojuegos[1] = new Videojuego("Grand Theft Auto V", 40);
            videojuegos[2] = new Videojuego("The Witcher 3: Wild Hunt", 60);
            videojuegos[3] = new Videojuego("Super Mario Odyssey", 30);
            videojuegos[4] = new Videojuego("Red Dead Redemption 2", 80);
        }
    }
}
//que carajos es una interface