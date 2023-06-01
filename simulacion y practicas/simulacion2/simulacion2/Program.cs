using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace simulacion2
{
    public class Vehiculo
    {
        //atributos
        private string marca;
        private string modelo;
        private int año;
        private double preciobase;

        //get y set
        public string Marca 
        {
            get { return marca; }
            set { marca = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public int Año
        {
            get { return año; }
            set { año = value; }
        }
        public double PrecioBase
        {
            get { return preciobase; }
            set { preciobase = value; }
        }
        //constructores
        public Vehiculo(){}
        public Vehiculo(string marca, string modelo, int año)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            preciobase = 10000;
        }
        public Vehiculo(string marca, string modelo, int año, double preciobase)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.año = año;
            this.preciobase = preciobase;
        }

        //metodos
    }
    public class Auto : Vehiculo
    {
        //atributos
        private int cantidadpuertas;
        //get y set
        public int Cantidadpuertas
        {
            get { return cantidadpuertas; }
            set { cantidadpuertas = value; }
        }
        //constructores
        public Auto():base() 
        { 

        }

        public Auto(string marca, string modelo, int año , int puertas) : base(marca,modelo,año)
        {
            this.cantidadpuertas = puertas;
        }

        public Auto(string marca, string modelo, int año, double preciobase , int puertas) : base(marca, modelo, año , preciobase)
        {
            this.cantidadpuertas = puertas;
        }

        //metodos
        public void CalcularPrecioFinal()
        {
            double precio = PrecioBase;
            if (Año >= 0 && Año <= 5)
            {
                precio += 5000;
            }
            else if (Año >= 5 && Año <= 10) 
            {
                precio += 3000;
            }
            precio *= 0.95;

            this.PrecioBase = precio;
        }
    }
    public class Camioneta : Vehiculo
    {
        //atributos
        private int capacidadcarga;
        //get y set
        public int CapacidadCarga
        {
            get{ return capacidadcarga; }
            set { capacidadcarga = value;}
        }
        //constructores
        public Camioneta() : base()
        {

        }

        public Camioneta(string marca, string modelo, int año, int carga) : base(marca, modelo, año)
        {
            this.CapacidadCarga = carga;
        }

        public Camioneta(string marca, string modelo, int año, double preciobase, int carga) : base(marca, modelo, año, preciobase)
        {
            this.CapacidadCarga = carga;
        }
        //metodos
        public void CalcularPrecioFinal()
        {
            double precio = PrecioBase;
            if (Año >= 0 && Año <= 5)
            {
                precio += 5000;
            }
            else if (Año >= 5 && Año <= 10)
            {
                precio += 3000;
            }
            precio *= 0.90;

            this.PrecioBase = precio;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehiculo[] vehiculos = new Vehiculo[5];
            vehiculos[0] = new Camioneta("Volvagen" , "Fulanovich" , 4 , 4000 , 59);
            vehiculos[1] = new Auto("Mustang","DOU",2,12000,2);
            vehiculos[2] = new Camioneta("romesantos", "sexo", 1, 13000, 100);
            vehiculos[3] = new Auto("Guitarra", "epica", 13, 4);
            vehiculos[4] = new Camioneta("Volvagen", "Fulanovich", 16, 19);
            int contador = 1;
            int cantautos = 0; 
            int cantcamion = 0;

            List<Type> tipos = new List<Type>();
            for (int i = 0; i < vehiculos.Length; i++)
            {
                if (vehiculos[i] is Auto)
                {
                    Auto auto = (Auto)vehiculos[i];
                    auto.CalcularPrecioFinal();
                    Console.WriteLine("El precio del auto N° " + contador + ": Es " + auto.PrecioBase);
                    cantautos++;
                }
                if (vehiculos[i] is Camioneta)
                {
                    Camioneta camioneta = (Camioneta)vehiculos[i];
                    camioneta.CalcularPrecioFinal();
                    Console.WriteLine("El precio del auto N° " + contador + ": Es " + camioneta.PrecioBase);
                    cantcamion++;
                }
                contador++;
            }
            foreach (Vehiculo v in vehiculos)
            {
                if (!tipos.Contains(v.GetType()))
                {
                    tipos.Add(v.GetType());
                }
            }
            Console.WriteLine("Hay un total de " + cantautos + " Autos");
            Console.WriteLine("Hay un total de " + cantcamion + " Camiones");
            Console.WriteLine("Hay un total de " + tipos.Count + " tipos de vehiculos");
            Console.ReadKey();
        }
    }
}
