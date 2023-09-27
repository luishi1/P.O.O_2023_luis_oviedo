using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraSimple
{
    public partial class Form1 : Form
    {

        double numero1 = 0;
        double numero2 = 0;
        string operador = "";
        bool nuevonum = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            if (nuevonum)
            {
                textBox1.Text = "";
                nuevonum = false;
            }
            Button boton = (Button)sender;
            textBox1.Text += boton.Text;
        }

        private void btnOperador(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            operador = boton.Text;
            numero1 = float.Parse(textBox1.Text);
            nuevonum = true;
        }

        private void btnigual_Click(object sender, EventArgs e)
        {
            if (nuevonum)
            {
                return;
            }
            numero2 = float.Parse(textBox1.Text);
            switch (operador)
            {
                case "+":
                    textBox1.Text = (numero1+numero2).ToString();
                    break;
                case "-":
                    textBox1.Text = (numero1 - numero2).ToString();
                    break;
                case "X":
                    textBox1.Text = (numero1 * numero2).ToString();
                    break;
                case "/":
                    if (numero2 != 0)
                    {
                        textBox1.Text = (numero1 / numero2).ToString();
                    }
                    else
                    {
                        textBox1.Text = "ERROR";
                    }
                    break;
            }
            nuevonum = true;
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            nuevonum = true;
            numero1 = 0;
            numero2 = 0;
            textBox1.Text = "";
        }

        private void btnpunto_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }
    }
}
