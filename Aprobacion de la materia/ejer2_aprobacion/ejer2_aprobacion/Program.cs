using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer2_aprobacion
{
    internal class Program
    {
        class persona
        {

            public const char sexodefault = 'H';
            private const int pesobajo = -1;
            private const int pesonormal = 0;
            private const int sobrepeso = 1;

            public string nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            public int edad
            {
                get { return edad; }
                set { edad = value; }
            }
            public string dni
            {
                get { return dni; }
            }
            public char sexo
            {
                get { return sexo; }
                set { sexo = value; }
            }
            public double peso
            {
                get { return peso; }
                set { peso = value; }
            }
            public double altura
            {
                get { return altura; }
                set { altura = value; }
            }

            public persona() { }

            public persona(string nombre, int edad, char sexo)
            {
                this.nombre = nombre;
                this.edad = edad;
                this.sexo = sexodefault;
            }

            public persona(string nombre, int edad, string dni, char sexo, double peso, double altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                dni = GenerarDni();
                this.sexo = compasexo(sexo);
                this.peso = peso;
                this.altura = altura;

            }

            private string GenerarDni()
            {
                Random rnd = new Random();
                int Dni = rnd.Next(10000000, 99999999);
                string dnipunteado = Dni.ToString("00000000");
                dnipunteado = dnipunteado.Insert(2, ".").Insert(6, ".").Insert(10, ".");
                return dnipunteado;
            }
            private char compasexo(char sexo)
            {
                if (sexo == 'H' || sexo == 'M')
                {
                    return sexo;
                }
                else
                {
                    return 'H';
                }

            }

            public int calcularIMC()
            {
                double imc = peso / (altura * altura);
                if (imc < 20)
                {
                    return pesobajo;
                }
                else if (imc >= 20 && imc <= 25)
                {
                    return pesonormal;
                }
                else
                {
                    return sobrepeso;
                }
            }

            public bool esMayorDeEdad()
            {
                if (edad > 18)
                {
                    return true;
                }
                else
                    return false;
            }
        }


        static void mostrarinfo(persona persona)
        {
            Console.WriteLine("Nombre: {0}", persona.nombre);
            Console.WriteLine("Edad: {1}", persona.edad);
            Console.WriteLine("Sexo: {2}", persona.sexo);
            Console.WriteLine("DNI: {3}", persona.dni);
            Console.WriteLine("Peso: {4} KG", persona.peso);
            Console.WriteLine("Altura: {5} M", persona.altura);
        }

        


        static void Main(string[] args)
        {
            string nombre;
            string dni = "";
            int edad;
            char sexo;
            double peso;
            double altura;

            //creamos primer objeto
            Console.Write("Ingrese el nombre de la persona:");
            nombre = Console.ReadLine();
            Console.Write("Ingrese la edad de la persona:");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el genero de la persona opciones validas H o M:");
            sexo = char.Parse(Console.ReadLine());
            Console.Write("Ingrese el peso de la persona:");
            peso = double.Parse(Console.ReadLine());
            Console.Write("Ingrese la altura de la persona:");
            altura = double.Parse(Console.ReadLine());

            persona persona1 = new persona(nombre, edad, dni , sexo, peso, altura);
           

            //creamos segundo objeto
            Console.Write("Ingrese el nombre de la persona2:");
            nombre = Console.ReadLine();
            Console.Write("Ingrese la edad de la persona2:");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el genero de la persona2 opciones validas H o M:");
            sexo = char.Parse(Console.ReadLine());

            persona persona2 = new persona(nombre, edad, sexo);

            //creamos tercer objeto
            persona persona3 = new persona();
            persona3.nombre = "luis";
            persona3.edad = 17;
            persona3.sexo = 'H';

            Console.WriteLine("Presione cualquier tecla para mostrar los datos");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Informacion Persona 1");
            mostrarinfo(persona1);
            if (persona1.calcularIMC() == -1)
            {
                Console.WriteLine("El usuario posee un peso muy bajo");
            }
            else if (persona1.calcularIMC() == 0)
            {
                Console.WriteLine("El usuario posee un peso normal");
            }
            else
            {
                Console.WriteLine("El usuario posee sobrepeso");
            }

            if (persona1.esMayorDeEdad() == true)
            {
                Console.WriteLine("El usuario es mayor de edad");
            }
            else
            {
                Console.WriteLine("El usuario es menor de edad");
            }

            //persona 2
            Console.WriteLine("Informacion Persona 2");
            mostrarinfo(persona2);
            if (persona2.calcularIMC() == -1)
            {
                Console.WriteLine("El usuario posee un peso muy bajo");
            }
            else if (persona2.calcularIMC() == 0)
            {
                Console.WriteLine("El usuario posee un peso normal");
            }
            else
            {
                Console.WriteLine("El usuario posee sobrepeso");
            }

            if (persona2.esMayorDeEdad() == true)
            {
                Console.WriteLine("El usuario es mayor de edad");
            }
            else
            {
                Console.WriteLine("El usuario es menor de edad");
            }

            //persona 3
            Console.WriteLine("Informacion Persona 3");
            mostrarinfo(persona3);
            if (persona3.calcularIMC() == -1)
            {
                Console.WriteLine("El usuario posee un peso muy bajo");
            }
            else if (persona3.calcularIMC() == 0)
            {
                Console.WriteLine("El usuario posee un peso normal");
            }
            else
            {
                Console.WriteLine("El usuario posee sobrepeso");
            }

            if (persona3.esMayorDeEdad() == true)
            {
                Console.WriteLine("El usuario es mayor de edad");
            }
            else
            {
                Console.WriteLine("El usuario es menor de edad");
            }
        }
    }
}
//Process is terminated due to StackOverflowException.
//error epico ayuda juas juas
//pila????