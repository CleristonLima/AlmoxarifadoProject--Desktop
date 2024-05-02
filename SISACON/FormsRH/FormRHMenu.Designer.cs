
namespace SISACON.FormsRH
{
    partial class FormRHMenu
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
            this.groupBoxDepartamento = new System.Windows.Forms.GroupBox();
            this.linkLabelCadDepartamento = new System.Windows.Forms.LinkLabel();
            this.linkLabelAtualizaDadosDep = new System.Windows.Forms.LinkLabel();
            this.groupBoxFuncionarios = new System.Windows.Forms.GroupBox();
            this.groupBoxDepartamento.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDepartamento
            // 
            this.groupBoxDepartamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDepartamento.Controls.Add(this.linkLabelAtualizaDadosDep);
            this.groupBoxDepartamento.Controls.Add(this.linkLabelCadDepartamento);
            this.groupBoxDepartamento.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.groupBoxDepartamento.Location = new System.Drawing.Point(13, 13);
            this.groupBoxDepartamento.Name = "groupBoxDepartamento";
            this.groupBoxDepartamento.Size = new System.Drawing.Size(629, 83);
            this.groupBoxDepartamento.TabIndex = 0;
            this.groupBoxDepartamento.TabStop = false;
            this.groupBoxDepartamento.Text = "Empresa";
            // 
            // linkLabelCadDepartamento
            // 
            this.linkLabelCadDepartamento.AutoSize = true;
            this.linkLabelCadDepartamento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelCadDepartamento.Location = new System.Drawing.Point(18, 48);
            this.linkLabelCadDepartamento.Name = "linkLabelCadDepartamento";
            this.linkLabelCadDepartamento.Size = new System.Drawing.Size(200, 19);
            this.linkLabelCadDepartamento.TabIndex = 14;
            this.linkLabelCadDepartamento.TabStop = true;
            this.linkLabelCadDepartamento.Text = "Cadastro de Departamentos";
            this.linkLabelCadDepartamento.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabelAtualizaDadosDep
            // 
            this.linkLabelAtualizaDadosDep.AutoSize = true;
            this.linkLabelAtualizaDadosDep.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelAtualizaDadosDep.Location = new System.Drawing.Point(318, 48);
            this.linkLabelAtualizaDadosDep.Name = "linkLabelAtualizaDadosDep";
            this.linkLabelAtualizaDadosDep.Size = new System.Drawing.Size(239, 19);
            this.linkLabelAtualizaDadosDep.TabIndex = 15;
            this.linkLabelAtualizaDadosDep.TabStop = true;
            this.linkLabelAtualizaDadosDep.Text = "Atualizar dados de departamento";
            this.linkLabelAtualizaDadosDep.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoxFuncionarios
            // 
            this.groupBoxFuncionarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFuncionarios.Font = new System.Drawing.Font("Calibri", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.groupBoxFuncionarios.Location = new System.Drawing.Point(13, 137);
            this.groupBoxFuncionarios.Name = "groupBoxFuncionarios";
            this.groupBoxFuncionarios.Size = new System.Drawing.Size(629, 225);
            this.groupBoxFuncionarios.TabIndex = 1;
            this.groupBoxFuncionarios.TabStop = false;
            this.groupBoxFuncionarios.Text = "Quadro de funcionarios";
            // 
            // FormRHMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 374);
            this.Controls.Add(this.groupBoxFuncionarios);
            this.Controls.Add(this.groupBoxDepartamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormRHMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECURSO HUMANOS";
            this.groupBoxDepartamento.ResumeLayout(false);
            this.groupBoxDepartamento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDepartamento;
        private System.Windows.Forms.LinkLabel linkLabelAtualizaDadosDep;
        private System.Windows.Forms.LinkLabel linkLabelCadDepartamento;
        private System.Windows.Forms.GroupBox groupBoxFuncionarios;
    }
}