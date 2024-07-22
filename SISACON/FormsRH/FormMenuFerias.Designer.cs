
namespace SISACON.FormsRH
{
    partial class FormMenuFerias
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
            this.grpBoxFerias = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLblConsulta = new System.Windows.Forms.LinkLabel();
            this.grpBoxFerias.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxFerias
            // 
            this.grpBoxFerias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFerias.Controls.Add(this.linkLabel1);
            this.grpBoxFerias.Controls.Add(this.linkLblConsulta);
            this.grpBoxFerias.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.grpBoxFerias.Location = new System.Drawing.Point(3, 3);
            this.grpBoxFerias.Name = "grpBoxFerias";
            this.grpBoxFerias.Size = new System.Drawing.Size(575, 113);
            this.grpBoxFerias.TabIndex = 0;
            this.grpBoxFerias.TabStop = false;
            this.grpBoxFerias.Text = "Férias";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(348, 50);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(208, 19);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Realizar férias do funcionário";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLblConsulta
            // 
            this.linkLblConsulta.AutoSize = true;
            this.linkLblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblConsulta.Location = new System.Drawing.Point(6, 50);
            this.linkLblConsulta.Name = "linkLblConsulta";
            this.linkLblConsulta.Size = new System.Drawing.Size(259, 19);
            this.linkLblConsulta.TabIndex = 19;
            this.linkLblConsulta.TabStop = true;
            this.linkLblConsulta.Text = "Consultar ou alterar dados das férias";
            this.linkLblConsulta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLblConsulta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblConsulta_LinkClicked);
            // 
            // FormMenuFerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 128);
            this.Controls.Add(this.grpBoxFerias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMenuFerias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FERIAS";
            this.grpBoxFerias.ResumeLayout(false);
            this.grpBoxFerias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxFerias;
        private System.Windows.Forms.LinkLabel linkLblConsulta;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}