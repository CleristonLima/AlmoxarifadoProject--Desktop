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
    public partial class FormMenuLicenca : Form
    {
        public FormMenuLicenca()
        {
            InitializeComponent();
        }

        private void FormMenuLicenca_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadLicenca = new SISACON.FormsRH.FormLicencaFunc();
                cadLicenca.Show();
            }
        }

        private void linkLblConsulta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadAtualizaLicenca = new SISACON.FormsRH.FormAtualizaCadLicenca();
                cadAtualizaLicenca.Show();
            }
        }
    }
}
