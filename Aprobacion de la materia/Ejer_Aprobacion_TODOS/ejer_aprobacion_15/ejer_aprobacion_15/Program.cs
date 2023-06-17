using System;
using System.Collections.Generic;

namespace ejer_aprobacion_15
{
    public class Almacen 
    {
        private List<Bebida>[,] estanterias;

        public Almacen(int numeroEstanterias)
        {
            estanterias = new List<Bebida>[numeroEstanterias, 1];
            for (int i = 0; i < numeroEstanterias; i++)
            {
                estanterias[i, 0] = new List<Bebida>();
            }
        }

        public double CalcularPrecio() 
        {
            double preciototal = 0;
            foreach (List<Bebida> estanteria in estanterias)
            {
                foreach (Bebida b in estanteria)
                {
                    preciototal += b.precio;
                }
            }
            return preciototal;
        }
        public double CalcularPrecionombre(string marca)
        {
            double preciototal = 0;
            foreach (List<Bebida> estanteria in estanterias)
            {
                Bebida bebida = estanteria.Find(b => b.marca == marca);
                if (bebida != null)
                {
                    preciototal += bebida.precio;
                }
            }
            return preciototal;
        }

        public double CalcularPrecioEstanteria(int Numestanteria)
        {
            double preciototal = 0;
            if (Numestanteria >= 0 && Numestanteria < estanterias.GetLength(0))
            {
                foreach (Bebida b in estanterias[Numestanteria,0])
                {
                    preciototal += b.precio;
                }
            }
            else
            {
                Console.WriteLine("La estanteria seleccionada no existe");
                preciototal = 0;
            }
            return preciototal;
        }

        public void AgregarProducto(Bebida producto, int Numestanteria)
        {
            if (Numestanteria >= 0 && Numestanteria < estanterias.GetLength(0))
            {
                if (!estanterias[Numestanteria, 0].Exists(b => b.identificador == producto.identificador))
                {
                    estanterias[Numestanteria, 0].Add(producto);
                    Console.WriteLine("Producto agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("Ya existe el producto " + producto.identificador + " con ese identificador en la estantería.");
                }
            }
            else
            {
                Console.WriteLine("No existe la estantería " + Numestanteria);
            }
        }

        public void EliminarProducto(string id)
        {
            foreach (List<Bebida> estanteria in estanterias)
            {
                Bebida bebida = estanteria.Find(b => b.identificador == id);
                if (bebida != null) 
                {
                    estanteria.Remove(bebida);
                    Console.WriteLine("Producto con el indentificador " + id + " ha sido eliminado.");
                    return;
                }
            }
            Console.WriteLine("No se encontró un producto con el ID " + id + " en el almacén.");
        }

        public void MostrarInformacion()
        {
            for (int i = 0; i < estanterias.GetLength(0); i++)
            {
                Console.WriteLine("Estanteria N° " + (i + 1) + ":");
                Console.WriteLine();
                foreach (Bebida b in estanterias[i, 0])
                {
                    if (b is AguaMineral agua)
                    {
                        agua.MostrarInfo();
                        Console.WriteLine();
                    }
                    else if (b is Gaseosa gaseosa)
                    {
                        gaseosa.MostrarInfo();
                        Console.WriteLine();
                    }
                }
            }
        }
    }
    public class Bebida
    {
        public string identificador { get; set; }
        public double litros { get; set; }
        public double precio { get; set; }
        public string marca { get; set; }

        public Bebida(string identificador, double litros, double precio, string marca)
        {
            this.identificador = identificador;
            this.litros = litros;
            this.precio = precio;
            this.marca = marca;
        }

        public virtual void MostrarInfo() 
        {
            Console.WriteLine("Identificador: " + identificador);
            Console.WriteLine("Litros: " + litros + " L");
            Console.WriteLine("Precio: " + precio + "$");
            Console.WriteLine("Marca: " + marca);
        }

    }
    public class AguaMineral : Bebida
    {
        private string origen { get; set; }

        public AguaMineral(string identificador, double litros, double precio, string marca , string origen) : base(identificador,litros,precio,marca)
        {
            this.origen = origen;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Origen: " + origen);
        }
    }
    public class Gaseosa : Bebida
    {
        private double porcentaje { get; set; }
        private bool promocion { get; set; }

