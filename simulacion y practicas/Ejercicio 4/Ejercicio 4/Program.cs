using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_4
{
    public class Electrodomestico
    {
        //constantes
        const double PRECIO_DEFAULT = 100;
        const string COLOR_DEFAULT = "Blanco";
        const char CONSUMOENERGEITOC_DEFAULT = 'F';
        const int PESO_DEFAULT = 5;

        //atributos
        public double preciobase;
        public string color;
        public char consumoenergetico;
        public int peso;

        public Electrodomestico()
        {
            preciobase = PRECIO_DEFAULT;
            color = COLOR_DEFAULT;
            consumoenergetico = CONSUMOENERGEITOC_DEFAULT;
            peso = PESO_DEFAULT;
        }
        public Electrodomestico(double precio, int peso)
        {
            this.preciobase = precio;
            color = COLOR_DEFAULT;
            consumoenergetico = CONSUMOENERGEITOC_DEFAULT;
            this.peso = peso;
        }

        public Electrodomestico(double precio, string color, char consumo, int peso)
        {
            this.preciobase = precio;
            ComprobarColor(color);
            ComprobarConsumoEnergetico(consumo);
            this.peso = peso;
        }

        //METODOS GET

        public double PrecioBase
        { 
            get {  return preciobase;  } 
        }

        public string Color
        {
            get { return color; }
        }
        public char Consumo
        {
            get { return consumoenergetico; }
        }

        public int Peso
        {
            get { return peso; }
        }

        //METODOS
        public void ComprobarConsumoEnergetico(char letra)
        {
            string letras = "ABCDEF";
            if (letras.Contains(letra))
            {
                this.consumoenergetico = letra;
            }
            else
            {
                this.consumoenergetico = 'F';
            }
        }

        public void ComprobarColor(string color)
        {
            string colorminus = color.ToLower();
            if (colorminus == "blanco" || colorminus == "rojo" || colorminus == "negro" || colorminus == "gris" || colorminus == "azul")
            {
                this.color = color;
            }
            else
            {
                this.color = "Blanco";
            }
        }

        public double precioFinal()
        {
            double preciofinal = PrecioBase;
            char letra = Consumo;
            int peso = Peso;

            switch (letra)
            {
                case 'A':
                    preciofinal =+ 100;
                    break;

                case 'B':
                    preciofinal =+ 80;
                    break;

                case 'C':
                    preciofinal =+ 60;
                    break;

                case 'D':
                    preciofinal =+ 50;
                    break;

                case 'E':
                    preciofinal =+ 30;
                    break;

                case 'F':
                    preciofinal =+ 10;
                    break;
            }
            if (peso >= 0 && peso <= 19)
            {
                preciofinal += 10;               
            }
            else if (peso >= 20 && peso <= 49)
            {
                preciofinal += 50;
            }
            else if (peso >= 50 && peso <= 79)
            {
                preciofinal += 80;
            }
            else
            {
                preciofinal += 100;
            }
            return preciofinal;
        }
    }
    public class Lavadora:Electrodomestico
    {
        //Constante
        const int CARGA_DEFAULT = 5;

        //atributo propio
        public int carga;

        //constructores 
        public Lavadora() : base()
        {
            carga = CARGA_DEFAULT;
        }

        public Lavadora(double precio , int peso) : base(precio,peso)
        {
            carga = CARGA_DEFAULT;
        }

        public Lavadora(double precio, string color, char consumo, int peso , int carga) : base(precio,color,consumo,peso)
        {
            this.carga = carga;
        }

        //metodo get
        public int Carga
        {
            get { return carga; }
        }

        //metodos
        public double precioFinal()
        {
            double precio = base.precioFinal();
            int carga = Carga;
            if (Carga >= 30)
            {
                precio =+ 50;
            }
            return precio;
        }
    }

    public class Television:Electrodomestico
    {
        //constantes
        const int RESOLUCION_DEFAULT = 20;
        const bool SINTONIZADOR_DEFAULT = false;
        //atributos
        public int resolucion;
        public bool sintonizadorTDT ;
        //constructores
        public Television() : base()
        {
            resolucion = RESOLUCION_DEFAULT;
            sintonizadorTDT = SINTONIZADOR_DEFAULT;
        }

        public Television(double precio, int peso) : base(precio, peso)
        {
            resolucion = RESOLUCION_DEFAULT;
            sintonizadorTDT = SINTONIZADOR_DEFAULT;
        }

        public Television(double precio, string color, char consumo, int peso, int resolucion , bool sintonizador) : base(precio, color, consumo, peso)
        {
            this.sintonizadorTDT = sintonizador;
            this.resolucion = resolucion;
        }
        //metodo get
        public int Resolucion
        {
            get { return resolucion; }
        }

        public bool Sintonizador
        {
            get { return sintonizadorTDT; }
        }

        //metodos
        public double precioFinal()
        {
            double precio = base.precioFinal();
            int resolucion = Resolucion;
            bool tienesintonizador = Sintonizador;
            if (resolucion >= 40)
            {
                precio *= 1.30;
            }
            if (tienesintonizador == true)
            {
                precio += 50;
            }
            return precio;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico[] electrodomesticos = new Electrodomestico[10];
            electrodomesticos[0] = new Television(10, 15);
            electrodomesticos[1] = new Lavadora(15, 58);
            electrodomesticos[2] = new Television(10, "blanco",'D', 20, 20, true);
            electrodomesticos[3] = new Lavadora(85, "gris", 'A', 32, 29);
            electrodomesticos[4] = new Lavadora();
            electrodomesticos[5] = new Television();
            electrodomesticos[6] = new Television(15, 65);
            electrodomesticos[7] = new Lavadora(34, 77);
            electrodomesticos[8] = new Lavadora(23, 32);
            electrodomesticos[9] = new Television(98, "rojo",'B', 65, 47, false);
            int televisores = 0, lavarropas = 0 ;
            List<Type> tipos = new List<Type>();

            int numero = 1;
            foreach (Electrodomestico e in electrodomesticos)
            {

                Console.WriteLine("Precio final del Objeto " + numero + " " + e.precioFinal());

                if (e is Television)
                {
                    televisores++;
                }
                if (e is Lavadora)
                {
                    lavarropas++;
                }
                if (!tipos.Contains(e.GetType()))
                {
                    tipos.Add(e.GetType());
                }
                numero++;
            }
            Console.WriteLine("La cantidad de lavadoras que hay es " + lavarropas + " y televisores son " + televisores);
                Console.WriteLine("La cantidad de tipos que hay en la clase electrodomesticos son " + tipos.Count);
            Console.ReadKey();
        }
    }
}
