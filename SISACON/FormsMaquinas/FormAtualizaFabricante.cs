using SISACON.ConexaoBD;
using SISACON.MaquinasClass;
using SISACON.MaquinasClass.FabricanteDAO;
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
    public partial class FormAtualizaFabricante : Form
    {
        public FormAtualizaFabricante()
        {
            InitializeComponent();

            PreencherComboBoxFabricante();
        }

        private void PreencherComboBoxFabricante()
        {
            string connectionString = ConexaoBancoDados.conn_;
            FabricanteDAO fabDAO = new FabricanteDAO(connectionString);
            List<Fabricante> fab = fabDAO.ObterFabricante();


            // Percorre cada departamento e concatena o nome com o código dentro de parênteses
            foreach (var fabricante in fab)
            {
                fabricante.NomeCompletoFab = $"{fabricante.COD_MANUFACTURE} - {fabricante.NAME_MANUFACTURE}";
            }

            // Define a fonte de dados do ComboBox
            cbxFabricante.DataSource = fab;
            // Define a propriedade DisplayMember para mostrar o nome completo
            cbxFabricante.DisplayMember = "NomeCompletoFab";
            cbxFabricante.ValueMember = "ID_MANUFACTURE";
        }

        private void cbxFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFabricante.SelectedItem != null)
            {
                // Obter o fabricante selecionado
                Fabricante selectedFabricante = (Fabricante)cbxFabricante.SelectedItem;

                // Preencher os TextBox com os valores do perfil selecionado
                txtNomeFab.Text = selectedFabricante.NAME_MANUFACTURE;
                txtCodFab.Text = selectedFabricante.COD_MANUFACTURE;
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

                    int idManufacture = (int)cbxFabricante.SelectedValue;

                    string connection = ConexaoBancoDados.conn_;
                    using (SqlConnection conn = new SqlConnection(connection))
                    {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            // Verificação do código duplicado (exceto para o próprio registro)
                            string queryCheck = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_MC_MANUFACTURE WHERE COD_MANUFACTURE = @codManufacture";
                            SqlCommand commandCheck = new SqlCommand(queryCheck, conn, transaction);
                            
                            commandCheck.Parameters.AddWithValue("@codManufacture", codManufacture);

                            int count = (int)commandCheck.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("O código do fabricante informado já existe cadastrado no sistema!", "ATENÇÃO!");
                                transaction.Rollback();
                                return;
                            }

                            // Atualização dos dados
                            string updateQuery = "UPDATE DB_ALMOXARIFADO..TB_MC_MANUFACTURE " +
                                                 "SET NAME_MANUFACTURE = @nameManufacture, " +
                                                 "    COD_MANUFACTURE = @codManufacture, " +
                                                 "    USER_UPDATE = @userUpdate, " +
                                                 "    DATE_UPDATE = @dateUpdate " +
                                                 "WHERE ID_MANUFACTURE = @idManufacture";

                            SqlCommand commandUpdate = new SqlCommand(updateQuery, conn, transaction);
                            commandUpdate.Parameters.AddWithValue("@nameManufacture", nameManufacture);
                            commandUpdate.Parameters.AddWithValue("@codManufacture", codManufacture);
                            commandUpdate.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                            commandUpdate.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);
                            commandUpdate.Parameters.AddWithValue("@idManufacture", idManufacture);

                            commandUpdate.ExecuteNonQuery();
                            transaction.Commit();
                            LimparDados();

                            MessageBox.Show("Dados Atualizados com sucesso!", "Atualizados");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro");
                        }
                    }
                }
            }
        }

        private void LimparDados()
        {
            txtCodFab.Text = "";
            txtNomeFab.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
