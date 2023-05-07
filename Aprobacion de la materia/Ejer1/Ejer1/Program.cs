using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer1
{
    class Cuenta
    {
        public string titular { get; set;}
        public double cantidad { get; set; }

        public Cuenta(string titular)
        {
            this.titular = titular;
        }

        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        public void ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidad += cantidad;
                Console.WriteLine("Se ingreso correctamente la cantidad");
            }
            else
            {
                Console.WriteLine("LA OPERACION FALLO");
            }
        }

        public void retirar(double cantidad)
        {
            if (cantidad > 0)
            {
                double result = this.cantidad - cantidad;
                if (result < 0)
                {
                    this.cantidad = 0;
                }
                else
                {
                    this.cantidad -= cantidad;
                    Console.WriteLine("Se retiro correctamente la cantidad");
                } 
            }
   
        }

        public void MostrarDatos()
        {
            Console.WriteLine("Titular: {0}", this.titular);
            Console.WriteLine("Cantidad: {0}", this.cantidad);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            double cantidad;
            Cuenta cuenta1 = new Cuenta("Luis", 100);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("INGRESE LA OPCIONE QUE DESEE REALIZAR");
                Console.WriteLine("1. ingresar");
                Console.WriteLine("2. retirar");
                Console.WriteLine("3. listar");
                Console.WriteLine("4. salir");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.Write("Ingrese la cantidad a ingresar: ");
                    cantidad = Double.Parse(Console.ReadLine());
                    cuenta1.ingresar(cantidad);
                    Console.ReadKey();
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.Write("Ingrese la cantidad a retirar: ");
                    cantidad = Double.Parse(Console.ReadLine());
                    cuenta1.retirar(cantidad);
                    Console.ReadKey();
                }
                if (opcion == 3)
                {
                    Console.Clear();
                    cuenta1.MostrarDatos();
                    Console.ReadKey();
                }
                if (opcion == 4)
                {
                    break;
                }
            }
        }
    }
}
