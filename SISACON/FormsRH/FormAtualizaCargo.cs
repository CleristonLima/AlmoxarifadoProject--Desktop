using SISACON.ConexaoBD;
using SISACON.RHClass;
using SISACON.RHClass.CargoDAO;
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
    public partial class FormAtualizaCargo : Form
    {
        public FormAtualizaCargo()
        {
            InitializeComponent();

            PreencherComboBoxPesquisaCargo();
        }

        private void PreencherComboBoxPesquisaCargo()
        {
            string connectionString = ConexaoBancoDados.conn_;
            CargoDAO cargoDAO = new CargoDAO(connectionString);
            List<Cargo> carg = cargoDAO.ObterCargo();

            cbxCargo.DataSource = carg;

            cbxCargo.DisplayMember = "NAME_OFFICE";
            cbxCargo.ValueMember = "ID_OFFICE";

            cbxStatus.Items.Add("Ativo");
            cbxStatus.Items.Add("Inativo");
        }

        private void FormAtualizaCargo_Load(object sender, EventArgs e)
        {
            AtualizarInformacoesCargoSelecionado();
        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarInformacoesCargoSelecionado();
        }

        private void AtualizarInformacoesCargoSelecionado()
        {
            if (cbxCargo.SelectedItem != null)
            {
                // Obter o departamento selecionado
                Cargo selectedCargo = (Cargo)cbxCargo.SelectedItem;

                // Preencher os TextBox com os valores do perfil selecionado
                txtCargo.Text = selectedCargo.NAME_OFFICE;

                if (selectedCargo.STATUS_OFFICE == 0)
                {
                    cbxStatus.SelectedItem = "Inativo";
                }
                else
                {
                    cbxStatus.SelectedItem = "Ativo";
                }

                if (selectedCargo.POSITION_OF_TRUST == 0)
                {
                    chkCargoConfianca.Checked = false;
                }
                else
                {
                    chkCargoConfianca.Checked = true;
                }
 
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string connectionString = ConexaoBancoDados.conn_;

            string usuarioLogado = UsuarioLogado.Login;

            string nameOffice = txtCargo.Text;
            int statusOffice;
            bool positionTrust = chkCargoConfianca.Checked;

            if (cbxStatus.Text == "Ativo")
            {
                statusOffice = 1;
            }
            else
            {
                statusOffice = 0;
            }

            DateTime dataHoraAtual = DateTime.Now;

            int officeId = (int)cbxCargo.SelectedValue;

            if (CargoExiste(nameOffice, officeId))
            {
                MessageBox.Show("O cargo informado já existe", "CARGO JÁ EXISTE!");
                return;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE DB_ALMOXARIFADO..TB_HR_OFFICE " +
                       "SET NAME_OFFICE = @NameOffice, " +
                       "STATUS_OFFICE = @StatusOffice, " +
                       "POSITION_OF_TRUST = @PositionTrust, " +
                       "USER_UPDATE = @UsuarioLogado, " +
                       "DATE_UPDATE = @DataHoraCadastro " +
                       "WHERE ID_OFFICE = @OfficeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NameOffice", nameOffice);
                command.Parameters.AddWithValue("@StatusOffice", statusOffice);
                command.Parameters.AddWithValue("@PositionTrust", positionTrust);
                command.Parameters.AddWithValue("@OfficeId", officeId);
                command.Parameters.AddWithValue("@UsuarioLogado", usuarioLogado);
                command.Parameters.AddWithValue("@DataHoraCadastro", dataHoraAtual);
                command.ExecuteNonQuery();

                MessageBox.Show("Os dados foram atualizados com sucesso!");
            }
        }

        private bool CargoExiste(string nameOffice, int officeId)
        {
            string connectionString = ConexaoBancoDados.conn_;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_OFFICE WHERE NAME_OFFICE = @NameOffice AND ID_OFFICE != @OfficeId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NameOffice", nameOffice);
                command.Parameters.AddWithValue("@OfficeId", officeId);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
