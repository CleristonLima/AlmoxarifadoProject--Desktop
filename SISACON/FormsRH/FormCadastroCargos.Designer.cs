﻿
namespace SISACON.FormsRH
{
    partial class FormCadastroCargos
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
            this.groupBoxCadCargo = new System.Windows.Forms.GroupBox();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.chkCargoConfianca = new System.Windows.Forms.CheckBox();
            this.groupBoxCadCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCadCargo
            // 
            this.groupBoxCadCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCadCargo.Controls.Add(this.chkCargoConfianca);
            this.groupBoxCadCargo.Controls.Add(this.cbxStatus);
            this.groupBoxCadCargo.Controls.Add(this.label3);
            this.groupBoxCadCargo.Controls.Add(this.btnVoltar);
            this.groupBoxCadCargo.Controls.Add(this.btnSalvar);
            this.groupBoxCadCargo.Controls.Add(this.txtCargo);
            this.groupBoxCadCargo.Controls.Add(this.lblTitle);
            this.groupBoxCadCargo.Controls.Add(this.lblCargo);
            this.groupBoxCadCargo.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.groupBoxCadCargo.Location = new System.Drawing.Point(12, 21);
            this.groupBoxCadCargo.Name = "groupBoxCadCargo";
            this.groupBoxCadCargo.Size = new System.Drawing.Size(579, 283);
            this.groupBoxCadCargo.TabIndex = 1;
            this.groupBoxCadCargo.TabStop = false;
            this.groupBoxCadCargo.Text = "Cadastro de cargos";
            // 
            // cbxStatus
            // 
            this.cbxStatus.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(137, 111);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(134, 26);
            this.cbxStatus.TabIndex = 26;
            this.cbxStatus.SelectedIndexChanged += new System.EventHandler(this.cbxStatus_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "* Status:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar.Location = new System.Drawing.Point(317, 213);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar.TabIndex = 24;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(441, 213);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(107, 37);
            this.btnSalvar.TabIndex = 23;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtCargo
            // 
            this.txtCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCargo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCargo.Location = new System.Drawing.Point(137, 62);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(442, 26);
            this.txtCargo.TabIndex = 21;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 165);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 19);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "* Campos obrigatórios";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(6, 64);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(131, 19);
            this.lblCargo.TabIndex = 1;
            this.lblCargo.Text = "* Nome do Cargo:";
            // 
            // chkCargoConfianca
            // 
            this.chkCargoConfianca.AutoSize = true;
            this.chkCargoConfianca.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCargoConfianca.Location = new System.Drawing.Point(351, 112);
            this.chkCargoConfianca.Name = "chkCargoConfianca";
            this.chkCargoConfianca.Size = new System.Drawing.Size(165, 23);
            this.chkCargoConfianca.TabIndex = 28;
            this.chkCargoConfianca.Text = "Cargo de confiança?";
            this.chkCargoConfianca.UseVisualStyleBackColor = true;
            // 
            // FormCadastroCargos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 312);
            this.Controls.Add(this.groupBoxCadCargo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCadastroCargos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE CARGOS";
            this.groupBoxCadCargo.ResumeLayout(false);
            this.groupBoxCadCargo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCadCargo;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.CheckBox chkCargoConfianca;
    }
}