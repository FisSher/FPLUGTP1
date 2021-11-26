
namespace Presentacion
{
    partial class LoginUCForm
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
            this.loginUC1 = new Presentacion.LoginUC();
            this.SuspendLayout();
            // 
            // loginUC1
            // 
            this.loginUC1.Location = new System.Drawing.Point(36, 35);
            this.loginUC1.Name = "loginUC1";
            this.loginUC1.Size = new System.Drawing.Size(271, 299);
            this.loginUC1.TabIndex = 0;
            // 
            // LoginUCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 402);
            this.Controls.Add(this.loginUC1);
            this.Name = "LoginUCForm";
            this.Text = "LoginUCForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginUC loginUC1;
    }
}