        public Gaseosa(string identificador, double litros, double precio, string marca, double porcentaje, bool promocion): base(identificador, litros, precio, marca)
        {
            this.porcentaje = porcentaje;
            this.promocion = promocion;
        }
        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine("Porcentaje: " + porcentaje + "% de azucar");
            if (promocion == true)
            {
                Console.WriteLine("Posee promocion");
            }
            else if(promocion == false)
            {
                Console.WriteLine("No posee promocion");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Almacen almacen = new Almacen(3);

            //objetos predefinidos
            almacen.AgregarProducto(new AguaMineral("agua1" , 2 , 120 , "MarcaA", "OrigenA"), 0);
            almacen.AgregarProducto(new AguaMineral("agua2", 1.5, 100, "MarcaA", "OrigenA"), 1);
            almacen.AgregarProducto(new Gaseosa("gaseosa1", 0.5, 80, "MarcaB", 10, false), 0);
            almacen.AgregarProducto(new Gaseosa("gaseosa2", 1, 120, "MarcaC", 5, true), 2);
            almacen.AgregarProducto(new AguaMineral("agua3", 2.5, 150, "MarcaB", "OrigenB"), 1);
            almacen.AgregarProducto(new Gaseosa("gaseosa3", 0.75, 90, "MarcaC", 8, false), 2);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingrese el N° de la opcion que desea realizar");
                Console.WriteLine("1.   Agregar producto.");
                Console.WriteLine("2.   Eliminar producto.");
                Console.WriteLine("3.   Calcular precio total de todos los productos.");
                Console.WriteLine("4.   Calcular precio total de todos los productos de una marca especifica.");
                Console.WriteLine("5.   Calcular precio total de todos los productos de una estanteria especifica.");
                Console.WriteLine("6.   Listar todos los productos.");
                Console.WriteLine("7.   Salir.");
                int opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese los datos del producto:");
                    Console.Write("Identificador: ");
                    string identificador = Console.ReadLine();
                    Console.Write("Litros: ");
                    double litros = double.Parse(Console.ReadLine());
                    Console.Write("Precio: ");
                    double precio = double.Parse(Console.ReadLine());
                    Console.Write("Marca: ");
                    string marca = Console.ReadLine();
                    Console.WriteLine("Tipo de producto:");
                    Console.WriteLine("1. Agua Mineral");
                    Console.WriteLine("2. Gaseosa");
                    int tipoProducto = int.Parse(Console.ReadLine());

                    if (tipoProducto == 1)
                    {
                        Console.Write("Origen: ");
                        string origen = Console.ReadLine();
                        AguaMineral aguaMineral = new AguaMineral(identificador, litros, precio, marca, origen);
                        Console.Write("Ingrese el número de estantería donde desea agregar el producto: ");
                        int numEstanteria = int.Parse(Console.ReadLine());
                        almacen.AgregarProducto(aguaMineral, numEstanteria);
                    }
                    else if (tipoProducto == 2)
                    {
                        Console.Write("Porcentaje de azúcar: ");
                        double porcentajeAzucar = double.Parse(Console.ReadLine());
                        Console.Write("¿Posee promoción? (S/N): ");
                        string tienePromocion = Console.ReadLine();
                        bool promocion = tienePromocion.ToLower() == "s";
                        Gaseosa gaseosa = new Gaseosa(identificador, litros, precio, marca, porcentajeAzucar, promocion);
                        Console.Write("Ingrese el número de estantería donde desea agregar el producto: ");
                        int numEstanteria = int.Parse(Console.ReadLine());
                        almacen.AgregarProducto(gaseosa, numEstanteria);
                    }

                    Console.ReadKey();
                }
                else if (opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el identificador del producto que desea eliminar:");
                    string identificador = Console.ReadLine();
                    almacen.EliminarProducto(identificador);
                    Console.ReadKey();
                }
                else if (opcion == 3)
                {
                    Console.Clear();
                    double precioTotal = almacen.CalcularPrecio();
                    Console.WriteLine("Precio total de todos los productos: $" + precioTotal);
                    Console.ReadKey();
                }
                else if (opcion == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese la marca de los productos que desea calcular el precio total:");
                    string marca = Console.ReadLine();
                    double precioTotalMarca = almacen.CalcularPrecionombre(marca);
                    Console.WriteLine("Precio total de los productos de la marca " + marca + ": $" + precioTotalMarca);
                    Console.ReadKey();
                }
                else if (opcion == 5)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el número de estantería que desea calcular el precio total:");
                    int numEstanteria = int.Parse(Console.ReadLine());
                    double precioTotalEstanteria = almacen.CalcularPrecioEstanteria(numEstanteria);
                    Console.WriteLine("Precio total de los productos en la estantería " + numEstanteria + ": $" + precioTotalEstanteria);
                    Console.ReadKey();
                }
                if (opcion == 6)
                {
                    Console.Clear();
                    almacen.MostrarInformacion();
                    Console.ReadKey();
                }
                if (opcion == 7)
                {
                    break;
                }
            }
        }
    }
}

