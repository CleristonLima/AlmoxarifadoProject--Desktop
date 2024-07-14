using SISACON.ConexaoBD;
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
using System.Text.RegularExpressions;
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

            // Habilitar o suporte a arrastar e soltar na PictureBox
            pictureBoxFoto.AllowDrop = true;

            // Lidar com o evento de arrastar e soltar
            /*pictureBoxFoto.DragEnter += (sender, e) =>
            {
                DragEventArgs dragEvent = e as DragEventArgs;
                if (dragEvent.Data.GetDataPresent(DataFormats.FileDrop))
                    dragEvent.Effect = DragDropEffects.Copy;
                else
                    dragEvent.Effect = DragDropEffects.None;
            };

            pictureBoxFoto.DragDrop += (sender, e) =>
            {
                DragEventArgs dragEvent = e as DragEventArgs;
                string[] files = (string[])dragEvent.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0)
                {
                    string imagePath = files[0]; // Pegue apenas o primeiro arquivo
                    pictureBoxFoto.Image = Image.FromFile(imagePath);
                }
            };*/

            txtCPFCNPJ.Leave += txtCPFCNPJ_Leave;
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

        private void txtCPFCNPJ_Leave(object sender, EventArgs e)
        {
            string cpfCnpj = Regex.Replace(txtCPFCNPJ.Text, @"[^\d]", "");

            if (cpfCnpj.Length == 11 || cpfCnpj.Length == 14)
            {
                if (IsCpfCnpjValido(cpfCnpj))
                {
                    //MessageBox.Show("CPF ou CNPJ válido!", "VALIDAÇÃO");
                    txtCPFCNPJ.BackColor = System.Drawing.Color.LightGreen;
                }
                else
                {
                    MessageBox.Show("CPF ou CNPJ inválido!", "DADOS INVÁLIDOS!");
                    txtCPFCNPJ.BackColor = System.Drawing.Color.LightCoral;
                }
            }
            else if (cpfCnpj.Length > 0)
            {
                MessageBox.Show("CPF ou CNPJ incompleto!", "DADOS INVÁLIDOS!");
                txtCPFCNPJ.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private bool IsCpfCnpjValido(string cpfCnpj)
        {
            // Remove caracteres não numéricos
            string digitsOnly = Regex.Replace(cpfCnpj, @"[^\d]", "");

            // Verifica se é CPF (11 dígitos) ou CNPJ (14 dígitos)
            if (digitsOnly.Length == 11)
            {
                return IsValidCPF(digitsOnly);
            }
            else if (digitsOnly.Length == 14)
            {
                return IsValidCNPJ(digitsOnly);
            }
            else
            {
                return false;
            }

        }

        private bool IsValidCPF(string cpf)
        {
            // Lista de CPFs inválidos conhecidos
            string[] invalidCpfs = { "12345678909", "00000000000", "11111111111", "22222222222", "33333333333",
                 "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999"
            };

            if (invalidCpfs.Contains(cpf))
            {
                return false; // CPF inválido
            }

            // Verifica se todos os dígitos são iguais
            if (cpf.All(c => c == cpf[0])) return false;

            // Faz o Calculo dos dígitos verificadores do CPF

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool IsValidCNPJ(string cnpj)
        {
            string[] invalidCnpj = { "12345678000199", "11111111111111", "22222222222222", "33333333333333", "44444444444444",
                    "55555555555555", "66666666666666", "77777777777777", "88888888888888", "99999999999999"
            };

            if (invalidCnpj.Contains(cnpj))
            {
                return false; // CNPJ inválido
            }

            // Verifica se todos os dígitos são iguais
            if (cnpj.All(c => c == cnpj[0])) return false;

            // Faz o Calculo dos dígitos verificadores do CNPJ
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
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

        private void cbxSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSexo.SelectedItem != null)
            {

                SelecionaSexo selectedSexo = (SelecionaSexo)cbxSexo.SelectedItem;

                int selectedSexoId = selectedSexo.ID_SEX_EMPLO;
            }
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

        private void btnFechar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
                

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;

                string cpfCnpj = txtConsultaCPFCNPJ.Text;

                int IdEmplo = 0;

                // Dados da tabela TB_HR_EMPLOYEES
                string name = txtNome.Text;
                string rgRne = txtRGRNE.Text;
                string cpfCnpj2 = txtCPFCNPJ.Text;
                DateTime bornDate = dateTimePickerDataNasc.Value.Date;
                string zipCode = txtCEP.Text;
                string address = txtEndereco.Text;
                string number = txtNumero.Text;
                string complement = txtComplemento.Text;
                string district = txtBairro.Text;
                string city = txtCidade.Text;
                int state = (int)cbxEstado.SelectedValue;
                int sex = (int)cbxSexo.SelectedValue;
                int department = (int)cbxDepartamento.SelectedValue;
                string nameLeader = cbxSuperior.Text;

                /*byte[] photo = null;

                bool photoChanged = false;

                // Verifica se a imagem foi alterada
                if (pictureBoxFoto.Image != null)
                {
                    try
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Substitua Jpeg pelo formato da sua imagem, se necessário
                            photo = ms.ToArray();
                            photoChanged = true;
                        }
                    }
                    catch (System.Runtime.InteropServices.ExternalException ex)
                    {
                        MessageBox.Show($"Erro ao salvar a imagem: {ex.Message}", "Erro de Imagem");
                        return;
                    }
                }*/


                int office = (int)cbxCargo.SelectedValue;
                int education = (int)cbxEscolaridade.SelectedValue;
                string phoneNumber1 = txtPhone1.Text;
                string phoneNumber2 = txtPhone2.Text;
                string email = txtEmail.Text;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string queryGetId = "SELECT ID_EMPLO FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";

                        SqlCommand commandGetId = new SqlCommand(queryGetId, conn, transaction);
                        commandGetId.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                        object idResult = commandGetId.ExecuteScalar();

                        if (idResult != null)
                        {
                            IdEmplo = (int)idResult;
                        }

                        else
                        {
                            MessageBox.Show("Funcionário não encontrado!", "Erro");
                            return;
                        }
                        string updateQuery = "UPDATE DB_ALMOXARIFADO..TB_HR_EMPLOYEES " +
                                           "  SET NAME_EMPLO = @nameEmplo" +
                                           ", RG_RNE = @rgRne " +
                                           ", CPF_CNPJ = @cpfCnpj2 " +
                                           ", BORN_DATE = @bornDate " +
                                           ", ZIP_CODE = @zipCode " +
                                           ", ADDRESS_EMPLO = @addressEmplo " +
                                           ", NUMBER = @number " +
                                           ", COMPLEMENT = @complement " +
                                           ", DISTRICT = @district " +
                                           ", CITY = @city " +
                                           ", UF_ID = @ufId " +
                                           ", ID_SEX_EMPLO = @idSexEmplo " +
                                           ", ID_EDUCATION = @idEducation " +
                                           ", ID_DEPARTMENT = @idDepartment " +
                                           ", ID_OFFICE = @idOffice " +
                                           ", NAME_LEADER = @nameLeader " +
                                           ", PHONE_NUMBER_1 = @phoneNumber1 " +
                                           ", PHONE_NUMBER_2 = @phoneNumber2 " +
                                           ", EMAIL = @email " +
                                           ", USER_UPDATE = @userUpdate " +
                                           ", DATE_UPDATE = @dateUpdate " +
                                           " WHERE ID_EMPLO = @IdEmplo ";

                        // Adiciona a foto à query apenas se ela foi alterada
                       /* if (photoChanged)
                        {
                            updateQuery += ", PHOTO = @photo";
                        }*/

                            SqlCommand command = new SqlCommand(updateQuery, conn, transaction);

                            // Atualizando os dados

                            command.Parameters.AddWithValue("@nameEmplo", name);
                            command.Parameters.AddWithValue("@rgRne", rgRne);
                            command.Parameters.AddWithValue("@cpfCnpj2", cpfCnpj2);
                            command.Parameters.AddWithValue("@bornDate", bornDate);
                            command.Parameters.AddWithValue("@zipCode", zipCode);
                            command.Parameters.AddWithValue("@addressEmplo", address);
                            command.Parameters.AddWithValue("@number", number);
                            command.Parameters.AddWithValue("@complement", complement);
                            command.Parameters.AddWithValue("@district", district);
                            command.Parameters.AddWithValue("@city", city);
                            command.Parameters.AddWithValue("@ufId", state);
                            command.Parameters.AddWithValue("@idSexEmplo", sex);
                            command.Parameters.AddWithValue("@idDepartment", department);
                            command.Parameters.AddWithValue("@nameLeader", nameLeader);
                            command.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                            command.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);
                            command.Parameters.AddWithValue("@idOffice", office);
                            command.Parameters.AddWithValue("@idEducation", education);
                            command.Parameters.AddWithValue("@phoneNumber1", phoneNumber1);
                            command.Parameters.AddWithValue("@phoneNumber2", phoneNumber2);
                            command.Parameters.AddWithValue("@email", email);

                            /*if (photoChanged)
                            {
                                command.Parameters.AddWithValue("@photo", photo);
                            }*/

                            command.Parameters.AddWithValue("@IdEmplo", IdEmplo);

                            command.ExecuteNonQuery();
                            transaction.Commit();

                            MessageBox.Show("Dados Atualizados com sucesso!", "Atualizados");
                    
                    } catch (Exception ex)
                    {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro");
                    }
                    
                }
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
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

        private void btnSalvar2_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;

            }else
            {
                if (string.IsNullOrWhiteSpace(txtNacionalidade.Text) || string.IsNullOrWhiteSpace(txtBoxNaturalidade.Text) || string.IsNullOrWhiteSpace(txtBoxNomeMae.Text) || string.IsNullOrWhiteSpace(txtAgencia.Text) ||
                    string.IsNullOrWhiteSpace(txtSalario.Text) || string.IsNullOrWhiteSpace(txtConta.Text) || cbxEstadoNascimento.SelectedIndex == -1 || cbxEstadoCivil.SelectedIndex == -1 || cbxTipoContratacao.SelectedIndex == -1 ||
                    cbxTipoConta.SelectedIndex == -1 || cbxBanco.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;

                string cpfCnpj = txtConsultaCPFCNPJ.Text;

                int IdEmplo = 0;

                DateTime dateHiring = dateTimePickerHiring.Value.Date;
                string nacionality = txtNacionalidade.Text;
                string bornCity = txtBoxNaturalidade.Text;
                int stateBorn = (int)cbxEstadoNascimento.SelectedValue;
                string nameMother = txtBoxNomeMae.Text;
                string nameFather = txtBoxNomePai.Text;
                int civilState = (int)cbxEstadoCivil.SelectedValue;
                int typeHiring = (int)cbxTipoContratacao.SelectedValue;

                decimal salary;

                if (!decimal.TryParse(txtSalario.Text, out salary))
                {
                    MessageBox.Show("O valor do salário é inválido. Insira um valor decimal.", "Erro de validação");
                    return;
                }

                int typeCount = (int)cbxTipoConta.SelectedValue;
                int bank = (int)cbxBanco.SelectedValue;
                int agency = int.Parse(txtAgencia.Text);
                string countSalary = txtConta.Text;
                int numberCLT = int.Parse(txtCLT.Text);
                string serie = txtSerie.Text;
                DateTime? dateEmissionCLT = string.IsNullOrWhiteSpace(dateTimePickerDataEmissaoCLT.Text) ? (DateTime?)null : dateTimePickerDataEmissaoCLT.Value.Date;
                long voterRegistration = long.Parse(txtEleitor.Text);
                int zoneRegistration = int.Parse(txtZona.Text);
                string sessionRegistration = txtSecao.Text;
                int numberReservist = int.Parse(txtReservista.Text);
                string serieReservist = txtSerieReservista.Text;
                long numberDriverLicense = long.Parse(txtCNH.Text);
                DateTime? dateValidateDriverLicense = string.IsNullOrWhiteSpace(dateTimePickerDataVencimentoCNH.Text) ? (DateTime?)null : dateTimePickerDataVencimentoCNH.Value.Date;
                string typeDriver = txtCategoria.Text;
                DateTime? dateEmissionDriverLicense = string.IsNullOrWhiteSpace(dateTimePickerDataEmissaoCNH.Text) ? (DateTime?)null : dateTimePickerDataEmissaoCNH.Value.Date;

                string connection = ConexaoBancoDados.conn_;
                using (SqlConnection conn = new SqlConnection(connection))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string queryGetIdEh = "SELECT EH.ID_EMPLO " +
                                            "FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES_HIRING EH " +
                                            "INNER JOIN DB_ALMOXARIFADO..TB_HR_EMPLOYEES E " +
                                                     "ON E.ID_EMPLO = EH.ID_EMPLO " +
                                            "WHERE E.CPF_CNPJ = @cpfCnpj";

                        SqlCommand commandGetIdEh = new SqlCommand(queryGetIdEh, conn, transaction);
                        commandGetIdEh.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                        object idResult = commandGetIdEh.ExecuteScalar();

                        if (idResult != null)
                        {
                            IdEmplo = (int)idResult;
                        }
                        else
                        {
                            MessageBox.Show("Funcionário não encontrado!", "Erro");
                            return;
                        }
                        string updateQuery2 = "UPDATE DB_ALMOXARIFADO..TB_HR_EMPLOYEES_HIRING " +
                                            "SET DATE_HIRING = @dateHiring " +
                                            "  , BORN_CITY = @bornCity " +
                                            "  , UF_ID_BORN = @ufIdBorn " +
                                            "  , NACIONALITY = @nacionality " +
                                            "  , NAME_MOTHER = @nameMother " +
                                            "  , NAME_FATHER = @nameFather " +
                                            "  , ID_CIVIL_STATE = @idCivilState " +
                                            "  , ID_TYPE_HIRING = @idTypeHiring " +
                                            "  , SALARY = @salary " +
                                            "  , ID_BANK = @idBank " +
                                            "  , ID_TYPE_COUNT = @idTypeCount " +
                                            "  , AGENCY = @agency " +
                                            "  , COUNT_SALARY = @countSalary " +
                                            "  , CLT_NUMBER = @cltNumber " +
                                            "  , SERIE = @serie " +
                                            "  , EMISSION_DATE_CLT = @emissionDateClt " +
                                            "  , ZONE_REGISTRATION = @zoneRegistration " +
                                            "  , SESSION_REGISTRATION = @sessionRegistration " +
                                            "  , NUMBER_RESERVIST = @numberReservist " +
                                            "  , SERIE_RESERVIST = @serieReservist " +
                                            "  , DATE_VALIDATE_DRIVER_LICENSE = @dateValidateDriverLicense " +
                                            "  , TYPE_DRIVER = @typeDriver " +
                                            "  , EMISSION_DATE_DRIVER_LICENSE = @emissionDateDriverLicense " +
                                            "  , VOTER_REGISTRATION = @voterRegistration " +
                                            "  , NUMBER_DRIVER_LICENSE = @numberDriverLicense " +
                                            "  , USER_UPDATE = @userUpdate " +
                                            "  , DATE_UPDATE = @dateUpdate " +
                                            "WHERE ID_EMPLO = @IdEmplo";

                        SqlCommand commandEmployeesHiring = new SqlCommand(updateQuery2, conn, transaction);

                        commandEmployeesHiring.Parameters.AddWithValue("@dateHiring", dateHiring);
                        commandEmployeesHiring.Parameters.AddWithValue("@bornCity", bornCity);
                        commandEmployeesHiring.Parameters.AddWithValue("@ufIdBorn", stateBorn);
                        commandEmployeesHiring.Parameters.AddWithValue("@nacionality", nacionality);
                        commandEmployeesHiring.Parameters.AddWithValue("@nameMother", nameMother);
                        commandEmployeesHiring.Parameters.AddWithValue("@nameFather", nameFather);
                        commandEmployeesHiring.Parameters.AddWithValue("@idCivilState", civilState);
                        commandEmployeesHiring.Parameters.AddWithValue("@idTypeHiring", typeHiring);
                        commandEmployeesHiring.Parameters.AddWithValue("@salary", salary);
                        commandEmployeesHiring.Parameters.AddWithValue("@idBank", bank);
                        commandEmployeesHiring.Parameters.AddWithValue("@idTypeCount", typeCount);
                        commandEmployeesHiring.Parameters.AddWithValue("@agency", agency);
                        commandEmployeesHiring.Parameters.AddWithValue("@countSalary", countSalary);
                        commandEmployeesHiring.Parameters.AddWithValue("@cltNumber", numberCLT);
                        commandEmployeesHiring.Parameters.AddWithValue("@serie", serie);
                        commandEmployeesHiring.Parameters.AddWithValue("@emissionDateClt", (object)dateEmissionCLT ?? DBNull.Value);
                        commandEmployeesHiring.Parameters.AddWithValue("@voterRegistration", voterRegistration);
                        commandEmployeesHiring.Parameters.AddWithValue("@zoneRegistration", zoneRegistration);
                        commandEmployeesHiring.Parameters.AddWithValue("@sessionRegistration", sessionRegistration);
                        commandEmployeesHiring.Parameters.AddWithValue("@numberReservist", numberReservist);
                        commandEmployeesHiring.Parameters.AddWithValue("@serieReservist", serieReservist);
                        commandEmployeesHiring.Parameters.AddWithValue("@numberDriverLicense", numberDriverLicense);
                        commandEmployeesHiring.Parameters.AddWithValue("@dateValidateDriverLicense", (object)dateValidateDriverLicense ?? DBNull.Value);
                        commandEmployeesHiring.Parameters.AddWithValue("@typeDriver", typeDriver);
                        commandEmployeesHiring.Parameters.AddWithValue("@emissionDateDriverLicense", (object)dateEmissionDriverLicense ?? DBNull.Value);
                        commandEmployeesHiring.Parameters.AddWithValue("@userUpdate", usuarioLogado);
                        commandEmployeesHiring.Parameters.AddWithValue("@dateUpdate", dataHoraAtual);

                        commandEmployeesHiring.Parameters.AddWithValue("@IdEmplo", IdEmplo);

                        commandEmployeesHiring.ExecuteNonQuery();
                        transaction.Commit();

                        MessageBox.Show("Dados Atualizados com sucesso!", "SUCESSO!!");

                        LimparCampos();

                        tabCtlCadFunc.SelectedIndex = 0;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao atualizar dados: {ex.Message}", "Erro");
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

        private void FormAtualizaCadastroFunc_Load(object sender, EventArgs e)
        {
            ConfigurarDateTimePicker(dateTimePickerDataEmissaoCLT);
            ConfigurarDateTimePicker(dateTimePickerDataVencimentoCNH);
            ConfigurarDateTimePicker(dateTimePickerDataEmissaoCNH);
        }

        private void ConfigurarDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = " "; // Espaço em branco para mostrar vazio
            dtp.ValueChanged += new EventHandler(DateTimePicker_ValueChanged);
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = sender as DateTimePicker;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePickerDataEmissaoCLT_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDataEmissaoCLT.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataEmissaoCLT.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePickerDataVencimentoCNH_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDataVencimentoCNH.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataVencimentoCNH.CustomFormat = "dd/MM/yyyy";

        }

        private void dateTimePickerDataEmissaoCNH_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerDataEmissaoCNH.Format = DateTimePickerFormat.Custom;
            dateTimePickerDataEmissaoCNH.CustomFormat = "dd/MM/yyyy";
        }
    }
}
