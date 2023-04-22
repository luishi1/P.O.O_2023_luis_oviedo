using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_listas_1
{
    class persona
    {
        public string nombre;
        public string apellido;
        public int edad;

        public string NombreCompleto
        {
            get
            {
                return nombre + ' ' + apellido;
            }
        }

        public persona(string nombre, string apellido , int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public void generar(string[] nombres , string[] apellidos , Random r1 , List<persona>list)
        {
            string nombre = nombres[r1.Next(nombres.Length)];
            string apellido = apellidos[r1.Next(apellidos.Length)];

            list.Add(new persona(nombre , apellido , r1.Next(0,80)));
        }

        public void mostrar(List<persona> list)
        {
            foreach (persona p in list)
            {
                Console.WriteLine(p.nombre +" "+ p.apellido + "," + p.edad +" años");
            }
        }
    }

    class pantalla
    {
       public int recargar = 10;
       public int fallecimientos = 60;
       public int nacimientos = 30;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            persona persona1 = new persona("ale" , "Oviedo" , 16);
            string[] nombres = // 31 nombres
            { "Luis" , "Tobias" , "Thiago" , "Gaspar", "Lautaro" ,"Matias" ,"Gonzalo" ,"Felipe" ,"Luca" ,"Alejandro" ,
            "Nazareno" , "Joseph" ,"Gabriel" ,"Maximiliano" ,"Lucio" , "Santino" , "Mike" ,"Tamara" ,"Angie" ,"Azul" ,
            "Sofia" ,"Antonella" ,"Claudia" ,"Constanza" , "Ashley" , "Abraham" ,"Barack" ,"Will" ,"Shakira" , "Michael" , "Lionel"};

            string[] apellidos = // 31 apellidos
            { "Oviedo" , "Coman" , "Magdalena" , "Kappou", "Del campo" ,"Speranza" ,"Benavente" ,"Canepa" ,"Folco" ,"Maldonado" ,
            "Castro" , "Shupingagua" ,"Volcan" ,"Bocutti" ,"Dibman" , "Constantino" , "Noble" ,"Rojas" ,"Ventura" ,"Nusdeo" , 
            "Zabalsa" ,"Vega" ,"Vergara" ,"Blanca" , "Aguero" , "Lincoln" ,"Obama" ,"Smith" ,"Ripoll " ,"Jackson" , "Messi"};

            Random rand = new Random();

            List<persona> list = new List<persona>();

            

            for (int i = 0; i < 15; i++)
            {
                persona1.generar(nombres ,apellidos , rand , list);
            }
            persona1.mostrar(list);

            while (true)
            {

            }
        }
    }
}
//Ejercicio 1
//En argentina tenemos personas que nacen cada 30 segundos y personas que fallecen cada 60 segundos. 
//1.Crear personas con nombres y apellidos random;
//2.Mostrar la lista de personas cada 10 segundos para que se pueda refrescar la informacion que tenemos
//3. Informar siempre cuantas personas tiene Argentina.
