using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.MaquinasClass
{
    public class Fabricante
    {
        public int ID_MANUFACTURE { get; set; }

        public string NAME_MANUFACTURE { get; set; }

        public string COD_MANUFACTURE { get; set; }

        public string NomeCompletoFab { get; set; }

        public Fabricante() { }

        public Fabricante(int id_manufacture, string name_manufacture, string cod_manufacture)
        {
            ID_MANUFACTURE = id_manufacture;
            NAME_MANUFACTURE = name_manufacture;
            COD_MANUFACTURE = cod_manufacture;
        }
    }
}
