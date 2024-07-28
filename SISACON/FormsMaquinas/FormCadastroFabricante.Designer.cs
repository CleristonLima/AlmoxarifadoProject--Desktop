
namespace SISACON.FormsMaquinas
{
    partial class FormCadastroFabricante
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
            this.grpBoxCadFab = new System.Windows.Forms.GroupBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar2 = new System.Windows.Forms.Button();
            this.txtCodFab = new System.Windows.Forms.TextBox();
            this.txtNomeFab = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.grpBoxCadFab.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxCadFab
            // 
            this.grpBoxCadFab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCadFab.Controls.Add(this.btnSalvar);
            this.grpBoxCadFab.Controls.Add(this.btnVoltar2);
            this.grpBoxCadFab.Controls.Add(this.txtCodFab);
            this.grpBoxCadFab.Controls.Add(this.txtNomeFab);
            this.grpBoxCadFab.Controls.Add(this.label7);
            this.grpBoxCadFab.Controls.Add(this.label1);
            this.grpBoxCadFab.Controls.Add(this.lblNome);
            this.grpBoxCadFab.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.grpBoxCadFab.Location = new System.Drawing.Point(13, 13);
            this.grpBoxCadFab.Name = "grpBoxCadFab";
            this.grpBoxCadFab.Size = new System.Drawing.Size(775, 266);
            this.grpBoxCadFab.TabIndex = 0;
            this.grpBoxCadFab.TabStop = false;
            this.grpBoxCadFab.Text = "Cadastro de Fabricantes";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(640, 211);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 37);
            this.btnSalvar.TabIndex = 108;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar2.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar2.Location = new System.Drawing.Point(512, 211);
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar2.TabIndex = 107;
            this.btnVoltar2.Text = "Voltar";
            this.btnVoltar2.UseVisualStyleBackColor = true;
            this.btnVoltar2.Click += new System.EventHandler(this.btnVoltar2_Click);
            // 
            // txtCodFab
            // 
            this.txtCodFab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodFab.Location = new System.Drawing.Point(180, 102);
            this.txtCodFab.MaxLength = 20;
            this.txtCodFab.Name = "txtCodFab";
            this.txtCodFab.Size = new System.Drawing.Size(175, 26);
            this.txtCodFab.TabIndex = 106;
            // 
            // txtNomeFab
            // 
            this.txtNomeFab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFab.Location = new System.Drawing.Point(180, 47);
            this.txtNomeFab.MaxLength = 100;
            this.txtNomeFab.Name = "txtNomeFab";
            this.txtNomeFab.Size = new System.Drawing.Size(589, 26);
            this.txtNomeFab.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 19);
            this.label7.TabIndex = 104;
            this.label7.Text = "* Campos obrigatórios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 88;
            this.label1.Text = "* Código do fabricante:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(6, 49);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(162, 19);
            this.lblNome.TabIndex = 87;
            this.lblNome.Text = "* Nome do fabricante:";
            // 
            // FormCadastroFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 291);
            this.Controls.Add(this.grpBoxCadFab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormCadastroFabricante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE FABRICANTES";
            this.grpBoxCadFab.ResumeLayout(false);
            this.grpBoxCadFab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxCadFab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodFab;
        private System.Windows.Forms.TextBox txtNomeFab;
        private System.Windows.Forms.Button btnVoltar2;
        private System.Windows.Forms.Button btnSalvar;
    }
}