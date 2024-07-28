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

namespace SISACON.FormsMaquinas
{
    public partial class FormCadastroFabricante : Form
    {
        public FormCadastroFabricante()
        {
            InitializeComponent();
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
                if (string.IsNullOrWhiteSpace(txtNomeFab.Text) || string.IsNullOrWhiteSpace(txtCodFab.Text))
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }
                else
                {
                    string usuarioLogado = UsuarioLogado.Login;
                    DateTime dataHoraAtual = DateTime.Now;

                    string nameManufacture = txtNomeFab.Text;
                    string codManufacture = txtCodFab.Text;

                    string connection = ConexaoBancoDados.conn_;
                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        conn.Open();

                        string query = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_MC_MANUFACTURE WHERE COD_MANUFACTURE = @codManufacture";

                        SqlCommand command = new SqlCommand(query, conn);
                        command.Parameters.AddWithValue("@codManufacture", codManufacture);

                        int count = (int)command.ExecuteScalar();

                        if(count > 0)
                        {
                            MessageBox.Show("O código do fabricante informado ja existe cadastrado no sistema!", "ATENÇÃO!");
                            return;
                        }
                         
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string queryInsert = "INSERT INTO DB_ALMOXARIFADO..TB_MC_MANUFACTURE (ID_MANUFACTURE, NAME_MANUFACTURE, COD_MANUFACTURE, USER_INSERT, DATE_INSERT) " +
                                                                                    "VALUES (NEXT VALUE FOR SEQ_MC_MANUFACTURE, @nameManufacture, @codManufacture, @userInsert, @dateInsert)";

                            using (SqlCommand commandInsert = new SqlCommand(queryInsert, conn, transaction))
                            {
                                commandInsert.Parameters.AddWithValue("@nameManufacture", nameManufacture);
                                commandInsert.Parameters.AddWithValue("@codManufacture", codManufacture);
                                commandInsert.Parameters.AddWithValue("@userInsert", usuarioLogado);
                                commandInsert.Parameters.AddWithValue("@dateInsert", dataHoraAtual);

                                commandInsert.ExecuteNonQuery();
                                transaction.Commit();
                                LimparCampos();

                                MessageBox.Show("Fabricante cadastrado com sucesso!", "Sucesso");
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
        }

        private void LimparCampos()
        {
            txtNomeFab.Text = "";
            txtCodFab.Text = "";
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
