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

namespace SISACON.FormsRH
{
    public partial class FormAtualizaCadastroFunc : Form
    {
        public FormAtualizaCadastroFunc()
        {
            InitializeComponent();
            ConfigurarDateTimePickers();
        }

        private void ConfigurarDateTimePickers()
        {
            dateTimePickerDataEmissaoCLT.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataEmissaoCLT.CustomFormat = " ";

            dateTimePickerDataVencimentoCNH.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataVencimentoCNH.CustomFormat = " ";

            dateTimePickerDataEmissaoCNH.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataEmissaoCNH.CustomFormat = " ";
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

                            if (count == 1)
                            {

                                string connectionString = ConexaoBancoDados.conn_;
                                using (SqlConnection conn_ = new SqlConnection(connectionString))
                                {
                                    conn_.Open();
                                    // Irá fazer a consulta na tabela TB_HR_EMPLOYEES
                                    string queryEmployees = "SELECT HE.NAME_EMPLO " +
                                                              " , HE.RG_RNE" +
                                                              " , HE.CPF_CNPJ " +
                                                              " , HE.BORN_DATE " +
                                                              " , HE.PHOTO " +
                                                              " , HE.ZIP_CODE " +
                                                              " , HE.ADDRESS_EMPLO " +
                                                              " , HE.NUMBER " +
                                                              " , HE.COMPLEMENT " +
                                                              " , HE.DISTRICT " +
                                                              " , HE.CITY " +
                                                              " , HE.UF_ID " +
                                                              " , HE.ID_SEX_EMPLO " +
                                                              " , HE.ID_EDUCATION " +
                                                              " , HE.ID_DEPARTMENT " +
                                                              " , HE.ID_OFFICE " +
                                                              " , HE.NAME_LEADER " +
                                                              " , HE.PHONE_NUMBER_1 " +
                                                              " , HE.PHONE_NUMBER_2 " +
                                                              " , HE.EMAIL " +
                                                              " , HEH.DATE_HIRING " +
                                                              " , HEH.NACIONALITY " +
                                                              " , HEH.BORN_CITY " +
                                                              " , HEH.UF_ID_BORN  " +
                                                              " , HEH.NAME_MOTHER " +
                                                              " , HEH.NAME_FATHER " +
                                                              " , HEH.ID_CIVIL_STATE " +
                                                              " , HEH.ID_TYPE_HIRING " +
                                                              " , HEH.SALARY " +
                                                              " , HEH.ID_TYPE_COUNT " +
                                                              " , HEH.ID_BANK " +
                                                              " , HEH.AGENCY  " +
                                                              " , HEH.COUNT_SALARY " +
                                                              " , HEH.CLT_NUMBER " +
                                                              " , HEH.SERIE " +
                                                              " , HEH.EMISSION_DATE_CLT " +
                                                              " , HEH.VOTER_REGISTRATION " +
                                                              " , HEH.ZONE_REGISTRATION " +
                                                              " , HEH.SESSION_REGISTRATION " +
                                                              " , HEH.NUMBER_RESERVIST " +
                                                              " , HEH.SERIE_RESERVIST " +
                                                              " , HEH.NUMBER_DRIVER_LICENSE " +
                                                              " , HEH.DATE_VALIDATE_DRIVER_LICENSE " +
                                                              " , HEH.TYPE_DRIVER " +
                                                              " , HEH.EMISSION_DATE_DRIVER_LICENSE " +
                                                              "  FROM TB_HR_EMPLOYEES HE " +
                                                              "    INNER JOIN TB_HR_EMPLOYEES_HIRING HEH " +
                                                              "   ON HEH.ID_EMPLO = HE.ID_EMPLO " +
                                                              "  WHERE CPF_CNPJ = @cpfCnpj";

                                    SqlCommand command = new SqlCommand(queryEmployees, conn_);
                                    command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                                    SqlDataReader reader = command.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        // Campos da tabela TB_HR_EMPLOYEES
                                        txtNome.Text = reader["NAME_EMPLO"].ToString();
                                        txtRGRNE.Text = reader["RG_RNE"].ToString();
                                        txtCPFCNPJ.Text = reader["CPF_CNPJ"].ToString();

                                        dateTimePickerDataNasc.Value = Convert.ToDateTime(reader["BORN_DATE"]);
                                        dateTimePickerDataNasc.Format = DateTimePickerFormat.Short;

                                        pictureBoxFoto.Text = reader["PHOTO"].ToString();
                                        txtCEP.Text = reader["ZIP_CODE"].ToString();
                                        txtEndereco.Text = reader["ADDRESS_EMPLO"].ToString();
                                        txtNumero.Text = reader["NUMBER"].ToString();
                                        txtComplemento.Text = reader["COMPLEMENT"].ToString();
                                        txtBairro.Text = reader["DISTRICT"].ToString();
                                        txtCidade.Text = reader["CITY"].ToString();

                                        cbxEstado.SelectedValue = reader["UF_ID"];
                                        cbxSexo.SelectedValue = reader["ID_SEX_EMPLO"];
                                        cbxEscolaridade.SelectedValue = reader["ID_EDUCATION"];
                                        cbxDepartamento.SelectedValue = reader["ID_DEPARTMENT"];
                                        cbxCargo.SelectedValue = reader["ID_OFFICE"];

                                        txtPhone1.Text = reader["PHONE_NUMBER_1"].ToString();
                                        txtPhone2.Text = reader["PHONE_NUMBER_2"].ToString();
                                        txtEmail.Text = reader["EMAIL"].ToString();

                                        //---------------------------------------------------------------//

                                        // Campos da tabela TB_HR_EMPLOYEES
                                        dateTimePickerHiring.Value = Convert.ToDateTime(reader["DATE_HIRING"]);
                                        dateTimePickerHiring.Format = DateTimePickerFormat.Short;

                                        txtNacionalidade.Text = reader["NACIONALITY"].ToString();
                                        txtBoxNaturalidade.Text = reader["BORN_CITY"].ToString();

                                        cbxEstadoNascimento.SelectedValue = reader["UF_ID_BORN"];

                                        txtBoxNomeMae.Text = reader["NAME_MOTHER"].ToString();
                                        txtBoxNomePai.Text = reader["NAME_FATHER"].ToString();

                                        cbxEstadoCivil.SelectedValue = reader["ID_CIVIL_STATE"];
                                        cbxTipoContratacao.SelectedValue = reader["ID_TYPE_HIRING"];

                                        txtSalario.Text = reader["SALARY"].ToString();

                                        cbxTipoConta.SelectedValue = reader["ID_TYPE_COUNT"];
                                        cbxBanco.SelectedValue = reader["ID_BANK"];

                                        txtAgencia.Text = reader["AGENCY"].ToString();
                                        txtConta.Text = reader["COUNT_SALARY"].ToString();
                                        txtCLT.Text = reader["CLT_NUMBER"].ToString();
                                        txtSerie.Text = reader["SERIE"].ToString();

                                        if (reader["EMISSION_DATE_CLT"] != DBNull.Value)
                                        {
                                            dateTimePickerDataEmissaoCLT.Value = Convert.ToDateTime(reader["EMISSION_DATE_CLT"]);
                                            dateTimePickerDataEmissaoCLT.CustomFormat = "dd/MM/yyyy";
                                        }
                                        else
                                        {
                                            dateTimePickerDataEmissaoCLT.CustomFormat = " ";
                                        }

                                        txtEleitor.Text = reader["VOTER_REGISTRATION"].ToString();
                                        txtZona.Text = reader["ZONE_REGISTRATION"].ToString();
                                        txtSecao.Text = reader["SESSION_REGISTRATION"].ToString();
                                        txtReservista.Text = reader["NUMBER_RESERVIST"].ToString();
                                        txtSerieReservista.Text = reader["SERIE_RESERVIST"].ToString();
                                        txtCNH.Text = reader["NUMBER_DRIVER_LICENSE"].ToString();

                                        if (reader["DATE_VALIDATE_DRIVER_LICENSE"] != DBNull.Value)
                                        {
                                            dateTimePickerDataVencimentoCNH.Value = Convert.ToDateTime(reader["DATE_VALIDATE_DRIVER_LICENSE"]);
                                            dateTimePickerDataVencimentoCNH.CustomFormat = "dd/MM/yyyy";
                                        }
                                        else
                                        {
                                            dateTimePickerDataVencimentoCNH.CustomFormat = " ";
                                        }

                                        txtCategoria.Text = reader["TYPE_DRIVER"].ToString();

                                        if (reader["EMISSION_DATE_DRIVER_LICENSE"] != DBNull.Value)
                                        {
                                            dateTimePickerDataEmissaoCNH.Value = Convert.ToDateTime(reader["EMISSION_DATE_DRIVER_LICENSE"]);
                                            dateTimePickerDataEmissaoCNH.CustomFormat = "dd/MM/yyyy";
                                        }
                                        else
                                        {
                                            dateTimePickerDataEmissaoCNH.CustomFormat = " ";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Não existe esse CPF ou CNPJ cadastrado!");
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro!!" + ex.Message);
                            transaction.Rollback();
                        }
                    }
                }
            }
        }
    }
}
