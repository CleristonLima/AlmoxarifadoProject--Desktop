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
    public partial class FormCadastroUsuario : Form
    {
        public FormCadastroUsuario()
        {
            InitializeComponent();
            // Atualiza o texto da label com o nome do usuário logado
            lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;

            PreencherComboBoxStatus();
            PreencherComboBoxPerfil();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
           
        }

        // Método para preencher o ComboBox de status
        private void PreencherComboBoxStatus()
        {
            // Criar uma lista de itens de status
            List<StatusCadastroUsuario> statusList = new List<StatusCadastroUsuario>();
            statusList.Add(new StatusCadastroUsuario(0, "Desbloqueado"));
            statusList.Add(new StatusCadastroUsuario(1, "Bloqueado"));

            // Associar a lista ao ComboBox
            cbxStatus.DataSource = statusList;
            cbxStatus.DisplayMember = "Descricao"; // Define a propriedade para exibir o texto
            cbxStatus.ValueMember = "StatusID"; // Define a propriedade para obter o valor selecionado
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar se há um item selecionado
            if (cbxStatus.SelectedItem != null)
            {
                // Obter o item selecionado
                StatusCadastroUsuario selectedStatus = (StatusCadastroUsuario)cbxStatus.SelectedItem;

                // Obter o ID do status selecionado
                int selectedValue = selectedStatus.StatusID;

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

        private void FormCadastroUsuario_Load(object sender, EventArgs e)
        {

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

                // Verifica se ja existe login

                if(LoginExiste(login))
                {
                    MessageBox.Show("O login informado já existe. Por favor, escolha outro.", "LOGIN JA EXISTE!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO DB_ALMOXARIFADO..TB_AD_LOGIN (ID_LOGIN, NAME_PEOPLE, LOGIN_NAME, PASSWORD_LOGIN, EMAIL, BLOCK_USER, ID_PROFILE, USER_INSERT, DATE_INSERT) " +
                       "VALUES (NEXT VALUE FOR SEQ_AD_LOGIN, @Name, @Login, @Password, @Email, @StatusID, @PerfilID, @UsuarioLogado, @DataHoraCadastro)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@StatusID", statusID);
                    command.Parameters.AddWithValue("@PerfilID", perfilID);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Os dados foram salvos com sucesso!");

                LimparCampos();
            }
        }

        private bool LoginExiste(string login)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_AD_LOGIN WHERE LOGIN_NAME = @Login";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Login", login);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtSenha.Text = "";
            txtEmail.Text = "";
            cbxStatus.SelectedIndex = 0; // Define o ComboBox de status para o primeiro item
            cbxPerfil.SelectedIndex = 0; // Define o ComboBox de perfil para o primeiro item
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
                // Exibe o formulário de inicialização do sistema
                var admin = new SISACON.FormsAdmin.FormAdministrador();
                admin.Show();
                this.Hide();
            }
        }

    }
}
