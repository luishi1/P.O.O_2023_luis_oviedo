using System;


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
            public string nombre;
            public int edad;
            public int dni;
            public char sexo;
            public double peso;
            public double altura;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            public int Edad
            {
                get { return edad; }
                set { edad = value; }
            }
            public int Dni
            {
                get { return dni; }
            }
            public char Sexo
            {
                get { return sexo; }
                set { sexo = value; }
            }
            public double Peso
            {
                get { return peso; }
                set { peso = value; }
            }
            public double Altura
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
                this.dni = GenerarDni();
                this.peso = 170;
                this.altura = 897;
            }

            public persona(string nombre, int edad, char sexo, double peso, double altura)
            {
                this.nombre = nombre;
                this.edad = edad;
                int dni = GenerarDni();
                this.sexo = compasexo(sexo);
                this.peso = peso;
                this.altura = altura;

            }

            public int GenerarDni()
            {
                Random rnd = new Random();
                int Dni = rnd.Next(10000000, 99999999);
                return Dni;
            }
            private char compasexo(char sexo)
            {
                if (sexo == 'H' || sexo == 'M' ||  sexo == 'h' || sexo == 'm')
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
            Console.WriteLine("Edad: {0}", persona.edad);
            Console.WriteLine("Sexo: {0}", persona.sexo);
            Console.WriteLine("DNI: {0}", persona.dni);
            Console.WriteLine("Peso: {0} KG", persona.peso);
            Console.WriteLine("Altura: {0} M", persona.altura);

            if (persona.calcularIMC() == -1)
            {
                Console.WriteLine("El usuario posee un peso muy bajo");
            }
            else if (persona.calcularIMC() == 0)
            {
                Console.WriteLine("El usuario posee un peso normal");
            }
            else
            {
                Console.WriteLine("El usuario posee sobrepeso");
            }

            if (persona.esMayorDeEdad() == true)
            {
                Console.WriteLine("El usuario es mayor de edad");
            }
            else
            {
                Console.WriteLine("El usuario es menor de edad");
            }
        }




        static void Main(string[] args)
        {
            string nombre, nombre2;
            int edad, edad2;
            char sexo, sexo2;
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

            persona persona1 = new persona(nombre, edad, sexo, peso, altura);
            persona1.dni = persona1.GenerarDni();

            Console.WriteLine("");
            //creamos segundo objeto
            Console.Write("Ingrese el nombre de la persona2:");
            nombre2 = Console.ReadLine();
            Console.Write("Ingrese la edad de la persona2:");
            edad2 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el genero de la persona2 opciones validas H o M:");
            sexo2 = char.Parse(Console.ReadLine());

            persona persona2 = new persona(nombre, edad, sexo);

            //creamos tercer objeto
            persona persona3 = new persona();
            persona3.nombre = "luis";
            persona3.edad = 17;
            persona3.dni = persona3.GenerarDni();
            persona3.sexo = 'H';
            persona3.peso = 58.97;
            persona3.altura = 1.90;

            Console.WriteLine("Presione cualquier tecla para mostrar los datos");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Informacion Persona 1");
            mostrarinfo(persona1);
            Console.WriteLine("");
            Console.WriteLine("");
            //persona 2
            Console.WriteLine("Informacion Persona 2");
            mostrarinfo(persona2);
            Console.WriteLine("");
            Console.WriteLine("");
            //persona 3
            Console.WriteLine("Informacion Persona 3");
            mostrarinfo(persona3);
        }
    }
}