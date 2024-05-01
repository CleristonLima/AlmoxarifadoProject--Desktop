using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISACON.ConexaoBD;

namespace SISACON.FormInitial
{
    public partial class FormInitial : Form
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public FormInitial()
        {
            InitializeComponent();

            // Atualiza o texto da label com o nome do usuário logado
            lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var admin = new SISACON.FormsAdmin.FormAdministrador();
                admin.Show();
                this.Hide();
            }
        }

        private void linklblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var admin = new SISACON.FormsAdmin.FormAdministrador();
                admin.Show();
                this.Hide();
            }

        }
    }
}
