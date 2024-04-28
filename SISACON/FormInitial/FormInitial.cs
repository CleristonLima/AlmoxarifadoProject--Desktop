using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SISACON.FormInitial
{
    public partial class FormInitial : Form
    {
        public FormInitial()
        {
            InitializeComponent();

            // Atualiza o texto da label com o nome do usuário logado
            lblUsuarioLogado.Text = "Bem vindo: " + UsuarioLogado.Login;
        }


    }
}
