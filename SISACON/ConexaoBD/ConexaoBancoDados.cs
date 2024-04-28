using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.ConexaoBD
{
    public static class ConexaoBancoDados
    {
        public static string conn_ { get; } = @"Data Source=DESKTOP-2MLSNHE\SQLEXPRESS;Initial Catalog=DB_ALMOXARIFADO;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
