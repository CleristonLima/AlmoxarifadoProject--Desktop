using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsAdmin
{
    public partial class FormAdministrador : Form
 
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public FormAdministrador()
        {
            InitializeComponent();
            // Atualiza o texto da label com o nome do usuário logado
            lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;
        }

        private void btnCadastroUser_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroUsuario = new SISACON.FormsAdmin.FormCadastroUsuario();
                cadastroUsuario.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var voltar = new SISACON.FormInitial.FormInitial();
                voltar.Show();
                this.Hide();
            }
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void btnCadastroPerfil_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadPerfil = new SISACON.FormsAdmin.FormOpcõesDeCadastroPerfil();
                cadPerfil.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadPerfil = new SISACON.FormsAdmin.FormOpcõesDeCadastroPerfil();
                cadPerfil.Show();
            }
        }
    }
}
