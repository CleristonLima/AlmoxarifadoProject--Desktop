using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class StatusCadastroCargo
    {
        public int StatusID { get; set; }
        public string Descricao { get; set; }

        public StatusCadastroCargo(int statusId, string descricao)
        {
            StatusID = statusId;
            Descricao = descricao;
        }
    }
}
