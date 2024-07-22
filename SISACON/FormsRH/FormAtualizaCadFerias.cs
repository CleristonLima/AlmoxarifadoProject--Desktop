using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsRH
{
    public partial class FormAtualizaCadFerias : Form
    {
        public FormAtualizaCadFerias()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtConsultaCPFCNPJ.Text))
                {
                    MessageBox.Show("Por favor informe o CPF ou CNPJ para atualizar os dados", "ATENÇÃO!!");
                }
                else
                {
                    string cpfCnpj = txtConsultaCPFCNPJ.Text;

                    string connection = ConexaoBancoDados.conn_;
                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // Verificar se o CPF já existe na tabela
                            string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";
                            SqlCommand commandCheckCpf = new SqlCommand(query, conn, transaction);
                            commandCheckCpf.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                            int count = (int)commandCheckCpf.ExecuteScalar();

                            if (count == 0)
                            {
                                MessageBox.Show("CPF ou CNPJ não encontrado!", "Erro");
                                transaction.Rollback();
                                return;
                            }

                            if (count == 1)
                            {

                                string connectionString = ConexaoBancoDados.conn_;
                                using (SqlConnection conn_ = new SqlConnection(connectionString))
                                {
                                    conn_.Open();

                                    string queryEmployees = "SELECT HE.NAME_EMPLO " +
                                                           "    , HE.RG_RNE " +
                                                           "    , HE.CPF_CNPJ " +
                                                           "    , HE.PHOTO " +
                                                           "    , EV.OBSERVATION " +
                                                           "    , EV.DATE_START_VACATION " +
                                                           "    , EV.DATE_FINISH_VACATION " +
                                                           "FROM TB_HR_EMPLOYEES HE " +
                                                           "INNER JOIN TB_HR_EMPLOYEES_X_VACATION EV " +
                                                           "    ON EV.ID_EMPLO = HE.ID_EMPLO " +
                                                           "WHERE HE.CPF_CNPJ = @cpfCnpj " +
                                                           "AND EV.DATE_FINISH_VACATION = ( " +
                                                           "    SELECT MAX(EV2.DATE_FINISH_VACATION) " +
                                                           "    FROM TB_HR_EMPLOYEES_X_VACATION EV2)";

                                    SqlCommand command = new SqlCommand(queryEmployees, conn_);
                                    command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                                    SqlDataReader reader = command.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        txtNome.Text = reader["NAME_EMPLO"].ToString();
                                        txtRGRNE.Text = reader["RG_RNE"].ToString();
                                        txtCPFCNPJ.Text = reader["CPF_CNPJ"].ToString();

                                        if (reader["PHOTO"] != DBNull.Value)
                                        {
                                            byte[] photoData = (byte[])reader["PHOTO"];
                                            using (MemoryStream ms = new MemoryStream(photoData))
                                            {
                                                pictureBoxFoto.Image = Image.FromStream(ms);
                                            }
                                        }
                                        else
                                        {
                                            pictureBoxFoto.Image = null;
                                        }

                                        dateTimePickerStartVacation.Value = Convert.ToDateTime(reader["DATE_START_VACATION"]);
                                        dateTimePickerStartVacation.Format = DateTimePickerFormat.Short;

                                        dateTimePickerFinishVacation.Value = Convert.ToDateTime(reader["DATE_FINISH_VACATION"]);
                                        dateTimePickerFinishVacation.Format = DateTimePickerFormat.Short;

                                        txtObservacao.Text = reader["OBSERVATION"].ToString();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Funcionário não encontrado!", "Erro");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao procurar dados: {ex.Message}", "Erro");
                        }
                    }
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtConsultaCPFCNPJ.Text) || dateTimePickerFinishVacation.Value == dateTimePickerFinishVacation.MinDate || dateTimePickerStartVacation.Value == dateTimePickerStartVacation.MinDate || string.IsNullOrWhiteSpace(txtObservacao.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;
                string cpfCnpj = txtCPFCNPJ.Text;
                int idEmploVac = 0;

                DateTime dateStartVacation = dateTimePickerStartVacation.Value.Date;
                DateTime dateFinishVacation = dateTimePickerFinishVacation.Value.Date;
                string observation = txtObservacao.Text;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    string queryIdEmploXVac = "SELECT EV.ID_EMPLO_X_VAC " +
                                            " FROM TB_HR_EMPLOYEES HE " +
                                            "INNER JOIN TB_HR_EMPLOYEES_X_VACATION EV " +
                                            "   ON EV.ID_EMPLO = HE.ID_EMPLO " +
                                            "WHERE HE.CPF_CNPJ = @cpfCnpj " +
                                            "AND EV.DATE_FINISH_VACATION = ( " +
                                            "    SELECT MAX(EV2.DATE_FINISH_VACATION) " +
                                            "    FROM TB_HR_EMPLOYEES_X_VACATION EV2)" ;

                    SqlCommand command = new SqlCommand(queryIdEmploXVac, conn);
                    command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                    object idResult = command.ExecuteScalar();

                    if (idResult != null)
                    {
                        idEmploVac = (int)idResult;
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string queryUpdate = "UPDATE TB_HR_EMPLOYEES_X_VACATION " +
                                           "   SET DATE_START_VACATION = @dateStartVacation " +
                                           "     , DATE_FINISH_VACATION = @dateFinishVacation " +
                                           "     , OBSERVATION = @observation " +
                                           "     , USER_UPDATE = @userUpdate " +
                                           "     , DATE_UPDATE = @dateUpdate " +
                                           "WHERE ID_EMPLO_X_VAC = @idEmploVac ";

                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conn, transaction))
                        {
                            commandUpdate.Parameters.AddWithValue("@idEmploVac", idEmploVac);
                            commandUpdate.Parameters.AddWithValue("@dateStartVacation", dateStartVacation);
                            commandUpdate.Parameters.AddWithValue("@dateFinishVacation", dateFinishVacation);
                            commandUpdate.Parameters.AddWithValue("@observation", observation);
                            commandUpdate.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                            commandUpdate.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);

                            commandUpdate.ExecuteNonQuery();
                            transaction.Commit();
                            //LimparCampos();

                            MessageBox.Show("Férias Atualizadas com sucesso!", "Sucesso");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao cadastrar dados: {ex.Message}", "Erro");
                    }
                }
            }
        }

        private void dateTimePickerStartVacation_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerStartVacation.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartVacation.CustomFormat = "dd/MM/yyyy";

        }

        private void dateTimePickerFinishVacation_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFinishVacation.Format = DateTimePickerFormat.Custom;
            dateTimePickerFinishVacation.CustomFormat = "dd/MM/yyyy";
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
