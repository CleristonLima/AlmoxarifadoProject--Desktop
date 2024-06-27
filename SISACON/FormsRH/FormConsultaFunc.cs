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
    public partial class FormConsultaFunc : Form
    {
        public FormConsultaFunc()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                if (string.IsNullOrWhiteSpace(txtCPFCNPJ.Text))
                {
                    MessageBox.Show("Por favor informe o CPF ou CNPJ para atualizar os dados", "ATENÇÃO!!");
                }
                else
                {
                    string cpfCnpj = txtCPFCNPJ.Text;

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

                            if (count > 0)
                            {
                                MessageBox.Show("CPF existente na base");
                            }
                            else
                            {
                                MessageBox.Show("Não existe CPF favor fazer o cadastro");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro!!" + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
