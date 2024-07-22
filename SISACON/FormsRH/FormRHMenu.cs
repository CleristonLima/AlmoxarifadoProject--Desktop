using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsRH
{
    public partial class FormRHMenu : Form
    {
        public FormRHMenu()
        {
            InitializeComponent();
        }

        private void linkLblCadDepartamento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroDep = new SISACON.FormsRH.FormCadastroDepartamento();
                cadastroDep.Show();
            }
        }

        private void linkLblAtualizaDadosDep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroDepAtualiza = new SISACON.FormsRH.FormAtualizaCadastroDepartamento();
                cadastroDepAtualiza.Show();
            }

        }

        private void linkLblCadCargos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroCargos = new SISACON.FormsRH.FormCadastroCargos();
                cadastroCargos.Show();
            }
        }

        private void linkLblAtualizaCargos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroCargosAtualiza = new SISACON.FormsRH.FormAtualizaCargo();
                cadastroCargosAtualiza.Show();
            }
        }

        private void linkLblCadFunc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadastroFuncionario = new SISACON.FormsRH.FormCadastroFunc();
                cadastroFuncionario.Show();
            }
        }

        private void linkLblAtualizaFunc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var consultaAtualizaFuncionario = new SISACON.FormsRH.FormAtualizaCadastroFunc();
                consultaAtualizaFuncionario.Show();
            }
        }

        private void linkLblExcluirFuncionario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var excluirFuncionario = new SISACON.FormsRH.FormDeletaCadastroFunc();
                excluirFuncionario.Show();
            }
        }

        private void linkLblDemissao_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var demissaoFuncionario = new SISACON.FormsRH.FormMenuDemissao();
                demissaoFuncionario.Show();
            }
        }

        private void linkLblFerias_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var feriasFuncionario = new SISACON.FormsRH.FormMenuFerias();
                feriasFuncionario.Show();
            }
        }
    }
}
