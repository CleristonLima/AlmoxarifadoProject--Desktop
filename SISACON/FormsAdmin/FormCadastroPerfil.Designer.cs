
namespace SISACON.FormsAdmin
{
    partial class FormCadastroPerfil
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
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.groupBoxPerfil = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtCodigoPerfil = new System.Windows.Forms.TextBox();
            this.txtNomePerfil = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPerfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLogado.Location = new System.Drawing.Point(570, 9);
            this.lblUsuarioLogado.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(0, 15);
            this.lblUsuarioLogado.TabIndex = 20;
            this.lblUsuarioLogado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxPerfil
            // 
            this.groupBoxPerfil.Controls.Add(this.lblTitle);
            this.groupBoxPerfil.Controls.Add(this.txtCodigoPerfil);
            this.groupBoxPerfil.Controls.Add(this.txtNomePerfil);
            this.groupBoxPerfil.Controls.Add(this.btnVoltar);
            this.groupBoxPerfil.Controls.Add(this.btnSalvar);
            this.groupBoxPerfil.Controls.Add(this.label2);
            this.groupBoxPerfil.Controls.Add(this.label1);
            this.groupBoxPerfil.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.groupBoxPerfil.Location = new System.Drawing.Point(12, 41);
            this.groupBoxPerfil.Name = "groupBoxPerfil";
            this.groupBoxPerfil.Size = new System.Drawing.Size(655, 286);
            this.groupBoxPerfil.TabIndex = 21;
            this.groupBoxPerfil.TabStop = false;
            this.groupBoxPerfil.Text = "Cadastro de Perfil";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 179);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 19);
            this.lblTitle.TabIndex = 19;
            this.lblTitle.Text = "* Campos obrigatórios";
            // 
            // txtCodigoPerfil
            // 
            this.txtCodigoPerfil.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPerfil.Location = new System.Drawing.Point(146, 117);
            this.txtCodigoPerfil.Name = "txtCodigoPerfil";
            this.txtCodigoPerfil.Size = new System.Drawing.Size(503, 26);
            this.txtCodigoPerfil.TabIndex = 18;
            // 
            // txtNomePerfil
            // 
            this.txtNomePerfil.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePerfil.Location = new System.Drawing.Point(146, 65);
            this.txtNomePerfil.Name = "txtNomePerfil";
            this.txtNomePerfil.Size = new System.Drawing.Size(503, 26);
            this.txtNomePerfil.TabIndex = 17;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar.Location = new System.Drawing.Point(387, 220);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(521, 220);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(107, 37);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "* Codigo do perfil:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Nome do perfil:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormCadastroPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 338);
            this.Controls.Add(this.groupBoxPerfil);
            this.Controls.Add(this.lblUsuarioLogado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCadastroPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE PERFIL";
            this.Load += new System.EventHandler(this.FormCadastroPerfil_Load);
            this.groupBoxPerfil.ResumeLayout(false);
            this.groupBoxPerfil.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.GroupBox groupBoxPerfil;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtCodigoPerfil;
        private System.Windows.Forms.TextBox txtNomePerfil;
        private System.Windows.Forms.Label lblTitle;
    }
}