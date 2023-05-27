using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] nombres =
            { "Felipe" , "Tobias" , "Agustin" , "Lucio" , "Marcos" , "Leandro" , "Gaspar" , "Thiago" , "Evelyn" , "Sebastian" , "Joaquin" , "Santiago" ,
                "Matias" , "Facundo" , "Claudia" , "Azul" , "Sofia" , "Tamara" , "Jorge" , "Gabriel" , "Angie" , "Aaron" , "Luis" , "Pablo" , "Esteban" , "Emma" , "Graciela" , "Estella" , "Sandra" };

            string[] apellidos =
            { "Canepa" , "Coman" , "Condori" , "Dibman" , "Gaspar" , "Gomez" , "Oshiro" , "Kappou" , "Magdalena" , "Torres" ,
                "Pardo" , "Reyes" , "Matayoshi" , "Otamendi" , "Quevedo" , "Vergara" , "Nusdeo" , "Zabalsa" , "Rojas" , "Ochoa" ,
                "Valera" , "Ventura" , "Polo" , "Oviedo"  , "Fiscella" , "Teruel" , "De pablo" , "Capalbo" , "Viane" , "Valdez"};

            string[] materias =
            {
                "Matematica" , "Filosofia" , "Fisica"
            };

            Random rand = new Random();
            Docente d = new Docente();
            Docente docente;
            int cantidad = 0;
            int alumnosA;
            int alumnasA;
            int totales;
        
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Ingrese la cantidad maxima de Alumnos en el aula");
                cantidad = int.Parse(Console.ReadLine());
                Aula aula = new Aula(5, cantidad, "Matematica");
                Console.Clear();
                docente = d.generarDocente(nombres, apellidos, rand, materias);
                aula.Obtenerdocente(docente);
                for (int i = 0; i < cantidad; i++)
                {
                    aula.generarAlumno(nombres,apellidos,rand);
                }
                if (aula.hayClase())
                {
                    Console.WriteLine("AULA N° " + aula.id);
                    Console.WriteLine("AULA de  " + aula.auladestinada);
                    Console.WriteLine("");
                    aula.mostrarAlumnos();
                    alumnasA = aula.Aprobadas();
                    alumnosA = aula.Aprobados();
                    totales = alumnosA + alumnasA;
                    Console.WriteLine("Hay un total de " + totales + " Aprobados , Un total de " + alumnasA + " Alumnas y un total de " + alumnosA + " Alumnos Aprobados");
                    Console.WriteLine("");
                    docente.mostrarDocente(docente);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No se pudo dar clases en el AULA N° " + aula.id);
                    Console.WriteLine("Toque caulquier tecla para reiniciar el ejercicio , repetir hasta que se cumpla las condiciones");
                    Console.ReadKey();
                }
            }
        }
    }
}
//ES PROBRAR HASTA QUE SE CUMPLA LAS CONDICIONES