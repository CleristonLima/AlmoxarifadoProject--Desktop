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
    public partial class FormAtualizaCadLicenca : Form
    {
        public FormAtualizaCadLicenca()
        {
            InitializeComponent();
        }

        private void FormAtualizaCadLicenca_Load(object sender, EventArgs e)
        {
            ConfigurarDateTimePicker(dateTimePickerStartLicense);
            ConfigurarDateTimePicker(dateTimePickerFinishLicense);
        }

        private void ConfigurarDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " "; // Espaço em branco para mostrar vazio
            dtp.ValueChanged += new EventHandler(dateTimePickerStartLicense_ValueChanged);
            dtp.ValueChanged += new EventHandler(dateTimePickerFinishLicense_ValueChanged);

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

                            else if (count == 1)
                            {
                                // Verifica se o funcionario esta demitido
                                string queryDemission = "SELECT COUNT(ED.ID_EMPLO) " +
                                                      "  FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES_DEMISSION ED " +
                                                      " INNER JOIN DB_ALMOXARIFADO..TB_HR_EMPLOYEES E " +
                                                      "    ON E.ID_EMPLO = ED.ID_EMPLO " +
                                                      "WHERE E.CPF_CNPJ = @cpfCnpj";

                                SqlCommand commandCheckDemission = new SqlCommand(queryDemission, conn, transaction);
                                commandCheckDemission.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                                int countDemission = (int)commandCheckDemission.ExecuteScalar();

                                if (countDemission > 0)
                                {
                                    MessageBox.Show("CPF ou CNPJ informado encontra-se demitido, não é possivel atualizar a licença!", "ATENÇÃO!");
                                    transaction.Rollback();
                                    return;
                                }
                                else
                                {
                                    string connectionString = ConexaoBancoDados.conn_;
                                    using (SqlConnection conn_ = new SqlConnection(connectionString))
                                    {
                                        conn_.Open();
                                        string queryEmployees = "SELECT HE.NAME_EMPLO " +
                                                              "     , HE.RG_RNE " +
                                                              "     , HE.CPF_CNPJ " +
                                                              "     , HE.PHOTO " +
                                                              "     , EL.DATE_START_LICENSE " +
                                                              "     , EL.DATE_FINISH_LICENSE " +
                                                              "     , EL.OBSERVATION " +
                                                              "FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES HE " +
                                                              "INNER JOIN DB_ALMOXARIFADO..TB_HR_EMPLOYEES_X_LICENSE EL " +
                                                              "   ON EL.ID_EMPLO = HE.ID_EMPLO" +
                                                              " WHERE HE.CPF_CNPJ = @cpfCnpj " +
                                                              "AND EL.DATE_FINISH_LICENSE = ( " +
                                                              "   SELECT MAX(EL2.DATE_FINISH_LICENSE) " +
                                                              "     FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES_X_LICENSE EL2) ";

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

                                            dateTimePickerStartLicense.Value = Convert.ToDateTime(reader["DATE_START_LICENSE"]);
                                            dateTimePickerStartLicense.Format = DateTimePickerFormat.Short;

                                            dateTimePickerFinishLicense.Value = Convert.ToDateTime(reader["DATE_FINISH_LICENSE"]);
                                            dateTimePickerFinishLicense.Format = DateTimePickerFormat.Short;

                                            txtObservacao.Text = reader["OBSERVATION"].ToString();
                                        }
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
                if (string.IsNullOrWhiteSpace(txtConsultaCPFCNPJ.Text) || dateTimePickerFinishLicense.Value == dateTimePickerFinishLicense.MinDate || dateTimePickerStartLicense.Value == dateTimePickerStartLicense.MinDate || string.IsNullOrWhiteSpace(txtObservacao.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;
                string cpfCnpj = txtCPFCNPJ.Text;
                int idEmploLic = 0;

                DateTime dateStartLicense = dateTimePickerStartLicense.Value.Date;
                DateTime dateFinishLicense = dateTimePickerFinishLicense.Value.Date;
                string observation = txtObservacao.Text;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    string queryIdEmploLic = "SELECT EL.ID_EMPLO_X_LIC " +
                                           "  FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES E " +
                                           "INNER JOIN DB_ALMOXARIFADO..TB_HR_EMPLOYEES_X_LICENSE EL " +
                                           "   ON EL.ID_EMPLO = E.ID_EMPLO " +
                                           "WHERE E.CPF_CNPJ = @cpfCnpj " +
                                           "AND EL.DATE_FINISH_LICENSE = ( " +
                                           "   SELECT MAX(EL2.DATE_FINISH_LICENSE) " +
                                           "     FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES_X_LICENSE EL2) ";

                    SqlCommand command = new SqlCommand(queryIdEmploLic, conn);
                    command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                    object idResult = command.ExecuteScalar();

                    if (idResult != null)
                    {
                        idEmploLic = (int)idResult;
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string queryUpdate = "UPDATE DB_ALMOXARIFADO..TB_HR_EMPLOYEES_X_LICENSE " +
                                            "  SET DATE_START_LICENSE = @dateStartLicense " +
                                            "    , DATE_FINISH_LICENSE = @dateFinishLicense " +
                                            "    , OBSERVATION = @observation " +
                                            "    , USER_UPDATE = @userUpdate " +
                                            "    , DATE_UPDATE = @dateUpdate " +
                                            "WHERE ID_EMPLO_X_LIC = @idEmploLic";

                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conn, transaction))
                        {
                            commandUpdate.Parameters.AddWithValue("@idEmploLic", idEmploLic);
                            commandUpdate.Parameters.AddWithValue("@dateStartLicense", dateStartLicense);
                            commandUpdate.Parameters.AddWithValue("@dateFinishLicense", dateFinishLicense);
                            commandUpdate.Parameters.AddWithValue("@observation", observation);
                            commandUpdate.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                            commandUpdate.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);

                            commandUpdate.ExecuteNonQuery();
                            transaction.Commit();
                            LimparCampos();

                            MessageBox.Show("Licença Atualizada com sucesso!", "Sucesso");
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

        private void LimparCampos()
        {
            txtConsultaCPFCNPJ.Text = "";
            txtNome.Text = "";
            txtRGRNE.Text = "";
            txtObservacao.Text = "";
            txtCPFCNPJ.Text = "";

            pictureBoxFoto.Image = null;

            dateTimePickerStartLicense.CustomFormat = " ";
            dateTimePickerStartLicense.Format = DateTimePickerFormat.Custom;

            dateTimePickerFinishLicense.CustomFormat = " ";
            dateTimePickerFinishLicense.Format = DateTimePickerFormat.Custom;
        }

        private void dateTimePickerStartLicense_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerStartLicense.Format = DateTimePickerFormat.Custom;
            dateTimePickerStartLicense.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePickerFinishLicense_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerFinishLicense.Format = DateTimePickerFormat.Custom;
            dateTimePickerFinishLicense.CustomFormat = "dd/MM/yyyy";
        }

    }
}
