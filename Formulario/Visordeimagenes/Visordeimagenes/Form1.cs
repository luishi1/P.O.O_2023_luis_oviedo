using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Imaging;

namespace Visordeimagenes
{
    public partial class Form1 : Form
    {

        //Variables
        private Image originalImage;
        private Size originalPictureBoxSize;
        private bool mantenerZoom = false;
        private bool flipado = false;
        private bool NB = false;
        private bool isSepia = false;
        SoundPlayer sonido;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            originalPictureBoxSize = PictureBox2.Size;
        }


        private void abrirbt_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Seleccionar Imágenes",
                Multiselect = true,
                Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    listname.Items.Add(fileName);
                }

                listname.SelectedIndex = 0;
                string selectedImagePath = listname.SelectedItem.ToString();
                LoadImage(selectedImagePath);
                reset();
            }
        }

        private void salirbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoadImage(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                PictureBox2.Image = new Bitmap(imagePath);
                if (!mantenerZoom)
                {
                    PictureBox2.Size = originalPictureBoxSize;
                }
            }
            else
            {
                PictureBox2.Image = null;
            }
        }
        private void listname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listname.SelectedIndex != -1 && listname.SelectedItem != null)
            {
                string selectedImagePath = listname.SelectedItem.ToString();
                LoadImage(selectedImagePath);
                reset();
            }
        }


        private void anteriorbtn_Click(object sender, EventArgs e)
        {
            if (listname.SelectedIndex > 0)
            {
                listname.SelectedIndex--;
            }
            else
            {
                listname.SelectedIndex = listname.Items.Count - 1;
            }

            string selectedImagePath = listname.SelectedItem.ToString();
            LoadImage(selectedImagePath);
            reset();
        }

        private void postbtn_Click(object sender, EventArgs e)
        {
            if (listname.SelectedIndex < listname.Items.Count - 1)
            {
                listname.SelectedIndex++;
            }
            else
            {
                listname.SelectedIndex = 0;
            }

            string selectedImagePath = listname.SelectedItem.ToString();
            LoadImage(selectedImagePath);
            reset();
        }

        private void eliminarbtn_Click(object sender, EventArgs e)
        {
            if (listname.SelectedIndex != -1)
            {
                int indexEliminado = listname.SelectedIndex;
                string selectedImagePath = listname.SelectedItem.ToString();

                listname.Items.RemoveAt(indexEliminado);

                if (listname.Items.Count > 0)
                {
                    if (indexEliminado == 0)
                    {
                        listname.SelectedIndex = 0;
                    }
                    else
                    {
                        listname.SelectedIndex = indexEliminado - 1;
                    }

                    string newSelectedImagePath = listname.SelectedItem.ToString();
                    LoadImage(newSelectedImagePath);
                    reset();
                }
                else
                {
                    PictureBox2.Image = null;
                }
            }
        }

        private void ziimbtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                PictureBox2.Size = new Size((int)(PictureBox2.Width * 1.1), (int)(PictureBox2.Height * 1.1));
            }
        }

        private void zoombtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                PictureBox2.Size = new Size((int)(PictureBox2.Width * 0.9), (int)(PictureBox2.Height * 0.9));
            }
        }

        private void rotarizqbtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                Image originalImage = PictureBox2.Image;
                originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBox2.Image = originalImage;
            }
        }

        private void rotarderbtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                Image originalImage = PictureBox2.Image;
                originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBox2.Image = originalImage;
            }
        }


        private void espejobtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                Image originalImage = PictureBox2.Image;
                originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                flipado = !flipado;
                PictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                PictureBox2.Image = originalImage;
            }
        }
        private void guardarbtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Title = "Guardar Imagen",
                    Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif|Todos los archivos|*.*"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;
                    PictureBox2.Image.Save(savePath);
                    MessageBox.Show("Imagen guardada correctamente.", "Guardar Imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que quiere apretar el boton?", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                sonido = new SoundPlayer(Application.StartupPath + @"\son\..wav");
                sonido.Play();
            }
        }


        private void filtrobtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                if (NB)
                {
                    PictureBox2.Image = originalImage;
                    NB = false;
                }
                else
                {
                    originalImage = PictureBox2.Image;
                    ImageAttributes imageAttributes = new ImageAttributes();
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                    new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                    new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                    new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                    });

                    imageAttributes.SetColorMatrix(colorMatrix);

                    Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);
                    using (Graphics graphics = Graphics.FromImage(filteredImage))
                    {
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
                    }
                    PictureBox2.Image = filteredImage;
                    NB = true;
                }
            }
        }

        private void sepiabtn_Click(object sender, EventArgs e)
        {
            if (PictureBox2.Image != null)
            {
                if (isSepia)
                {
                    PictureBox2.Image = originalImage;
                    isSepia = false;
                }
                else
                {
                    originalImage = PictureBox2.Image; 
                    ImageAttributes imageAttributes = new ImageAttributes();
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                    new float[] {0.393f, 0.349f, 0.272f, 0, 0},
                    new float[] {0.769f, 0.686f, 0.534f, 0, 0},          
                    new float[] {0.189f, 0.168f, 0.131f, 0, 0},          
                    new float[] {0, 0, 0, 1, 0},                        
                    new float[] {0, 0, 0, 0, 1}                        
                    });

                    imageAttributes.SetColorMatrix(colorMatrix);
                    Bitmap filteredImage = new Bitmap(originalImage.Width, originalImage.Height);
                    using (Graphics graphics = Graphics.FromImage(filteredImage))
                    {
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, imageAttributes);
                    }
                    PictureBox2.Image = filteredImage;
                    isSepia = true;
                }
            }
        }

        private void reset()
        {
            NB = false;
            isSepia = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

