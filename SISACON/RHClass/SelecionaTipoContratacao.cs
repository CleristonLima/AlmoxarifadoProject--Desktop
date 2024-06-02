using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaTipoContratacao
    {
        public int ID_TYPE_HIRING { get; set; }

        public string DESC_HIRING { get; set; }

        public SelecionaTipoContratacao() { }

        public SelecionaTipoContratacao(int id_type_hiring, string desc_hiring)
        {
            ID_TYPE_HIRING = id_type_hiring;
            DESC_HIRING = desc_hiring;
        }
    }
}
