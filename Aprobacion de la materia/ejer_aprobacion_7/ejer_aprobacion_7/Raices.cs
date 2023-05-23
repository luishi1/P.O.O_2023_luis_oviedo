using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_7
{
    internal class Raices
    {
        public double a;
        public double b;
        public double c;

        public Raices(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }


        public double getDiscriminante()
        {
            double discriminante = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
            return discriminante;
        }
        public string obtenerRaices()
        {
            double discriminante = getDiscriminante();
            string msg;
            if (discriminante >= 0)
            {

                double x1 = (-b + discriminante) / a * 2;
                double x2 = (-b - discriminante) / a * 2;

                if (x1 == x2)
                {
                    msg = "La raiz es " + x1;
                    return msg;
                }
                else if (x1 != x2)
                {
                    msg = "Las raices son " + x1 + " y " + x2;
                    return msg;
                }
            }
            msg = "No posee raices";
            return msg;
        }

        // public void obtenerRaiz()
        // {
        // double descriminante = getDescriminante();
        // if (tieneRaiz())
        // {
        // double x = -b / a * 2;
        // Console.WriteLine("tiene una unica raiz que es" + x);
        // }
        // else
        // {
        // Console.WriteLine("No tiene raiz unica");
        // }
        // }

        public bool tieneRaices()
        {
            double descriminante = getDiscriminante();
            return descriminante >= 0;
        }
        public bool tieneRaiz()
        {
            double descriminante = getDiscriminante();
            return descriminante == 0;
        }

        public void calcular()
        {
            double descriminante = getDiscriminante();
            string msg = obtenerRaices(); ;
            if (tieneRaices())
            {
                Console.WriteLine(msg);
            }
            else if (tieneRaiz())
            {
                Console.WriteLine(msg);
            }
            else
            {
                Console.WriteLine("la ecuacion no posee una solucion que pertenezca al conjunto de los numeros Reales");
            }
        }
    }
}
