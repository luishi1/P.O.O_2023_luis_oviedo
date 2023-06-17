using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace ejer_aprobacion_17
{
    public abstract class Baraja
    {
        protected List<Cartas> cartas;
        protected List<Cartas> mazo;
        protected Random ran;
        protected int totalCartas;
        protected int cartasPorPalo;

        public Baraja(int totalCartas, int cartasPorPalo)
        {
            cartas = new List<Cartas>();
            mazo = new List<Cartas>();
            ran = new Random();
            this.totalCartas = totalCartas;
            this.cartasPorPalo = cartasPorPalo;
            CrearBaraja();
        }

        public abstract void CrearBaraja();

        public void Barajar()
        {
            // Algoritmo de Fisher-Yates
            for (int i = 0; i < cartas.Count; i++)
            {
                int indicerandom = ran.Next(cartas.Count);
                Cartas puente = cartas[i];
                cartas[i] = cartas[indicerandom];
                cartas[indicerandom] = puente;
            }
        }

        public Cartas SiguienteCarta()
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
                Console.WriteLine("Ya no quedan más cartas");
                return null;
            }
        }

        public virtual int CartasDisponibles()
        {
            return totalCartas;
        }


        public List<Cartas> DarCartas(int cantidad)
        {
            List<Cartas> cartasmano = new List<Cartas>();

            if (cantidad <= cartas.Count)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    Cartas carta = SiguienteCarta();
                    cartasmano.Add(carta);
                }
            }
            else
            {
                Console.WriteLine("No hay suficientes cartas en el mazo");
            }
            return cartasmano;
        }

        public void CartasMazo()
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
                Console.WriteLine("Aún no ha salido ninguna carta");
            }
        }

        public void mostrarBaraja()
        {
            foreach (Cartas c in cartas)
            {
                Console.WriteLine(c.numero + " " + c.palo);
            }

            if (this is BarajaEspañola barajaEspañola && barajaEspañola.IncluirOchoNueve)
            {
                string[] palos = { "OROS", "COPAS", "ESPADAS", "BASTOS" };

                foreach (string palo in palos)
                {
                    Console.WriteLine("8 " + palo);
                    Console.WriteLine("9 " + palo);
                }
            }
        }



    }

    public class BarajaEspañola : Baraja
    {
        public bool IncluirOchoNueve { get; set; }

        public BarajaEspañola(bool incluirOchoNueve) : base((incluirOchoNueve ? 12 : 10) * 4, 12)
        {
            IncluirOchoNueve = incluirOchoNueve;
        }

        public override void CrearBaraja()
        {
            string[] palo = { "OROS", "COPAS", "ESPADAS", "BASTOS" };
            foreach (string p in palo)
            {
                for (int i = 1; i <= 12; i++)
                {
                    if (IncluirOchoNueve || (i != 8 && i != 9))
                    {
                        Cartas carta = new Cartas(i, p);
                        cartas.Add(carta);
                    }
                }

                if (IncluirOchoNueve)
                {
                    Cartas cartaOcho = new Cartas(8, p);
                    cartas.Add(cartaOcho);

                    Cartas cartaNueve = new Cartas(9, p);
                    cartas.Add(cartaNueve);
                }
            }
        }
        public override int CartasDisponibles()
        {
            return totalCartas;
        }


    }

    public class BarajaFrancesa : Baraja
    {
        public BarajaFrancesa() : base(52, 13)
        {
        }

        public override void CrearBaraja()
        {
            string[] palo = { "DIAMANTES", "PICAS", "CORAZONES", "TREBOLES" };
            foreach (string p in palo)
            {
                for (int i = 1; i <= cartasPorPalo; i++)
                {
                    string numeroCarta = ObtenerNumeroCarta(i);
                    Cartas carta = new Cartas(i, p);
                    cartas.Add(carta);
                }
            }
        }

        private string ObtenerNumeroCarta(int numero)
        {
            switch (numero)
            {
                case 1:
                    return "As";
                case 11:
                    return "Jota";
                case 12:
                    return "Reina";
                case 13:
                    return "Rey";
                default:
                    return numero.ToString();
            }
        }

        public void CartaRoja(Cartas carta)
        {
            if (carta.palo == "CORAZONES" || carta.palo == "DIAMANTES")
            {
                Console.WriteLine("La carta es roja");
            }
            else
            {
                Console.WriteLine("La carta no es roja");
            }
        }

        public void CartaNegra(Cartas carta)
        {
            if (carta.palo == "PICAS" || carta.palo == "TREBOLES")
            {
                Console.WriteLine("La carta es negra");
            }
            else
            {
                Console.WriteLine("La carta no es negra");
            }
        }
    }

    public class Cartas
    {
        public int numero { get; set; }
        public string palo { get; set; }

        public Cartas() { }
        public Cartas(int numero, string palo)
        {
            this.numero = numero;
            this.palo = palo;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            Baraja baraja = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Elegir la opción que desea realizar:");
                Console.WriteLine("1. Crear Baraja Española");
                Console.WriteLine("2. Crear Baraja Francesa");
                Console.WriteLine("3. Barajar");
                Console.WriteLine("4. Mostrar Cartas Disponibles");
                Console.WriteLine("5. Extraer Cartas");
                Console.WriteLine("6. Mostrar Cartas en el Mazo");
                Console.WriteLine("7. Mostrar Baraja Completa");
                Console.WriteLine("8. Salir");

                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.WriteLine("¿Desea incluir los ochos y nueves? (S/N)");
                    string respuesta = Console.ReadLine();
                    bool incluirOchoNueve = respuesta.ToLower() == "s";

                    if (incluirOchoNueve)
                    {
                        Console.WriteLine("Se creó la baraja española con las cartas del 1 al 12 con todos los palos, incluyendo los ochos y nueves.");
                    }
                    else
                    {
                        Console.WriteLine("Se creó la baraja española con las cartas del 1 al 12 sin las cartas 8 y 9.");
                    }
                    baraja = new BarajaEspañola(incluirOchoNueve);
                }

                else if (opcion == 2)
                {
                    baraja = new BarajaFrancesa();
                }
                else if (opcion == 3)
                {
                    if (baraja != null)
                    {
                        baraja.Barajar();
                        Console.WriteLine("Baraja barajada.");
                    }
                    else
                    {
                        Console.WriteLine("No se ha creado ninguna baraja.");
                    }
                }
                else if (opcion == 4)
                {
                    if (baraja != null)
                    {
                        Console.WriteLine("Cartas disponibles en la baraja: " + baraja.CartasDisponibles());
                    }
                    else
                    {
                        Console.WriteLine("No se ha creado ninguna baraja.");
                    }
                }
                else if (opcion == 5)
                {
                    if (baraja != null)
                    {
                        Console.WriteLine("Ingrese la cantidad de cartas que desea extraer:");
                        int cantidad = int.Parse(Console.ReadLine());
                        List<Cartas> cartasmano = baraja.DarCartas(cantidad);
                        foreach (Cartas carta in cartasmano)
                        {
                            Console.WriteLine(carta.numero + " " + carta.palo);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se ha creado ninguna baraja.");
                    }
                }
                else if (opcion == 6)
                {
                    if (baraja != null)
                    {
                        baraja.CartasMazo();
                    }
                    else
                    {
                        Console.WriteLine("No se ha creado ninguna baraja.");
                    }
                }
                else if (opcion == 7)
                {
                    if (baraja != null)
                    {
                        baraja.mostrarBaraja();
                    }
                    else
                    {
                        Console.WriteLine("No se ha creado ninguna baraja.");
                    }
                }
                else if (opcion == 8)
                {
                    Console.WriteLine("Saliendo del programa...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }

                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

    }
}
