using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.AdminClass
{
    public class Perfis
    {
        public int ID_PROFILE { get; set; }
        public string NAME_PROFILE { get; set; }

        public string CODE_PROFILE { get; set; }

        public Perfis(int id_profile, string name_profile, string code_profile)
        {
            ID_PROFILE = id_profile;
            NAME_PROFILE = name_profile;
            CODE_PROFILE = code_profile;
        }
    }
}