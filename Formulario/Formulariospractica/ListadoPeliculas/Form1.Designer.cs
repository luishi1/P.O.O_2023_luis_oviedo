namespace ListadoPeliculas
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
            this.ListaPeliculas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.agregarbtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextTitulo = new System.Windows.Forms.TextBox();
            this.TextDirector = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextFecha = new System.Windows.Forms.TextBox();
            this.TextDuracion = new System.Windows.Forms.TextBox();
            this.editarbtn = new System.Windows.Forms.Button();
            this.borrarbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListaPeliculas
            // 
            this.ListaPeliculas.ColumnWidth = 2;
            this.ListaPeliculas.FormattingEnabled = true;
            this.ListaPeliculas.Location = new System.Drawing.Point(12, 40);
            this.ListaPeliculas.Name = "ListaPeliculas";
            this.ListaPeliculas.Size = new System.Drawing.Size(307, 160);
            this.ListaPeliculas.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "PELICULAS PARA ALQUILAR";
            // 
            // agregarbtn
            // 
            this.agregarbtn.Location = new System.Drawing.Point(330, 206);
            this.agregarbtn.Name = "agregarbtn";
            this.agregarbtn.Size = new System.Drawing.Size(75, 23);
            this.agregarbtn.TabIndex = 2;
            this.agregarbtn.Text = "Agregar";
            this.agregarbtn.UseVisualStyleBackColor = true;
            this.agregarbtn.Click += new System.EventHandler(this.agregarbtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(492, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(312, 160);
            this.listBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(586, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "ALQUILADAS";
            // 
            // TextTitulo
            // 
            this.TextTitulo.Location = new System.Drawing.Point(330, 63);
            this.TextTitulo.Name = "TextTitulo";
            this.TextTitulo.Size = new System.Drawing.Size(156, 20);
            this.TextTitulo.TabIndex = 5;
            // 
            // TextDirector
            // 
            this.TextDirector.Location = new System.Drawing.Point(330, 102);
            this.TextDirector.Name = "TextDirector";
            this.TextDirector.Size = new System.Drawing.Size(156, 20);
            this.TextDirector.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Titulo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Director";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Año de lanzamiento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(327, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Duracion(Minutos)";
            // 
            // TextFecha
            // 
            this.TextFecha.Location = new System.Drawing.Point(330, 180);
            this.TextFecha.Name = "TextFecha";
            this.TextFecha.Size = new System.Drawing.Size(156, 20);
            this.TextFecha.TabIndex = 12;
            // 
            // TextDuracion
            // 
            this.TextDuracion.Location = new System.Drawing.Point(330, 141);
            this.TextDuracion.Name = "TextDuracion";
            this.TextDuracion.Size = new System.Drawing.Size(156, 20);
            this.TextDuracion.TabIndex = 11;
            // 
            // editarbtn
            // 
            this.editarbtn.Location = new System.Drawing.Point(411, 206);
            this.editarbtn.Name = "editarbtn";
            this.editarbtn.Size = new System.Drawing.Size(75, 23);
            this.editarbtn.TabIndex = 15;
            this.editarbtn.Text = "Editar";
            this.editarbtn.UseVisualStyleBackColor = true;
            this.editarbtn.Click += new System.EventHandler(this.editarbtn_Click);
            // 
            // borrarbtn
            // 
            this.borrarbtn.Location = new System.Drawing.Point(367, 235);
            this.borrarbtn.Name = "borrarbtn";
            this.borrarbtn.Size = new System.Drawing.Size(75, 23);
            this.borrarbtn.TabIndex = 16;
            this.borrarbtn.Text = "Borrar";
            this.borrarbtn.UseVisualStyleBackColor = true;
            this.borrarbtn.Click += new System.EventHandler(this.borrarbtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Alquilar una pelicula";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Comprar todas las peliculas";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(656, 206);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Devolver pelicula";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(656, 249);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Devolver todo";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(813, 305);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.borrarbtn);
            this.Controls.Add(this.editarbtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TextFecha);
            this.Controls.Add(this.TextDuracion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextDirector);
            this.Controls.Add(this.TextTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.agregarbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListaPeliculas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListaPeliculas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button agregarbtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextTitulo;
        private System.Windows.Forms.TextBox TextDirector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextFecha;
        private System.Windows.Forms.TextBox TextDuracion;
        private System.Windows.Forms.Button editarbtn;
        private System.Windows.Forms.Button borrarbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

