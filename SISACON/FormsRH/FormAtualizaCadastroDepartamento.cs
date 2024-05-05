using SISACON.ConexaoBD;
using SISACON.RHClass;
using SISACON.RHClass.DepartamentoDAO;
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

namespace SISACON.FormsRH
{
    public partial class FormAtualizaCadastroDepartamento : Form
    {
        public FormAtualizaCadastroDepartamento()
        {
            InitializeComponent();

            PreencherComboBoxPesquisaDepartamento(); 
            AtualizarInformacoesDepartamentoSelecionado();
        }

        private void PreencherComboBoxPesquisaDepartamento()
        {
            string connectionString = ConexaoBancoDados.conn_;
            DepartamentoDAO depDAO = new DepartamentoDAO(connectionString);
            List<Departamento> dep = depDAO.ObterDepartamento();

            // Percorre cada departamento e concatena o nome com o código dentro de parênteses
            foreach (var departamento in dep)
            {
                departamento.NomeCompletoDepto = $"{departamento.NAME_DEPARTMENT} ({departamento.CODE_DEPARTMENT})";
            }

            // Define a fonte de dados do ComboBox
            cbxDepartamento.DataSource = dep;
            // Define a propriedade DisplayMember para mostrar o nome completo
            cbxDepartamento.DisplayMember = "NomeCompletoDepto";
            cbxDepartamento.ValueMember = "ID_DEPARTMENT";

            cbxStatus.Items.Add("Ativo");
            cbxStatus.Items.Add("Inativo");
        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarInformacoesDepartamentoSelecionado();
        }

        private void FormAtualizaCadastroDepartamento_Load(object sender, EventArgs e)
        {
            AtualizarInformacoesDepartamentoSelecionado();
        }

        private void AtualizarInformacoesDepartamentoSelecionado()
        {
            if (cbxDepartamento.SelectedItem != null)
            {
                // Obter o departamento selecionado
                Departamento selectedDep = (Departamento)cbxDepartamento.SelectedItem;

                // Preencher os TextBox com os valores do perfil selecionado
                txtDepartamento.Text = selectedDep.NAME_DEPARTMENT;
                txtSigla.Text = selectedDep.CODE_DEPARTMENT;

                if (selectedDep.STATUS_DEPARTMENT == 0)
                {
                    cbxStatus.SelectedItem = "Inativo";
                }
                else
                {
                    cbxStatus.SelectedItem = "Ativo";
                }
            }
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
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

                string nameDepartment = txtDepartamento.Text;
                string codeDepartment = txtSigla.Text;
                int statusDepartment; // Obter o valor selecionado do ComboBox de status

                if (cbxStatus.Text == "Ativo")
                {
                    statusDepartment = 1;
                }
                else
                {
                    statusDepartment = 0;
                }

                DateTime dataHoraAtual = DateTime.Now;

                int departmentoId = (int)cbxDepartamento.SelectedValue; // Obter o ID do departamento selecionado

                if (SiglaExiste(codeDepartment, departmentoId))
                {
                    MessageBox.Show("A sigla do departamento informado já existe, por favor informe outra", "SIGLA JÁ EXISTE!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE DB_ALMOXARIFADO..TB_HR_DEPARTMENTS " +
                           "SET NAME_DEPARTMENT = @NameDepartment, " +
                           "CODE_DEPARTMENT = @CodeDepartment, " +
                           "STATUS_DEPARTMENT = @StatusDepartment, " +
                           "USER_UPDATE = @UsuarioLogado, " +
                           "DATE_UPDATE = @DataHoraCadastro " +
                           "WHERE ID_DEPARTMENT = @DepartmentId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NameDepartment", nameDepartment);
                    command.Parameters.AddWithValue("@CodeDepartment", codeDepartment);
                    command.Parameters.AddWithValue("@StatusDepartment", statusDepartment); // Correção: Usar @StatusDepartment
                    command.Parameters.AddWithValue("@DepartmentId", departmentoId);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram atualizados com sucesso!");
                }
            }
        }

            private bool SiglaExiste(string codeDepartment, int departmentoId)
            {
                string connectionString = ConexaoBancoDados.conn_;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_DEPARTMENTS WHERE CODE_DEPARTMENT = @CodeDepartment AND ID_DEPARTMENT != @DepartmentId"; // Correção: Excluir o departamento atual da contagem
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CodeDepartment", codeDepartment);
                    command.Parameters.AddWithValue("@DepartmentId", departmentoId);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
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
    }
}
