
namespace SISACON.FormsRH
{
    partial class FormMenuLicenca
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
            this.gpbLicFunc = new System.Windows.Forms.GroupBox();
            this.lblRealizaCadastro = new System.Windows.Forms.LinkLabel();
            this.linkLblConsulta = new System.Windows.Forms.LinkLabel();
            this.gpbLicFunc.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbLicFunc
            // 
            this.gpbLicFunc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbLicFunc.Controls.Add(this.lblRealizaCadastro);
            this.gpbLicFunc.Controls.Add(this.linkLblConsulta);
            this.gpbLicFunc.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.gpbLicFunc.Location = new System.Drawing.Point(13, 12);
            this.gpbLicFunc.Name = "gpbLicFunc";
            this.gpbLicFunc.Size = new System.Drawing.Size(644, 108);
            this.gpbLicFunc.TabIndex = 0;
            this.gpbLicFunc.TabStop = false;
            this.gpbLicFunc.Text = "Licença dos funcionários";
            // 
            // lblRealizaCadastro
            // 
            this.lblRealizaCadastro.AutoSize = true;
            this.lblRealizaCadastro.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealizaCadastro.Location = new System.Drawing.Point(418, 49);
            this.lblRealizaCadastro.Name = "lblRealizaCadastro";
            this.lblRealizaCadastro.Size = new System.Drawing.Size(203, 19);
            this.lblRealizaCadastro.TabIndex = 21;
            this.lblRealizaCadastro.TabStop = true;
            this.lblRealizaCadastro.Text = "Realizar cadastro de licenças";
            this.lblRealizaCadastro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRealizaCadastro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLblConsulta
            // 
            this.linkLblConsulta.AutoSize = true;
            this.linkLblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblConsulta.Location = new System.Drawing.Point(6, 49);
            this.linkLblConsulta.Name = "linkLblConsulta";
            this.linkLblConsulta.Size = new System.Drawing.Size(275, 19);
            this.linkLblConsulta.TabIndex = 20;
            this.linkLblConsulta.TabStop = true;
            this.linkLblConsulta.Text = "Consultar ou alterar dados das licenças";
            this.linkLblConsulta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLblConsulta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblConsulta_LinkClicked);
            // 
            // FormMenuLicenca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 129);
            this.Controls.Add(this.gpbLicFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMenuLicenca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LICENÇA DOS FUNCIONÁRIOS";
            this.Load += new System.EventHandler(this.FormMenuLicenca_Load);
            this.gpbLicFunc.ResumeLayout(false);
            this.gpbLicFunc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbLicFunc;
        private System.Windows.Forms.LinkLabel lblRealizaCadastro;
        private System.Windows.Forms.LinkLabel linkLblConsulta;
    }
}