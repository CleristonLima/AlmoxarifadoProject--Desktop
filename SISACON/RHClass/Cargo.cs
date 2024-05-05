using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class Cargo
    {
        public int ID_OFFICE { get; set; }

        public string NAME_OFFICE { get; set; }

        public int STATUS_OFFICE { get; set; }

        public Cargo(int id_office, string name_office, int status_office)
        {
            ID_OFFICE = id_office;
            NAME_OFFICE = name_office;
            STATUS_OFFICE = status_office;
        }
    }
}
