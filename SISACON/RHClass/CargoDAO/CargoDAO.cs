using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.CargoDAO
{
    public class CargoDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public CargoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cargo> ObterCargo()
        {
            List<Cargo> cargo = new List<Cargo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_OFFICE, NAME_OFFICE, STATUS_OFFICE  FROM DB_ALMOXARIFADO..TB_HR_OFFICE";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_office = Convert.ToInt32(reader["ID_OFFICE"]);
                    string name_office = Convert.ToString(reader["NAME_OFFICE"]);
                    int status_office = Convert.ToInt32(reader["STATUS_OFFICE"]);

                    Cargo car = new Cargo(id_office, name_office, status_office);
                    cargo.Add(car);
                }

                reader.Close();
            }

            return cargo;
        }
    }
}
