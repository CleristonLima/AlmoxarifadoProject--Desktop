
namespace SISACON.FormsRH
{
    partial class FormMenuDemissao
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
            this.gpbDemissoes = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLblConsulta = new System.Windows.Forms.LinkLabel();
            this.gpbDemissoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDemissoes
            // 
            this.gpbDemissoes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDemissoes.Controls.Add(this.linkLabel1);
            this.gpbDemissoes.Controls.Add(this.linkLblConsulta);
            this.gpbDemissoes.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.gpbDemissoes.Location = new System.Drawing.Point(3, 3);
            this.gpbDemissoes.Name = "gpbDemissoes";
            this.gpbDemissoes.Size = new System.Drawing.Size(541, 100);
            this.gpbDemissoes.TabIndex = 0;
            this.gpbDemissoes.TabStop = false;
            this.gpbDemissoes.Text = "Demissões";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(389, 45);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(129, 19);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Realizar demissão";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLblConsulta
            // 
            this.linkLblConsulta.AutoSize = true;
            this.linkLblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblConsulta.Location = new System.Drawing.Point(9, 45);
            this.linkLblConsulta.Name = "linkLblConsulta";
            this.linkLblConsulta.Size = new System.Drawing.Size(279, 19);
            this.linkLblConsulta.TabIndex = 18;
            this.linkLblConsulta.TabStop = true;
            this.linkLblConsulta.Text = "Consultar ou alterar dados de demissão";
            this.linkLblConsulta.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLblConsulta.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblConsulta_LinkClicked);
            // 
            // FormMenuDemissao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(546, 115);
            this.Controls.Add(this.gpbDemissoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMenuDemissao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DEMISSÕES";
            this.gpbDemissoes.ResumeLayout(false);
            this.gpbDemissoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDemissoes;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLblConsulta;
    }
}