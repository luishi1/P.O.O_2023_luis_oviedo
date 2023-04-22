using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app6
{
    internal class Program
    {
        class tareas
        {
            public string nombre;
            public int prioridad;

            public tareas(string nombre, int prioridad)
            {
             this.nombre = nombre;
             this.prioridad = prioridad;
            }

            public void insertar(string nombre, int prio, List<tareas> list)
            {
                list.Add(new tareas(nombre, prio));
            }

          

        }

        static void Main(string[] args)
        {
            List<tareas>list = new List<tareas>();
            tareas tarea1 = new tareas("ayuda",1);
            list.Add(new tareas("dormir", 1));
            list.Add(new tareas("comer", 1));
            list.Add(new tareas("jugar a la play", 3));
            list.Add(new tareas("deporte", 2));
            list.Add(new tareas("estudiar", 1));
            list.Add(new tareas("respirar", 3));
            list.Add(new tareas("explotar la casa de gaspar", 1));

            int opcion, opcion2;
            string nombre;
            int prioridad;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingrese que opcion quiere realizar");
                Console.WriteLine("1. insertar nueva tarea");
                Console.WriteLine("2. mostrar orden");
                Console.WriteLine("3. salir");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Inserter por favor el nombre de la tarea");
                    nombre = Console.ReadLine();
                    Console.WriteLine("Inserter por favor la prioridad de la tarea");
                    Console.WriteLine("SIGNIFICADOS");
                    Console.WriteLine("1 = TAREA SUPER IMPORTANTE");
                    Console.WriteLine("2 = TAREA MEDIANA IMPORTANTE");
                    Console.WriteLine("3 = NO ES TAN IMPORTANCIA");
                    Console.WriteLine("4 >= = EXISTE?");
                    prioridad = int.Parse(Console.ReadLine());
                    tarea1.insertar(nombre, prioridad,list);
                    Console.ReadKey();
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Inserte por favor de la manera que desee que se ordene");
                    Console.WriteLine("1 = por nombre de la tarea");
                    Console.WriteLine("2 = por prioridad");
                    opcion2 = int.Parse(Console.ReadLine());
                    if (opcion2 == 1)
                    {
                        Console.Clear();
                        list.Sort((x, y) => x.nombre.CompareTo(y.nombre));

                        foreach (tareas t in list)
                        {
                            Console.WriteLine(t.nombre + " prioridad: " + t.prioridad);
                        }
                        Console.ReadKey();
                    }
                    if (opcion2 == 2)
                    {
                        Console.Clear();
                        list.Sort((x, y) => x.prioridad.CompareTo(y.prioridad));

                        foreach (tareas t in list)
                        {
                            Console.WriteLine(t.nombre + " prioridad: " + t.prioridad);
                        }
                        Console.ReadKey();
                    }
                }
                if (opcion == 3)
                {
                    break;
                }
            }
           
        }

    }
}
//6. Crear un programa que permita al usuario ingresar una lista de tareas y organizarlas por orden de prioridad.