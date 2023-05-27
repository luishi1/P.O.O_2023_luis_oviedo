using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    public class Docente : Persona
    {
        public string materia { get; set; }

        public Docente() { }
        public Docente(string nombre, string apellido, int edad, string materia)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.sexo = diferenciarGenero();
            this.materia = materia;
        }

        public bool Ausente()
        {
            double probabilidad = 0.2;
            Random random = new Random();
            // si random es menor a la probabilidad el profesor falta
            return random.NextDouble() > probabilidad;
        }

        public Docente generarDocente(string[] nombres, string[] apellidos, Random rand, string[] materias)
        {
            string nombre = nombres[rand.Next(nombres.Length)];
            string apellido = apellidos[rand.Next(apellidos.Length)];
            string materia = materias[rand.Next(materias.Length)];
            int edad = rand.Next(19, 62);
            Docente docente = new Docente(nombre, apellido, edad, materia);
            return docente;
        }

        public void mostrarDocente(Docente docente)
        {
            Console.WriteLine("Docente de " + docente.materia);
            Console.WriteLine("Nombre Completo : " + docente.nombre + " " + docente.apellido + ", Edad : " + docente.edad +  ", Genero : " + docente.sexo);
        }
    }

}
