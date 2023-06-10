using System;
using System.Collections.Generic;


namespace Ejer_aprobacion_12
{
    public class Revolver
    {
        static Random random = new Random();
        public int posicionActual;
        public int posicionBala;

        public Revolver()
        {
            posicionActual = GenerarActual();
            posicionBala = GenerarPosBalas();
        }

        public int GenerarActual()
        {
            return random.Next(0, 6);
        }

        public int GenerarPosBalas()
        {
            return random.Next(0, 6);
        }

        public bool Disparar()
        {
            return posicionActual == posicionBala;
        }
        public void siguienteBala()
        {
            posicionActual = (posicionActual + 1) % 6;
        }
    }

    public class Jugadores
    {
        static Random rand = new Random();
        public int ID;
        public string nombre;
        public bool tavivo;

        public Jugadores(int ID)
        {
            this.ID = ID;
            nombre = GenerarNombre();
            tavivo = true;
        }

        public string GenerarNombre()
        {
            string[] nombres =
            { "Felipe" , "Tobias" , "Agustin" , "Lucio" , "Marcos" , "Leandro" , "Gaspar" , "Thiago" , "Evelyn" , "Sebastian" , "Joaquin" , "Santiago" ,
            "Matias" , "Facundo" , "Claudia" , "Azul" , "Sofia" , "Tamara" , "Jorge" , "Gabriel" , "Angie" , "Aaron" , "Luis" , "Pablo" , "Esteban" , "Emma" , "Graciela" , "Estella" , "Sandra" };
            string nombre = nombres[rand.Next(nombres.Length)] + " " + ID;
            return nombre;
        }

        public void Disparar(Revolver revolver, ref bool juegoTerminado)
        {
            if (tavivo)
            {
                if (revolver.Disparar())
                {
                    tavivo = false;
                    juegoTerminado = true;
                    Console.WriteLine("El jugador " + nombre + " ha MUERTO");
                }
                else
                {
                    revolver.siguienteBala();
                    Console.WriteLine("El jugador " + nombre + " sigue VIVO");
                }
            }
        }

    }

    public class Juego
    {
        public List<Jugadores> jugadores;
        public Revolver Revolver;

        public Juego()
        {
            jugadores = new List<Jugadores>();
            Revolver = new Revolver();
        }

        public bool FinJuego()
        {
            foreach (Jugadores j in jugadores)
            {
                if (j.tavivo == false)
                {
                    Console.WriteLine("El juego termino el jugador " + j.nombre + " a MUERTO");
                    return true;
                }
            }
            return false;
        }

        public void ronda()
        {
            bool juegoTerminado = false;
            int contador = 1;
            while (!juegoTerminado)
            {
                foreach (Jugadores J in jugadores)
                {
                    Console.WriteLine("Ronda " + contador);
                    Console.WriteLine("Nombre del Jugador " + J.nombre);
                    Console.Write("Disparo.......");
                    Console.ReadLine();
                    J.Disparar(Revolver, ref juegoTerminado);
                    if (!J.tavivo)
                    {
                        Console.WriteLine("Estado del Jugador: Muerto");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("Estado del Jugador: Vivo");
                        Console.WriteLine("");
                    }
                    if (juegoTerminado)
                        break;
                }
                contador++;
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();
            List<Jugadores> personas = juego.jugadores;
            Console.WriteLine("Ingrese la cantidad de jugadores que van a participar en el juego");
            int cantidad = int.Parse(Console.ReadLine());
            for (int i = 0; i < cantidad; i++)
            {
                Jugadores jugador = new Jugadores(i + 1);
                personas.Add(jugador);
            }
            while (true)
            {
                Console.Clear();
                juego.ronda();
                Console.WriteLine();
                if (juego.FinJuego())
                {
                    break;
                }
            }
        }
    }
}
/*
Use una variable bandera para que en el metodo disparar de jugador
me indique si el juego acaba o no asi si un jugador muere no lo continue

el termine ref se usa para pasar una referencia de una variable
dentro del metodo si recibe una modificacion se modifica el valor de la misma
 */
