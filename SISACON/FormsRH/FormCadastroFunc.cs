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
    public partial class FormCadastroFunc : Form
    {

        public FormCadastroFunc()
        {
            InitializeComponent();

            // Habilitar o suporte a arrastar e soltar na PictureBox
            pictureBoxFoto.AllowDrop = true;

            // Lidar com o evento de arrastar e soltar
            pictureBoxFoto.DragEnter += (sender, e) =>
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
            };

            txtCPFCNPJ.Leave += txtCPFCNPJ_Leave;

            // Adicionando Handlers para os eventos TextChanged das TextBox da agência e conta
            txtAgencia.TextChanged += txtAgencia_TextChanged;
            txtConta.TextChanged += txtConta_TextChanged;

            PreencherComboEstado();
            PreencherComboxSexo();
            PreencherComboxEscolaridade();
            PreencherComboxDepartamento();
            PreencherComboxCargo();
            PreencherComboEstadoNasc();
            PreencherComboEstadoCivil();
            PreencherComboxTipoContratacao();
            PreencherComboxTipoConta();
            PreencherComboxBanco();
            PreencherComboxSuperior();

            this.Load += new EventHandler(FormCadastroFunc_Load);
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFoto_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCPFCNPJ_TextChanged(object sender, EventArgs e)
        {

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

            List<SelecionaEstado> estadoComPrompt = new List<SelecionaEstado>
            {
                new SelecionaEstado { ID_UF = -1, CODE_UF = "--Selecione" }
            };

            estadoComPrompt.AddRange(estado);

            cbxEstado.DataSource = estadoComPrompt;
            cbxEstado.DisplayMember = "CODE_UF";
            cbxEstado.ValueMember = "ID_UF";

            cbxEstado.SelectedIndex = 0;
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

            List<SelecionaSexo> sexoComPrompt = new List<SelecionaSexo>
            {
                new SelecionaSexo { ID_SEX_EMPLO = -1, CODE_SEX_EMPLO = "", DESC_SEX_EMPLO = "-Selecione" }
            };

            sexoComPrompt.AddRange(sexo);

            cbxSexo.DataSource = sexoComPrompt;
            cbxSexo.DisplayMember = "NomeSexo";
            cbxSexo.ValueMember = "ID_SEX_EMPLO";

            cbxSexo.SelectedIndex = 0;
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

            List<SelecionaEscolaridade> escolaComPrompt = new List<SelecionaEscolaridade>
            {
                new SelecionaEscolaridade { ID_EDUCATION = -1, NAME_EDUCATION = "--Selecione" }
            };

            escolaComPrompt.AddRange(escola);

            cbxEscolaridade.DataSource = escolaComPrompt;
            cbxEscolaridade.DisplayMember = "NAME_EDUCATION";
            cbxEscolaridade.ValueMember = "ID_EDUCATION";

            cbxEscolaridade.SelectedIndex = 0;
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

            List<Departamento> departamentoComPrompt = new List<Departamento>
            {
                new Departamento { ID_DEPARTMENT = -1, NAME_DEPARTMENT = "--Selecione" }
            };

            departamentoComPrompt.AddRange(departamento);

            cbxDepartamento.DataSource = departamentoComPrompt;
            cbxDepartamento.DisplayMember = "NAME_DEPARTMENT";
            cbxDepartamento.ValueMember = "ID_DEPARTMENT";

            cbxDepartamento.SelectedIndex = 0;
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

            List<Cargo> cargoComPrompt = new List<Cargo>
            {
                new Cargo { ID_OFFICE = -1, NAME_OFFICE = "--Selecione" }
            };

            cargoComPrompt.AddRange(cargo);

            cbxCargo.DataSource = cargoComPrompt;
            cbxCargo.DisplayMember = "NAME_OFFICE";
            cbxCargo.ValueMember = "ID_OFFICE";

            cbxCargo.SelectedIndex = 0;
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

            List<SelecionaEstado> estadoNascComPrompt = new List<SelecionaEstado>
            {
                new SelecionaEstado { ID_UF = -1, CODE_UF = "--Selecione" }
            };

            estadoNascComPrompt.AddRange(estado);

            cbxEstadoNascimento.DataSource = estadoNascComPrompt;
            cbxEstadoNascimento.DisplayMember = "CODE_UF";
            cbxEstadoNascimento.ValueMember = "ID_UF";

            cbxEstadoNascimento.SelectedIndex = 0;
        }

        private void lblEmissao_Click(object sender, EventArgs e)
        {

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

            List<SelecionaEstadoCivil> estadoCivilComPrompt = new List<SelecionaEstadoCivil>
            {
                new SelecionaEstadoCivil { ID_CIVIL_STATE = -1, DESC_CIVIL_STATE = "--Selecione" }
            };

            estadoCivilComPrompt.AddRange(estadoCivil);

            cbxEstadoCivil.DataSource = estadoCivilComPrompt;
            cbxEstadoCivil.DisplayMember = "DESC_CIVIL_STATE";
            cbxEstadoCivil.ValueMember = "ID_CIVIL_STATE";

            cbxEstadoCivil.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

            List<SelecionaTipoContratacao> tipoContratacaoComPrompt = new List<SelecionaTipoContratacao>
            {
                new SelecionaTipoContratacao { ID_TYPE_HIRING = -1, DESC_HIRING = "--Selecione" }
            };

            tipoContratacaoComPrompt.AddRange(tipoContratacao);

            cbxTipoContratacao.DataSource = tipoContratacaoComPrompt;
            cbxTipoContratacao.DisplayMember = "DESC_HIRING";
            cbxTipoContratacao.ValueMember = "ID_TYPE_HIRING";

            cbxTipoContratacao.SelectedIndex = 0;
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

            List<SelecionaTipoConta> tipoContaComPrompt = new List<SelecionaTipoConta>
            {
                new SelecionaTipoConta { ID_TYPE_COUNT = -1, CODE_TYPE_COUNT = "", NAME_TYPE_COUNT = "-Selecione" }
            };

            tipoContaComPrompt.AddRange(conta);

            cbxTipoConta.DataSource = tipoContaComPrompt;
            cbxTipoConta.DisplayMember = "NomeConta";
            cbxTipoConta.ValueMember = "ID_TYPE_COUNT";

            cbxTipoConta.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
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

            List<SelecionaBanco> bancoComPrompt = new List<SelecionaBanco>
            {
                new SelecionaBanco { ID_BANK = 0, DESC_BANK = "Selecione" }
            };

            bancoComPrompt.AddRange(banco);

            cbxBanco.DataSource = bancoComPrompt;
            cbxBanco.DisplayMember = "NameBank";
            cbxBanco.ValueMember = "ID_BANK";

            cbxBanco.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAgencia_TextChanged(object sender, EventArgs e)
        {
            /*if (ValidarAgencia(txtAgencia.Text))
            {
                txtAgencia.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                txtAgencia.BackColor = System.Drawing.Color.LightCoral;
            }*/
        }

        /*private bool ValidarAgencia(string agencia)
        {
            return Regex.IsMatch(agencia, @"^\d{4}$");
        }*/

        private void txtConta_TextChanged(object sender, EventArgs e)
        {
            /*if (ValidarConta(txtConta.Text))
            {
                txtConta.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                txtConta.BackColor = System.Drawing.Color.LightCoral;
            }*/
        }

       /* private bool ValidarConta(string conta)
        {
            return Regex.IsMatch(conta, @"^\d{5}-\d{1}$") || Regex.IsMatch(conta, @"^\d{8}$");
        }

        private bool VerificarAgenciaEConta(string agencia, string conta)
        {
            if (!ValidarAgencia(agencia))
            {
                return false;
            }

            if (!ValidarConta(conta))
            {
                return false;
            }

            return VerificarDigitoVerificador(conta);
        }

        private bool VerificarDigitoVerificador(string conta)
        {
            conta = conta.Replace(" ", "");

            string numeroConta;
            string digitoVerificador;

            // Verificar se a conta contém um hífen
            if (conta.Contains('-'))
            {
                var partes = conta.Split('-');
                numeroConta = partes[0];
                digitoVerificador = partes[1];
            }
            else
            {
                // Se não houver hífen, assumimos que o último caractere é o dígito verificador
                numeroConta = conta.Substring(0, conta.Length - 1);
                digitoVerificador = conta.Substring(conta.Length - 1);
            }

            // Calcular o dígito verificador
            int soma = 0;
            foreach (var c in numeroConta)
            {
                soma += int.Parse(c.ToString());
            }

            int digitoCalculado = soma % 10;

            // Verificar se o dígito verificador calculado é igual ao fornecido
            return digitoCalculado.ToString() == digitoVerificador;
        }*/



        private void btnProximo_Click(object sender, EventArgs e)
        {
            string connectionString = ConexaoBancoDados.conn_;

            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtRGRNE.Text) || string.IsNullOrWhiteSpace(txtCPFCNPJ.Text) || string.IsNullOrWhiteSpace(txtCEP.Text) ||
                    string.IsNullOrWhiteSpace(txtEndereco.Text) || string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtBairro.Text) || string.IsNullOrWhiteSpace(txtCidade.Text) ||
                    string.IsNullOrWhiteSpace(txtPhone1.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || cbxEstado.SelectedIndex == -1 || cbxSexo.SelectedIndex == -1 || cbxDepartamento.SelectedIndex == -1 || cbxCargo.SelectedIndex == -1 || cbxEscolaridade.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }

                string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;

                // Dados da tabela TB_HR_EMPLOYEES
                string name = txtNome.Text;
                string rgRne = txtRGRNE.Text;
                string cpfCnpj = txtCPFCNPJ.Text;
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
                // Converte a imagem em bytes
                byte[] photo = null;
                if (pictureBoxFoto.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Substitua Jpeg pelo formato da sua imagem, se necessário
                        photo = ms.ToArray();
                    }
                }

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

                        // Verificar se o CPF já existe na tabela

                        string queryCheckCpf = "SELECT COUNT(*) FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";

                        SqlCommand commandCheckCpf = new SqlCommand(queryCheckCpf, conn, transaction);
                        commandCheckCpf.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);

                        int cpfCount = (int)commandCheckCpf.ExecuteScalar();

                        if (cpfCount > 0)
                        {
                            MessageBox.Show("O CPF informado já está cadastrado no sistema.", "CPF EXISTENTE!!");
                        }

                        // Para inserir na tabela TB_HR_EMPLOYEES

                        string queryEmployees = "INSERT INTO DB_ALMOXARIFADO..TB_HR_EMPLOYEES (ID_EMPLO, NAME_EMPLO, RG_RNE, CPF_CNPJ, BORN_DATE, ZIP_CODE, ADDRESS_EMPLO, NUMBER, COMPLEMENT, DISTRICT, CITY, UF_ID, ID_SEX_EMPLO, ID_DEPARTMENT, NAME_LEADER, PHOTO, USER_INSERT, DATE_INSERT, ID_OFFICE, ID_EDUCATION, PHONE_NUMBER_1, PHONE_NUMBER_2, EMAIL)" +
                                                                                  "VALUES(NEXT VALUE FOR SEQ_HR_EMPLOYEES, @nameEmplo, @rgRne, @cpfCnpj, @bornDate, @zipCode, @addressEmplo, @number, @complement, @district, @city, @ufId, @idSexEmplo, @idDepartment, @nameLeader, @photo, @userInsert, @dateInsert, @idOffice, @idEducation, @phoneNumber1, @phoneNumber2, @email)";

                        SqlCommand command = new SqlCommand(queryEmployees, conn, transaction);

                        // Adicionando os dados

                        command.Parameters.AddWithValue("@nameEmplo", name);
                        command.Parameters.AddWithValue("@rgRne", rgRne);
                        command.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
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
                        command.Parameters.AddWithValue("@userInsert", usuarioLogado);
                        command.Parameters.AddWithValue("@dateInsert", dataHoraAtual);
                        command.Parameters.AddWithValue("@idOffice", office);
                        command.Parameters.AddWithValue("@idEducation", education);
                        command.Parameters.AddWithValue("@phoneNumber1", phoneNumber1);
                        command.Parameters.AddWithValue("@phoneNumber2", phoneNumber2);
                        command.Parameters.AddWithValue("@email", email);

                        // Verifica se a foto é nula
                        SqlParameter photoParam = new SqlParameter("@photo", SqlDbType.VarBinary);

                        if (photo != null)
                        {
                            //command.Parameters.AddWithValue("@photo", photo);
                            photoParam.Value = photo;
                        }

                        else
                        {
                            //command.Parameters.AddWithValue("@photo", DBNull.Value);
                            photoParam.Value = DBNull.Value;
                        }

                        command.Parameters.Add(photoParam);

                        command.ExecuteNonQuery();
                        transaction.Commit();

                        MessageBox.Show("Dados cadastrados com sucesso!", "Sucesso");

                        tabCtlCadFunc.SelectedIndex = 1;

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao inserir dados: {ex.Message}", "Erro");
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConexaoBancoDados.conn_;

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

        // Botão Salvar
        private void button2_Click(object sender, EventArgs e)
        {

            string connectionString = ConexaoBancoDados.conn_;

            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtNacionalidade.Text) || string.IsNullOrWhiteSpace(txtBoxNaturalidade.Text) || string.IsNullOrWhiteSpace(txtBoxNomeMae.Text) || string.IsNullOrWhiteSpace(txtAgencia.Text) ||
                    string.IsNullOrWhiteSpace(txtSalario.Text) || string.IsNullOrWhiteSpace(txtConta.Text) || cbxEstadoNascimento.SelectedIndex == -1 || cbxEstadoCivil.SelectedIndex == -1 || cbxTipoContratacao.SelectedIndex == -1 || 
                    cbxTipoConta.SelectedIndex == -1 || cbxBanco.SelectedIndex == -1)
                {
                    MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "CAMPOS NÃO PREENCHIDOS!");
                    return;
                }
                    // Para verificar a agencia e conta
                    /* string agencia = txtAgencia.Text;
                     string conta = txtConta.Text;

                     if (txtAgencia.BackColor == System.Drawing.Color.LightGreen && txtConta.BackColor == System.Drawing.Color.LightGreen)
                     {
                         if (VerificarAgenciaEConta(agencia, conta))
                         {
                             MessageBox.Show("Agência e Conta válidas!", "VALIDAÇÃO");
                             // Proceda com a operação de submissão
                         }

                         VerificarAgenciaEConta(agencia, conta);


                     }
                     else
                     {
                         MessageBox.Show("Agência e Conta Inválidas!", "INVALIDAÇÃO");
                     }*/

                    string usuarioLogado = UsuarioLogado.Login;
                DateTime dataHoraAtual = DateTime.Now;

                string cpfCnpj = txtCPFCNPJ.Text;

                // Dados da tabela TB_HR_EMPLOYEES_HIRING

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

                        // Para inserir na tabela TB_HR_EMPLOYEES_HIRING

                        //Pegando o ID da primeira tabela
                        string queryGetEmploId = "SELECT ID_EMPLO FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";
                        SqlCommand commandGetEmploId = new SqlCommand(queryGetEmploId, conn, transaction);
                        commandGetEmploId.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                        int emploId = Convert.ToInt32(commandGetEmploId.ExecuteScalar());

                        string queryEmployeesHiring = "INSERT INTO DB_ALMOXARIFADO..TB_HR_EMPLOYEES_HIRING (ID_EMP_X_HIR, ID_EMPLO, DATE_HIRING, BORN_CITY, UF_ID_BORN, NACIONALITY, NAME_MOTHER, NAME_FATHER, ID_CIVIL_STATE, ID_TYPE_HIRING, SALARY, ID_BANK, ID_TYPE_COUNT, AGENCY, COUNT_SALARY, CLT_NUMBER, SERIE, EMISSION_DATE_CLT, VOTER_REGISTRATION, ZONE_REGISTRATION, SESSION_REGISTRATION, NUMBER_RESERVIST, SERIE_RESERVIST, NUMBER_DRIVER_LICENSE, DATE_VALIDATE_DRIVER_LICENSE, TYPE_DRIVER, EMISSION_DATE_DRIVER_LICENSE, USER_INSERT, DATE_INSERT)" +
                                                                                             "VALUES (NEXT VALUE FOR SEQ_HR_EMPLOYEES_HIRING, @emploId, @dateHiring, @bornCity, @ufIdBorn, @nacionality, @nameMother, @nameFather, @idCivilState, @idTypeHiring, @salary, @idBank, @idTypeCount, @agency, @countSalary, @numberCLT, @serie, @emissionDateClt, @voterRegistration, @zoneRegistration, @sessionRegistration, @numberReservist, @serieReservist, @numberDriverLicense, @dateValidateDriverLicense, @typeDriver, @emissionDateDriverLicense, @userInsert, @dateInsert)";

                        SqlCommand commandEmployeesHiring = new SqlCommand(queryEmployeesHiring, conn, transaction);

                        commandEmployeesHiring.Parameters.AddWithValue("@emploId", emploId);
                        commandEmployeesHiring.Parameters.AddWithValue("@dateHiring", dateHiring);
                        commandEmployeesHiring.Parameters.AddWithValue("@bornCity", bornCity);
                        commandEmployeesHiring.Parameters.AddWithValue("@ufIdBorn", stateBorn);
                        commandEmployeesHiring.Parameters.AddWithValue("@nacionality", nacionality);
                        commandEmployeesHiring.Parameters.AddWithValue("@nameMother", nameMother);
                        commandEmployeesHiring.Parameters.AddWithValue("@nameFather", nameFather);
                        commandEmployeesHiring.Parameters.AddWithValue("@idCivilState", civilState);
                        commandEmployeesHiring.Parameters.AddWithValue("@idTypeHiring", typeHiring);
                        commandEmployeesHiring.Parameters.AddWithValue("@salary", salary);
                        commandEmployeesHiring.Parameters.AddWithValue("@idTypeCount", typeCount);
                        commandEmployeesHiring.Parameters.AddWithValue("@idBank", bank);
                        commandEmployeesHiring.Parameters.AddWithValue("@agency", agency);
                        commandEmployeesHiring.Parameters.AddWithValue("@countSalary", countSalary);
                        commandEmployeesHiring.Parameters.AddWithValue("@numberCLT", numberCLT);
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
                        commandEmployeesHiring.Parameters.AddWithValue("@userInsert", usuarioLogado);
                        commandEmployeesHiring.Parameters.AddWithValue("@dateInsert", dataHoraAtual);

                        commandEmployeesHiring.ExecuteNonQuery();
                        transaction.Commit();

                        MessageBox.Show("Dados cadastrados com sucesso!", "SUCESSO!!");

                        LimparCampos();

                        tabCtlCadFunc.SelectedIndex = 0;

                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if (transaction.Connection != null)
                            {
                                transaction.Rollback();
                            }
                        }
                        catch (Exception rollbackEx)
                        {
                            MessageBox.Show($"Erro ao reverter a transação: {rollbackEx.Message}", "Erro");
                        }

                        MessageBox.Show($"Erro ao inserir dados: {ex.Message}", "Erro");
                    }
                }
            }
        }
    

        private void LimparCampos()
        {
            // Limpando os campos que são referente a tabela TB_HR_EMPLOYEES
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

            // Opcionalmente, defina o foco para o primeiro campo para facilitar o próximo cadastro
            txtNome.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            string connectionString = ConexaoBancoDados.conn_;

            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Se voltar o cadastro será cancelado, deseja fazer isso?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                { 
                
                    string cpfCnpj = txtCPFCNPJ.Text;


                    string connection = ConexaoBancoDados.conn_;

                    using (SqlConnection conn = new SqlConnection(connection))
                     {
                        conn.Open();
                        SqlTransaction transaction = conn.BeginTransaction();

                        try
                        {
                            string deleteEmplo = "DELETE FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES WHERE CPF_CNPJ = @cpfCnpj";
                            using (SqlCommand cmd = new SqlCommand(deleteEmplo, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@cpfCnpj", cpfCnpj);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Cadastro cancelado com sucesso!", "Sucesso");

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao cancelar cadastro: {ex.Message}", "Erro");
                        }
                        finally
                        {
                            conn.Close();
                        }

                        this.Close();
                    }
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        // Vai trazer os campos de datas em branco em caso de ser não opcional
        private void FormCadastroFunc_Load(object sender, EventArgs e)
        {
            // Configurar DateTimePicker para mostrar vazio inicialmente
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

        private void dateTimePickerDataNasc_ValueChanged(object sender, EventArgs e)
        {
            
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

        private void lblSecao_Click(object sender, EventArgs e)
        {

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

            List<SelecionaSuperior> superiorComPrompt = new List<SelecionaSuperior>
            {
                new SelecionaSuperior { NAME = "", OFFICE = "" }
            };

            superiorComPrompt.AddRange(superior);

            cbxSuperior.DataSource = superiorComPrompt;
            cbxSuperior.DisplayMember = "NameSuperior";
            cbxSuperior.ValueMember = "NameSuperior";

            cbxSuperior.SelectedIndex = 0;
        }
    }
    
}
