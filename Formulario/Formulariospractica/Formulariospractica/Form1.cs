using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulariospractica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Agregar1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void Borrar1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                listBox1.Items.Clear();
            }
        }

        private void IZQaDER_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                foreach (var itemseleccionado in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(itemseleccionado);
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void IZQaDERTO_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 1)
            {
                foreach (var items in listBox1.Items)
                {
                    listBox2.Items.Add(items);
                }
                listBox1.Items.Clear();
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Agregar2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                listBox2.Items.Add(textBox2.Text);
                textBox2.Text = "";
            }
        }

        private void Borrar2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                listBox2.Items.Clear();
            }
        }

        private void DERaIZQ_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                foreach (var index in listBox2.SelectedItems)
                {
                    listBox1.Items.Add(index);
                }
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void DERaIZQTO_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count >= 1)
            {
                foreach (var itemS in listBox2.Items)
                {
                    listBox1.Items.Add(itemS);
                }
                listBox2.Items.Clear();
            }
        }
    }
}
