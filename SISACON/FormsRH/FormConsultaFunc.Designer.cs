
namespace SISACON.FormsRH
{
    partial class FormConsultaFunc
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
            this.gpboxConsulta = new System.Windows.Forms.GroupBox();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.lblCampos = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtCPFCNPJ = new System.Windows.Forms.TextBox();
            this.lblCPFCNPJ = new System.Windows.Forms.Label();
            this.gpboxConsulta.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpboxConsulta
            // 
            this.gpboxConsulta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gpboxConsulta.AutoSize = true;
            this.gpboxConsulta.Controls.Add(this.lblConsulta);
            this.gpboxConsulta.Controls.Add(this.lblCampos);
            this.gpboxConsulta.Controls.Add(this.btnPesquisar);
            this.gpboxConsulta.Controls.Add(this.txtCPFCNPJ);
            this.gpboxConsulta.Controls.Add(this.lblCPFCNPJ);
            this.gpboxConsulta.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.gpboxConsulta.Location = new System.Drawing.Point(13, 12);
            this.gpboxConsulta.Name = "gpboxConsulta";
            this.gpboxConsulta.Size = new System.Drawing.Size(704, 182);
            this.gpboxConsulta.TabIndex = 0;
            this.gpboxConsulta.TabStop = false;
            this.gpboxConsulta.Text = "Atualização de dados do funcionario";
            this.gpboxConsulta.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulta.Location = new System.Drawing.Point(7, 42);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(397, 19);
            this.lblConsulta.TabIndex = 58;
            this.lblConsulta.Text = "Para atualização dos dados por favor informe o CPF ou CNPJ";
            // 
            // lblCampos
            // 
            this.lblCampos.AutoSize = true;
            this.lblCampos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampos.Location = new System.Drawing.Point(7, 134);
            this.lblCampos.Name = "lblCampos";
            this.lblCampos.Size = new System.Drawing.Size(155, 19);
            this.lblCampos.TabIndex = 57;
            this.lblCampos.Text = "* Campos obrigatórios";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPesquisar.Location = new System.Drawing.Point(433, 82);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 33);
            this.btnPesquisar.TabIndex = 28;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCPFCNPJ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFCNPJ.Location = new System.Drawing.Point(101, 82);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(293, 26);
            this.txtCPFCNPJ.TabIndex = 27;
            // 
            // lblCPFCNPJ
            // 
            this.lblCPFCNPJ.AutoSize = true;
            this.lblCPFCNPJ.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPFCNPJ.Location = new System.Drawing.Point(7, 84);
            this.lblCPFCNPJ.Name = "lblCPFCNPJ";
            this.lblCPFCNPJ.Size = new System.Drawing.Size(88, 19);
            this.lblCPFCNPJ.TabIndex = 26;
            this.lblCPFCNPJ.Text = "* CPF/CNPJ:";
            // 
            // FormConsultaFunc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 202);
            this.Controls.Add(this.gpboxConsulta);
            this.MaximizeBox = false;
            this.Name = "FormConsultaFunc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATUALIZAR DADOS DOS FUNCIONARIOS";
            this.gpboxConsulta.ResumeLayout(false);
            this.gpboxConsulta.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpboxConsulta;
        private System.Windows.Forms.TextBox txtCPFCNPJ;
        private System.Windows.Forms.Label lblCPFCNPJ;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblCampos;
        private System.Windows.Forms.Label lblConsulta;
    }
}