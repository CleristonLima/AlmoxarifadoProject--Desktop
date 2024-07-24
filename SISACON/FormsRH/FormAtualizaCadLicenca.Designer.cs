
namespace SISACON.FormsRH
{
    partial class FormAtualizaCadLicenca
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
            this.grpBoxLicencaAtualiza = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtConsultaCPFCNPJ = new System.Windows.Forms.TextBox();
            this.lblCPFCNPJ = new System.Windows.Forms.Label();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.txtCPFCNPJ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRGRNE = new System.Windows.Forms.TextBox();
            this.lblRGRNE = new System.Windows.Forms.Label();
            this.dateTimePickerFinishLicense = new System.Windows.Forms.DateTimePicker();
            this.lblDtTermFerias = new System.Windows.Forms.Label();
            this.dateTimePickerStartLicense = new System.Windows.Forms.DateTimePicker();
            this.lblDataIniFerias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnVoltar2 = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grpBoxLicencaAtualiza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxLicencaAtualiza
            // 
            this.grpBoxLicencaAtualiza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxLicencaAtualiza.Controls.Add(this.btnSalvar);
            this.grpBoxLicencaAtualiza.Controls.Add(this.btnVoltar2);
            this.grpBoxLicencaAtualiza.Controls.Add(this.label7);
            this.grpBoxLicencaAtualiza.Controls.Add(this.txtObservacao);
            this.grpBoxLicencaAtualiza.Controls.Add(this.label1);
            this.grpBoxLicencaAtualiza.Controls.Add(this.dateTimePickerFinishLicense);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblDtTermFerias);
            this.grpBoxLicencaAtualiza.Controls.Add(this.dateTimePickerStartLicense);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblDataIniFerias);
            this.grpBoxLicencaAtualiza.Controls.Add(this.txtCPFCNPJ);
            this.grpBoxLicencaAtualiza.Controls.Add(this.label3);
            this.grpBoxLicencaAtualiza.Controls.Add(this.txtRGRNE);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblRGRNE);
            this.grpBoxLicencaAtualiza.Controls.Add(this.pictureBoxFoto);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblFoto);
            this.grpBoxLicencaAtualiza.Controls.Add(this.txtNome);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblNome);
            this.grpBoxLicencaAtualiza.Controls.Add(this.btnPesquisar);
            this.grpBoxLicencaAtualiza.Controls.Add(this.txtConsultaCPFCNPJ);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblCPFCNPJ);
            this.grpBoxLicencaAtualiza.Controls.Add(this.lblConsulta);
            this.grpBoxLicencaAtualiza.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.grpBoxLicencaAtualiza.Location = new System.Drawing.Point(13, 12);
            this.grpBoxLicencaAtualiza.Name = "grpBoxLicencaAtualiza";
            this.grpBoxLicencaAtualiza.Size = new System.Drawing.Size(903, 601);
            this.grpBoxLicencaAtualiza.TabIndex = 0;
            this.grpBoxLicencaAtualiza.TabStop = false;
            this.grpBoxLicencaAtualiza.Text = "Atualização de dados de licença";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPesquisar.Location = new System.Drawing.Point(422, 67);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 33);
            this.btnPesquisar.TabIndex = 85;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtConsultaCPFCNPJ
            // 
            this.txtConsultaCPFCNPJ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultaCPFCNPJ.Location = new System.Drawing.Point(100, 72);
            this.txtConsultaCPFCNPJ.Name = "txtConsultaCPFCNPJ";
            this.txtConsultaCPFCNPJ.Size = new System.Drawing.Size(293, 26);
            this.txtConsultaCPFCNPJ.TabIndex = 84;
            // 
            // lblCPFCNPJ
            // 
            this.lblCPFCNPJ.AutoSize = true;
            this.lblCPFCNPJ.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPFCNPJ.Location = new System.Drawing.Point(6, 74);
            this.lblCPFCNPJ.Name = "lblCPFCNPJ";
            this.lblCPFCNPJ.Size = new System.Drawing.Size(88, 19);
            this.lblCPFCNPJ.TabIndex = 83;
            this.lblCPFCNPJ.Text = "* CPF/CNPJ:";
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulta.Location = new System.Drawing.Point(6, 41);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(567, 19);
            this.lblConsulta.TabIndex = 82;
            this.lblConsulta.Text = "Para atualizar os dados de licença do funcionário é necessário informar o CPF ou " +
    "CNPJ";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(139, 116);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(465, 26);
            this.txtNome.TabIndex = 87;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(6, 118);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(124, 19);
            this.lblNome.TabIndex = 86;
            this.lblNome.Text = "Nome Completo:";
            // 
            // lblFoto
            // 
            this.lblFoto.AllowDrop = true;
            this.lblFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.Location = new System.Drawing.Point(745, 94);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(71, 19);
            this.lblFoto.TabIndex = 88;
            this.lblFoto.Text = "Foto 3x4:";
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFoto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBoxFoto.Location = new System.Drawing.Point(693, 116);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(178, 168);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoto.TabIndex = 89;
            this.pictureBoxFoto.TabStop = false;
            this.pictureBoxFoto.WaitOnLoad = true;
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFCNPJ.Location = new System.Drawing.Point(100, 201);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(184, 26);
            this.txtCPFCNPJ.TabIndex = 93;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 92;
            this.label3.Text = "CPF/CNPJ:";
            // 
            // txtRGRNE
            // 
            this.txtRGRNE.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRGRNE.Location = new System.Drawing.Point(100, 157);
            this.txtRGRNE.Name = "txtRGRNE";
            this.txtRGRNE.Size = new System.Drawing.Size(184, 26);
            this.txtRGRNE.TabIndex = 91;
            // 
            // lblRGRNE
            // 
            this.lblRGRNE.AutoSize = true;
            this.lblRGRNE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRGRNE.Location = new System.Drawing.Point(6, 159);
            this.lblRGRNE.Name = "lblRGRNE";
            this.lblRGRNE.Size = new System.Drawing.Size(67, 19);
            this.lblRGRNE.TabIndex = 90;
            this.lblRGRNE.Text = "RG/RNE:";
            // 
            // dateTimePickerFinishLicense
            // 
            this.dateTimePickerFinishLicense.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFinishLicense.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFinishLicense.Location = new System.Drawing.Point(199, 282);
            this.dateTimePickerFinishLicense.Name = "dateTimePickerFinishLicense";
            this.dateTimePickerFinishLicense.Size = new System.Drawing.Size(127, 26);
            this.dateTimePickerFinishLicense.TabIndex = 100;
            // 
            // lblDtTermFerias
            // 
            this.lblDtTermFerias.AutoSize = true;
            this.lblDtTermFerias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtTermFerias.Location = new System.Drawing.Point(6, 288);
            this.lblDtTermFerias.Name = "lblDtTermFerias";
            this.lblDtTermFerias.Size = new System.Drawing.Size(176, 19);
            this.lblDtTermFerias.TabIndex = 99;
            this.lblDtTermFerias.Text = "* Data de fim da licença:";
            // 
            // dateTimePickerStartLicense
            // 
            this.dateTimePickerStartLicense.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartLicense.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartLicense.Location = new System.Drawing.Point(199, 242);
            this.dateTimePickerStartLicense.Name = "dateTimePickerStartLicense";
            this.dateTimePickerStartLicense.Size = new System.Drawing.Size(127, 26);
            this.dateTimePickerStartLicense.TabIndex = 98;
            // 
            // lblDataIniFerias
            // 
            this.lblDataIniFerias.AutoSize = true;
            this.lblDataIniFerias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataIniFerias.Location = new System.Drawing.Point(6, 247);
            this.lblDataIniFerias.Name = "lblDataIniFerias";
            this.lblDataIniFerias.Size = new System.Drawing.Size(191, 19);
            this.lblDataIniFerias.TabIndex = 97;
            this.lblDataIniFerias.Text = "* Data de inicio da licença:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 101;
            this.label1.Text = "* Observações:";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtObservacao.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(137, 333);
            this.txtObservacao.MaxLength = 1000;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(478, 157);
            this.txtObservacao.TabIndex = 102;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 19);
            this.label7.TabIndex = 103;
            this.label7.Text = "* Campos obrigatórios";
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar2.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar2.Location = new System.Drawing.Point(619, 542);
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar2.TabIndex = 104;
            this.btnVoltar2.Text = "Voltar";
            this.btnVoltar2.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSalvar.Location = new System.Drawing.Point(751, 540);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 37);
            this.btnSalvar.TabIndex = 105;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormAtualizaCadLicenca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 625);
            this.Controls.Add(this.grpBoxLicencaAtualiza);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAtualizaCadLicenca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATUALIZAÇÃO - CADASTRO LICENÇA";
            this.Load += new System.EventHandler(this.FormAtualizaCadLicenca_Load);
            this.grpBoxLicencaAtualiza.ResumeLayout(false);
            this.grpBoxLicencaAtualiza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxLicencaAtualiza;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtConsultaCPFCNPJ;
        private System.Windows.Forms.Label lblCPFCNPJ;
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.TextBox txtCPFCNPJ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRGRNE;
        private System.Windows.Forms.Label lblRGRNE;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinishLicense;
        private System.Windows.Forms.Label lblDtTermFerias;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartLicense;
        private System.Windows.Forms.Label lblDataIniFerias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVoltar2;
        private System.Windows.Forms.Button btnSalvar;
    }
}