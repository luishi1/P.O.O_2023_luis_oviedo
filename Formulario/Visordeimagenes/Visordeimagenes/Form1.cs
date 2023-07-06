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

namespace Visordeimagenes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                pictureBox1.Image = new Bitmap(listname.SelectedItem.ToString());
            }
        }

        private void salirbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listname.SelectedIndex != -1 && listname.SelectedItem != null)
            {
                string selectedImagePath = listname.SelectedItem.ToString();

                if (File.Exists(selectedImagePath))
                {
                    pictureBox1.Image = new Bitmap(selectedImagePath);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

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
        }

        private void rotatebtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Image originalImage = pictureBox1.Image;
                originalImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = originalImage;
            }
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
                        pictureBox1.Image = new Bitmap(listname.Items[0].ToString());
                    }
                    else
                    {
                        pictureBox1.Image = new Bitmap(listname.Items[indexEliminado - 1].ToString());
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                }
                if (selectedImagePath == listname.Text)
                {
                    listname.SelectedIndex = indexEliminado - 1;
                }
            }
        }

        private void zoombtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                LimitPictureBoxSize();
            }
        }

        private void ziimbtn_Click(object sender, EventArgs e)
        {
            if (pictureBox1.SizeMode == PictureBoxSizeMode.AutoSize)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                LimitPictureBoxSize();
            }
        }

        //--------------------------------//
        private void LimitPictureBoxSize()
        {
            if (pictureBox1.Image != null)
            {
                int maxWidth = panel1.Width;
                int maxHeight = panel1.Height;

                int newWidth = pictureBox1.Image.Width;
                int newHeight = pictureBox1.Image.Height;

                if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    if (newWidth > maxWidth || newHeight > maxHeight)
                    {
                        double widthRatio = (double)maxWidth / newWidth;
                        double heightRatio = (double)maxHeight / newHeight;
                        double zoomRatio = Math.Min(widthRatio, heightRatio);

                        newWidth = (int)(newWidth * zoomRatio);
                        newHeight = (int)(newHeight * zoomRatio);
                    }
                }

                pictureBox1.Size = new Size(newWidth, newHeight);
                pictureBox1.Location = new Point((panel1.Width - newWidth) / 2, (panel1.Height - newHeight) / 2);
            }
        }

    }
}
