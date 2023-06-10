using System;
using System.Collections.Generic;

namespace ejer_aprobacion_13
{
    public class Empleado
    {
        private static readonly Random random = new Random();
        public const double PLUS = 300;

        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Salario { get; set; }

        public Empleado() { }

        public Empleado(string nombre, int edad, double salario)
        {
            Nombre = nombre;
            Edad = edad;
            Salario = salario;
        }

        public Empleado(double salario)
        {
            Nombre = GenerarNombre();
            Edad = GenerarEdad();
            Salario = salario;
        }

        public virtual void SumarPlus()
        {
            Salario += PLUS;
        }

        private static string GenerarNombre()
        {
            string[] nombres =
            {
                "Felipe", "Tobias", "Agustin", "Lucio", "Marcos", "Leandro", "Gaspar", "Thiago", "Evelyn", "Sebastian",
                "Joaquin", "Santiago", "Matias", "Facundo", "Claudia", "Azul", "Sofia", "Tamara", "Jorge", "Gabriel",
                "Angie", "Aaron", "Luis", "Pablo", "Esteban", "Emma", "Graciela", "Estella", "Sandra", "Goku"
            };
            return nombres[random.Next(nombres.Length)];
        }

        private static int GenerarEdad()
        {
            return random.Next(18, 70);
        }

        public virtual void Mostrar()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Salario: " + Salario);
        }
    }

    public class Comercial : Empleado
    {
        public double Comision { get; set; }

        public Comercial() : base() { }

        public Comercial(string nombre, int edad, double salario, double comision) : base(nombre, edad, salario)
        {
            Comision = comision;
        }

        public Comercial(double salario, double comision) : base(salario)
        {
            Comision = comision;
        }

        public override void SumarPlus()
        {
            if (Edad > 30 && Comision > 200)
            {
                Salario += PLUS;
            }
        }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine("Comision: " + Comision);
        }
    }

    public class Repartidor : Empleado
    {
        public string Zona { get; set; }

        public Repartidor() : base() { }

        public Repartidor(string nombre, int edad, double salario, string zona) : base(nombre, edad, salario)
        {
            Zona = zona;
        }

        public Repartidor(double salario, string zona) : base(salario)
        {
            Zona = zona;
        }

        public override void SumarPlus()
        {
            if (Edad > 25 && Zona == "zona 3")
            {
                Salario += PLUS;
            }
        }

        public override void Mostrar()
        {
            base.Mostrar();
            Console.WriteLine("Zona: " + Zona);
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            List<Comercial> comerciantes = new List<Comercial>();
            List<Repartidor> repartidores = new List<Repartidor>();

            Comercial comercial1 = new Comercial(233, 339);
            Comercial comercial2 = new Comercial("Cell", 45, 500, 435);
            Comercial comercial3 = new Comercial(520, 140);
            Repartidor repartidor1 = new Repartidor(233, "zona 3");
            Repartidor repartidor2 = new Repartidor("Ballin", 20, 500, "zona 3");
            Repartidor repartidor3 = new Repartidor(520, "zona 3");

            comerciantes.Add(comercial1);
            comerciantes.Add(comercial2);
            comerciantes.Add(comercial3);

            repartidores.Add(repartidor1);
            repartidores.Add(repartidor2);
            repartidores.Add(repartidor3);

            Console.WriteLine("Repartidores");
            Console.WriteLine();

            foreach (Repartidor repartidor in repartidores)
            {
                Console.WriteLine("---------------");
                repartidor.Mostrar();
                repartidor.SumarPlus();
                Console.WriteLine();
                Console.WriteLine("Salario POST-PLUS");
                Console.WriteLine();
                repartidor.Mostrar();
            }
            Console.WriteLine("---------------");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Comerciantes");
            Console.WriteLine();

            foreach (Comercial comercial in comerciantes)
            {
                Console.WriteLine("---------------");
                comercial.Mostrar();
                comercial.SumarPlus();
                Console.WriteLine();
                Console.WriteLine("Salario POST-PLUS");
                Console.WriteLine();
                comercial.Mostrar();
            }

            Console.WriteLine("---------------");
        }
    }
}
