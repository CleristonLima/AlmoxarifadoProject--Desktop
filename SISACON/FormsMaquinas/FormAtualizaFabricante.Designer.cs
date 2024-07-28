
namespace SISACON.FormsMaquinas
{
    partial class FormAtualizaFabricante
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
            this.grpBoxFabricante = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFabricante = new System.Windows.Forms.ComboBox();
            this.grpBoxCadFabricante = new System.Windows.Forms.GroupBox();
            this.lblCargo = new System.Windows.Forms.Label();
            this.txtNomeFab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodFab = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grpBoxFabricante.SuspendLayout();
            this.grpBoxCadFabricante.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxFabricante
            // 
            this.grpBoxFabricante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFabricante.Controls.Add(this.cbxFabricante);
            this.grpBoxFabricante.Controls.Add(this.label1);
            this.grpBoxFabricante.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.grpBoxFabricante.Location = new System.Drawing.Point(13, 13);
            this.grpBoxFabricante.Name = "grpBoxFabricante";
            this.grpBoxFabricante.Size = new System.Drawing.Size(577, 107);
            this.grpBoxFabricante.TabIndex = 0;
            this.grpBoxFabricante.TabStop = false;
            this.grpBoxFabricante.Text = "Selecione o fabricante";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fabricante:";
            // 
            // cbxFabricante
            // 
            this.cbxFabricante.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFabricante.FormattingEnabled = true;
            this.cbxFabricante.Location = new System.Drawing.Point(106, 49);
            this.cbxFabricante.Name = "cbxFabricante";
            this.cbxFabricante.Size = new System.Drawing.Size(286, 26);
            this.cbxFabricante.TabIndex = 2;
            this.cbxFabricante.SelectedIndexChanged += new System.EventHandler(this.cbxFabricante_SelectedIndexChanged);
            // 
            // grpBoxCadFabricante
            // 
            this.grpBoxCadFabricante.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCadFabricante.Controls.Add(this.btnSalvar);
            this.grpBoxCadFabricante.Controls.Add(this.btnVoltar);
            this.grpBoxCadFabricante.Controls.Add(this.lblTitle);
            this.grpBoxCadFabricante.Controls.Add(this.txtCodFab);
            this.grpBoxCadFabricante.Controls.Add(this.label2);
            this.grpBoxCadFabricante.Controls.Add(this.txtNomeFab);
            this.grpBoxCadFabricante.Controls.Add(this.lblCargo);
            this.grpBoxCadFabricante.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.grpBoxCadFabricante.Location = new System.Drawing.Point(13, 140);
            this.grpBoxCadFabricante.Name = "grpBoxCadFabricante";
            this.grpBoxCadFabricante.Size = new System.Drawing.Size(577, 254);
            this.grpBoxCadFabricante.TabIndex = 1;
            this.grpBoxCadFabricante.TabStop = false;
            this.grpBoxCadFabricante.Text = "Cadastro do fabricante";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(15, 66);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(162, 19);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "* Nome do fabricante:";
            // 
            // txtNomeFab
            // 
            this.txtNomeFab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFab.Location = new System.Drawing.Point(183, 64);
            this.txtNomeFab.Name = "txtNomeFab";
            this.txtNomeFab.Size = new System.Drawing.Size(373, 26);
            this.txtNomeFab.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "* Código do fabricante:";
            // 
            // txtCodFab
            // 
            this.txtCodFab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodFab.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodFab.Location = new System.Drawing.Point(183, 119);
            this.txtCodFab.Name = "txtCodFab";
            this.txtCodFab.Size = new System.Drawing.Size(373, 26);
            this.txtCodFab.TabIndex = 24;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 173);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 19);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "* Campos obrigatórios";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnVoltar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar.Location = new System.Drawing.Point(320, 200);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(107, 37);
            this.btnVoltar.TabIndex = 26;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalvar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.Green;
            this.btnSalvar.Location = new System.Drawing.Point(449, 200);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(107, 37);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // FormAtualizaFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 406);
            this.Controls.Add(this.grpBoxCadFabricante);
            this.Controls.Add(this.grpBoxFabricante);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAtualizaFabricante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATUALIZAR - CADASTRO DE FABRICANTES";
            this.grpBoxFabricante.ResumeLayout(false);
            this.grpBoxFabricante.PerformLayout();
            this.grpBoxCadFabricante.ResumeLayout(false);
            this.grpBoxCadFabricante.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxFabricante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFabricante;
        private System.Windows.Forms.GroupBox grpBoxCadFabricante;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.TextBox txtCodFab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeFab;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnSalvar;
    }
}