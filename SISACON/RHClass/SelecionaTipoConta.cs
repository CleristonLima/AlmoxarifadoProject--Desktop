using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaTipoConta
    {
        public int ID_TYPE_COUNT { get; set; }

        public string CODE_TYPE_COUNT { get; set; }

        public string NAME_TYPE_COUNT { get; set; }

        public string NomeConta
        {
            get { return $"{CODE_TYPE_COUNT} - {NAME_TYPE_COUNT}"; }
        }

        public SelecionaTipoConta() { }


        public SelecionaTipoConta(int id_type_count, string code_type_count, string name_type_count)
        {
            ID_TYPE_COUNT = id_type_count;
            CODE_TYPE_COUNT = code_type_count;
            NAME_TYPE_COUNT = name_type_count;
        }
    }
}
