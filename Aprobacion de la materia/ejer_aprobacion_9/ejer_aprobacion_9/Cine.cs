using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_9
{
    public class Cine
    {
        public string titulo;
        public int precioentrada;
        public Asiento[,] asientos;
        public Random ran = new Random();

        public Cine() { }
        public Cine(string titulo, int precioentrada)
        {
            this.titulo = titulo;
            this.precioentrada = precioentrada;
            asientos = new Asiento[8, 9];
            generarAsientos();
        }

        //generamos los asientos  para que cuando se inicie el objeto cine ya vengan creados
        //recorre los asientos y las columna y las inecializa
        public void generarAsientos()
        {
            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    //hacemos que el array asientos reciba un nuevo asiento sumandole 1 a cada uno
                    // se puede realizar operaciones entre char y int
                    asientos[fila, columna] = new Asiento(fila + 1, (char)('A' + columna));
                }
            }
        }

        //si la edad del  espectador es mayor a 18 o igual devuelve true
        public bool EdadSuficiente(int edad)
        {
            return edad >= 18;
        }

        //booleano de que si el dinero del espectador es mayor o igual al precio entrada devuelve true
        public bool DineroSuficiente(int dinero)
        {
            return dinero >= precioentrada;
        }


        //recorre el array de asientos y comprueba si el asiento no esta ocupado devuelve true es decir que hay asientos
        public bool SitiosDisponibles()
        {
            foreach (Asiento a in asientos)
            {
                if (!a.EstaOcupado())
                {
                    return true;
                }

            }
            return false;
        }


        //creo una lista de asientos para almacenar los asientos disponibles
        //recoremos nuevamente asientos y si los asientos no estan ocupados  los agregamos a la lista
        //ponemos una condicion de que si la lista tiene elementos devuelva un indice random , del caso contrario no devuelve nada
        public Asiento BuscarAsiento()
        {
            List<Asiento> asientosdisponibles = new List<Asiento>();
            foreach (Asiento a in asientos)
            {
                if (!a.EstaOcupado())
                {
                    asientosdisponibles.Add(a);
                }
            }

            if (asientosdisponibles.Count > 0)
            {
                int indice = ran.Next(asientosdisponibles.Count);
                return asientosdisponibles[indice];
            }

            return null;

        }

        public void Simulacion()
        {
            while (true)
            {
                string[] nombres =
                { "Felipe" , "Tobias" , "Agustin" , "Lucio" , "Marcos" , "Leandro" , "Gaspar" , "Thiago" , "Evelyn" , "Sebastian" , "Joaquin" , "Santiago" ,
                "Matias" , "Facundo" , "Claudia" , "Azul" , "Sofia" , "Tamara" , "Jorge" , "Gabriel" , "Angie" , "Aaron" , "Luis" , "Pablo" , "Esteban" , "Emma" , "Graciela" , "Estella" , "Sandra" ,
                "Goku" };

                string nombre = nombres[ran.Next(nombres.Length)];
                int edad = ran.Next(10, 70);
                int dinero = ran.Next(100, 7000);

                Console.WriteLine("Ingresa Espectador");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                if (EdadSuficiente(edad) && DineroSuficiente(dinero) && SitiosDisponibles())
                {
                    Asiento asiento = BuscarAsiento();
                    if (asiento != null)
                    {
                        asiento.SentarEspectador(new Espectador(nombre, edad, dinero));
                        Console.WriteLine("El Espectador de nombre " + nombre + " se esta sentando en la fila " + asiento.FilaColumna());
                    }
                    else
                    {
                        Console.WriteLine("El Espectador de nombre " + nombre + " no se pudo sentar por que no hay asientos disponibles");
                    }
                }
                else
                {
                    Console.WriteLine("El Espectador de nombre " + nombre + " no cumple las condiciones para entrar a la sala");
                }

                Console.WriteLine("Presiona cualquier tecla para continuar o 'x' para terminar el programa.");
                if (Console.ReadKey().KeyChar == 'x')
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
