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
    public partial class FormMenuDemissao : Form
    {
        public FormMenuDemissao()
        {
            InitializeComponent();
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
                var consultaDemissao = new SISACON.FormsRH.FormConsultaAltDemissao();
                consultaDemissao.Show();
            }
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
                var Demissao = new SISACON.FormsRH.FormDemissaoFunc();
                Demissao.Show();
            }
        }
    }
}
