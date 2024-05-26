using SISACON.ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISACON.RHClass.EstadoCivilDAO
{
    public class EstadoCivilDAO
    {
        private readonly string connectionString = ConexaoBancoDados.conn_;

        public EstadoCivilDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<SelecionaEstadoCivil> ObterEstadoCivil()
        {
            List<SelecionaEstadoCivil> estadoCivil = new List<SelecionaEstadoCivil>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID_CIVIL_STATE, DESC_CIVIL_STATE FROM DB_ALMOXARIFADO..TB_HR_CIVIL_STATE";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id_civil_state = Convert.ToInt32(reader["ID_CIVIL_STATE"]);
                    string desc_civil_state = Convert.ToString(reader["DESC_CIVIL_STATE"]);

                    SelecionaEstadoCivil estcivil = new SelecionaEstadoCivil(id_civil_state, desc_civil_state);
                    estadoCivil.Add(estcivil);
                }

                reader.Close();
            }

            return estadoCivil;
        }
    }
}
