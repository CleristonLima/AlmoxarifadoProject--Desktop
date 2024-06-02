using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaEstadoCivil
    {
        public int ID_CIVIL_STATE { get; set; }

        public string DESC_CIVIL_STATE { get; set; }

        public SelecionaEstadoCivil() { }

        public SelecionaEstadoCivil(int id_civil_state, string desc_civil_state)
        {
            ID_CIVIL_STATE = id_civil_state;
            DESC_CIVIL_STATE = desc_civil_state;
        }
    }
}
