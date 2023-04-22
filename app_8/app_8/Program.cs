using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_8
{
    internal class Program
    {
        class biblioteca
        {
            public string nombre_usu;
            public string nombre_libro;
            public int prestamos;
            public int devolucioes;

            public biblioteca(string nombre_usu, string nombre_libro, int prestamos, int devolucioes)
            {
                this.nombre_usu = nombre_usu;
                this.nombre_libro = nombre_libro;
                this.prestamos = prestamos;
                this.devolucioes = devolucioes;
            }

            //DD de Depositar y Donar , soy una locura
            public void DD(string nombreu , string nombrelibro , int prestamos , int devoluciones , List<biblioteca> list )
            {
                foreach (biblioteca b in list)
                {
                    if (b.nombre_usu.ToUpper() == nombreu.ToUpper())
                    {
                        devoluciones = b.devolucioes + 1;
                    }
                }
                list.Add(new biblioteca(nombreu, nombrelibro, prestamos, devoluciones));
            }

            public void prestar(biblioteca usuario , List<biblioteca> list , string nombreu)
            {
               
                list.Remove(usuario);
                foreach (biblioteca b in list)
                {
                    if (b.nombre_usu.ToUpper() == nombreu.ToUpper())
                    {
                        usuario.prestamos = usuario.prestamos + 1;
                    }
                }
            }

            public biblioteca buscar(string libro, List<biblioteca> list)
            {
                foreach (biblioteca b in list)
                {
                    if (b.nombre_libro.ToUpper() == libro.ToUpper())
                        return b;

                }
                return null;
            }

            public void mostrar(List<biblioteca> list)
            {
                foreach (biblioteca b in list)
                {
                    Console.WriteLine(b.nombre_libro + ", Entregado por el usuario " + b.nombre_usu + " Tiene un total de "+ b.prestamos+ " prestamos actualmente y un total de "+ b.devolucioes+" devoluciones o registros  actualmente");
                }

            }
        }
        static void Main(string[] args)
        {
            string nombre_usu;
            string nombre_libro;
            int prestamos = 0;
            int devoluciones = 0;
            int opcion , opcion2 ;
            biblioteca biblioteca1 = new biblioteca("a","a",0,0);
            biblioteca usuario;
            List<biblioteca> list = new List<biblioteca>();
            list.Add(new biblioteca("Fujimoto", "CSM", 0, 0));
            list.Add(new biblioteca("cortazar", "soledad", 0, 0));
            list.Add(new biblioteca("ishigod", "calamares", 0, 0));
            list.Add(new biblioteca("merlina", "comeras", 0, 0));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("             B I B L I O T E C A ");
                Console.WriteLine("elija la opcion que deseea realizar");
                Console.WriteLine("1. Depositar o donar libro ");
                Console.WriteLine("2. Prestarme libro");
                Console.WriteLine("3. Buscar libro");
                Console.WriteLine("4. Ver biblioteca");
                Console.WriteLine("5. Salir");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Inserte los siguientes datos");
                    Console.Write("Nombre de usuario:");
                    nombre_usu = Console.ReadLine();
                    Console.Write("Nombre del libro:");
                    nombre_libro = Console.ReadLine();
                    biblioteca1.DD(nombre_usu, nombre_libro, prestamos, devoluciones,list);
                    Console.ReadKey();
                }
                if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Inserte los siguientes datos");
                    Console.Write("Nombre del libro:");
                    nombre_libro = Console.ReadLine();
                    usuario = biblioteca1.buscar(nombre_libro, list);
                    nombre_usu = usuario.nombre_usu;
                    if (usuario == null)
                    {
                        Console.Write("No se encontro el libro que busca");
                        Console.ReadKey();
                    }
                    else
                      {
                        Console.WriteLine("Se encontro el libro que busca ¿Quiere tomarlo prestado?");
                        Console.WriteLine("1. SIPI");
                        Console.WriteLine("2. NOPE");
                        opcion2 = int.Parse(Console.ReadLine());
                        if (opcion2 == 1)
                        {
                            biblioteca1.prestar(usuario, list , nombre_usu);
                        }
                        if (opcion2 == 2)
                        {
                            Console.WriteLine("bueno");
                        }
                        Console.ReadKey();
                    }
                }
                if (opcion == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del libro que quiere buscar");
                    nombre_libro = Console.ReadLine();
                    usuario = biblioteca1.buscar(nombre_libro, list);
                    if (usuario == null)
                    {
                        Console.WriteLine("No se encontro el libro que busca");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Se encontro");
                        Console.ReadKey();
                    }
                }
                if (opcion == 4)
                {
                    Console.Clear();
                    biblioteca1.mostrar(list);
                    Console.ReadKey();
                }
                if (opcion == 5)
                {
                    break;
                }
            }
            
        }
    }
}
//8. Crear un programa que simule una biblioteca,
//permitiendo al usuario buscar y prestar libros, y llevando un registro de los préstamos y devoluciones.

//buscar(nombre , libro , prestamos , devoluciones ) , insertar , eliminar
//no salio el de prestamos

