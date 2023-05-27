using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    public class Aula
    {
        public int id { get; set; }
        public int alumnosmax { get; set; }
        public string auladestinada { get; set; }
        public Docente docente { get; set; }
        public List<Alumno> alumnos;

        public Aula() { }
        public Aula(int id, int alumnosmax, string auladestinada)
        {
            this.id = id;
            this.alumnosmax = alumnosmax;
            this.auladestinada = auladestinada;
            this.alumnos = new List<Alumno>();
        }

        public void Obtenerdocente(Docente docente)
        {
            this.docente = docente;
        }

        public void generarAlumno(string[] nombres, string[] apellidos, Random rand)
        {
            string nombre = nombres[rand.Next(nombres.Length)];
            string apellido = apellidos[rand.Next(apellidos.Length)];
            int edad = rand.Next(16, 19);
            double calificacion = rand.Next(1, 10);
            alumnos.Add(new Alumno(nombre, apellido, edad, calificacion));
        }

        public void mostrarAlumnos()
        {
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine("Nombre completo : " + a.nombre + " " + a.apellido + ", Edad : " + a.edad + ", Calificacion : " + a.calificacion + " El alumno se encuentra en " + a.nota);
            }
        }
        public int Aprobados()
        {
            int aprobados = 0;
            foreach (Alumno a in alumnos)
            {
                if (a.sexo == "Hombre" && a.calificacion >= 6)
                {
                    aprobados++;
                }
            }
            return aprobados;
        }

        public int Aprobadas()
        {
            int aprobadas = 0;
            foreach (Alumno a in alumnos)
            {
                if (a.sexo == "Mujer" && a.calificacion >= 6)
                {
                    aprobadas++;
                }
            }
            return aprobadas;
        }

        public bool hayClase()
        {
            if (docente == null || !docente.Ausente())
            {
                return false;
            }
            if (docente.materia != auladestinada)
            {
                return false;
            }
            int alumnospresentes = (int)Math.Ceiling(alumnosmax * 0.5);
            return alumnospresentes > alumnosmax / 2;
        }

    }

}
