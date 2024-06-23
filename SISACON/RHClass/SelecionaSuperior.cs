using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass
{
    public class SelecionaSuperior
    {
        public string NAME { get; set; }

        public string OFFICE { get; set; }

        public string NameSuperior
        {
            get { return $"{NAME} - {OFFICE}"; }
        }

        public SelecionaSuperior() { 
        
        }

        public SelecionaSuperior(string name, string office)
        { 
            NAME = name;
            OFFICE = office;
        }
    }
}
