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
    public partial class FormLicencaFunc : Form
    {
        public FormLicencaFunc()
        {
            InitializeComponent();
        }

        private void FormLicencaFunc_Load(object sender, EventArgs e)
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

                                if(countDemission > 0)
                                {
                                    MessageBox.Show("CPF ou CNPJ informado encontra-se demitido, não é possivel cadastrar a licença!", "ATENÇÃO!");
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
                                                              "FROM TB_HR_EMPLOYEES HE " +
                                                              " WHERE HE.CPF_CNPJ = @cpfCnpj";

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
                int idEmplo = 0;

                DateTime dateStartLicense = dateTimePickerStartLicense.Value.Date;
                DateTime dateFinishLicense = dateTimePickerFinishLicense.Value.Date;
                string observation = txtObservacao.Text;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();

                    string queryIdEmplo = "SELECT HE.ID_EMPLO " +
                                        " FROM TB_HR_EMPLOYEES HE " +
                                        " WHERE HE.CPF_CNPJ = @cpfCnpj";

                    SqlCommand command = new SqlCommand(queryIdEmplo, conn);
                    command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                    object idResult = command.ExecuteScalar();

                    if (idResult != null)
                    {
                        idEmplo = (int)idResult;
                    }

                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string queryInsert = "INSERT INTO TB_HR_EMPLOYEES_X_LICENSE (ID_EMPLO_X_LIC, ID_EMPLO, DATE_START_LICENSE, DATE_FINISH_LICENSE, OBSERVATION, USER_INSERT, DATE_INSERT)" +
                                                                       "VALUES  (NEXT VALUE FOR SEQ_HR_EMPLOYEES_X_LICENSE, @idEmplo, @dateStartLicense, @dateFinishLicense, @observation, @userInsert, @dateInsert)";

                        using (SqlCommand commandInsert = new SqlCommand(queryInsert, conn, transaction))
                        {
                            commandInsert.Parameters.AddWithValue("@idEmplo", idEmplo);
                            commandInsert.Parameters.AddWithValue("@dateStartLicense", dateStartLicense);
                            commandInsert.Parameters.AddWithValue("@dateFinishLicense", dateFinishLicense);
                            commandInsert.Parameters.AddWithValue("@observation", observation);
                            commandInsert.Parameters.AddWithValue("@userInsert", usuarioLogado);
                            commandInsert.Parameters.AddWithValue("@dateInsert", dataHoraAtual);

                            commandInsert.ExecuteNonQuery();
                            transaction.Commit();
                            LimparCampos();

                            MessageBox.Show("Licença cadastrada com sucesso!", "Sucesso");
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

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
