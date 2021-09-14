
namespace UI
{
    partial class Padre
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
            this.buttonVIRGINIA = new System.Windows.Forms.Button();
            this.TEXTBOXVIRGINIA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonVIRGINIA
            // 
            this.buttonVIRGINIA.Location = new System.Drawing.Point(442, 37);
            this.buttonVIRGINIA.Name = "buttonVIRGINIA";
            this.buttonVIRGINIA.Size = new System.Drawing.Size(75, 23);
            this.buttonVIRGINIA.TabIndex = 0;
            this.buttonVIRGINIA.Text = "HOLA";
            this.buttonVIRGINIA.UseVisualStyleBackColor = true;
            this.buttonVIRGINIA.Click += new System.EventHandler(this.button1_Click);
            // 
            // TEXTBOXVIRGINIA
            // 
            this.TEXTBOXVIRGINIA.Location = new System.Drawing.Point(321, 37);
            this.TEXTBOXVIRGINIA.Name = "TEXTBOXVIRGINIA";
            this.TEXTBOXVIRGINIA.Size = new System.Drawing.Size(100, 20);
            this.TEXTBOXVIRGINIA.TabIndex = 1;
            // 
            // Padre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TEXTBOXVIRGINIA);
            this.Controls.Add(this.buttonVIRGINIA);
            this.Name = "Padre";
            this.Text = "Padre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonVIRGINIA;
        private System.Windows.Forms.TextBox TEXTBOXVIRGINIA;
    }
}