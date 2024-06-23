using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.CargoDAO
{
    public class SuperiorDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public SuperiorDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaSuperior> ObterSuperior()
        {
            List<SelecionaSuperior> superior = new List<SelecionaSuperior>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT HRE.NAME_EMPLO, HRO.NAME_OFFICE FROM DB_ALMOXARIFADO..TB_HR_EMPLOYEES HRE INNER JOIN TB_HR_OFFICE HRO ON HRO.ID_OFFICE = HRE.ID_OFFICE WHERE HRO.POSITION_OF_TRUST = 1";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string name_emplo = Convert.ToString(reader["NAME_EMPLO"]);
                    string name_office = Convert.ToString(reader["NAME_OFFICE"]);

                    SelecionaSuperior sup = new SelecionaSuperior(name_emplo, name_office);
                    superior.Add(sup);
                }

                reader.Close();
            }

            return superior;
        }
    }
}
