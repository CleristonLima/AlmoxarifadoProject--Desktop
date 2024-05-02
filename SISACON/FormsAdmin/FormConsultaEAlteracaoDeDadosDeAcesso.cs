using SISACON.AdminClass;
using SISACON.AdminClass.PerfilDao;
using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsAdmin
{
    public partial class FormConsultaEAlteracaoDeDadosDeAcesso : Form
    {
        private int loginIDAtual;
        private int perfilIDAtual;

        public FormConsultaEAlteracaoDeDadosDeAcesso()
        {
            InitializeComponent();
            //lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;

            PreencherComboBoxStatus();
            PreencherComboBoxPerfil();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string login = txtLoginPesquisa.Text.Trim();

            if (string.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Por favor, insira um login para pesquisar.", "Campo vazio");
                return;
            }

            string connectionString = ConexaoBancoDados.conn_;

            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ID_LOGIN, NAME_PEOPLE, LOGIN_NAME, PASSWORD_LOGIN, EMAIL, BLOCK_USER, ID_PROFILE  FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE LOGIN_NAME = @Login";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        loginIDAtual = Convert.ToInt32(reader["ID_LOGIN"]); // Armazenar o ID_LOGIN atual do usuário
                        txtNome.Text = reader["NAME_PEOPLE"].ToString();
                        txtLogin.Text = reader["LOGIN_NAME"].ToString();
                        txtSenha.Text = reader["PASSWORD_LOGIN"].ToString();
                        txtEmail.Text = reader["EMAIL"].ToString();

                        // Preencher o ComboBox de Status com base no valor retornado da consulta
                        int blockUser = Convert.ToInt32(reader["BLOCK_USER"]);
                        cbxStatus.SelectedValue = blockUser;

                        // Preencher o ComboBox de Perfil
                        PreencherComboBoxPerfil();
                        cbxPerfil.SelectedValue = reader["ID_PROFILE"];
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.", "Pesquisa de Usuário");
                    }

                    reader.Close();
                }
            }
        }

        private void PreencherComboBoxPerfil()
        {
            string connectionString = ConexaoBancoDados.conn_;
            PerfilDAO perfilDAO = new PerfilDAO(connectionString);
            List<Perfis> perfis = perfilDAO.ObterTodos();
            cbxPerfil.DataSource = perfis;
            cbxPerfil.DisplayMember = "NAME_PROFILE";
            cbxPerfil.ValueMember = "ID_PROFILE";
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedItem != null)
            {
                // Obter o item selecionado
                StatusCadastroUsuario selectedStatus = (StatusCadastroUsuario)cbxStatus.SelectedItem;

                // Obter o ID do status selecionado
                int selectedValue = selectedStatus.StatusID;

            }
        }

        private void FormConsultaEAlteracaoDeDadosDeAcesso_Load(object sender, EventArgs e)
        {
            PreencherComboBoxStatus();
        }

        private void PreencherComboBoxStatus()
        {
            // Criar uma lista de itens de status
            List<StatusCadastroUsuario> statusList = new List<StatusCadastroUsuario>();
            statusList.Add(new StatusCadastroUsuario(0, "Desbloqueado"));
            statusList.Add(new StatusCadastroUsuario(1, "Bloqueado"));

            // Associar a lista ao ComboBox
            cbxStatus.DataSource = statusList;
            cbxStatus.DisplayMember = "Descricao"; // Nome do campo a ser exibido
            cbxStatus.ValueMember = "StatusID"; // Nome do campo que contém o ID associado
        }

        private void cbxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPerfil.SelectedItem != null)
            {
                // Obter o perfil selecionado
                Perfis selectedPerfil = (Perfis)cbxPerfil.SelectedItem;

                // Obter o ID do perfil selecionado
                int selectedPerfilID = selectedPerfil.ID_PROFILE;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string connectionString = ConexaoBancoDados.conn_;

            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }

            else
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtLogin.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;

                string name = txtNome.Text;
                string login = txtLogin.Text;
                string password = txtSenha.Text;
                string email = txtEmail.Text;
                int statusID = (int)cbxStatus.SelectedValue;
                int perfilID = (int)cbxPerfil.SelectedValue;

                DateTime dataHoraAtual = DateTime.Now;

                bool updateRequired = true; // Flag para indicar se o update é necessário

                // Verificar se o perfil foi alterado
                if (name == GetNameAtual(loginIDAtual) &&
                    login == GetLoginAtual(loginIDAtual) &&
                    password == GetPasswordAtual(loginIDAtual) &&
                    email == GetEmailAtual(loginIDAtual) &&
                    statusID == GetStatusAtual(loginIDAtual) &&
                    perfilID == GetPerfilAtual(loginIDAtual))
                {
                    updateRequired = false; // Se nenhum campo foi alterado, não é necessário fazer o update
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE DB_ALMOXARIFADO..TB_AD_LOGIN " +
                                  "SET NAME_PEOPLE = @NamePeople," +
                                  "LOGIN_NAME = @Login," +
                                  "PASSWORD_LOGIN = @Password," +
                                  "EMAIL = @Email," +
                                  "BLOCK_USER = @StatusID," +
                                  "ID_PROFILE = @PerfilID," +
                                  "USER_UPDATE = @UsuarioLogado," +
                                  "DATE_UPDATE = @DataHoraCadastro " +
                                  "WHERE ID_LOGIN = @LoginIDAtual";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NamePeople", name);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@StatusID", statusID);
                    command.Parameters.AddWithValue("@PerfilID", perfilID);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.Parameters.AddWithValue("@LoginIDAtual", loginIDAtual); // Substitua perfilIDAtual pelo ID_PROFILE atual do usuário

                    // Executar o update apenas se necessário
                    if (updateRequired)
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Dados atualizados com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Nenhuma alteração realizada.", "Sem alterações");
                    }
                }
            }
        }

        private string GetNameAtual(int loginID)
        {
            string name = "";

            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT NAME_PEOPLE FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    name = result.ToString();
                }
            }

            return name;
        }

        private string GetLoginAtual(int loginID)
        {
            string login = "";

            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT LOGIN_NAME FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    login = result.ToString();
                }
            }

            return login;
        }

        private string GetPasswordAtual(int loginID)
        {
            string password = "";

            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT PASSWORD_LOGIN FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    password = result.ToString();
                }
            }

            return password;
        }

        private string GetEmailAtual(int loginID)
        {
            string email = "";

            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT EMAIL FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    email = result.ToString();
                }
            }

            return email;
        }

        private int GetStatusAtual(int loginID)
        {
            int statusID = -1;

            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT BLOCK_USER FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    statusID = Convert.ToInt32(result);
                }
            }

            return statusID;
        }

        private int GetPerfilAtual(int loginID)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ID_PROFILE FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE ID_LOGIN = @LoginID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LoginID", loginID);

                // Executar o comando SQL e obter o ID do perfil
                object result = command.ExecuteScalar();

                // Verificar se o resultado é nulo antes de converter para int
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Tratar o caso em que o ID de login não foi encontrado ou o perfil está vazio
                    // Por exemplo, lançar uma exceção ou retornar um valor padrão
                    throw new Exception("Perfil não encontrado para o ID de login fornecido.");
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                this.Close();
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtLoginPesquisa.Text = "";
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtEmail.Text = "";
            cbxStatus.SelectedIndex = 0; // Define o ComboBox de status para o primeiro item
            cbxPerfil.SelectedIndex = 0; // Define o ComboBox de perfil para o primeiro item
        }
    }
}
