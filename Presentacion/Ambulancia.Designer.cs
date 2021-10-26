
namespace Presentacion
{
    partial class Ambulancia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBoxCod = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPasajeros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxEmergencia = new System.Windows.Forms.CheckBox();
            this.checkBoxServicio = new System.Windows.Forms.CheckBox();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.textBoxBusq = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(31, 51);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregar.TabIndex = 0;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 271);
            this.dataGridView1.TabIndex = 1;
            // 
            // textBoxCod
            // 
            this.textBoxCod.Location = new System.Drawing.Point(31, 25);
            this.textBoxCod.Name = "textBoxCod";
            this.textBoxCod.Size = new System.Drawing.Size(75, 20);
            this.textBoxCod.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Codigo";
            // 
            // textBoxPasajeros
            // 
            this.textBoxPasajeros.Location = new System.Drawing.Point(123, 25);
            this.textBoxPasajeros.Name = "textBoxPasajeros";
            this.textBoxPasajeros.Size = new System.Drawing.Size(75, 20);
            this.textBoxPasajeros.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pasajeros";
            // 
            // checkBoxEmergencia
            // 
            this.checkBoxEmergencia.AutoSize = true;
            this.checkBoxEmergencia.Location = new System.Drawing.Point(222, 25);
            this.checkBoxEmergencia.Name = "checkBoxEmergencia";
            this.checkBoxEmergencia.Size = new System.Drawing.Size(82, 17);
            this.checkBoxEmergencia.TabIndex = 6;
            this.checkBoxEmergencia.Text = "Emergencia";
            this.checkBoxEmergencia.UseVisualStyleBackColor = true;
            // 
            // checkBoxServicio
            // 
            this.checkBoxServicio.AutoSize = true;
            this.checkBoxServicio.Location = new System.Drawing.Point(222, 51);
            this.checkBoxServicio.Name = "checkBoxServicio";
            this.checkBoxServicio.Size = new System.Drawing.Size(78, 17);
            this.checkBoxServicio.TabIndex = 7;
            this.checkBoxServicio.Text = "En servicio";
            this.checkBoxServicio.UseVisualStyleBackColor = true;
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.Location = new System.Drawing.Point(123, 51);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(75, 23);
            this.buttonEliminar.TabIndex = 8;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxBusq
            // 
            this.textBoxBusq.Location = new System.Drawing.Point(319, 22);
            this.textBoxBusq.Name = "textBoxBusq";
            this.textBoxBusq.Size = new System.Drawing.Size(112, 20);
            this.textBoxBusq.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Buscar";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "En servicio",
            "Emergencia",
            "Codigo",
            "Pasajeros"});
            this.comboBox1.Location = new System.Drawing.Point(437, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mediante";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(461, 48);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(97, 26);
            this.buttonBuscar.TabIndex = 14;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ambulancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 366);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxBusq);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.checkBoxServicio);
            this.Controls.Add(this.checkBoxEmergencia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPasajeros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCod);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAgregar);
            this.Name = "Ambulancia";
            this.Text = "Ambulancia";
            this.Load += new System.EventHandler(this.Ambulancia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPasajeros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxEmergencia;
        private System.Windows.Forms.CheckBox checkBoxServicio;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.TextBox textBoxBusq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonBuscar;
    }
}