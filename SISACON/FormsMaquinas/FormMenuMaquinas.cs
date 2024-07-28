using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsMaquinas
{
    public partial class FormMenuMaquinas : Form
    {
        public FormMenuMaquinas()
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
                var cadastroFab = new SISACON.FormsMaquinas.FormCadastroFabricante();
                cadastroFab.Show();
            }
        }

        private void lblConAltFab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var atulizaFab = new SISACON.FormsMaquinas.FormAtualizaFabricante();
                atulizaFab.Show();
            }
        }
    }
}
