using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_8
{
    public class Alumno : Persona
    {
        public double calificacion { get; set; }
        public string nota { get; set; }

        public Alumno() { }
        public Alumno(string nombre, string apellido, int edad, double calificacion)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.sexo = diferenciarGenero();
            this.calificacion = calificacion;
            this.nota = alumnoAprobado();
        }
        public string alumnoAprobado()
        {
            if (calificacion >= 9)
            {
                nota = "Avanzado";
                return nota;
            }
            else if (calificacion < 9 && calificacion >= 6)
            {
                nota = "Suficiente";
                return nota;
            }
            else
            {
                nota = "Proceso";
                return nota;
            }
        }



        public void mostrarTodo(List<Alumno> alumnos)
        {
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine("Nombre Completo : " + a.nombre + " " + a.apellido + " , Edad : " + a.edad + " , Calificacion : " + a.calificacion + " El alumno actualmente se encuentra en " + a.nota);
            }
        }

        public bool Ausente()
        {
            double faltazo = 0.5;
            Random ran = new Random();
            double random = ran.NextDouble();
            return random > faltazo;
        }
    }
}
