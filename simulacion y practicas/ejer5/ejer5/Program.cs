using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer5
{
    interface Entregable
    {
        void Entregar();
        void Devolver();
        bool IsEntregado();
    }
    public class Series:Entregable
    {
        //constante
        const int NUMERO_TEMPORADAS_DEFAULT = 3;
        const bool ENTREGA_DEFAULT = false;
        //atributos
        private string titulo;
        private int temporadas;
        private bool entregado;
        private string genero;
        private string creador;
        //constructores 
        public Series()
        {
        }
        public Series(string titulo , string creador)
        {
            this.titulo = titulo;
            temporadas = NUMERO_TEMPORADAS_DEFAULT;
            entregado = ENTREGA_DEFAULT;
            this.creador = creador;
        }

        public Series(string titulo, int temporadas, string genero, string creador)
        {
            this.titulo = titulo;
            this.temporadas = temporadas;
            this.genero = genero;
            this.creador = creador;
        }
        //metodos get y set
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public int Temporadas
        {
            get { return temporadas; }
            set { temporadas = value; }
        }
        public string Creador
        {
            get { return creador; }
            set { creador = value; }
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        //metodos
        public void Entregar()
        {
            entregado = true;
        }
        public void Devolver()
        {
            entregado = false;
        }
        public bool IsEntregado()
        {
            return entregado;
        }
        public int CompareTo(object a)
        {
            int serietemporada = 0;
            Series[] serie = (Series[])a;
            int mayorhoras = serie[0].temporadas;

            for (int i = 0; i < 5; i++)
            {
                if (mayorhoras < serie[i].temporadas)
                {
                    serietemporada = i;
                    mayorhoras = serie[i].temporadas;
                }
            }
            return serietemporada;
        }
    }
    public class Videojuegos:Entregable
    {
        //constantes
        const int HORAS_DEFAULT = 10;
        const bool ENTREGA_DEFAULT = false;
        //atributos
        private string titulo;
        private int horasestimadas;
        private string creador;
        private bool entregado;
        private string compañia;

        //get y set
        public string Titulo
        {
            get { return titulo; }     
            set { titulo = value; }
        }
        public int Horas
        {
            get { return horasestimadas; }
            set { horasestimadas = value; }
        }
        public string Creador
        {
            get { return creador; }
            set { creador = value; }
        }
        public string Compañia
        {
            get { return compañia; }
            set { compañia = value; }
        }
        //constructores
        public Videojuegos()
        {
        }
        public Videojuegos(string titulo, string creador)
        {
            this.titulo = titulo;
            horasestimadas = HORAS_DEFAULT;
            entregado = ENTREGA_DEFAULT;
            this.creador = creador;
        }

        public Videojuegos(string titulo, int horas, string compañia, string creador)
        {
            this.titulo = titulo;
            this.horasestimadas = horas;
            this.compañia = compañia;
            this.creador = creador;
        }

        //metodos
        public void Entregar()
        {
            entregado = true;
        }
        public void Devolver()
        {
            entregado = false;
        }
        public bool IsEntregado()
        {
            return entregado;
        }
        static public int CompareTo(object a)
        {
            int juegohoras = 0;
            Videojuegos[] juego = (Videojuegos[])a;
            int mayorhoras = juego[0].horasestimadas;

            for (int i = 0; i < 5; i++)
            {
                if (mayorhoras < juego[i].horasestimadas)
                {
                    juegohoras = i;
                    mayorhoras = juego[i].horasestimadas;
                }
            }
            return juegohoras;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Series[] series = new Series[5];
            Videojuegos[] videojuegos = new Videojuegos[5];

            series[0] = new Series("Serie 1", 8, "Drama", "David Benioff");
            series[1] = new Series("Serie 2", 2, "DraAFma", "DavSDSid DBeDSnioff");
            series[2] = new Series("Serie 3", 5, "DramDDa", "ADAS BeDASDASnioff");
            series[3] = new Series("Serie 4", 4, "DraDDma", "FFA Benioff");
            series[4] = new Series();
            videojuegos[0] = new Videojuegos("juego 1" , 24 , "S" , "D");
            videojuegos[1] = new Videojuegos("juego 2" , 4 , "4" , "d");
            videojuegos[2] = new Videojuegos("juego 3" , 32 , "ds" , "d");
            videojuegos[3] = new Videojuegos("Juego 4" , 8 , "dasda" , "kl");
            videojuegos[4] = new Videojuegos();

            series[0].Entregar();
            series[2].Entregar();
            series[4].Entregar();
            videojuegos[1].Entregar();
            videojuegos[3].Entregar();

            int cantjuegos = 0; int cantseries = 0;

            foreach (Videojuegos v in videojuegos)
            {
                if (v.IsEntregado() == true)
                {
                    cantjuegos++;
                }
            }
            foreach (Series s in series)
            {
                if (s.IsEntregado() == true)
                {
                    cantseries++;
                }
            }
            Console.WriteLine("La cantidad de juegos entregados es " + cantjuegos);
            Console.WriteLine("La cantidad de series entregadas es " + cantseries);
         
        }
    }
}
