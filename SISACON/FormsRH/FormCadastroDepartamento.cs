using SISACON.ConexaoBD;
using SISACON.RHClass;
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
    public partial class FormCadastroDepartamento : Form
    {
        public FormCadastroDepartamento()
        {
            InitializeComponent();

            PreencherComboBoxStatus();
        }

        private void PreencherComboBoxStatus()
        {
            // Criar uma lista de itens de status
            List<StatusCadastroDepartamento> statusList = new List<StatusCadastroDepartamento>();
            statusList.Add(new StatusCadastroDepartamento(0, "Inativo"));
            statusList.Add(new StatusCadastroDepartamento(1, "Ativo"));

            // Associar a lista ao ComboBox
            cbxStatus.DataSource = statusList;
            cbxStatus.DisplayMember = "Descricao"; // Define a propriedade para exibir o texto
            cbxStatus.ValueMember = "StatusID"; // Define a propriedade para obter o valor selecionado
        }

        private void cbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStatus.SelectedItem != null)
            {
                // Obter o item selecionado
                StatusCadastroDepartamento selectedStatus = (StatusCadastroDepartamento)cbxStatus.SelectedItem;

                // Obter o ID do status selecionado
                int selectedValue = selectedStatus.StatusID;

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
                if (string.IsNullOrWhiteSpace(txtDepartamento.Text) || string.IsNullOrWhiteSpace(txtSigla.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }
                string usuarioLogado = UsuarioLogado.Login;

                string nameDepartment = txtDepartamento.Text;
                string codeDepartment = txtSigla.Text;
                int statusDep = (int)cbxStatus.SelectedValue;

                DateTime dataHoraAtual = DateTime.Now;

                if (DepartamentoExiste(codeDepartment))
                {
                    MessageBox.Show("A sigla do departamento informado já existe.", "SIGLA JA EXISTE!");
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO DB_ALMOXARIFADO..TB_HR_DEPARTMENTS (ID_DEPARTMENT, NAME_DEPARTMENT, CODE_DEPARTMENT, STATUS_DEPARTMENTS, USER_INSERT, DATE_INSERT) " +
                                                                   "VALUES (NEXT VALUE FOR SEQ_HR_DEPARTMENTS, @NameDepartment, @CodeDepartment, @StatusDepartment, @UsuarioLogado, @DataHoraCadastro)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NameDepartment", nameDepartment);
                    command.Parameters.AddWithValue("@CodeDepartment", codeDepartment);
                    command.Parameters.AddWithValue("@StatusDepartment", statusDep);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram salvos com sucesso!");

                    LimparCampos();
                }
            }
        }

        private bool DepartamentoExiste(string codeDepartment)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_DEPARTMENTS WHERE CODE_DEPARTMENT = @CodeDepartment";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CodeDepartment", codeDepartment);

                int count = (int)command.ExecuteScalar();
                return count > 0;

            }

        }

        private void LimparCampos()
        {
            txtDepartamento.Text = "";
            txtSigla.Text = "";
            cbxStatus.SelectedIndex = 1;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
