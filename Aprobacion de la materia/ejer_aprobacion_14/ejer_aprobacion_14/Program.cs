using System;

class Producto
{
    private string nombre;
    private double precio;

    public Producto(string nombre, double precio)
    {
        this.nombre = nombre;
        this.precio = precio;
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public override string ToString()
    {
        return "Nombre: " + nombre + ", Precio: " + precio;
    }
    public virtual double Calcular(int cantidad)
    {
        return precio * cantidad;
    }
}

class Perecedero : Producto
{
   
    private int diasCaducar;

  
    public Perecedero(string nombre, double precio, int diasCaducar) : base(nombre, precio)
    {
        this.diasCaducar = diasCaducar;
    }

   
    public int DiasCaducar
    {
        get { return diasCaducar; }
        set { diasCaducar = value; }
    }


    public override string ToString()
    {
        return base.ToString() + ", Días a caducar: " + diasCaducar;
    }
    public override double Calcular(int cantidad)
    {
        if (diasCaducar == 1)
        {
            return base.Calcular(cantidad) / 4;
        }
        else if (diasCaducar == 2)
        {
            return base.Calcular(cantidad) / 3;
        }
        else if (diasCaducar == 3)
        {
            return base.Calcular(cantidad) / 2;
        }
        else
        {
            return base.Calcular(cantidad);
        }
    }
}

class NoPerecedero : Producto
{

    private string tipo;


    public NoPerecedero(string nombre, double precio, string tipo) : base(nombre, precio)
    {
        this.tipo = tipo;
    }


    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public override string ToString()
    {
        return base.ToString() + ", Tipo: " + tipo;
    }
    public override double Calcular(int cantidad)
    {
        return base.Calcular(cantidad);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Producto[] productos = new Producto[5];

        
        Producto producto1 = new Producto("Producto1", 10.5);
        NoPerecedero noperecedero1 = new NoPerecedero("Producto1", 10.5 , "Comestible");
        Perecedero perecedero1 = new Perecedero("Perecedero1", 20.5, 1);
        Perecedero perecedero2 = new Perecedero("Perecedero1", 8.96, 5);
        Perecedero perecedero3 = new Perecedero("Perecedero1", 70.2, 3);


        productos[0] = producto1;
        productos[1] = noperecedero1;
        productos[2] = perecedero1;
        productos[3] = perecedero2;
        productos[4] = perecedero3;


        int cantidad = 5;

        foreach (Producto producto in productos)
        {
            Console.WriteLine(producto);
            double precioTotal = producto.Calcular(cantidad);
            Console.WriteLine("Precio total por vender " + cantidad + " productos: " + precioTotal);
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}
/*
Nos piden que gestionemos una serie de productos.
Los productos tienen los siguientes atributos:
Nombre
Precio
Tenemos dos tipos de productos:
Perecedero: tiene un atributo llamado días a caducar
No perecedero: tiene un atributo llamado tipo
Crea sus constructores, getters, setters y toString.
Tendremos una función llamada calcular, que según cada clase hará una cosa u otra, a esta función le pasaremos un número siendo la cantidad de productos
En Producto, simplemente sería multiplicar el precio por la cantidad de productos pasados.
En Perecedero, aparte de lo que hace producto, el precio se reducirá según los días a caducar:
Si le queda 1 día para caducar, se reducirá 4 veces el precio final.
Si le quedan 2 días para caducar, se reducirá 3 veces el precio final.
Si le quedan 3 días para caducar, se reducirá a la mitad de su precio final.
En NoPerecedero, hace lo mismo que en producto
Crea una clase ejecutable y crea un array de productos y muestra el precio total de vender 5  productos de cada uno. Crea tú mismo los elementos del array.

 */