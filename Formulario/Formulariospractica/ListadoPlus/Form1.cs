using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadoPlus
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Agregar")
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    int edad;
                    if (!int.TryParse(textBox3.Text,out edad))
                    {
                        MessageBox.Show("Es obligatorio llenar este campo con un valor numerico", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        textBox3.Clear();
                        return;
                    }
                    string nombre = textBox1.Text;
                    string apellido = textBox2.Text;
                    listBox1.Items.Add(nombre);
                    listBox2.Items.Add(apellido);
                    listBox3.Items.Add(edad);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                else
                {
                    MessageBox.Show("Es obligatorio llenar todos los campos si deseea agregar un usuario", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK,MessageBoxIcon.Hand);
                }
            }
            if (button1.Text == "Editar")
            {
                if (listBox1.SelectedIndex != -1 || listBox2.SelectedIndex != -1 || listBox3.SelectedIndex != -1)
                {
                    int index = listBox1.SelectedIndex;
                    if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                    {
                        int edad;
                        if (!int.TryParse(textBox3.Text, out edad))
                        {
                            MessageBox.Show("Es obligatorio llenar este campo con un valor numerico", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            textBox3.Clear();
                            return;
                        }
                        string nombre = textBox1.Text;
                        string apellido = textBox2.Text;
                        listBox1.Items[index] = nombre;
                        listBox2.Items[index] = apellido;
                        listBox3.Items[index] = edad;
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Es obligatorio llenar todos los campos si deseea editar un usuario", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Es obligatorio seleccionar un usuario antes de poder editarlo", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
        }
            if (button1.Text == "Borrar")
            {
                if (listBox1.SelectedIndex != -1 || listBox2.SelectedIndex != -1 || listBox3.SelectedIndex != -1)
                {
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    listBox2.Items.RemoveAt(index);
                    listBox3.Items.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("Es obligatorio seleccionar un usuario antes de poder borrarlo", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button1.Text == "")
            {
                MessageBox.Show("Es obligatorio seleccionar una opcion", "Cuidado que tu corazon esta colgando en mis manos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void toolStripComboBox1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                button1.Text = "Agregar";
            }
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                button1.Text = "Borrar";
            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                button1.Text = "Editar";
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = -1;
            listBox2.SelectedIndex = -1;
            listBox3.SelectedIndex = -1;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexseleccionado = listBox1.SelectedIndex;
            listBox2.SelectedIndex = indexseleccionado;
            listBox3.SelectedIndex =indexseleccionado;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexseleccionado = listBox2.SelectedIndex;
            listBox1.SelectedIndex = indexseleccionado;
            listBox3.SelectedIndex = indexseleccionado;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexseleccionado = listBox3.SelectedIndex;
            listBox2.SelectedIndex = indexseleccionado;
            listBox1.SelectedIndex = indexseleccionado;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1 && listBox1.Items.Count > 0 && listBox2.Items.Count > 0 && listBox1.Items.Count > 0)
            {
                int index = listBox1.SelectedIndex;
                string nombre = listBox1.Items[index].ToString();
                string apellido = listBox2.Items[index].ToString();
                string edad = listBox3.Items[index].ToString();
                foreach (var item in listBox1.Items) 
                {
                    listBox4.Items.Add(nombre + " " + apellido + " " + edad + " años");
                }
                listBox1.Items.RemoveAt(index);
                listBox2.Items.RemoveAt(index);
                listBox3.Items.RemoveAt(index);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox2.Items.Count > 0 && listBox1.Items.Count > 0)
            {
                int index = 0;
                foreach (var item in listBox1.Items)
                {
                    string nombre = listBox1.Items[index].ToString();
                    string apellido = listBox2.Items[index].ToString();
                    string edad = listBox3.Items[index].ToString();
                    listBox4.Items.Add(nombre + " " + apellido + " " + edad + " años");
                    index++;
                }
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();
            }
        }
    }
}
