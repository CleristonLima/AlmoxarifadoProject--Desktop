using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class StatusCadastroDepartamento
    {
        public int StatusID { get; set; }
        public String Descricao { get; set; }

        public StatusCadastroDepartamento(int statusId, string descricao)
        {
            StatusID = statusId;
            Descricao = descricao;
        }
    }
}
