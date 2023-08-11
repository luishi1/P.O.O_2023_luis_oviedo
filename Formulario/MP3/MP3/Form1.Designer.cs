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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.importarbtn = new System.Windows.Forms.Button();
            this.listamusica = new System.Windows.Forms.ListBox();
            this.cerrarbtn = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.antbtn = new System.Windows.Forms.Button();
            this.playbtn = new System.Windows.Forms.Button();
            this.postbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(158, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(514, 235);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // importarbtn
            // 
            this.importarbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importarbtn.ForeColor = System.Drawing.Color.Red;
            this.importarbtn.Location = new System.Drawing.Point(38, 12);
            this.importarbtn.Name = "importarbtn";
            this.importarbtn.Size = new System.Drawing.Size(75, 23);
            this.importarbtn.TabIndex = 1;
            this.importarbtn.Text = "📥";
            this.importarbtn.UseVisualStyleBackColor = true;
            this.importarbtn.Click += new System.EventHandler(this.importarbtn_Click);
            // 
            // listamusica
            // 
            this.listamusica.FormattingEnabled = true;
            this.listamusica.Location = new System.Drawing.Point(12, 41);
            this.listamusica.Name = "listamusica";
            this.listamusica.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listamusica.Size = new System.Drawing.Size(131, 316);
            this.listamusica.TabIndex = 2;
            this.listamusica.SelectedIndexChanged += new System.EventHandler(this.listamusica_SelectedIndexChanged);
            // 
            // cerrarbtn
            // 
            this.cerrarbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cerrarbtn.ForeColor = System.Drawing.Color.Red;
            this.cerrarbtn.Location = new System.Drawing.Point(713, 12);
            this.cerrarbtn.Name = "cerrarbtn";
            this.cerrarbtn.Size = new System.Drawing.Size(75, 23);
            this.cerrarbtn.TabIndex = 3;
            this.cerrarbtn.Text = "❌";
            this.cerrarbtn.UseVisualStyleBackColor = true;
            this.cerrarbtn.Click += new System.EventHandler(this.cerrarbtn_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(158, 341);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(514, 45);
            this.trackBar1.TabIndex = 7;
            // 
            // antbtn
            // 
            this.antbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.antbtn.ForeColor = System.Drawing.Color.Red;
            this.antbtn.Location = new System.Drawing.Point(158, 299);
            this.antbtn.Name = "antbtn";
            this.antbtn.Size = new System.Drawing.Size(75, 23);
            this.antbtn.TabIndex = 8;
            this.antbtn.Text = "⏪";
            this.antbtn.UseVisualStyleBackColor = true;
            // 
            // playbtn
            // 
            this.playbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playbtn.ForeColor = System.Drawing.Color.Red;
            this.playbtn.Location = new System.Drawing.Point(376, 299);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(75, 23);
            this.playbtn.TabIndex = 9;
            this.playbtn.Text = "▶️";
            this.playbtn.UseVisualStyleBackColor = true;
            // 
            // postbtn
            // 
            this.postbtn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postbtn.ForeColor = System.Drawing.Color.Red;
            this.postbtn.Location = new System.Drawing.Point(597, 299);
            this.postbtn.Name = "postbtn";
            this.postbtn.Size = new System.Drawing.Size(75, 23);
            this.postbtn.TabIndex = 10;
            this.postbtn.Text = "⏩";
            this.postbtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(800, 468);
            this.Controls.Add(this.postbtn);
            this.Controls.Add(this.playbtn);
            this.Controls.Add(this.antbtn);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.cerrarbtn);
            this.Controls.Add(this.listamusica);
            this.Controls.Add(this.importarbtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button importarbtn;
        private System.Windows.Forms.ListBox listamusica;
        private System.Windows.Forms.Button cerrarbtn;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button antbtn;
        private System.Windows.Forms.Button playbtn;
        private System.Windows.Forms.Button postbtn;
    }
}

