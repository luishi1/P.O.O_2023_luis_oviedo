using System;
using System.Collections.Generic;

namespace ejer_aprobacio_10
{
    public class Cartas
    {
        public int numero { get; set; }
        public string palo { get; set; }

        public Cartas(){}
        public Cartas(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }
    }

    public class Baraja
    {
        private List<Cartas> cartas;
        private List<Cartas> mazo;
        private Random ran;

        public Baraja()
        {
            cartas = new List<Cartas>();
            mazo = new List<Cartas>();
            ran = new Random();
            CrearBaraja();
        }

        //metodo para iniciarlizar la baraja de una vez
        public void CrearBaraja()
        {
            string[] palo = { "Espada", "Oro", "Basto", "Copa" };
            foreach (string p in palo)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (i != 8 && i != 9)
                    {
                        Cartas carta = new Cartas(i, p);
                        cartas.Add(carta);
                    }
                }
            }
        }

        public void Barajar()
        {
            //algoritmo de Fisher-Yates
            for (int i = 0; i < cartas.Count ; i++)
            {
                int indicerandom = ran.Next(cartas.Count);
                Cartas puente = cartas[i];
                cartas[i] = cartas[indicerandom];
                cartas[indicerandom] = puente;
            }
        }

        public Cartas siguienteCarta()
        {
            if (cartas.Count > 0)
            {
                Cartas carta = cartas[0];
                cartas.RemoveAt(0);
                mazo.Add(carta);
                return carta;
            }
            else
            {
                Console.WriteLine("Ya no quedan mas cartas");
                return null;
            }
        }

        public int cartasDisponibles()
        {
            return cartas.Count;
        }

        public List<Cartas> DarCartas(int cantidad)
        {
            List<Cartas> cartasmano = new List<Cartas>();

            if (cantidad <= cartas.Count)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Cartas carta = siguienteCarta();
                    cartasmano.Add(carta);
                }
            }
            else
            {
                Console.WriteLine("No hay suficientes cartas en el mazo");
            }
            return cartasmano;
        }

        public void cartasMazo()
        {
            if (mazo.Count > 0)
            {
                foreach (Cartas c in mazo)
                {
                    Console.WriteLine(c.numero + " " + c.palo);
                }
            }
            else
            {
                Console.WriteLine("Aun no a salido ninguna carta");
            }
        }

        public void mostrarBaraja()
        {
            foreach (Cartas c in cartas)
            {
                Console.WriteLine(c.numero + " " + c.palo);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Baraja baraja = new Baraja();
            baraja.Barajar();

            Console.WriteLine("Cartas disponibles en la baraja: " + baraja.cartasDisponibles());

            Console.WriteLine("");

            Console.WriteLine("Ingrese la cantidad de cartas que desea quitar");
            int cantidad = int.Parse(Console.ReadLine());

            List<Cartas> cartasmano = baraja.DarCartas(cantidad);

            foreach (Cartas carta in cartasmano)
            {
                Console.WriteLine(carta.numero + " " + carta.palo);
            }

            Console.WriteLine("");

            Console.WriteLine("Cartas disponibles en la baraja después de repartir " + cantidad + " cartas: " + baraja.cartasDisponibles());

            Console.WriteLine("");

            baraja.cartasMazo();

            Console.WriteLine("");

            baraja.mostrarBaraja();

            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}
