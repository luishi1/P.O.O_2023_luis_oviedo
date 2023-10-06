namespace EvaluacionForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.ordenarbtn = new System.Windows.Forms.Button();
            this.borrarbtn = new System.Windows.Forms.Button();
            this.intercambiarbtn = new System.Windows.Forms.Button();
            this.primerultimobtn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "Gaspar",
            "Pablo",
            "Angie",
            "Azul",
            "Felipe",
            "Gabriel",
            "Sofia",
            "Tamara",
            "Thiago",
            "Tobias"});
            this.listBox1.Location = new System.Drawing.Point(12, 29);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(50, 199);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Anto",
            "Alejandro",
            "Gonza",
            "Andres",
            "Mateo",
            "Matias",
            "Maximiliano",
            "Lujan",
            "Malena",
            "Lautaro"});
            this.listBox2.Location = new System.Drawing.Point(259, 29);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(65, 199);
            this.listBox2.TabIndex = 1;
            // 
            // ordenarbtn
            // 
            this.ordenarbtn.Location = new System.Drawing.Point(68, 29);
            this.ordenarbtn.Name = "ordenarbtn";
            this.ordenarbtn.Size = new System.Drawing.Size(185, 23);
            this.ordenarbtn.TabIndex = 2;
            this.ordenarbtn.Text = "Ordenar";
            this.ordenarbtn.UseVisualStyleBackColor = true;
            this.ordenarbtn.Click += new System.EventHandler(this.ordenarbtn_Click);
            // 
            // borrarbtn
            // 
            this.borrarbtn.Location = new System.Drawing.Point(68, 75);
            this.borrarbtn.Name = "borrarbtn";
            this.borrarbtn.Size = new System.Drawing.Size(185, 23);
            this.borrarbtn.TabIndex = 3;
            this.borrarbtn.Text = "Borrar5";
            this.borrarbtn.UseVisualStyleBackColor = true;
            this.borrarbtn.Click += new System.EventHandler(this.borrarbtn_Click);
            // 
            // intercambiarbtn
            // 
            this.intercambiarbtn.Location = new System.Drawing.Point(68, 120);
            this.intercambiarbtn.Name = "intercambiarbtn";
            this.intercambiarbtn.Size = new System.Drawing.Size(185, 23);
            this.intercambiarbtn.TabIndex = 4;
            this.intercambiarbtn.Text = "Intercambiar5";
            this.intercambiarbtn.UseVisualStyleBackColor = true;
            this.intercambiarbtn.Click += new System.EventHandler(this.intercambiarbtn_Click);
            // 
            // primerultimobtn
            // 
            this.primerultimobtn.Location = new System.Drawing.Point(68, 160);
            this.primerultimobtn.Name = "primerultimobtn";
            this.primerultimobtn.Size = new System.Drawing.Size(185, 50);
            this.primerultimobtn.TabIndex = 5;
            this.primerultimobtn.Text = "intercambiar primeros y ultimos";
            this.primerultimobtn.UseVisualStyleBackColor = true;
            this.primerultimobtn.Click += new System.EventHandler(this.primerultimobtn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(366, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "Agregar",
            "Editar",
            "Borrar"});
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Agregar",
            "Borrar",
            "Editar"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.Text = "Seleccionar Opcion";
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(43, 22);
            this.toolStripButton1.Text = "Cerrar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Nombre2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Nombre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(259, 278);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 278);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 341);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.primerultimobtn);
            this.Controls.Add(this.intercambiarbtn);
            this.Controls.Add(this.borrarbtn);
            this.Controls.Add(this.ordenarbtn);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button ordenarbtn;
        private System.Windows.Forms.Button borrarbtn;
        private System.Windows.Forms.Button intercambiarbtn;
        private System.Windows.Forms.Button primerultimobtn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

