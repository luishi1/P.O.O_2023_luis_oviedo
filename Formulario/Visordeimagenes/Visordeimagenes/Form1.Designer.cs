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
            this.anteriorbtn = new System.Windows.Forms.Button();
            this.postbtn = new System.Windows.Forms.Button();
            this.zoombtn = new System.Windows.Forms.Button();
            this.ziimbtn = new System.Windows.Forms.Button();
            this.eliminarbtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PictureBox2 = new System.Windows.Forms.PictureBox();
            this.rotarizqbtn = new System.Windows.Forms.Button();
            this.rotarderbtn = new System.Windows.Forms.Button();
            this.guardarbtn = new System.Windows.Forms.Button();
            this.espejobtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.filtrobtn = new System.Windows.Forms.Button();
            this.sepiabtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // abrirbt
            // 
            this.abrirbt.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.abrirbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abrirbt.Location = new System.Drawing.Point(12, 25);
            this.abrirbt.Name = "abrirbt";
            this.abrirbt.Size = new System.Drawing.Size(117, 39);
            this.abrirbt.TabIndex = 1;
            this.abrirbt.Text = "Abrir";
            this.abrirbt.UseVisualStyleBackColor = false;
            this.abrirbt.Click += new System.EventHandler(this.abrirbt_Click);
            // 
            // salirbtn
            // 
            this.salirbtn.BackColor = System.Drawing.Color.Firebrick;
            this.salirbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirbtn.Location = new System.Drawing.Point(1315, 796);
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
            this.listname.Location = new System.Drawing.Point(1153, 25);
            this.listname.MultiColumn = true;
            this.listname.Name = "listname";
            this.listname.ScrollAlwaysVisible = true;
            this.listname.Size = new System.Drawing.Size(290, 758);
            this.listname.TabIndex = 3;
            this.listname.SelectedIndexChanged += new System.EventHandler(this.listname_SelectedIndexChanged);
            // 
            // anteriorbtn
            // 
            this.anteriorbtn.AutoSize = true;
            this.anteriorbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.anteriorbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.anteriorbtn.Location = new System.Drawing.Point(534, 810);
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
            this.postbtn.Location = new System.Drawing.Point(662, 810);
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
            this.zoombtn.Location = new System.Drawing.Point(263, 810);
            this.zoombtn.Name = "zoombtn";
            this.zoombtn.Size = new System.Drawing.Size(75, 31);
            this.zoombtn.TabIndex = 6;
            this.zoombtn.Text = "➖";
            this.zoombtn.UseVisualStyleBackColor = false;
            this.zoombtn.Click += new System.EventHandler(this.zoombtn_Click);
            // 
            // ziimbtn
            // 
            this.ziimbtn.AutoSize = true;
            this.ziimbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ziimbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.ziimbtn.Location = new System.Drawing.Point(135, 810);
            this.ziimbtn.Name = "ziimbtn";
            this.ziimbtn.Size = new System.Drawing.Size(75, 31);
            this.ziimbtn.TabIndex = 7;
            this.ziimbtn.Text = "➕";
            this.ziimbtn.UseVisualStyleBackColor = false;
            this.ziimbtn.Click += new System.EventHandler(this.ziimbtn_Click);
            // 
            // eliminarbtn
            // 
            this.eliminarbtn.AutoSize = true;
            this.eliminarbtn.BackColor = System.Drawing.Color.Firebrick;
            this.eliminarbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.eliminarbtn.Location = new System.Drawing.Point(1069, 810);
            this.eliminarbtn.Name = "eliminarbtn";
            this.eliminarbtn.Size = new System.Drawing.Size(75, 31);
            this.eliminarbtn.TabIndex = 8;
            this.eliminarbtn.Text = "🗑";
            this.eliminarbtn.UseVisualStyleBackColor = false;
            this.eliminarbtn.Click += new System.EventHandler(this.eliminarbtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.PictureBox2);
            this.panel1.Location = new System.Drawing.Point(135, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 779);
            this.panel1.TabIndex = 18;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // PictureBox2
            // 
            this.PictureBox2.Location = new System.Drawing.Point(3, 17);
            this.PictureBox2.Name = "PictureBox2";
            this.PictureBox2.Size = new System.Drawing.Size(963, 702);
            this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox2.TabIndex = 0;
            this.PictureBox2.TabStop = false;
            // 
            // rotarizqbtn
            // 
            this.rotarizqbtn.AutoSize = true;
            this.rotarizqbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rotarizqbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.rotarizqbtn.Location = new System.Drawing.Point(395, 810);
            this.rotarizqbtn.Name = "rotarizqbtn";
            this.rotarizqbtn.Size = new System.Drawing.Size(75, 31);
            this.rotarizqbtn.TabIndex = 10;
            this.rotarizqbtn.Text = "↩️";
            this.rotarizqbtn.UseVisualStyleBackColor = false;
            this.rotarizqbtn.Click += new System.EventHandler(this.rotarizqbtn_Click);
            // 
            // rotarderbtn
            // 
            this.rotarderbtn.AutoSize = true;
            this.rotarderbtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.rotarderbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.rotarderbtn.Location = new System.Drawing.Point(801, 810);
            this.rotarderbtn.Name = "rotarderbtn";
            this.rotarderbtn.Size = new System.Drawing.Size(75, 31);
            this.rotarderbtn.TabIndex = 11;
            this.rotarderbtn.Text = "↪️";
            this.rotarderbtn.UseVisualStyleBackColor = false;
            this.rotarderbtn.Click += new System.EventHandler(this.rotarderbtn_Click);
            // 
            // guardarbtn
            // 
            this.guardarbtn.AutoSize = true;
            this.guardarbtn.BackColor = System.Drawing.Color.MediumTurquoise;
            this.guardarbtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.guardarbtn.Location = new System.Drawing.Point(54, 773);
            this.guardarbtn.Name = "guardarbtn";
            this.guardarbtn.Size = new System.Drawing.Size(75, 31);
            this.guardarbtn.TabIndex = 13;
            this.guardarbtn.Text = "💾";
            this.guardarbtn.UseVisualStyleBackColor = false;
            this.guardarbtn.Click += new System.EventHandler(this.guardarbtn_Click);
            // 
            // espejobtn
            // 
            this.espejobtn.AutoSize = true;
            this.espejobtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.espejobtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.espejobtn.Location = new System.Drawing.Point(937, 810);
            this.espejobtn.Name = "espejobtn";
            this.espejobtn.Size = new System.Drawing.Size(75, 31);
            this.espejobtn.TabIndex = 14;
            this.espejobtn.Text = "🔁";
            this.espejobtn.UseVisualStyleBackColor = false;
            this.espejobtn.Click += new System.EventHandler(this.espejobtn_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.button1.Location = new System.Drawing.Point(54, 726);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 15;
            this.button1.Text = "🐒";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // filtrobtn
            // 
            this.filtrobtn.AutoSize = true;
            this.filtrobtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.filtrobtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.filtrobtn.Location = new System.Drawing.Point(54, 605);
            this.filtrobtn.Name = "filtrobtn";
            this.filtrobtn.Size = new System.Drawing.Size(75, 31);
            this.filtrobtn.TabIndex = 16;
            this.filtrobtn.Text = "🐙";
            this.filtrobtn.UseVisualStyleBackColor = false;
            this.filtrobtn.Click += new System.EventHandler(this.filtrobtn_Click);
            // 
            // sepiabtn
            // 
            this.sepiabtn.AutoSize = true;
            this.sepiabtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sepiabtn.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
            this.sepiabtn.Location = new System.Drawing.Point(54, 666);
            this.sepiabtn.Name = "sepiabtn";
            this.sepiabtn.Size = new System.Drawing.Size(75, 31);
            this.sepiabtn.TabIndex = 17;
            this.sepiabtn.Text = "👨‍🎨";
            this.sepiabtn.UseVisualStyleBackColor = false;
            this.sepiabtn.Click += new System.EventHandler(this.sepiabtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1455, 853);
            this.Controls.Add(this.sepiabtn);
            this.Controls.Add(this.filtrobtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.espejobtn);
            this.Controls.Add(this.guardarbtn);
            this.Controls.Add(this.rotarderbtn);
            this.Controls.Add(this.rotarizqbtn);
            this.Controls.Add(this.eliminarbtn);
            this.Controls.Add(this.ziimbtn);
            this.Controls.Add(this.zoombtn);
            this.Controls.Add(this.postbtn);
            this.Controls.Add(this.anteriorbtn);
            this.Controls.Add(this.listname);
            this.Controls.Add(this.salirbtn);
            this.Controls.Add(this.abrirbt);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Imagenes Visor de";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button abrirbt;
        private System.Windows.Forms.Button salirbtn;
        private System.Windows.Forms.ListBox listname;
        private System.Windows.Forms.Button anteriorbtn;
        private System.Windows.Forms.Button postbtn;
        private System.Windows.Forms.Button zoombtn;
        private System.Windows.Forms.Button ziimbtn;
        private System.Windows.Forms.Button eliminarbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button rotarizqbtn;
        private System.Windows.Forms.Button rotarderbtn;
        private System.Windows.Forms.Button guardarbtn;
        private System.Windows.Forms.Button espejobtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button filtrobtn;
        private System.Windows.Forms.Button sepiabtn;
        private System.Windows.Forms.PictureBox PictureBox2;
    }
}

