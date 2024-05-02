
namespace SISACON.FormsAdmin
{
    partial class FormAdministrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdministrador));
            this.linklblAdmin = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.btnConsultaUsuário = new System.Windows.Forms.Button();
            this.btnCadastroPerfil = new System.Windows.Forms.Button();
            this.btnCadastroUser = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // linklblAdmin
            // 
            this.linklblAdmin.AutoSize = true;
            this.linklblAdmin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblAdmin.Location = new System.Drawing.Point(112, 308);
            this.linklblAdmin.Name = "linklblAdmin";
            this.linklblAdmin.Size = new System.Drawing.Size(145, 19);
            this.linklblAdmin.TabIndex = 11;
            this.linklblAdmin.TabStop = true;
            this.linklblAdmin.Text = "Cadastro de usuário";
            this.linklblAdmin.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(489, 308);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(47, 19);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Perfis";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(710, 308);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(242, 19);
            this.linkLabel2.TabIndex = 13;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Consultar/Alterar dados de acesso";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // btnConsultaUsuário
            // 
            this.btnConsultaUsuário.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultaUsuário.Image")));
            this.btnConsultaUsuário.Location = new System.Drawing.Point(757, 131);
            this.btnConsultaUsuário.Name = "btnConsultaUsuário";
            this.btnConsultaUsuário.Size = new System.Drawing.Size(157, 156);
            this.btnConsultaUsuário.TabIndex = 2;
            this.btnConsultaUsuário.UseVisualStyleBackColor = true;
            this.btnConsultaUsuário.Click += new System.EventHandler(this.btnConsultaUsuário_Click);
            // 
            // btnCadastroPerfil
            // 
            this.btnCadastroPerfil.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastroPerfil.Image")));
            this.btnCadastroPerfil.Location = new System.Drawing.Point(429, 131);
            this.btnCadastroPerfil.Name = "btnCadastroPerfil";
            this.btnCadastroPerfil.Size = new System.Drawing.Size(176, 158);
            this.btnCadastroPerfil.TabIndex = 1;
            this.btnCadastroPerfil.UseVisualStyleBackColor = true;
            this.btnCadastroPerfil.Click += new System.EventHandler(this.btnCadastroPerfil_Click);
            // 
            // btnCadastroUser
            // 
            this.btnCadastroUser.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastroUser.Image")));
            this.btnCadastroUser.Location = new System.Drawing.Point(111, 131);
            this.btnCadastroUser.Margin = new System.Windows.Forms.Padding(10);
            this.btnCadastroUser.Name = "btnCadastroUser";
            this.btnCadastroUser.Size = new System.Drawing.Size(146, 158);
            this.btnCadastroUser.TabIndex = 0;
            this.btnCadastroUser.UseVisualStyleBackColor = true;
            this.btnCadastroUser.Click += new System.EventHandler(this.btnCadastroUser_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.Control;
            this.btnVoltar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Red;
            this.btnVoltar.Location = new System.Drawing.Point(111, 407);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnVoltar.Size = new System.Drawing.Size(92, 31);
            this.btnVoltar.TabIndex = 14;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 450);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linklblAdmin);
            this.Controls.Add(this.btnConsultaUsuário);
            this.Controls.Add(this.btnCadastroPerfil);
            this.Controls.Add(this.btnCadastroUser);
            this.Name = "FormAdministrador";
            this.Text = "ADMINISTRADOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAdministrador_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastroUser;
        private System.Windows.Forms.Button btnCadastroPerfil;
        private System.Windows.Forms.Button btnConsultaUsuário;
        private System.Windows.Forms.LinkLabel linklblAdmin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button btnVoltar;
    }
}