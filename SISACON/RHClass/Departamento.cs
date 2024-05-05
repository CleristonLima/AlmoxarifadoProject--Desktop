using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class Departamento
    {
        public int ID_DEPARTMENT { get; set; }

        public string NAME_DEPARTMENT { get; set; }

        public string CODE_DEPARTMENT { get; set; }

        public int STATUS_DEPARTMENT { get; set; }

        public string NomeCompletoDepto { get; set; } // Propriedade para armazenar o nome completo e a sigla

        public Departamento(int id_departament, string name_department, string code_department, int status_department)
        {
            ID_DEPARTMENT = id_departament;
            NAME_DEPARTMENT = name_department;
            CODE_DEPARTMENT = code_department;
            STATUS_DEPARTMENT = status_department;
        }
    }
}
