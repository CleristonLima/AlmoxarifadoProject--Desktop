
namespace SISACON.FormsRH
{
    partial class FormAtualizaCadFerias
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
            this.gpbAtualizaFerias = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFinishVacation = new System.Windows.Forms.DateTimePicker();
            this.lblDtTermFerias = new System.Windows.Forms.Label();
            this.dateTimePickerStartVacation = new System.Windows.Forms.DateTimePicker();
            this.lblDataIniFerias = new System.Windows.Forms.Label();
            this.txtCPFCNPJ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRGRNE = new System.Windows.Forms.TextBox();
            this.lblRGRNE = new System.Windows.Forms.Label();
            this.pictureBoxFoto = new System.Windows.Forms.PictureBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtConsultaCPFCNPJ = new System.Windows.Forms.TextBox();
            this.lblCPFCNPJ = new System.Windows.Forms.Label();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.gpbAtualizaFerias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbAtualizaFerias
            // 
            this.gpbAtualizaFerias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbAtualizaFerias.Controls.Add(this.btnSalvar);
            this.gpbAtualizaFerias.Controls.Add(this.btnVoltar2);
            this.gpbAtualizaFerias.Controls.Add(this.label7);
            this.gpbAtualizaFerias.Controls.Add(this.txtObservacao);
            this.gpbAtualizaFerias.Controls.Add(this.label1);
            this.gpbAtualizaFerias.Controls.Add(this.dateTimePickerFinishVacation);
            this.gpbAtualizaFerias.Controls.Add(this.lblDtTermFerias);
            this.gpbAtualizaFerias.Controls.Add(this.dateTimePickerStartVacation);
            this.gpbAtualizaFerias.Controls.Add(this.lblDataIniFerias);
            this.gpbAtualizaFerias.Controls.Add(this.txtCPFCNPJ);
            this.gpbAtualizaFerias.Controls.Add(this.label3);
            this.gpbAtualizaFerias.Controls.Add(this.txtRGRNE);
            this.gpbAtualizaFerias.Controls.Add(this.lblRGRNE);
            this.gpbAtualizaFerias.Controls.Add(this.pictureBoxFoto);
            this.gpbAtualizaFerias.Controls.Add(this.lblFoto);
            this.gpbAtualizaFerias.Controls.Add(this.txtNome);
            this.gpbAtualizaFerias.Controls.Add(this.lblNome);
            this.gpbAtualizaFerias.Controls.Add(this.btnPesquisar);
            this.gpbAtualizaFerias.Controls.Add(this.txtConsultaCPFCNPJ);
            this.gpbAtualizaFerias.Controls.Add(this.lblCPFCNPJ);
            this.gpbAtualizaFerias.Controls.Add(this.lblConsulta);
            this.gpbAtualizaFerias.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.gpbAtualizaFerias.Location = new System.Drawing.Point(13, 13);
            this.gpbAtualizaFerias.Name = "gpbAtualizaFerias";
            this.gpbAtualizaFerias.Size = new System.Drawing.Size(846, 602);
            this.gpbAtualizaFerias.TabIndex = 0;
            this.gpbAtualizaFerias.TabStop = false;
            this.gpbAtualizaFerias.Text = "Atualização dados de férias";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSalvar.Location = new System.Drawing.Point(703, 545);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 37);
            this.btnSalvar.TabIndex = 97;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar2.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar2.Location = new System.Drawing.Point(579, 545);
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar2.TabIndex = 96;
            this.btnVoltar2.Text = "Voltar";
            this.btnVoltar2.UseVisualStyleBackColor = true;
            this.btnVoltar2.Click += new System.EventHandler(this.btnVoltar2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 517);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 19);
            this.label7.TabIndex = 95;
            this.label7.Text = "* Campos obrigatórios";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtObservacao.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(129, 336);
            this.txtObservacao.MaxLength = 1000;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(478, 157);
            this.txtObservacao.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 93;
            this.label1.Text = "* Observações:";
            // 
            // dateTimePickerFinishVacation
            // 
            this.dateTimePickerFinishVacation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFinishVacation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFinishVacation.Location = new System.Drawing.Point(199, 292);
            this.dateTimePickerFinishVacation.Name = "dateTimePickerFinishVacation";
            this.dateTimePickerFinishVacation.Size = new System.Drawing.Size(127, 26);
            this.dateTimePickerFinishVacation.TabIndex = 92;
            this.dateTimePickerFinishVacation.ValueChanged += new System.EventHandler(this.dateTimePickerFinishVacation_ValueChanged);
            // 
            // lblDtTermFerias
            // 
            this.lblDtTermFerias.AutoSize = true;
            this.lblDtTermFerias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDtTermFerias.Location = new System.Drawing.Point(6, 297);
            this.lblDtTermFerias.Name = "lblDtTermFerias";
            this.lblDtTermFerias.Size = new System.Drawing.Size(172, 19);
            this.lblDtTermFerias.TabIndex = 91;
            this.lblDtTermFerias.Text = "* Data de fim das férias:";
            // 
            // dateTimePickerStartVacation
            // 
            this.dateTimePickerStartVacation.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerStartVacation.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStartVacation.Location = new System.Drawing.Point(199, 251);
            this.dateTimePickerStartVacation.Name = "dateTimePickerStartVacation";
            this.dateTimePickerStartVacation.Size = new System.Drawing.Size(127, 26);
            this.dateTimePickerStartVacation.TabIndex = 90;
            this.dateTimePickerStartVacation.ValueChanged += new System.EventHandler(this.dateTimePickerStartVacation_ValueChanged);
            // 
            // lblDataIniFerias
            // 
            this.lblDataIniFerias.AutoSize = true;
            this.lblDataIniFerias.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataIniFerias.Location = new System.Drawing.Point(6, 256);
            this.lblDataIniFerias.Name = "lblDataIniFerias";
            this.lblDataIniFerias.Size = new System.Drawing.Size(187, 19);
            this.lblDataIniFerias.TabIndex = 89;
            this.lblDataIniFerias.Text = "* Data de inicio das férias:";
            // 
            // txtCPFCNPJ
            // 
            this.txtCPFCNPJ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPFCNPJ.Location = new System.Drawing.Point(100, 209);
            this.txtCPFCNPJ.Name = "txtCPFCNPJ";
            this.txtCPFCNPJ.Size = new System.Drawing.Size(184, 26);
            this.txtCPFCNPJ.TabIndex = 85;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 84;
            this.label3.Text = "CPF/CNPJ:";
            // 
            // txtRGRNE
            // 
            this.txtRGRNE.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRGRNE.Location = new System.Drawing.Point(100, 165);
            this.txtRGRNE.Name = "txtRGRNE";
            this.txtRGRNE.Size = new System.Drawing.Size(184, 26);
            this.txtRGRNE.TabIndex = 83;
            // 
            // lblRGRNE
            // 
            this.lblRGRNE.AutoSize = true;
            this.lblRGRNE.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRGRNE.Location = new System.Drawing.Point(6, 167);
            this.lblRGRNE.Name = "lblRGRNE";
            this.lblRGRNE.Size = new System.Drawing.Size(67, 19);
            this.lblRGRNE.TabIndex = 82;
            this.lblRGRNE.Text = "RG/RNE:";
            // 
            // pictureBoxFoto
            // 
            this.pictureBoxFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxFoto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBoxFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFoto.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBoxFoto.Location = new System.Drawing.Point(645, 121);
            this.pictureBoxFoto.Name = "pictureBoxFoto";
            this.pictureBoxFoto.Size = new System.Drawing.Size(178, 168);
            this.pictureBoxFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFoto.TabIndex = 81;
            this.pictureBoxFoto.TabStop = false;
            this.pictureBoxFoto.WaitOnLoad = true;
            // 
            // lblFoto
            // 
            this.lblFoto.AllowDrop = true;
            this.lblFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFoto.AutoSize = true;
            this.lblFoto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoto.Location = new System.Drawing.Point(699, 99);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(71, 19);
            this.lblFoto.TabIndex = 80;
            this.lblFoto.Text = "Foto 3x4:";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(136, 119);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(465, 26);
            this.txtNome.TabIndex = 79;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(6, 121);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(124, 19);
            this.lblNome.TabIndex = 78;
            this.lblNome.Text = "Nome Completo:";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.Yellow;
            this.btnPesquisar.Location = new System.Drawing.Point(422, 65);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(119, 33);
            this.btnPesquisar.TabIndex = 77;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtConsultaCPFCNPJ
            // 
            this.txtConsultaCPFCNPJ.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsultaCPFCNPJ.Location = new System.Drawing.Point(100, 70);
            this.txtConsultaCPFCNPJ.Name = "txtConsultaCPFCNPJ";
            this.txtConsultaCPFCNPJ.Size = new System.Drawing.Size(293, 26);
            this.txtConsultaCPFCNPJ.TabIndex = 76;
            // 
            // lblCPFCNPJ
            // 
            this.lblCPFCNPJ.AutoSize = true;
            this.lblCPFCNPJ.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPFCNPJ.Location = new System.Drawing.Point(6, 72);
            this.lblCPFCNPJ.Name = "lblCPFCNPJ";
            this.lblCPFCNPJ.Size = new System.Drawing.Size(88, 19);
            this.lblCPFCNPJ.TabIndex = 75;
            this.lblCPFCNPJ.Text = "* CPF/CNPJ:";
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsulta.Location = new System.Drawing.Point(6, 39);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(468, 19);
            this.lblConsulta.TabIndex = 72;
            this.lblConsulta.Text = "Para atualizar os dados das férias é necessário informar o CPF ou CNPJ";
            // 
            // FormAtualizaCadFerias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 627);
            this.Controls.Add(this.gpbAtualizaFerias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAtualizaCadFerias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATUALIZACAO - CADASTRO FÉRIAS";
            this.Load += new System.EventHandler(this.FormAtualizaCadFerias_Load);
            this.gpbAtualizaFerias.ResumeLayout(false);
            this.gpbAtualizaFerias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbAtualizaFerias;
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtConsultaCPFCNPJ;
        private System.Windows.Forms.Label lblCPFCNPJ;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblFoto;
        private System.Windows.Forms.PictureBox pictureBoxFoto;
        private System.Windows.Forms.Label lblRGRNE;
        private System.Windows.Forms.TextBox txtRGRNE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCPFCNPJ;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinishVacation;
        private System.Windows.Forms.Label lblDtTermFerias;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartVacation;
        private System.Windows.Forms.Label lblDataIniFerias;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnVoltar2;
        private System.Windows.Forms.Button btnSalvar;
    }
}