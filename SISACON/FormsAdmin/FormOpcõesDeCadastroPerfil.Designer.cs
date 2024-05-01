
namespace SISACON.FormsAdmin
{
    partial class FormOpcõesDeCadastroPerfil
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
            this.linkLabelCadPerfil = new System.Windows.Forms.LinkLabel();
            this.linkLabelAtualizarCadPerfil = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabelCadPerfil
            // 
            this.linkLabelCadPerfil.AutoSize = true;
            this.linkLabelCadPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCadPerfil.Location = new System.Drawing.Point(45, 30);
            this.linkLabelCadPerfil.Name = "linkLabelCadPerfil";
            this.linkLabelCadPerfil.Size = new System.Drawing.Size(130, 19);
            this.linkLabelCadPerfil.TabIndex = 13;
            this.linkLabelCadPerfil.TabStop = true;
            this.linkLabelCadPerfil.Text = "Cadastro de perfil";
            this.linkLabelCadPerfil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabelCadPerfil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCadPerfil_LinkClicked);
            // 
            // linkLabelAtualizarCadPerfil
            // 
            this.linkLabelAtualizarCadPerfil.AutoSize = true;
            this.linkLabelAtualizarCadPerfil.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelAtualizarCadPerfil.Location = new System.Drawing.Point(45, 96);
            this.linkLabelAtualizarCadPerfil.Name = "linkLabelAtualizarCadPerfil";
            this.linkLabelAtualizarCadPerfil.Size = new System.Drawing.Size(194, 19);
            this.linkLabelAtualizarCadPerfil.TabIndex = 14;
            this.linkLabelAtualizarCadPerfil.TabStop = true;
            this.linkLabelAtualizarCadPerfil.Text = "Atualizar cadastro de perfil";
            this.linkLabelAtualizarCadPerfil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabelAtualizarCadPerfil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAtualizarCadPerfil_LinkClicked);
            // 
            // FormOpcõesDeCadastroPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 171);
            this.Controls.Add(this.linkLabelAtualizarCadPerfil);
            this.Controls.Add(this.linkLabelCadPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormOpcõesDeCadastroPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE PERFIL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelCadPerfil;
        private System.Windows.Forms.LinkLabel linkLabelAtualizarCadPerfil;
    }
}