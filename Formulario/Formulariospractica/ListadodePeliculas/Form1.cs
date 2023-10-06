using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadodePeliculas
{
    public class Peliculas 
    {
        public string Titulo { get; set; }
        public string Director { get; set; }
        public int Duracion { get; set; }
        public int Lanzamiento { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
