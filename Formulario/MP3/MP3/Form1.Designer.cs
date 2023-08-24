namespace MP3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.importarbtn = new System.Windows.Forms.Button();
            this.listamusica = new System.Windows.Forms.ListBox();
            this.cerrarbtn = new System.Windows.Forms.Button();
            this.antbtn = new System.Windows.Forms.Button();
            this.playbtn = new System.Windows.Forms.Button();
            this.postbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.borrarbtn = new System.Windows.Forms.Button();
            this.volumen = new System.Windows.Forms.TrackBar();
            this.duracion = new System.Windows.Forms.TrackBar();
            this.labelfinal = new System.Windows.Forms.Label();
            this.labelnicial = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.reiniciar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.duracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // importarbtn
            // 
            resources.ApplyResources(this.importarbtn, "importarbtn");
            this.importarbtn.ForeColor = System.Drawing.Color.Red;
            this.importarbtn.Name = "importarbtn";
            this.importarbtn.UseVisualStyleBackColor = true;
            this.importarbtn.Click += new System.EventHandler(this.importarbtn_Click);
            // 
            // listamusica
            // 
            this.listamusica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(76)))), ((int)(((byte)(196)))));
            this.listamusica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listamusica.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.listamusica, "listamusica");
            this.listamusica.ForeColor = System.Drawing.SystemColors.Menu;
            this.listamusica.FormattingEnabled = true;
            this.listamusica.Name = "listamusica";
            this.listamusica.SelectedIndexChanged += new System.EventHandler(this.listamusica_SelectedIndexChanged);
            // 
            // cerrarbtn
            // 
            resources.ApplyResources(this.cerrarbtn, "cerrarbtn");
            this.cerrarbtn.ForeColor = System.Drawing.Color.Red;
            this.cerrarbtn.Name = "cerrarbtn";
            this.cerrarbtn.UseVisualStyleBackColor = true;
            this.cerrarbtn.Click += new System.EventHandler(this.cerrarbtn_Click);
            // 
            // antbtn
            // 
            resources.ApplyResources(this.antbtn, "antbtn");
            this.antbtn.ForeColor = System.Drawing.Color.Red;
            this.antbtn.Name = "antbtn";
            this.antbtn.UseVisualStyleBackColor = true;
            this.antbtn.Click += new System.EventHandler(this.antbtn_Click);
            // 
            // playbtn
            // 
            resources.ApplyResources(this.playbtn, "playbtn");
            this.playbtn.ForeColor = System.Drawing.Color.Red;
            this.playbtn.Name = "playbtn";
            this.playbtn.UseVisualStyleBackColor = true;
            this.playbtn.Click += new System.EventHandler(this.playbtn_Click);
            // 
            // postbtn
            // 
            resources.ApplyResources(this.postbtn, "postbtn");
            this.postbtn.ForeColor = System.Drawing.Color.Red;
            this.postbtn.Name = "postbtn";
            this.postbtn.UseVisualStyleBackColor = true;
            this.postbtn.Click += new System.EventHandler(this.postbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(28)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.importarbtn);
            this.panel1.Controls.Add(this.cerrarbtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MP3.Properties.Resources.oaaaa;
            this.pictureBox2.InitialImage = global::MP3.Properties.Resources.oaaaa;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(28)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.borrarbtn);
            this.panel2.Controls.Add(this.volumen);
            this.panel2.Controls.Add(this.duracion);
            this.panel2.Controls.Add(this.labelfinal);
            this.panel2.Controls.Add(this.labelnicial);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.reiniciar);
            this.panel2.Controls.Add(this.playbtn);
            this.panel2.Controls.Add(this.antbtn);
            this.panel2.Controls.Add(this.postbtn);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // borrarbtn
            // 
            resources.ApplyResources(this.borrarbtn, "borrarbtn");
            this.borrarbtn.ForeColor = System.Drawing.Color.Red;
            this.borrarbtn.Name = "borrarbtn";
            this.borrarbtn.UseVisualStyleBackColor = true;
            this.borrarbtn.Click += new System.EventHandler(this.borrarbtn_Click);
            // 
            // volumen
            // 
            resources.ApplyResources(this.volumen, "volumen");
            this.volumen.Maximum = 100;
            this.volumen.Name = "volumen";
            this.volumen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumen.Value = 100;
            this.volumen.Scroll += new System.EventHandler(this.volumen_Scroll);
            // 
            // duracion
            // 
            resources.ApplyResources(this.duracion, "duracion");
            this.duracion.Name = "duracion";
            this.duracion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.duracion.Scroll += new System.EventHandler(this.duracion_Scroll);
            // 
            // labelfinal
            // 
            resources.ApplyResources(this.labelfinal, "labelfinal");
            this.labelfinal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelfinal.Name = "labelfinal";
            this.labelfinal.Click += new System.EventHandler(this.labelfinal_Click);
            // 
            // labelnicial
            // 
            resources.ApplyResources(this.labelnicial, "labelnicial");
            this.labelnicial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelnicial.Name = "labelnicial";
            this.labelnicial.Click += new System.EventHandler(this.labelnicial_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MP3.Properties.Resources.shadowwizard;
            this.pictureBox3.InitialImage = global::MP3.Properties.Resources.oaaaa;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // reiniciar
            // 
            resources.ApplyResources(this.reiniciar, "reiniciar");
            this.reiniciar.ForeColor = System.Drawing.Color.Red;
            this.reiniciar.Name = "reiniciar";
            this.reiniciar.UseVisualStyleBackColor = true;
            this.reiniciar.Click += new System.EventHandler(this.reiniciar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(220)))));
            this.pictureBox1.Image = global::MP3.Properties.Resources.vinilo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(220)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listamusica);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.duracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button importarbtn;
        private System.Windows.Forms.ListBox listamusica;
        private System.Windows.Forms.Button cerrarbtn;
        private System.Windows.Forms.Button antbtn;
        private System.Windows.Forms.Button playbtn;
        private System.Windows.Forms.Button postbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button reiniciar;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar duracion;
        private System.Windows.Forms.Label labelfinal;
        private System.Windows.Forms.Label labelnicial;
        private System.Windows.Forms.TrackBar volumen;
        private System.Windows.Forms.Button borrarbtn;
    }
}

