using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisorImagenesSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Selecciona imagen",
                Multiselect = true,
                Filter = "Archivos de imagen|*.jpg;*.png;*.gif|Todos los archivos|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var nombres in openFileDialog.FileNames)
                {
                    listBox1.Items.Add(nombres);
                    CargarImagen(nombres);
                }
            }
        }

        public void CargarImagen(string nombres) 
        {
            if (File.Exists(nombres))
            {
                pictureBox1.Image = new Bitmap(nombres);
            }
        }
        
        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null && listBox1.SelectedIndex >= 0)
            {
                string img = listBox1.SelectedItem.ToString();
                CargarImagen(img);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex--;
                string img = listBox1.SelectedItem.ToString();
                CargarImagen(img);
            }
            else
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                string img = listBox1.SelectedItem.ToString();
                CargarImagen(img);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex++;
                string img = listBox1.SelectedItem.ToString();
                CargarImagen(img);
            }
            else
            {
                listBox1.SelectedIndex = 0;
                string img = listBox1.SelectedItem.ToString();
                CargarImagen(img);
            }
        }
    }
}
