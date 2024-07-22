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
    public partial class FormConsultaAltDemissao : Form
    {
        public FormConsultaAltDemissao()
        {
            InitializeComponent();
        }

        private void FormConsultaAltDemissao_Load(object sender, EventArgs e)
        {
            ConfigurarDateTimePicker(dateTimePickerDemission);
            ConfigurarDateTimePicker(dateTimePickerHiring);
        }

        private void ConfigurarDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " "; // Espaço em branco para mostrar vazio
            dtp.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
            dtp.ValueChanged += new EventHandler(dateTimePickerHiring_ValueChanged);

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
                                                          "     , HE.RG_RNE " +
                                                          "     , HE.CPF_CNPJ " +
                                                          "     , HE.PHOTO " +
                                                          "     , HEH.DATE_HIRING " +
                                                          "     , HED.DATE_DEMISSION " +
                                                          "	    , HED.REASON " +
                                                          "	    , HED.OBSERVATIONS " +
                                                          "FROM TB_HR_EMPLOYEES HE " +
                                                          "INNER JOIN TB_HR_EMPLOYEES_HIRING HEH " +
                                                          "   ON HEH.ID_EMPLO = HE.ID_EMPLO " +
                                                          "INNER JOIN TB_HR_EMPLOYEES_DEMISSION HED " +
                                                          "   ON HED.ID_EMPLO = HE.ID_EMPLO " +
                                                          "WHERE HE.CPF_CNPJ = @cpfCnpj";

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

                                        dateTimePickerHiring.Value = Convert.ToDateTime(reader["DATE_HIRING"]);
                                        dateTimePickerHiring.Format = DateTimePickerFormat.Short;

                                        txtMotivo.Text = reader["REASON"].ToString();
                                        txtObservacao.Text = reader["OBSERVATIONS"].ToString();

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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtConsultaCPFCNPJ.Text) || string.IsNullOrWhiteSpace(txtMotivo.Text) || string.IsNullOrWhiteSpace(txtObservacao.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;

                string cpfCnpj = txtCPFCNPJ.Text;
                int idEmplo = 0;

                DateTime dateDemission = dateTimePickerDemission.Value.Date;
                string reason = txtMotivo.Text;
                string observations = txtObservacao.Text;

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
                        string queryUpdate = "UPDATE DB_ALMOXARIFADO..TB_HR_EMPLOYEES_DEMISSION " +
                                            "SET DATE_DEMISSION  = @dateDemission " + 
                                            "  , REASON = @reason " + 
                                            "  , OBSERVATIONS = @observations " +
                                            "  , USER_UPDATE = @userUpdate " +
                                            "  , DATE_UPDATE = @dateUpdate " +
                                            "WHERE ID_EMPLO = @idEmplo ";
                        using (SqlCommand commandUpdate = new SqlCommand(queryUpdate, conn, transaction))
                        {
                            commandUpdate.Parameters.AddWithValue("@idEmplo", idEmplo);
                            commandUpdate.Parameters.AddWithValue("@dateDemission", dateDemission);
                            commandUpdate.Parameters.AddWithValue("@reason", reason);
                            commandUpdate.Parameters.AddWithValue("@observations", observations);
                            commandUpdate.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                            commandUpdate.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);

                            commandUpdate.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Demissão atualizada com sucesso!", "Sucesso");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro");
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDemission.Format = DateTimePickerFormat.Custom;
            dateTimePickerDemission.CustomFormat = "dd/MM/yyyy";
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePickerHiring_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
