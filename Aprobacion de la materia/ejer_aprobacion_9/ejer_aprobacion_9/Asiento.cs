using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejer_aprobacion_9
{
    public class Asiento
    {
        public int fila;
        public char columna;
        public Espectador espectador;

        public Asiento() { }
        public Asiento(int fila, char columna)
        {
            this.fila = fila;
            this.columna = columna;
            this.espectador = null;
        }

        //booleano para preguntar si el asiento tiene un espectador , si esta ocupado es decir no nulo devuelve verdadero
        public bool EstaOcupado()
        {
            return espectador != null;
        }

        // esto para devolver la fila y la columna 
        public string FilaColumna()
        {
            return fila + "" + columna;
        }

        //sentamos el espectador en el asiento
        public void SentarEspectador(Espectador e)
        {
            this.espectador = e;
        }
    }
}
