using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulacion1
{
    public class libro
    {
        private string titulo;
        private string autor;
        private int año;
        private string genero;
        private double precio;

        //metodos set y get
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public int Año
        {
            get { return año; }
            set { año = value; }
        }
        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        //constructores
        public libro() { }
        public libro(string titulo, string autor, int año, string genero, double precio)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.genero = genero;
            this.precio = precio;
        }

        //metodos
        public void CalcularDescuento(double descuento)
        {
            double precioactualizado = precio * (descuento / 100);
            precio = precioactualizado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Titulo del libro: " + titulo + " Escrito por " + autor + " lanzado en el año " + año + " libro del genero " + genero + ". Precio actualmente " + precio + "$");
        }
    }
    public class Revista
    {
        //atributos
        private string titulo;
        private string autor;
        private int año;
        private int cantpaginas;
        private double precio;
        //metodos get y set
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        public int Año
        {
            get { return año; }
            set { año = value; }
        }
        public int Cantpaginas
        {
            get { return cantpaginas; }
            set { cantpaginas = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        //constructores
        public Revista() {}
        public Revista(string titulo , string autor , int año , int cant , double precio)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.año = año;
            this.cantpaginas = cant;
            this.precio = precio;
        }
        //metodos
        public void CalcularDescuento(double descuento)
        {
            double precioactualizado = precio * (descuento / 100);
            precio = precioactualizado;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("Titulo del libro: " + titulo + " Escrito por " + autor + " lanzado en el año " + año + " Posee una cantidad de paginas de  " + cantpaginas + ". Precio actualmente " + precio + "$");
        }
    }
    public class Libreria
    {
        //atributos
        public List<libro> libros;
        public List<Revista> revistas;

        //constuctores
        public Libreria() 
        {
            libros = new List<libro>();
            revistas = new List<Revista>();
        }
        public Libreria(List<libro> libros , List<Revista> revistas)
        {
            this.libros = libros;
            this.revistas= revistas;
        }

        //metodos
        public void AgregarLibro(libro libro)
        {
            libros.Add(libro);
        }

        public void AgregarRevist(Revista revista)
        {
            revistas.Add(revista);
        }

        public void MostrarInformacionLibros()
        {
            foreach (libro l in libros)
            {
                l.MostrarInformacion();
            }
        }
        public void MostrarInformacionRevista()
        {
            foreach (Revista r in revistas)
            {
                r.MostrarInformacion();
            }
        }

    }

       internal class Program
       {
        static void Main(string[] args)
        {
            Libreria libreria = new Libreria();
            libro libro1 = new libro("OSTRAS" , "Yo" , 2029 , "Comedia Romantica" , 900);
            libro libro2 = new libro("penes", "Yo", 2023, "Comedia Romantica", 9100);
            Revista revista1 = new Revista("yogurt" , "yo" , 205 , 9 , 2313);
            Revista revista2 = new Revista("yogurt23123", "yo", 2035, 945, 23413);

            //comienza el ejer
            libreria.AgregarLibro(libro1);
            libreria.AgregarLibro(libro2);
            libreria.AgregarRevist(revista2);
            libreria.AgregarRevist(revista1);
            libreria.MostrarInformacionLibros();
            libreria.MostrarInformacionRevista();

            List<libro> libros = libreria.libros;
            List<Revista> revistas = libreria.revistas;
            foreach (libro l in libros)
            {
                l.CalcularDescuento(10);
            }
            foreach (Revista r in revistas)
            {
                r.CalcularDescuento(20);
            }
            Console.WriteLine("----------------------------------");
            libreria.MostrarInformacionLibros();
            libreria.MostrarInformacionRevista();
        } 
       }
    }

