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
    }
}
