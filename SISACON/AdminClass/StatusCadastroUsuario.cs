using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON
{
    public class StatusCadastroUsuario
    {
        public int StatusID { get; set; }
        public string Descricao { get; set; }

        public StatusCadastroUsuario(int statusId, string descricao) 
        {
            StatusID = statusId;
            Descricao = descricao;
        }
    }
}
