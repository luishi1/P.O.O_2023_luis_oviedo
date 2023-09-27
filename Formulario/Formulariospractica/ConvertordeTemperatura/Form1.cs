using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertordeTemperatura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double T;
            if (Double.TryParse(textBox1.Text, out T)) 
            {
                Double TemperaturaC = 0;
                Double TemperaturaK = 0;
                Double TemperaturaF = 0;

                if (comboBox1.Text == "Celsius")
                {
                    TemperaturaC = T;
                    TemperaturaK = T + 273.15;
                    TemperaturaF = (T * 1.8) + 32;
                }
                else if (comboBox1.Text == "Fahrenheit")
                {
                    TemperaturaF = T;
                    TemperaturaC = (T - 32) / 1.8;
                    TemperaturaK = (T + 459.67) * 5 / 9;
                }
                else if (comboBox1.Text == "Kelvin")
                {
                    TemperaturaK = T;
                    TemperaturaC = T - 273.15;
                    TemperaturaF = (T * 9 / 5) - 459.67;
                }

                CelTxt.Text = TemperaturaC + " °C";
                FahTxt.Text = TemperaturaF + " °F";
                KelTxt.Text = TemperaturaK + " K";
            }
            else
            {
                CelTxt.Text = "ERROR";
                FahTxt.Text = "ERROR";
                KelTxt.Text = "ERROR";
               DialogResult resultado = MessageBox.Show("ENTRADA INVALIDA POR FAVOR INGRESE UNA TEMPERATURA CORRECTA PARA LA CONVERSION","Error",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                if (resultado == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }
        }

    }
}
