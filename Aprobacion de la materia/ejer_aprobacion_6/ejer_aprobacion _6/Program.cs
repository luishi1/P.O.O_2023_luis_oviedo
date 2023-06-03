using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion__6
{
    internal class Program
    {
        class libro
        {
            //atributos
            public int isbn;
            public string titulo;
            public string autor;
            public int paginas;

            //propiedades
            public int ISBN
            {
                get { return isbn; }
                set { isbn = value; }
            }

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

            public int Paginas
            {
                get { return paginas; }
                set { paginas = value; }
            }


            public libro(int isbn, string titulo, string autor, int pag)
            {
                this.isbn = isbn;
                this.titulo = titulo;
                this.autor = autor;
                this.paginas = pag;
            }

            public void mostrartodo()
            {
                Console.WriteLine("El libro de titulo " + titulo + "con ISBN de numero" + isbn + " creado por " + autor + "que tiene " + paginas + "paginas");
            }

            static void Main(string[] args)
            {
                libro libro1 = new libro(7656546 , "El principito" , "Antoine de Saint-Exupéry" , 120);
                libro libro2 = new libro(1489632, "El Matadero", "Esteban Echevarria ", 26);

                if (libro1.paginas > libro2.paginas)
                {
                    Console.WriteLine(libro1.titulo + " tiene mas paginas que " + libro2.titulo);
                }
                else if (libro1.paginas < libro2.paginas)
                {
                    Console.WriteLine(libro2.titulo + " tiene mas paginas que " + libro1.titulo);
                }
                else
                {
                    Console.WriteLine("Ambos tiene la misma cantidad de paginas");
                }

            }
        }
    }
}
