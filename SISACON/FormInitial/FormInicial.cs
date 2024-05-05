using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISACON.ConexaoBD;

namespace SISACON.FormInitial
{
    public partial class FormInicial : Form
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public FormInicial()
        {
            InitializeComponent();

            // Atualiza o texto da label com o nome do usuário logado
            lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var admin = new SISACON.FormsAdmin.FormAdministrador();
                admin.Show();
                this.Hide();
            }
        }

        private void linklblAdmin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var admin = new SISACON.FormsAdmin.FormAdministrador();
                admin.Show();
                this.Hide();
            }

        }

        private void btnRH_Click(object sender, EventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {

                var rh = new SISACON.FormsRH.FormRHMenu();
                rh.Show();
            }
        }

        private void linkLblRH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                var rh = new SISACON.FormsRH.FormRHMenu();
                rh.Show();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form form in forms)
            {
                // Fecha o formulário atual, exceto o formulário principal (this)
                if (form != this)
                {
                    form.Close();
                }
            }

        }

        private void linkLblSair_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();

            foreach (Form form in forms)
            {
                // Fecha o formulário atual, exceto o formulário principal (this)
                if (form != this)
                {
                    form.Close();
                }
            }
        }
        
    }
}
