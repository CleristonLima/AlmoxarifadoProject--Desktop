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
using System.Drawing;
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
            cbxEstadoCivil.DataSource = estadoCivil;
            cbxEstadoCivil.DisplayMember = "DESC_CIVIL_STATE";
            cbxEstadoCivil.ValueMember = "ID_CIVIL_STATE";
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
            cbxBanco.DataSource = banco;
            cbxBanco.DisplayMember = "NameBank";
            cbxBanco.ValueMember = "ID_BANK";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAgencia_TextChanged(object sender, EventArgs e)
        {
            if (ValidarAgencia(txtAgencia.Text))
            {
                txtAgencia.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                txtAgencia.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private bool ValidarAgencia(string agencia)
        {
            return Regex.IsMatch(agencia, @"^\d{4}$");
        }

        private void txtConta_TextChanged(object sender, EventArgs e)
        {
            if (ValidarConta(txtConta.Text))
            {
                txtConta.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                txtConta.BackColor = System.Drawing.Color.LightCoral;
            }
        }

        private bool ValidarConta(string conta)
        {
            // Verifica se a conta está no formato XXXXX-X ou XXXXXXX
            return Regex.IsMatch(conta, @"^\d{5}-\d{1}$") || Regex.IsMatch(conta, @"^\d{6}$");
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Para verificar a agencia e conta
            string agencia = txtAgencia.Text;
            string conta = txtConta.Text;

            if (txtAgencia.BackColor == System.Drawing.Color.LightGreen && txtConta.BackColor == System.Drawing.Color.LightGreen)
            {
                if (VerificarAgenciaEConta(agencia, conta))
                {
                    MessageBox.Show("Agência e Conta válidas!", "VALIDAÇÃO");
                    // Proceda com a operação de submissão
                }

            }
            else
            {
                MessageBox.Show("Agência e Conta Inválidas!", "INVALIDAÇÃO");
            }

        }
    }
}
