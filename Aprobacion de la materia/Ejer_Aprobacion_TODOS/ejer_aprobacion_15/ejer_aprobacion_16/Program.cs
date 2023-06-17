using System;

namespace ejer_aprobacion_16
{
    public class Agenda
    {
        public Contacto[] contactos;

        public Agenda()
        {
            contactos = new Contacto[10];
        }

        public void AñadirContacto(Contacto contacto)
        {
            if (AgendaLlena())
            {
                Console.WriteLine("No se pueden agregar más contactos. La agenda está llena.");
                return;
            }

            foreach (Contacto c in contactos)
            {
                if (c != null && c.nombre == contacto.nombre)
                {
                    Console.WriteLine("No se puede agregar un duplicado del mismo contacto");
                    return;
                }
            }

            for (int i = 0; i < contactos.Length; i++)
            {
                if (contactos[i] == null)
                {
                    contactos[i] = contacto;
                    Console.WriteLine("Contacto agregado en la posición: " + (i+1));
                    return;
                }
            }
        }

        public void ExisteContacto(Contacto contacto)
        {
            foreach (Contacto c in contactos)
            {
                if (c != null && c.nombre == contacto.nombre)
                {
                    Console.WriteLine("El contacto que desea buscar ya existe.");
                    return;
                }
            }
            Console.WriteLine("El contacto no existe en la agenda.");
        }

        public void ListarContactos()
        {
            int contador = 1;
            foreach (Contacto contacto in contactos)
            {
                if (contacto != null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Contacto N°: " + contador);
                    Console.WriteLine("Nombre agendado: " + contacto.nombre);
                    Console.WriteLine("Numero agendado: " + contacto.numero);
                    Console.WriteLine();
                }
                contador++;
            }
        }

        public void BuscaContacto(string nombre)
        {
            nombre = nombre.ToLower();
            foreach (Contacto contacto in contactos)
            {
                if (contacto != null && contacto.nombre.ToLower() == nombre)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nombre agendado: " + contacto.nombre);
                    Console.WriteLine("Numero agendado: " + contacto.numero);
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("El contacto no existe en la agenda.");
        }


        public void EliminarContacto(Contacto contacto)
        {
            foreach (Contacto c in contactos)
            {
                if (c != null && c.Equals(contacto))
                {
                    for (int i = 0; i < contactos.Length; i++)
                    {
                        if (contactos[i] != null && contactos[i].Equals(contacto))
                        {
                            contactos[i] = null;
                            Console.WriteLine("Contacto eliminado de la agenda.");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("El contacto no existe en la agenda.");
        }

        public void EliminarContactoPorNombre(string nombre)
        {
            foreach (Contacto contacto in contactos)
            {
                if (contacto != null && contacto.nombre.ToLower() == nombre)
                {
                    EliminarContacto(contacto);
                    return;
                }
            }

            Console.WriteLine("El contacto no existe en la agenda.");
        }

        public void EliminarContactoPorNumero(int numero)
        {
            foreach (Contacto contacto in contactos)
            {
                if (contacto != null && contacto.numero == numero)
                {
                    EliminarContacto(contacto);
                    return;
                }
            }

            Console.WriteLine("El contacto no existe en la agenda.");
        }

        public bool AgendaLlena()
        {
            foreach (Contacto contacto in contactos)
            {
                if (contacto == null)
                {
                    return false;
                }
            }
            return true;
        }

        public int HuecosLibres()
        {
            int contador = 0;
            foreach (Contacto contacto in contactos)
            {
                if (contacto == null)
                {
                    contador++;
                }
            }
            return contador;
        }
    }

    public class Contacto
    {
        public string nombre { get; set; }
        public int numero { get; set; }

        public Contacto(string nombre, int numero)
        {
            this.nombre = nombre;
            this.numero = numero;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            Contacto contacto1 = new Contacto("Juan", 123456789);
            Contacto contacto2 = new Contacto("Maria", 987654321);
            Contacto contacto3 = new Contacto("Carlos", 123456789);
            Contacto contacto4 = new Contacto("Laura", 123456789);
            Contacto contacto5 = new Contacto("Pedro", 123456789);
            Contacto contacto6 = new Contacto("Ana", 987654321);
            Contacto contacto7 = new Contacto("Luis", 123456789);
            Contacto contacto8 = new Contacto("Sofia", 123456789);
            Contacto contacto9 = new Contacto("Pablo", 123456789);


            agenda.AñadirContacto(contacto1);
            agenda.AñadirContacto(contacto2);
            agenda.AñadirContacto(contacto3);
            agenda.AñadirContacto(contacto4);
            agenda.AñadirContacto(contacto5);
            agenda.AñadirContacto(contacto6);
            agenda.AñadirContacto(contacto7);
            agenda.AñadirContacto(contacto8);
            agenda.AñadirContacto(contacto9);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Elegir la opción que desea realizar:");
                Console.WriteLine("1. Agendar Contacto");
                Console.WriteLine("2. Existe Contacto");
                Console.WriteLine("3. Listar Contactos");
                Console.WriteLine("4. Buscar Contacto");
                Console.WriteLine("5. Eliminar Contacto");
                Console.WriteLine("6. La agenda se encuentra llena?");
                Console.WriteLine("7. Cuántos huecos libres hay?");
                Console.WriteLine("8. Salir");

                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del contacto:");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el número de teléfono:");
                    int numero = int.Parse(Console.ReadLine());
                    Contacto contacto = new Contacto(nombre, numero);
                    agenda.AñadirContacto(contacto);
                }
                else if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del contacto:");
                    string nombreBuscar = Console.ReadLine().ToLower();
                    Contacto contactoBuscar = new Contacto(nombreBuscar, 0);
                    agenda.ExisteContacto(contactoBuscar);
                }
                else if (opcion == 3)
                {
                    Console.Clear();
                    agenda.ListarContactos();
                }
                else if (opcion == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre del contacto a buscar:");
                    string nombreBuscarContacto = Console.ReadLine();
                    agenda.BuscaContacto(nombreBuscarContacto);
                }
                else if (opcion == 5)
                {
                    Console.Clear();
                    Console.WriteLine("¿Desea eliminar por nombre o número?");
                    Console.WriteLine("1. Eliminar por nombre");
                    Console.WriteLine("2. Eliminar por número");
                    int opcionEliminar = int.Parse(Console.ReadLine());

                    switch (opcionEliminar)
                    {
                        case 1:
                            Console.WriteLine("Ingrese el nombre del contacto a eliminar:");
                            string nombreEliminar = Console.ReadLine().ToLower();
                            agenda.EliminarContactoPorNombre(nombreEliminar);
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el número del contacto a eliminar:");
                            int numeroEliminar = int.Parse(Console.ReadLine());
                            agenda.EliminarContactoPorNumero(numeroEliminar);
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }

                else if (opcion == 6)
                {
                    Console.Clear();
                    Console.WriteLine("La agenda se encuentra llena: " + agenda.AgendaLlena());
                }
                else if (opcion == 7)
                {
                    Console.Clear();
                    Console.WriteLine("Huecos libres en la agenda: " + agenda.HuecosLibres());
                }
                else if (opcion == 8)
                {
                    break;
                }
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
