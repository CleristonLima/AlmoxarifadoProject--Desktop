using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaEscolaridade
    {
        public int ID_EDUCATION { get; set; }

        public string NAME_EDUCATION { get; set; }

        public SelecionaEscolaridade() { }


        public SelecionaEscolaridade(int id_education, string name_education)
        {
            ID_EDUCATION = id_education;
            NAME_EDUCATION = name_education;
        }
    }
}
