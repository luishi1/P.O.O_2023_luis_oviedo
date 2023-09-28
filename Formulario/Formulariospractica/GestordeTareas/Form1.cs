using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestordeTareas
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedItems.Count > -1)
            {
                string texto = textBox2.Text;
                int index = listBox1.SelectedIndex;
                if (textBox2.Text.Length > 0)
                {
                    listBox1.Items[index] = texto;
                    listBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("INGRESE UN TEXTO PRIMERO", "ATENCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("SELECCIONE UN ITEM PRIMERO ", "ATENCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    listBox2.Items.Add(item);
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                foreach (var item in listBox2.SelectedItems)
                {
                    listBox3.Items.Add(item);
                }
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex != -1)
            {
                foreach (var item in listBox3.SelectedItems)
                {
                    listBox2.Items.Add(item);
                }
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                foreach (var item in listBox2.SelectedItems)
                {
                    listBox1.Items.Add(item);
                }
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
        }
    }
}
