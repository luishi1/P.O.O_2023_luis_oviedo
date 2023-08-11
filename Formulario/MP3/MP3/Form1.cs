using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string lpstrCommand,
        StringBuilder lpstrReturnString, int uReturnLengh, int hwndCallback);


        //constantes 
        const int MAX_PATH = 260;
        const string Tipo = "MPEGVIDEO";
        const string sAlias = "ArchivoDeSonido";
        private string fileName;

        public delegate void ReproductorMessage(string Msg);
        public event ReproductorMessage ReproductorEstado;

        public string NombreDeArchivo
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void importarbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Title = "Selecciona Archivos",
                Multiselect = true,
                Filter = "Archivos de audio|*.MP3|Todos los archivos|*.*"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                foreach (var item in openFile.FileNames)
                {
                    string nombremusica = Path.GetFileName(item);
                    listamusica.Items.Add(nombremusica);
                }
                Reproducir();
            }
        }

        public void Reproducir()
        {
            
        }


        private void listamusica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cerrarbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
