using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MP3
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string lpstrCommand,StringBuilder lpstrReturnString, int uReturnLengh, int hwndCallback);

        private MP3 MP3;
        private Timer contador;
        private int currentPosition = 0;
        private int songDuration = 0;
        private bool isSeeking = false;
        private List<string> listaArchivos = new List<string>(); 
        public Form1()
        {
            InitializeComponent();
            MP3 = new MP3();
            contador = new Timer();
            contador.Interval = 100;
            contador.Tick += timer1_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void importarbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Seleccione archivos",
                Filter = "Archivos MP3 (*.mp3)|*.mp3",
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string nombre in ofd.FileNames)
                {
                    string nombrelimpio = Path.GetFileNameWithoutExtension(nombre);
                    listamusica.Items.Add(nombrelimpio);
                    listaArchivos.Add(nombre);
                }
            }
        }


        private void listamusica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listamusica.SelectedIndex >= 0)
            {
                int selectedIndex = listamusica.SelectedIndex;
                string ruta = listaArchivos[selectedIndex];

                if (File.Exists(ruta)) 
                {
                    MP3.Play(ruta);
                    playbtn.Text = "⏸️";
                    sonando = true;
                    contador.Start();
                }
                else
                {
                    MessageBox.Show($"El archivo {ruta} no se encuentra en la ubicación especificada.");
                }
            }
        }

        private void cerrarbtn_Click(object sender, EventArgs e)
        {
            MP3.Stop();
            Application.Exit();
        }

        private bool sonando = false;

        private void playbtn_Click(object sender, EventArgs e)
        {
            if (listamusica.SelectedIndex >= 0)
            {
                if (!sonando)
                {
                    string ruta = listamusica.SelectedItem.ToString();
                    MP3.Play(ruta);
                    playbtn.Text = "⏸️";
                    sonando = true;
                    contador.Start();
                }
                else
                {
                    if (MP3.IsPlaying())
                    {
                        MP3.Pause();
                        playbtn.Text = "▶️";
                        contador.Stop();
                    }
                    else
                    {
                        MP3.Resume();
                        playbtn.Text = "⏸️";
                        contador.Start();
                    }
                }
            }
        }


        private int indiceactual = -1;
        private void antbtn_Click(object sender, EventArgs e)
        {
            if (listamusica.Items.Count > 0)
            {
                indiceactual--;
                if (indiceactual < 0)
                {
                    indiceactual = listamusica.Items.Count - 1;
                }

                listamusica.SelectedIndex = indiceactual;
                string ruta = listaArchivos[indiceactual];
                MP3.Stop();
                MP3.Play(ruta);
                playbtn.Text = "⏸️";
                sonando = true;
                contador.Start();
            }
        }

        private void postbtn_Click(object sender, EventArgs e)
        {
            if (listamusica.Items.Count > 0)
            {
                indiceactual++;
                if (indiceactual >= listamusica.Items.Count)
                {
                    indiceactual = 0;
                }
                listamusica.SelectedIndex = indiceactual;
                string ruta = listaArchivos[indiceactual];
                MP3.Stop();
                MP3.Play(ruta);
                playbtn.Text = "⏸️";
                sonando = true;
                contador.Start();
            }
        }

        private void reiniciar_Click(object sender, EventArgs e)
        {
            if (listamusica.SelectedIndex >= 0)
            {
                string ruta = listamusica.SelectedItem.ToString();
                MP3.Stop();
                MP3.Play(ruta);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isSeeking && MP3.IsFileOpen())
            {
                currentPosition = MP3.GetCurrentPosition();
                songDuration = MP3.GetDuration();

                int currentMinutes = currentPosition / 1000 / 60;
                int currentSeconds = (currentPosition / 1000) % 60;

                int durationMinutes = songDuration / 1000 / 60;
                int durationSeconds = (songDuration / 1000) % 60;

                labelnicial.Text = $"{currentMinutes:D2}:{currentSeconds:D2}";
                labelfinal.Text = $"{durationMinutes:D2}:{durationSeconds:D2}";


                if (currentPosition >= duracion.Minimum && currentPosition <= duracion.Maximum)
                {
                duracion.Value = currentPosition;
                }
            }
        }
        //no sirvio , luego veo el tutorial
        private void duracion_Scroll(object sender, EventArgs e)
        {
            isSeeking = true;

            int newPosition = duracion.Value;
            MP3.Seek(newPosition);
            currentPosition = newPosition;

            int currentMinutes = currentPosition / 1000 / 60;
            int currentSeconds = (currentPosition / 1000) % 60;

            labelnicial.Text = $"{currentMinutes:D2}:{currentSeconds:D2}";

            if (sonando)
            {
                MP3.Resume();
                contador.Start();
            }
            isSeeking = false;
        }

        private void labelnicial_Click(object sender, EventArgs e)
        {

        }

        private void labelfinal_Click(object sender, EventArgs e)
        {

        }

        private void volumen_Scroll(object sender, EventArgs e)
        {
            int volumenn = volumen.Value;
            int volumenescalado = volumenn * 10; 
            MP3.SetVolume(volumenescalado);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }

    public class MP3
    {
        private string currentFilePath = "";

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr hwndCallback);

        public void Play(string filePath)
        {
            Stop();
            currentFilePath = filePath;
            mciSendString($"open \"{currentFilePath}\" type mpegvideo alias mediafile", null, 0, IntPtr.Zero);
            mciSendString("play mediafile", null, 0, IntPtr.Zero);
        }

        public void Stop()
        {
            mciSendString("stop mediafile", null, 0, IntPtr.Zero);
            mciSendString("close mediafile", null, 0, IntPtr.Zero);
        }

        public void Pause()
        {
            mciSendString("pause mediafile", null, 0, IntPtr.Zero);
        }

        public void Resume()
        {
            mciSendString("resume mediafile", null, 0, IntPtr.Zero);
        }

        public void Seek(int newPosition)
        {
            mciSendString($"seek mediafile to {newPosition}", null, 0, IntPtr.Zero);
        }

        public int GetCurrentPosition()
        {
            StringBuilder sb = new StringBuilder(128);
            mciSendString("status mediafile position", sb, sb.Capacity, IntPtr.Zero);
            int.TryParse(sb.ToString(), out int position);
            return position;
        }

        public int GetDuration()
        {
            StringBuilder sb = new StringBuilder(128);
            mciSendString("status mediafile length", sb, sb.Capacity, IntPtr.Zero);
            int.TryParse(sb.ToString(), out int duration);
            return duration;
        }

        public bool IsPlaying()
        {
            StringBuilder sb = new StringBuilder(128);
            mciSendString("status mediafile mode", sb, sb.Capacity, IntPtr.Zero);
            return sb.ToString() == "playing";
        }
        public void SetPosition(int newPosition)
        {
            mciSendString($"set mediafile time format milliseconds", null, 0, IntPtr.Zero);
            mciSendString($"set mediafile seek exactly {newPosition}", null, 0, IntPtr.Zero);
        }
        public bool IsFileOpen()
        {
            StringBuilder sb = new StringBuilder(128);
            mciSendString("status mediafile mode", sb, sb.Capacity, IntPtr.Zero);
            return sb.ToString() == "playing" || sb.ToString() == "paused";
        }
        public void SetVolume(int volume)
        {
            mciSendString($"setaudio mediafile volume to {volume}", null, 0, IntPtr.Zero);
        }
    }
}
