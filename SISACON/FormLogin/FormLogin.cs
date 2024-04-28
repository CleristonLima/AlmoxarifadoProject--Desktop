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

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
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
                var initial = new SISACON.FormInitial.FormInitial();
                initial.Show();
                this.Hide();
            }
            else
            {
                // Exibe uma mensagem de erro se as credenciais não forem válidas
                MessageBox.Show("Nome de usuário ou senha inválidos.");
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
    }

    public static class UsuarioLogado
    {
        public static string Login { get; set; }
    }
}