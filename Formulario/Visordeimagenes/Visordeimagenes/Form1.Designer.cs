using System.Drawing;

namespace Visordeimagenes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.abrirbt = new System.Windows.Forms.Button();
            this.salirbtn = new System.Windows.Forms.Button();
            this.listname = new System.Windows.Forms.ListBox();
            this.rotatebtn = new System.Windows.Forms.Button();
            this.anteriorbtn = new System.Windows.Forms.Button();
            this.postbtn = new System.Windows.Forms.Button();
            this.zoombtn = new System.Windows.Forms.Button();
            this.ziimbtn = new System.Windows.Forms.Button();
            this.eliminarbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // abrirbt
            // 
            this.abrirbt.BackColor = System.Drawing.Color.SteelBlue;
            this.abrirbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirbt.Location = new System.Drawing.Point(12, 47);
            this.abrirbt.Name = "abrirbt";
            this.abrirbt.Size = new System.Drawing.Size(117, 39);
            this.abrirbt.TabIndex = 1;
            this.abrirbt.Text = "Abrir";
            this.abrirbt.UseVisualStyleBackColor = false;
            this.abrirbt.Click += new System.EventHandler(this.abrirbt_Click);
            // 
            // salirbtn
            // 
            this.salirbtn.BackColor = System.Drawing.Color.DarkRed;
            this.salirbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirbtn.Location = new System.Drawing.Point(1100, 568);
            this.salirbtn.Name = "salirbtn";
            this.salirbtn.Size = new System.Drawing.Size(128, 45);
            this.salirbtn.TabIndex = 2;
            this.salirbtn.Text = "Salir";
            this.salirbtn.UseVisualStyleBackColor = false;
            this.salirbtn.Click += new System.EventHandler(this.salirbtn_Click);
            // 
            // listname
            // 
            this.listname.FormattingEnabled = true;
            this.listname.Location = new System.Drawing.Point(939, 25);
            this.listname.Name = "listname";
            this.listname.Size = new System.Drawing.Size(290, 537);
            this.listname.TabIndex = 3;
            this.listname.SelectedIndexChanged += new System.EventHandler(this.listname_SelectedIndexChanged);
            // 
            // rotatebtn
            // 
            this.rotatebtn.AutoSize = true;
            this.rotatebtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rotatebtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.rotatebtn.Location = new System.Drawing.Point(756, 582);
            this.rotatebtn.Name = "rotatebtn";
            this.rotatebtn.Size = new System.Drawing.Size(75, 31);
            this.rotatebtn.TabIndex = 0;
            this.rotatebtn.Text = "🔄";
            this.rotatebtn.UseVisualStyleBackColor = false;
            this.rotatebtn.Click += new System.EventHandler(this.rotatebtn_Click);
            // 
            // anteriorbtn
            // 
            this.anteriorbtn.AutoSize = true;
            this.anteriorbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.anteriorbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.anteriorbtn.Location = new System.Drawing.Point(141, 582);
            this.anteriorbtn.Name = "anteriorbtn";
            this.anteriorbtn.Size = new System.Drawing.Size(75, 31);
            this.anteriorbtn.TabIndex = 4;
            this.anteriorbtn.Text = "⏪";
            this.anteriorbtn.UseVisualStyleBackColor = false;
            this.anteriorbtn.Click += new System.EventHandler(this.anteriorbtn_Click);
            // 
            // postbtn
            // 
            this.postbtn.AutoSize = true;
            this.postbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.postbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.postbtn.Location = new System.Drawing.Point(242, 582);
            this.postbtn.Name = "postbtn";
            this.postbtn.Size = new System.Drawing.Size(75, 31);
            this.postbtn.TabIndex = 5;
            this.postbtn.Text = "⏩";
            this.postbtn.UseVisualStyleBackColor = false;
            this.postbtn.Click += new System.EventHandler(this.postbtn_Click);
            // 
            // zoombtn
            // 
            this.zoombtn.AutoSize = true;
            this.zoombtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.zoombtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.zoombtn.Location = new System.Drawing.Point(54, 483);
            this.zoombtn.Name = "zoombtn";
            this.zoombtn.Size = new System.Drawing.Size(75, 31);
            this.zoombtn.TabIndex = 6;
            this.zoombtn.Text = "➕";
            this.zoombtn.UseVisualStyleBackColor = false;
            this.zoombtn.Click += new System.EventHandler(this.zoombtn_Click);
            // 
            // ziimbtn
            // 
            this.ziimbtn.AutoSize = true;
            this.ziimbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ziimbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.ziimbtn.Location = new System.Drawing.Point(54, 531);
            this.ziimbtn.Name = "ziimbtn";
            this.ziimbtn.Size = new System.Drawing.Size(75, 31);
            this.ziimbtn.TabIndex = 7;
            this.ziimbtn.Text = "➖";
            this.ziimbtn.UseVisualStyleBackColor = false;
            this.ziimbtn.Click += new System.EventHandler(this.ziimbtn_Click);
            // 
            // eliminarbtn
            // 
            this.eliminarbtn.AutoSize = true;
            this.eliminarbtn.BackColor = System.Drawing.Color.Firebrick;
            this.eliminarbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.eliminarbtn.Location = new System.Drawing.Point(855, 582);
            this.eliminarbtn.Name = "eliminarbtn";
            this.eliminarbtn.Size = new System.Drawing.Size(75, 31);
            this.eliminarbtn.TabIndex = 8;
            this.eliminarbtn.Text = "🗑";
            this.eliminarbtn.UseVisualStyleBackColor = false;
            this.eliminarbtn.Click += new System.EventHandler(this.eliminarbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(792, 545);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(135, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 551);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1240, 629);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eliminarbtn);
            this.Controls.Add(this.ziimbtn);
            this.Controls.Add(this.zoombtn);
            this.Controls.Add(this.postbtn);
            this.Controls.Add(this.anteriorbtn);
            this.Controls.Add(this.rotatebtn);
            this.Controls.Add(this.listname);
            this.Controls.Add(this.salirbtn);
            this.Controls.Add(this.abrirbt);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button abrirbt;
        private System.Windows.Forms.Button salirbtn;
        private System.Windows.Forms.ListBox listname;
        private System.Windows.Forms.Button rotatebtn;
        private System.Windows.Forms.Button anteriorbtn;
        private System.Windows.Forms.Button postbtn;
        private System.Windows.Forms.Button zoombtn;
        private System.Windows.Forms.Button ziimbtn;
        private System.Windows.Forms.Button eliminarbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

