﻿using SISACON.ConexaoBD;
using SISACON.RHClass;
using SISACON.RHClass.CargoDAO;
using SISACON.RHClass.DepartamentoDAO;
using SISACON.RHClass.EscolaridadeDAO;
using SISACON.RHClass.EstadoCivilDAO;
using SISACON.RHClass.EstadoDAO;
using SISACON.RHClass.SexoDAO;
using SISACON.RHClass.TipoContratacaoDAO;
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
    public partial class FormDeletaCadastroFunc : Form
    {
        public FormDeletaCadastroFunc()
        {
            InitializeComponent();

        }

        private void cbxSuperior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSuperior.SelectedItem != null)
            {

                SelecionaSuperior selectedSuperior = (SelecionaSuperior)cbxSuperior.SelectedItem;

                string selectedSup = selectedSuperior.NameSuperior;
            }
        }

        private void PreencherComboxSuperior()
        {
            string connectionString = ConexaoBancoDados.conn_;
            SuperiorDAO superiorDAO = new SuperiorDAO(connectionString);
            List<SelecionaSuperior> superior = superiorDAO.ObterSuperior();

            cbxSuperior.DataSource = superior;
            cbxSuperior.DisplayMember = "NameSuperior";
            cbxSuperior.ValueMember = "NameSuperior";
        }

        private void cbxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCargo.SelectedItem != null)
            {

                Cargo selectedCargo = (Cargo)cbxCargo.SelectedItem;

                int selectedCargoId = selectedCargo.ID_OFFICE;
            }
        }

        private void PreencherComboxCargo()
        {
            string connectionString = ConexaoBancoDados.conn_;
            CargoDAO cargoDAO = new CargoDAO(connectionString);
            List<Cargo> cargo = cargoDAO.ObterCargo();

            cbxCargo.DataSource = cargo;
            cbxCargo.DisplayMember = "NAME_OFFICE";
            cbxCargo.ValueMember = "ID_OFFICE";
        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDepartamento.SelectedItem != null)
            {

                Departamento selectedDepartamento = (Departamento)cbxDepartamento.SelectedItem;

                int selectedDepartamentoId = selectedDepartamento.ID_DEPARTMENT;
            }
        }

        private void PreencherComboxDepartamento()
        {
            string connectionString = ConexaoBancoDados.conn_;
            DepartamentoDAO departamentoDAO = new DepartamentoDAO(connectionString);
            List<Departamento> departamento = departamentoDAO.ObterDepartamento();

            cbxDepartamento.DataSource = departamento;
            cbxDepartamento.DisplayMember = "NAME_DEPARTMENT";
            cbxDepartamento.ValueMember = "ID_DEPARTMENT";
        }

        private void cbxEscolaridade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEscolaridade.SelectedItem != null)
            {

                SelecionaEscolaridade selectedEscolaridade = (SelecionaEscolaridade)cbxEscolaridade.SelectedItem;

                int selectedEducationId = selectedEscolaridade.ID_EDUCATION;
            }
        }

        private void PreencherComboxEscolaridade()
        {
            string connectionString = ConexaoBancoDados.conn_;
            EscolaridadeDAO escolaridadeDAO = new EscolaridadeDAO(connectionString);
            List<SelecionaEscolaridade> escola = escolaridadeDAO.ObterEscolaridade();
            cbxEscolaridade.DataSource = escola;
            cbxEscolaridade.DisplayMember = "NAME_EDUCATION";
            cbxEscolaridade.ValueMember = "ID_EDUCATION";
        }

        private void cbxSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelecionaSexo selectedSexo = (SelecionaSexo)cbxSexo.SelectedItem;

            int selectedSexoId = selectedSexo.ID_SEX_EMPLO;
        }

        private void PreencherComboxSexo()
        {
            string connectionString = ConexaoBancoDados.conn_;
            SexoDAO sexoDAO = new SexoDAO(connectionString);
            List<SelecionaSexo> sexo = sexoDAO.ObterSexo();
            cbxSexo.DataSource = sexo;
            cbxSexo.DisplayMember = "NomeSexo";
            cbxSexo.ValueMember = "ID_SEX_EMPLO";
        }

        private void cbxEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEstado.SelectedItem != null)
            {

                SelecionaEstado selectedEstado = (SelecionaEstado)cbxEstado.SelectedItem;

                int selectedEstadoId = selectedEstado.ID_UF;
            }
        }

        private void PreencherComboEstado()
        {
            string connectionString = ConexaoBancoDados.conn_;
            EstadoDAO estadoDAO = new EstadoDAO(connectionString);
            List<SelecionaEstado> estado = estadoDAO.ObterEstado();
            cbxEstado.DataSource = estado;
            cbxEstado.DisplayMember = "CODE_UF";
            cbxEstado.ValueMember = "ID_UF";
        }

        private void cbxEstadoNascimento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEstadoNascimento.SelectedItem != null)
            {

                SelecionaEstado selectedEstadoNasc = (SelecionaEstado)cbxEstadoNascimento.SelectedItem;

                int selectedEstadoNascId = selectedEstadoNasc.ID_UF;
            }
        }

        private void PreencherComboEstadoNasc()
        {
            string connectionString = ConexaoBancoDados.conn_;
            EstadoDAO estadoDAO = new EstadoDAO(connectionString);
            List<SelecionaEstado> estado = estadoDAO.ObterEstado();

            cbxEstadoNascimento.DataSource = estado;
            cbxEstadoNascimento.DisplayMember = "CODE_UF";
            cbxEstadoNascimento.ValueMember = "ID_UF";
        }

        private void cbxEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEstadoCivil.SelectedItem != null)
            {

                SelecionaEstadoCivil selectedEstadoCivil = (SelecionaEstadoCivil)cbxEstadoCivil.SelectedItem;

                int selectedEstadoNascId = selectedEstadoCivil.ID_CIVIL_STATE;
            }
        }

        private void PreencherComboEstadoCivil()
        {
            string connectionString = ConexaoBancoDados.conn_;
            EstadoCivilDAO estadoCivilDAO = new EstadoCivilDAO(connectionString);
            List<SelecionaEstadoCivil> estadoCivil = estadoCivilDAO.ObterEstadoCivil();

            cbxEstadoCivil.DataSource = estadoCivil;
            cbxEstadoCivil.DisplayMember = "DESC_CIVIL_STATE";
            cbxEstadoCivil.ValueMember = "ID_CIVIL_STATE";
        }

        private void cbxTipoContratacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoContratacao.SelectedItem != null)
            {

                SelecionaTipoContratacao selectedTipoContratacao = (SelecionaTipoContratacao)cbxTipoContratacao.SelectedItem;

                int selectedTipoContratacaoId = selectedTipoContratacao.ID_TYPE_HIRING;
            }
        }

        private void PreencherComboxTipoContratacao()
        {
            string connectionString = ConexaoBancoDados.conn_;
            TipoContratacaoDAO tipoContratacaoDAO = new TipoContratacaoDAO(connectionString);
            List<SelecionaTipoContratacao> tipoContratacao = tipoContratacaoDAO.ObterTipoContratacao();

            cbxTipoContratacao.DataSource = tipoContratacao;
            cbxTipoContratacao.DisplayMember = "DESC_HIRING";
            cbxTipoContratacao.ValueMember = "ID_TYPE_HIRING";
        }

        private void cbxTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoConta.SelectedItem != null)
            {

                SelecionaTipoConta selectedTipoConta = (SelecionaTipoConta)cbxTipoConta.SelectedItem;

                int selectedTipoContaId = selectedTipoConta.ID_TYPE_COUNT;
            }
        }

        private void PreencherComboxTipoConta()
        {
            string connectionString = ConexaoBancoDados.conn_;
            TipoContaDAO tipoContaDAO = new TipoContaDAO(connectionString);
            List<SelecionaTipoConta> conta = tipoContaDAO.ObterTipoConta();

            cbxTipoConta.DataSource = conta;
            cbxTipoConta.DisplayMember = "NomeConta";
            cbxTipoConta.ValueMember = "ID_TYPE_COUNT";
        }

        private void cbxBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBanco.SelectedItem != null)
            {

                SelecionaBanco selectedBanco = (SelecionaBanco)cbxBanco.SelectedItem;

                int selectedBancoId = selectedBanco.ID_BANK;
            }
        }

        private void PreencherComboxBanco()
        {
            string connectionString = ConexaoBancoDados.conn_;
            BancoDAO bancoDAO = new BancoDAO(connectionString);
            List<SelecionaBanco> banco = bancoDAO.ObterBanco();

            cbxBanco.DataSource = banco;
            cbxBanco.DisplayMember = "NameBank";
            cbxBanco.ValueMember = "ID_BANK";
        }


        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(txtConsultaCPFCNPJ.Text))
            {
                MessageBox.Show("Por favor informe o CPF ou CNPJ para atualizar os dados", "ATENÇÃO!!");
                LimparCampos();
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

                                        txtCEP.Text = reader["ZIP_CODE"].ToString();
                                        txtEndereco.Text = reader["ADDRESS_EMPLO"].ToString();
                                        txtNumero.Text = reader["NUMBER"].ToString();
                                        txtComplemento.Text = reader["COMPLEMENT"].ToString();
                                        txtBairro.Text = reader["DISTRICT"].ToString();
                                        txtCidade.Text = reader["CITY"].ToString();

                                        PreencherComboEstado();
                                        cbxEstado.SelectedValue = reader["UF_ID"];

                                        PreencherComboxSexo();
                                        cbxSexo.SelectedValue = reader["ID_SEX_EMPLO"];

                                        PreencherComboxEscolaridade();
                                        cbxEscolaridade.SelectedValue = reader["ID_EDUCATION"];

                                        PreencherComboxDepartamento();
                                        cbxDepartamento.SelectedValue = reader["ID_DEPARTMENT"];

                                        PreencherComboxCargo();
                                        cbxCargo.SelectedValue = reader["ID_OFFICE"];

                                        PreencherComboxSuperior();
                                        cbxSuperior.SelectedValue = reader["NAME_LEADER"];

                                        txtPhone1.Text = reader["PHONE_NUMBER_1"].ToString();
                                        txtPhone2.Text = reader["PHONE_NUMBER_2"].ToString();
                                        txtEmail.Text = reader["EMAIL"].ToString();

                                        //---------------------------------------------------------------//

                                        // Campos da tabela TB_HR_EMPLOYEES
                                        dateTimePickerHiring.Value = Convert.ToDateTime(reader["DATE_HIRING"]);
                                        dateTimePickerHiring.Format = DateTimePickerFormat.Short;

                                        txtNacionalidade.Text = reader["NACIONALITY"].ToString();
                                        txtBoxNaturalidade.Text = reader["BORN_CITY"].ToString();

                                        PreencherComboEstadoNasc();
                                        cbxEstadoNascimento.SelectedValue = reader["UF_ID_BORN"];

                                        txtBoxNomeMae.Text = reader["NAME_MOTHER"].ToString();
                                        txtBoxNomePai.Text = reader["NAME_FATHER"].ToString();

                                        PreencherComboEstadoCivil();
                                        cbxEstadoCivil.SelectedValue = reader["ID_CIVIL_STATE"];

                                        PreencherComboxTipoContratacao();
                                        cbxTipoContratacao.SelectedValue = reader["ID_TYPE_HIRING"];

                                        txtSalario.Text = reader["SALARY"].ToString();

                                        PreencherComboxTipoConta();
                                        cbxTipoConta.SelectedValue = reader["ID_TYPE_COUNT"];

                                        PreencherComboxBanco();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {

                tabCtlCadFunc.SelectedIndex = 0;

            }
        }

        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {

                tabCtlCadFunc.SelectedIndex = 1;

            }
        }

        private void txtConsultaCPFCNPJ_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;

            }
            else
            {

                string cpfCnpj = txtConsultaCPFCNPJ.Text;

                int IdEmplo = 0;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Obter o ID_EMPLO com base no CPF_CNPJ
                        string queryGetId = "SELECT ID_EMPLO FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";
                        SqlCommand commandGetId = new SqlCommand(queryGetId, conn, transaction);
                        commandGetId.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                        object idResult = commandGetId.ExecuteScalar();
                        if (idResult == null)
                        {
                            MessageBox.Show("Funcionário não encontrado!", "Erro");
                            return;
                        }

                        int idEmplo = (int)idResult;

                        // Deletar da tabela TB_HR_EMPLOYEES_HIRING
                        string queryDeleteHiring = "DELETE FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES_HIRING WHERE ID_EMPLO = @idEmplo";
                        SqlCommand commandDeleteHiring = new SqlCommand(queryDeleteHiring, conn, transaction);
                        commandDeleteHiring.Parameters.AddWithValue("@idEmplo", idEmplo);
                        commandDeleteHiring.ExecuteNonQuery();

                        // Deletar da tabela TB_HR_EMPLOYEES
                        string queryDeleteEmployees = "DELETE FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE ID_EMPLO = @idEmplo";
                        SqlCommand commandDeleteEmployees = new SqlCommand(queryDeleteEmployees, conn, transaction);
                        commandDeleteEmployees.Parameters.AddWithValue("@idEmplo", idEmplo);
                        commandDeleteEmployees.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Funcionário excluído com sucesso!", "Sucesso");
                        LimparCampos();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erro ao excluir funcionário: " + ex.Message, "Erro");
                    }
                }
            }
        }

        private void LimparCampos()
        {
            txtConsultaCPFCNPJ.Text = "";
            txtNome.Text = "";
            txtRGRNE.Text = "";
            txtCPFCNPJ.Text = "";
            dateTimePickerDataNasc.Value = DateTime.Today;
            txtCEP.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cbxEstado.SelectedIndex = -1;
            cbxSexo.SelectedIndex = -1;
            cbxDepartamento.SelectedIndex = -1;
            cbxSuperior.SelectedIndex = -1;
            pictureBoxFoto.Image = null;
            cbxCargo.SelectedIndex = -1;
            cbxEscolaridade.SelectedIndex = -1;
            txtPhone1.Text = "";
            txtPhone2.Text = "";
            txtEmail.Text = "";

            // Limpando os campos que são referente a tabela TB_HR_EMPLOYEES_HIRING
            txtNacionalidade.Text = "";
            txtBoxNaturalidade.Text = "";
            txtBoxNomeMae.Text = "";
            txtBoxNomePai.Text = "";
            cbxTipoConta.SelectedIndex = -1;
            cbxBanco.SelectedIndex = -1;
            cbxEstadoCivil.SelectedIndex = -1;
            cbxTipoContratacao.SelectedIndex = -1;
            txtSalario.Text = "";
            txtAgencia.Text = "";
            txtConta.Text = "";
            txtCLT.Text = "";
            txtSerie.Text = "";

            dateTimePickerDataEmissaoCLT.CustomFormat = " ";
            dateTimePickerDataEmissaoCLT.Format = DateTimePickerFormat.Custom;

            txtEleitor.Text = "";
            txtZona.Text = "";
            txtSecao.Text = "";
            txtReservista.Text = "";
            txtSerieReservista.Text = "";
            txtCNH.Text = "";

            dateTimePickerDataVencimentoCNH.CustomFormat = " ";
            dateTimePickerDataVencimentoCNH.Format = DateTimePickerFormat.Custom;

            txtCategoria.Text = "";

            dateTimePickerDataEmissaoCNH.CustomFormat = " ";
            dateTimePickerDataEmissaoCNH.Format = DateTimePickerFormat.Custom;

            txtConsultaCPFCNPJ.Focus();
        }
    }
}
