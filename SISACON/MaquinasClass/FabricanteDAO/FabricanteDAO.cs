using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.MaquinasClass.FabricanteDAO
{
    public class FabricanteDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public FabricanteDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Fabricante> ObterFabricante()
        {
            List<Fabricante> fabricante = new List<Fabricante>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_MANUFACTURE, NAME_MANUFACTURE, COD_MANUFACTURE FROM DB_ALMOXARIFADO..TB_MC_MANUFACTURE";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_manufacture = Convert.ToInt32(reader["ID_MANUFACTURE"]);
                    string name_manufacture = Convert.ToString(reader["NAME_MANUFACTURE"]);
                    string cod_manufacture = Convert.ToString(reader["COD_MANUFACTURE"]);

                    Fabricante fabr = new Fabricante(id_manufacture, name_manufacture, cod_manufacture);
                    fabricante.Add(fabr);
                }

                reader.Close();
            }

            return fabricante;
        }
    }
}
