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
    public partial class FormAtualizaCadastroPerfil : Form
    {
        public FormAtualizaCadastroPerfil()
        {
            InitializeComponent();
            //lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;

            PreencherComboBoxPerfil();
        }

        private void PreencherComboBoxPerfil()
        {
            string connectionString = ConexaoBancoDados.conn_;

            PerfilDAO perfilDAO = new PerfilDAO(connectionString);

            List<Perfis> perfis = perfilDAO.ObterTodos();

            comboBoxPerfil.DataSource = perfis;
            comboBoxPerfil.DisplayMember = "NAME_PROFILE";
            comboBoxPerfil.ValueMember = "ID_PROFILE";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPerfil.SelectedItem != null)
            {
                // Obter o perfil selecionado
                Perfis selectedPerfil = (Perfis)comboBoxPerfil.SelectedItem;

                // Preencher os TextBox com os valores do perfil selecionado
                txtNomePerfil.Text = selectedPerfil.NAME_PROFILE;
                txtCodigoPerfil.Text = selectedPerfil.CODE_PROFILE;
            }
        }

        private void txtNomePerfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoPerfil_TextChanged(object sender, EventArgs e)
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
                string usuarioLogado = UsuarioLogado.Login;

                string nameProfile = txtNomePerfil.Text;
                string codeProfile = txtCodigoPerfil.Text;

                DateTime dataHoraAtual = DateTime.Now;

                Perfis selectedPerfil = (Perfis)comboBoxPerfil.SelectedItem;
                int profileId = selectedPerfil.ID_PROFILE;

                if (PerfilExiste(codeProfile, profileId))
                {
                    MessageBox.Show("O código perfil informado já existe.", "PERFIL JA EXISTE!");
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE DB_ALMOXARIFADO..TB_AD_PROFILE " +
                           "SET NAME_PROFILE = @NameProfile, " +
                           "CODE_PROFILE = @CodeProfile, " +
                           "USER_UPDATE = @UsuarioLogado, " +
                           "DATE_UPDATE = @DataHoraCadastro " +
                           "WHERE ID_PROFILE = @ProfileId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NameProfile", nameProfile);
                    command.Parameters.AddWithValue("@CodeProfile", codeProfile);
                    command.Parameters.AddWithValue("@ProfileId", profileId);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram atualizados com sucesso!");
                }

            }
            
        }

        private bool PerfilExiste(string codeProfile, int profileId)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_AD_PROFILE WHERE CODE_PROFILE = @CodeProfile AND ID_PROFILE != @ProfileId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodeProfile", codeProfile);
                command.Parameters.AddWithValue("@ProfileId", profileId);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAtualizaCadastroPerfil_Load(object sender, EventArgs e)
        {

        }
    }
}
