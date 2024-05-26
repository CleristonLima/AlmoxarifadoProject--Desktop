using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaSexo
    {
        public int ID_SEX_EMPLO { get; set; }

        public string CODE_SEX_EMPLO { get; set; }

        public string DESC_SEX_EMPLO { get; set; }

        public string NomeSexo
        {
            get { return $"{CODE_SEX_EMPLO} - {DESC_SEX_EMPLO}"; }
        }

        public SelecionaSexo(int id_sex_emplo, string code_sex_emplo, string desc_sex_emplo)
        {
            ID_SEX_EMPLO = id_sex_emplo;
            CODE_SEX_EMPLO = code_sex_emplo;
            DESC_SEX_EMPLO = desc_sex_emplo;
        }
    }
}
