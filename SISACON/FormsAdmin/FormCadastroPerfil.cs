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
    public partial class FormCadastroPerfil : Form
    {
        public FormCadastroPerfil()
        {
            InitializeComponent();
            //lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormCadastroPerfil_Load(object sender, EventArgs e)
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
                if (string.IsNullOrWhiteSpace(txtNomePerfil.Text) || string.IsNullOrWhiteSpace(txtCodigoPerfil.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }
                string usuarioLogado = UsuarioLogado.Login;

                string nameProfile = txtNomePerfil.Text;
                string codeProfile = txtCodigoPerfil.Text;

                DateTime dataHoraAtual = DateTime.Now;

                if (PerfilExiste(codeProfile))
                {
                    MessageBox.Show("O código perfil informado já existe.", "PERFIL JA EXISTE!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO DB_ALMOXARIFADO..TB_AD_PROFILE (ID_PROFILE, NAME_PROFILE, CODE_PROFILE, USER_INSERT, DATE_INSERT) " +
                                                                   "VALUES (NEXT VALUE FOR SEQ_AD_PROFILE, @NameProfile, @CodeProfile, @UsuarioLogado, @DataHoraCadastro)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NameProfile", nameProfile);
                    command.Parameters.AddWithValue("@CodeProfile", codeProfile);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram salvos com sucesso!");

                    LimparCampos();
                }
            }
        }

        private bool PerfilExiste(string codeProfile)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_AD_PROFILE WHERE CODE_PROFILE = @CodeProfile";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodeProfile", codeProfile);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void LimparCampos()
        {
            txtNomePerfil.Text = "";
            txtCodigoPerfil.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
