namespace Formulariospractica
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
            this.Agregar1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.Agregar2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.DERaIZQ = new System.Windows.Forms.Button();
            this.DERaIZQTO = new System.Windows.Forms.Button();
            this.IZQaDER = new System.Windows.Forms.Button();
            this.IZQaDERTO = new System.Windows.Forms.Button();
            this.Borrar1 = new System.Windows.Forms.Button();
            this.Borrar2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Agregar1
            // 
            this.Agregar1.Location = new System.Drawing.Point(120, 386);
            this.Agregar1.Name = "Agregar1";
            this.Agregar1.Size = new System.Drawing.Size(75, 23);
            this.Agregar1.TabIndex = 0;
            this.Agregar1.Text = "Agregar";
            this.Agregar1.UseVisualStyleBackColor = true;
            this.Agregar1.Click += new System.EventHandler(this.Agregar1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(120, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(155, 342);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(362, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(155, 342);
            this.listBox2.TabIndex = 2;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // Agregar2
            // 
            this.Agregar2.Location = new System.Drawing.Point(362, 386);
            this.Agregar2.Name = "Agregar2";
            this.Agregar2.Size = new System.Drawing.Size(75, 23);
            this.Agregar2.TabIndex = 3;
            this.Agregar2.Text = "Agregar";
            this.Agregar2.UseVisualStyleBackColor = true;
            this.Agregar2.Click += new System.EventHandler(this.Agregar2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 360);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(362, 360);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // DERaIZQ
            // 
            this.DERaIZQ.Location = new System.Drawing.Point(281, 12);
            this.DERaIZQ.Name = "DERaIZQ";
            this.DERaIZQ.Size = new System.Drawing.Size(75, 23);
            this.DERaIZQ.TabIndex = 6;
            this.DERaIZQ.Text = "<--";
            this.DERaIZQ.UseVisualStyleBackColor = true;
            this.DERaIZQ.Click += new System.EventHandler(this.DERaIZQ_Click);
            // 
            // DERaIZQTO
            // 
            this.DERaIZQTO.Location = new System.Drawing.Point(281, 41);
            this.DERaIZQTO.Name = "DERaIZQTO";
            this.DERaIZQTO.Size = new System.Drawing.Size(75, 23);
            this.DERaIZQTO.TabIndex = 7;
            this.DERaIZQTO.Text = "<<--";
            this.DERaIZQTO.UseVisualStyleBackColor = true;
            this.DERaIZQTO.Click += new System.EventHandler(this.DERaIZQTO_Click);
            // 
            // IZQaDER
            // 
            this.IZQaDER.Location = new System.Drawing.Point(281, 331);
            this.IZQaDER.Name = "IZQaDER";
            this.IZQaDER.Size = new System.Drawing.Size(75, 23);
            this.IZQaDER.TabIndex = 8;
            this.IZQaDER.Text = "-->";
            this.IZQaDER.UseVisualStyleBackColor = true;
            this.IZQaDER.Click += new System.EventHandler(this.IZQaDER_Click);
            // 
            // IZQaDERTO
            // 
            this.IZQaDERTO.Location = new System.Drawing.Point(281, 291);
            this.IZQaDERTO.Name = "IZQaDERTO";
            this.IZQaDERTO.Size = new System.Drawing.Size(75, 23);
            this.IZQaDERTO.TabIndex = 9;
            this.IZQaDERTO.Text = "-->>";
            this.IZQaDERTO.UseVisualStyleBackColor = true;
            this.IZQaDERTO.Click += new System.EventHandler(this.IZQaDERTO_Click);
            // 
            // Borrar1
            // 
            this.Borrar1.Location = new System.Drawing.Point(120, 415);
            this.Borrar1.Name = "Borrar1";
            this.Borrar1.Size = new System.Drawing.Size(75, 23);
            this.Borrar1.TabIndex = 10;
            this.Borrar1.Text = "Borrar";
            this.Borrar1.UseVisualStyleBackColor = true;
            this.Borrar1.Click += new System.EventHandler(this.Borrar1_Click);
            // 
            // Borrar2
            // 
            this.Borrar2.Location = new System.Drawing.Point(362, 415);
            this.Borrar2.Name = "Borrar2";
            this.Borrar2.Size = new System.Drawing.Size(75, 23);
            this.Borrar2.TabIndex = 11;
            this.Borrar2.Text = "Borrar";
            this.Borrar2.UseVisualStyleBackColor = true;
            this.Borrar2.Click += new System.EventHandler(this.Borrar2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 450);
            this.Controls.Add(this.Borrar2);
            this.Controls.Add(this.Borrar1);
            this.Controls.Add(this.IZQaDERTO);
            this.Controls.Add(this.IZQaDER);
            this.Controls.Add(this.DERaIZQTO);
            this.Controls.Add(this.DERaIZQ);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Agregar2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.Agregar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Agregar1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button Agregar2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button DERaIZQ;
        private System.Windows.Forms.Button DERaIZQTO;
        private System.Windows.Forms.Button IZQaDER;
        private System.Windows.Forms.Button IZQaDERTO;
        private System.Windows.Forms.Button Borrar1;
        private System.Windows.Forms.Button Borrar2;
    }
}

