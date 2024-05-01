using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISACON.FormsAdmin
{
    public partial class FormOpcõesDeCadastroPerfil : Form
    {
        public FormOpcõesDeCadastroPerfil()
        {
            InitializeComponent();
        }

        private void linkLabelCadPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadUsuario = new SISACON.FormsAdmin.FormCadastroPerfil();
                cadUsuario.Show();
            }
        }

        private void linkLabelAtualizarCadPerfil_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ConexaoInternet.ConexaoInternet.VerificarConexao())
            {
                MessageBox.Show("Sem Conexão com a internet!!", "SEM ACESSO A REDE!");
                return;
            }
            else
            {
                // Exibe o formulário de inicialização do sistema
                var cadUsuarioAtualiza = new SISACON.FormsAdmin.FormAtualizaCadastroPerfil();
                cadUsuarioAtualiza.Show();
            }

        }
    }
}
