using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadoPeliculas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void agregarbtn_Click(object sender, EventArgs e)
        {
            if (TextTitulo.Text.Length > 0 && TextDirector.Text.Length > 0 && TextDuracion.Text.Length > 0 && TextFecha.Text.Length > 0)
            {
                int duracion;
                int fecha;
                if (!int.TryParse(TextDuracion.Text, out duracion))
                {
                    MessageBox.Show("Debe ingrese un dato de tipo numerico", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextDuracion.Clear();
                    return;
                }
                if (!int.TryParse(TextFecha.Text , out fecha))
                {
                    MessageBox.Show("Debe ingrese un dato correcto para el año del estreno de la pelicula , debe ser mayor o igual 1878 y menor a 2024", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (fecha < 1878 || fecha > 2024)
                {
                    MessageBox.Show("Debe ingrese un dato correcto para el año del estreno de la pelicula , debe ser mayor o igual 1878 y menor a 2024", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextFecha.Text = "";
                    return;
                }
                string titulo = TextTitulo.Text;
                string director = TextDirector.Text;
                string Pelicula = titulo + "  |  " + director + "  |  " + duracion + " min" + "  |  " + fecha;
                ListaPeliculas.Items.Add(Pelicula);
                TextTitulo.Clear();
                TextDirector.Clear();
                TextDuracion.Clear();
                TextFecha.Clear();
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios si deseea agregar una pelicula a la lista", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editarbtn_Click(object sender, EventArgs e)
        {
            if (ListaPeliculas.SelectedIndex > -1)
            {
                if (TextTitulo.Text.Length > 0 && TextDirector.Text.Length > 0 && TextDuracion.Text.Length > 0 && TextFecha.Text.Length > 0)
                {
                    int duracion;
                    int fecha;
                    if (!int.TryParse(TextDuracion.Text, out duracion))
                    {
                        MessageBox.Show("Debe ingrese un dato de tipo numerico", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TextDuracion.Clear();
                        return;
                    }
                    if (!int.TryParse(TextFecha.Text, out fecha))
                    {
                        MessageBox.Show("Debe ingrese un dato correcto para el año del estreno de la pelicula , debe ser mayor o igual 1878 y menor a 2024", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (fecha < 1878 || fecha > 2024)
                    {
                        MessageBox.Show("Debe ingrese un dato correcto para el año del estreno de la pelicula , debe ser mayor o igual 1878 y menor a 2024", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        TextFecha.Text = "";
                        return;
                    }
                    string titulo = TextTitulo.Text;
                    string director = TextDirector.Text;
                    string Pelicula = titulo + "  |  " + director + "  |  " + duracion + " min" + "  |  " + fecha;
                    int index = ListaPeliculas.SelectedIndex;
                    ListaPeliculas.Items[index] = Pelicula;
                    TextTitulo.Clear();
                    TextDirector.Clear();
                    TextDuracion.Clear();
                    TextFecha.Clear();
                }
                else
                {
                    MessageBox.Show("Todos los campos son obligatorios si deseea editar una pelicula a la lista", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No puede realizar ninguna modificacion debido a que no selecciono ninguna pelicula del listado para editar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void borrarbtn_Click(object sender, EventArgs e)
        {
            if (ListaPeliculas.SelectedIndex > -1)
            {
                int index = ListaPeliculas.SelectedIndex;
                ListaPeliculas.Items.RemoveAt(index);
            }
            else
            {
                MessageBox.Show("No puede realizar ninguna eliminacion debido a que no selecciono ninguna pelicula del listado para borrar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListaPeliculas.SelectedIndex > -1 && ListaPeliculas.Items.Count > 0)
            {
                foreach (var item in ListaPeliculas.SelectedItems)
                {
                    listBox1.Items.Add(item);
                }
                ListaPeliculas.Items.RemoveAt(ListaPeliculas.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar una pelicula", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1 && listBox1.Items.Count > 0)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    ListaPeliculas.Items.Add(item);
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Primero debes seleccionar una pelicula", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListaPeliculas.Items.Count > 0)
            {
                foreach (var item in ListaPeliculas.Items)
                {
                    listBox1.Items.Add(item);
                }
                ListaPeliculas.Items.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(listBox1.Items.Count > 0)
            {
                foreach (var item in listBox1.Items)
                {
                    ListaPeliculas.Items.Add(item);
                }
                listBox1.Items.Clear();
            }
        }

        private bool color = true;
        private void Form1_Click(object sender, EventArgs e)
        {
            if (color)
            {
                this.BackColor = Color.Aqua;
                color = false;
            }
            else
            {
                this.BackColor = Color.CadetBlue;
                color = true;
            }
        }
    }
}
