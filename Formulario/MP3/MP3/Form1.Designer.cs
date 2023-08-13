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
            this.importarbtn = new System.Windows.Forms.Button();
            this.listamusica = new System.Windows.Forms.ListBox();
            this.cerrarbtn = new System.Windows.Forms.Button();
            this.antbtn = new System.Windows.Forms.Button();
            this.playbtn = new System.Windows.Forms.Button();
            this.postbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
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
            this.importarbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importarbtn.ForeColor = System.Drawing.Color.Red;
            this.importarbtn.Location = new System.Drawing.Point(53, 140);
            this.importarbtn.Name = "importarbtn";
            this.importarbtn.Size = new System.Drawing.Size(75, 23);
            this.importarbtn.TabIndex = 1;
            this.importarbtn.Text = "📥";
            this.importarbtn.UseVisualStyleBackColor = true;
            this.importarbtn.Click += new System.EventHandler(this.importarbtn_Click);
            // 
            // listamusica
            // 
            this.listamusica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(76)))), ((int)(((byte)(196)))));
            this.listamusica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listamusica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listamusica.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listamusica.ForeColor = System.Drawing.SystemColors.Menu;
            this.listamusica.FormattingEnabled = true;
            this.listamusica.ItemHeight = 22;
            this.listamusica.Location = new System.Drawing.Point(195, 245);
            this.listamusica.Name = "listamusica";
            this.listamusica.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listamusica.Size = new System.Drawing.Size(606, 66);
            this.listamusica.TabIndex = 2;
            this.listamusica.SelectedIndexChanged += new System.EventHandler(this.listamusica_SelectedIndexChanged);
            // 
            // cerrarbtn
            // 
            this.cerrarbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarbtn.ForeColor = System.Drawing.Color.Red;
            this.cerrarbtn.Location = new System.Drawing.Point(53, 433);
            this.cerrarbtn.Name = "cerrarbtn";
            this.cerrarbtn.Size = new System.Drawing.Size(75, 23);
            this.cerrarbtn.TabIndex = 3;
            this.cerrarbtn.Text = "❌";
            this.cerrarbtn.UseVisualStyleBackColor = true;
            this.cerrarbtn.Click += new System.EventHandler(this.cerrarbtn_Click);
            // 
            // antbtn
            // 
            this.antbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antbtn.ForeColor = System.Drawing.Color.Red;
            this.antbtn.Location = new System.Drawing.Point(23, 24);
            this.antbtn.Name = "antbtn";
            this.antbtn.Size = new System.Drawing.Size(87, 47);
            this.antbtn.TabIndex = 8;
            this.antbtn.Text = "⏪";
            this.antbtn.UseVisualStyleBackColor = true;
            this.antbtn.Click += new System.EventHandler(this.antbtn_Click);
            // 
            // playbtn
            // 
            this.playbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playbtn.ForeColor = System.Drawing.Color.Red;
            this.playbtn.Location = new System.Drawing.Point(162, 24);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(83, 47);
            this.playbtn.TabIndex = 9;
            this.playbtn.Text = "▶️";
            this.playbtn.UseVisualStyleBackColor = true;
            this.playbtn.Click += new System.EventHandler(this.playbtn_Click);
            // 
            // postbtn
            // 
            this.postbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postbtn.ForeColor = System.Drawing.Color.Red;
            this.postbtn.Location = new System.Drawing.Point(292, 24);
            this.postbtn.Name = "postbtn";
            this.postbtn.Size = new System.Drawing.Size(76, 47);
            this.postbtn.TabIndex = 10;
            this.postbtn.Text = "⏩";
            this.postbtn.UseVisualStyleBackColor = true;
            this.postbtn.Click += new System.EventHandler(this.postbtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(28)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.importarbtn);
            this.panel1.Controls.Add(this.cerrarbtn);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(201, 469);
            this.panel1.TabIndex = 11;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MP3.Properties.Resources.oaaaa;
            this.pictureBox2.InitialImage = global::MP3.Properties.Resources.oaaaa;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(28)))), ((int)(((byte)(60)))));
            this.panel2.Controls.Add(this.volumen);
            this.panel2.Controls.Add(this.duracion);
            this.panel2.Controls.Add(this.labelfinal);
            this.panel2.Controls.Add(this.labelnicial);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.reiniciar);
            this.panel2.Controls.Add(this.playbtn);
            this.panel2.Controls.Add(this.antbtn);
            this.panel2.Controls.Add(this.postbtn);
            this.panel2.Location = new System.Drawing.Point(195, 308);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(606, 161);
            this.panel2.TabIndex = 12;
            // 
            // volumen
            // 
            this.volumen.Location = new System.Drawing.Point(494, 44);
            this.volumen.Maximum = 100;
            this.volumen.Name = "volumen";
            this.volumen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.volumen.Size = new System.Drawing.Size(45, 104);
            this.volumen.TabIndex = 18;
            this.volumen.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumen.Value = 100;
            this.volumen.Scroll += new System.EventHandler(this.volumen_Scroll);
            // 
            // duracion
            // 
            this.duracion.Enabled = false;
            this.duracion.Location = new System.Drawing.Point(64, 103);
            this.duracion.Name = "duracion";
            this.duracion.Size = new System.Drawing.Size(263, 45);
            this.duracion.TabIndex = 17;
            this.duracion.TickStyle = System.Windows.Forms.TickStyle.None;
            this.duracion.Scroll += new System.EventHandler(this.duracion_Scroll);
            // 
            // labelfinal
            // 
            this.labelfinal.AutoSize = true;
            this.labelfinal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelfinal.Location = new System.Drawing.Point(333, 110);
            this.labelfinal.Name = "labelfinal";
            this.labelfinal.Size = new System.Drawing.Size(0, 13);
            this.labelfinal.TabIndex = 16;
            this.labelfinal.Click += new System.EventHandler(this.labelfinal_Click);
            // 
            // labelnicial
            // 
            this.labelnicial.AutoSize = true;
            this.labelnicial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelnicial.Location = new System.Drawing.Point(23, 110);
            this.labelnicial.Name = "labelnicial";
            this.labelnicial.Size = new System.Drawing.Size(0, 13);
            this.labelnicial.TabIndex = 15;
            this.labelnicial.Click += new System.EventHandler(this.labelnicial_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MP3.Properties.Resources.shadowwizard;
            this.pictureBox3.InitialImage = global::MP3.Properties.Resources.oaaaa;
            this.pictureBox3.Location = new System.Drawing.Point(545, 110);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(61, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // reiniciar
            // 
            this.reiniciar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reiniciar.ForeColor = System.Drawing.Color.Red;
            this.reiniciar.Location = new System.Drawing.Point(384, 88);
            this.reiniciar.Name = "reiniciar";
            this.reiniciar.Size = new System.Drawing.Size(76, 47);
            this.reiniciar.TabIndex = 12;
            this.reiniciar.Text = "🔄";
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
            this.pictureBox1.Location = new System.Drawing.Point(195, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(606, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(148)))), ((int)(((byte)(220)))));
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listamusica);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

