using System;
using System.Windows.Forms;
using SISACON.ConexaoBD;
using SISACON.ConexaoInternet;
using System.Data.SqlClient;


namespace SISACON
{
    public partial class FormLogin : Form
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;
        private int numeroTentativas = 0;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            // Obtém as credenciais do usuário do formulário
            string login = txtBoxLogin.Text;
            string senha = txtBoxSenha.Text;

            // Realiza a consulta no banco de dados para verificar as credenciais
            bool credenciaisValidas = VerificarCredenciais(login, senha);

            if (credenciaisValidas)
            {
                // Armazena o nome de usuário na classe UsuarioLogado após o login bem-sucedido
                UsuarioLogado.Login = login;

                // Exibe o formulário de inicialização do sistema
                var initial = new SISACON.FormInitial.FormInicial();
                initial.Show();
                this.Hide();
            } 
            else
            {
                numeroTentativas++;

                if (numeroTentativas >= 5)
                {
                    bool usuarioBloqueado = VerificarUsuarioBloqueado(login);

                    if (!usuarioBloqueado)
                    {
                        BloquearUsuario(login);
                        MessageBox.Show("Número máximo de tentativas de acesso foi excedido! Seu usuário foi bloqueado! Favor entrar em contato com o suporte!", "USUÁRIO BLOQUEADO!");
                    }
                    else
                    {
                        MessageBox.Show("Seu usuário consta como bloqueado. Favor entrar em contato com o suporte!", "USUÁRIO BLOQUEADO!");
                    }
                }
                else
                {
                    MessageBox.Show("Nome de usuário ou senha inválidos!");
                }
            }
        }

        private bool VerificarCredenciais(string login, string senha)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE LOGIN_NAME = @Login AND PASSWORD_LOGIN = @Senha";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Senha", senha);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool VerificarUsuarioBloqueado(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BLOCK_USER FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE LOGIN_NAME = @Login";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return (bool)result;
                    }
                }
            }
            return false;
        }

        private void BloquearUsuario(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE DB_ALMOXARIFADO..TB_AD_LOGIN SET BLOCK_USER = 1 WHERE LOGIN_NAME = @Login";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public static class UsuarioLogado
    {
        public static string Login { get; set; }
    }
}