using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaEstado
    {
        public int ID_UF { get; set; }

        public string CODE_UF { get; set; }

        public string DESC_UF { get; set; }

        public SelecionaEstado(int id_uf, string code_uf, string desc_uf)
        {
            ID_UF = id_uf;
            CODE_UF = code_uf;
            DESC_UF = desc_uf;
        }
    }
}
