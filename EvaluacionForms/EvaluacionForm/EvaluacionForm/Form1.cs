using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluacionForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool sortear;
        private void ordenarbtn_Click(object sender, EventArgs e)
        {
            sortear = true;
            if (sortear)
            {
                listBox1.Sorted = true;
                listBox2.Sorted = true;
            }
        }
        
        private void borrarbtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0 ; i--) 
                {
                    if (listBox1.Items[i].ToString().Length <= 5 )
                    {
                        listBox1.Items.RemoveAt(i);
                    }
                }      
            }

            if (listBox2.Items.Count > 0)
            {
                for (int i = listBox2.Items.Count - 1 ; i >= 0 ; i--)
                {
                    if (listBox2.Items[i].ToString().Length <= 5)
                    {
                        listBox2.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void intercambiarbtn_Click(object sender, EventArgs e)
        {
            List<string> listatemporal = new List<string>();
            List<string> listatemporal2 = new List<string>();
            //listabox1
            if (listBox1.Items.Count > 0)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    if (listBox1.Items[i].ToString().Length <= 5)
                    {
                        listatemporal.Add(listBox1.Items[i].ToString());
                        listBox1.Items.RemoveAt(i);
                    }
                }
            }
            if (listBox2.Items.Count > 0)
            {
                for (int i = listBox2.Items.Count - 1; i >= 0; i--)
                {
                    if (listBox2.Items[i].ToString().Length <= 5)
                    {
                        listatemporal2.Add(listBox2.Items[i].ToString());
                        listBox2.Items.RemoveAt(i);
                    }
                }
            }
            for (int i = 0; i < listatemporal.Count; i++)
            {
                listBox1.Items.Add(listatemporal[i].ToString());
            }
            for (int i = 0; i < listatemporal2.Count; i++)
            {
                listBox2.Items.Add(listatemporal2[i].ToString());
            }
        }
        private void primerultimobtn_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox2.Items.Count > 0)
            {
                int indicefinal1 = listBox1.Items.Count - 1;
                int indicefinal2 = listBox2.Items.Count - 1;
                string primero1 = listBox1.Items[0].ToString();
                string ultimo1 = listBox1.Items[indicefinal1].ToString();
                string primero2 = listBox2.Items[0].ToString();
                string ultimo2 = listBox2.Items[indicefinal2].ToString();

                listBox1.Items[0] = primero2;
                listBox2.Items[0] = primero1;
                listBox1.Items[indicefinal1] = ultimo2;
                listBox2.Items[indicefinal2] = ultimo1;
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                button1.Text = "Agregar";
                button2.Text = "Agregar";
            }
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                button1.Text = "Borrar";
                button2.Text = "Borrar";
            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                button1.Text = "Editar";
                button2.Text = "Editar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Agregar")
            {
                if (textBox1.Text.Length > 0)
                {
                    listBox1.Items.Add(textBox1.Text);
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("El textobox esta vacio", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button1.Text == "Borrar")
            {
                if (listBox1.SelectedIndex != -1)
                {
                    int indice = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(indice);
                }
                else
                {
                    MessageBox.Show("no selecciono un elemento del textbox1", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button1.Text == "Editar")
            {
                if (listBox1.SelectedIndex != -1 && textBox1.Text.Length > 0)
                {
                    int indice = listBox1.SelectedIndex;
                    listBox1.Items[indice] = textBox1.Text;
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("no selecciono un elemento del textbox1", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button1.Text == "")
            {
                MessageBox.Show("Es obligatorio seleccionar una opcion antes de poder editarlo", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Agregar")
            {
                if (textBox2.Text.Length > 0)
                {
                    listBox2.Items.Add(textBox2.Text);
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("El textobox2 esta vacio", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button2.Text == "Borrar")
            {
                if (listBox2.SelectedIndex != -1)
                {
                    int indice = listBox2.SelectedIndex;
                    listBox2.Items.RemoveAt(indice);
                }
                else
                {
                    MessageBox.Show("no selecciono un elemento del textbox2", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button2.Text == "Editar")
            {
                if (listBox2.SelectedIndex != -1 && textBox2.Text.Length > 0)
                {
                    int indice = listBox2.SelectedIndex;
                    listBox2.Items[indice] = textBox2.Text;
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("no selecciono un elemento del textbox2", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            if (button2.Text == "")
            {
                MessageBox.Show("Es obligatorio seleccionar una opcion antes de poder editarlo", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}