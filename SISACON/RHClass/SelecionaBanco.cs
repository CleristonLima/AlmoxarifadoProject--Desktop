using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaBanco
    {
        public int ID_BANK { get; set; }

        public string DESC_BANK { get; set; }

        public string NameBank
        {
            get { return $"{ID_BANK} - {DESC_BANK}"; }
        }


        public SelecionaBanco(int id_bank, string desc_bank)
        {
            ID_BANK = id_bank;
            DESC_BANK = desc_bank;
        }
    }
}
