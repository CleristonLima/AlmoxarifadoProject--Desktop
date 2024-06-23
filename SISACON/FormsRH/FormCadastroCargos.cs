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
    public partial class FormCadastroCargos : Form
    {
        public FormCadastroCargos()
        {
            InitializeComponent();

            PreencherComboBoxStatus();
        }

        private void PreencherComboBoxStatus()
        {
            // Criar uma lista de itens de status
            List<StatusCadastroCargo> statusList = new List<StatusCadastroCargo>();
            statusList.Add(new StatusCadastroCargo(0, "Inativo"));
            statusList.Add(new StatusCadastroCargo(1, "Ativo"));

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
                StatusCadastroCargo selectedStatus = (StatusCadastroCargo)cbxStatus.SelectedItem;

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
                if (string.IsNullOrWhiteSpace(txtCargo.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }
                string usuarioLogado = UsuarioLogado.Login;
                string nameOffice = txtCargo.Text;
                int statusOffice = (int)cbxStatus.SelectedValue;
                bool positionOfTrust = chkCargoConfianca.Checked;

                DateTime dataHoraAtual = DateTime.Now;

                if (CargoExiste(nameOffice))
                {
                    MessageBox.Show("O cargo informado já existe.", "CARGO JA EXISTE!");
                    return;
                }
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO DB_ALMOXARIFADO..TB_HR_OFFICE (ID_OFFICE, NAME_OFFICE, STATUS_OFFICE, POSITION_OF_TRUST, USER_INSERT, DATE_INSERT) " +
                                                                   "VALUES (NEXT VALUE FOR SEQ_HR_OFFICE, @NameOffice, @StatusOffice, @PositionTrust, @UsuarioLogado, @DataHoraCadastro)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NameOffice", nameOffice);
                    command.Parameters.AddWithValue("@StatusOffice", statusOffice);
                    command.Parameters.AddWithValue("@PositionTrust", positionOfTrust);
                    command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                    command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram salvos com sucesso!");

                    LimparCampos();
                }
            }

        }


        private bool CargoExiste(string nameCargo)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_OFFICE WHERE NAME_OFFICE = @NameOffice";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NameOffice", nameCargo);

                int count = (int)command.ExecuteScalar();
                return count > 0;

            }
        }

        private void LimparCampos()
        {
            txtCargo.Text = "";
            cbxStatus.SelectedIndex = 1;
            chkCargoConfianca.Checked = false;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
