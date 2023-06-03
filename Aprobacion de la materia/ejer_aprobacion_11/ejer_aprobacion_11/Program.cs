using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_11
{
    interface IApuestas
    {
        void ResultadosPosibles();
        void MostrarResultado();
        void MostrarApuestas();
        void GenerarApuesta();
    }

    interface IConstantes
    {
        int DineroInicial { get; }
        int CantPartidos { get; }
        int CantJugadores { get; }
        int Resultados { get; }
    }

    public class Constantes : IConstantes
    {
        public int DineroInicial { get { return 10; } }
        public int CantPartidos { get { return 5; } }
        public int CantJugadores { get { return 4; } }
        public int Resultados { get { return 2; } }
    }

    public class Jugador
    {
        static Random random = new Random();
        public string name;
        public int numero;
        public double dinero;
        public int cant_ganadas;
        public List<string> apuestas;

        public Jugador(int numero)
        {
            name = GenerarNombre();
            this.numero = numero;
            dinero = (new Constantes().DineroInicial);
            cant_ganadas = 0;
            apuestas = new List<string>();
        }

        public void Ganar(double monto)
        {
            dinero += monto;
            cant_ganadas++;
        }

        public string GenerarNombre()
        {
            string[] nombres =
            { "Felipe" , "Tobias" , "Gaspar" , "Thiago" , "Claudia" , "Azul" , "Sofia" , "Tamara" , "Angie" , "Luis"  , "Goku" , "Vegeta" , "Gonza" , "Ale" , "Anto" , "Matias" , "Nazareno" , "Andres"};
            string nombre = nombres[random.Next(nombres.Length)];
            return nombre;
        }

        public void MostrarJugador()
        {
            Console.WriteLine("Jugador N° : " + numero);
            Console.WriteLine("Nombre del jugador : " + name);
        }
    }

    public class Apuesta : IApuestas
    {
        static Random random = new Random();
        public List<Jugador> jugadores;
        public List<string> resultados;
        public double dineroacumulado;

        public Apuesta()
        {
            jugadores = new List<Jugador>();
            resultados = new List<string>();
            dineroacumulado = 0;
        }

        public void GenerarResultados()
        {
            for (int i = 0; i < new Constantes().CantPartidos; i++)
            {
                int resultado = random.Next(3);

                switch (resultado)
                {
                    case 0:
                        resultados.Add("A");
                        break;
                    case 1:
                        resultados.Add("B");
                        break;
                    case 2:
                        resultados.Add("C");
                        break;

                }
            }
        }

        public void ResultadosPosibles()
        {
            foreach (Jugador j in jugadores)
            {
                int aciertos = 0;

                foreach (string A in j.apuestas)
                {
                    if (resultados.Contains(A))
                    {
                        aciertos++;
                    }
                }

                if (aciertos >= new Constantes().Resultados)
                {
                    double monto = dineroacumulado / jugadores.Count;
                    j.Ganar(monto);
                }
            }
        }

        public void MostrarResultado()
        {
            foreach (Jugador j in jugadores)
            {
                if (j.cant_ganadas == new Constantes().Resultados)
                {
                    Console.WriteLine("El jugador de nombre " + j.name + " que era el jugador N° " + j.numero + " es el Ganador");
                    Console.WriteLine("Gano un total de " + j.dinero + "$");
                }
            }
        }

        public void MostrarApuestas()
        {
            Console.WriteLine("Apuestas creadas");
            for (int i = 0; i < new Constantes().CantPartidos; i++)
            {
                Console.WriteLine("Apuesta creada para el partido N° " + (i + 1));
                Console.WriteLine("Era " + resultados[i]);
            }
        }

        public void GenerarApuesta()
        {
            GenerarResultados();

            for (int i = 0; i < new Constantes().CantJugadores; i++)
            {
                jugadores.Add(new Jugador(i + 1));
            }

            foreach (Jugador j in jugadores)
            {
                if (j.dinero > 0)
                {
                    Console.WriteLine("--------------------------------");
                    j.MostrarJugador();
                    Console.WriteLine("Ingrese una opcion A , B o C");
                    for (int i = 0; i < new Constantes().CantPartidos; i++)
                    {
                        Console.WriteLine("Partido N° " + (i + 1));
                        string opcion = Console.ReadLine();
                        j.apuestas.Add(opcion);
                    }
                    Console.WriteLine("--------------------------------");
                }
            }
            Console.WriteLine("--------------------------------");
            ResultadosPosibles();
            Console.WriteLine("--------------------------------");
            MostrarApuestas();
            Console.WriteLine("--------------------------------");
            MostrarResultado();
            Console.WriteLine("--------------------------------");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Apuesta juego = new Apuesta();
            juego.GenerarApuesta();
            Console.ReadKey();
        }
    }

}